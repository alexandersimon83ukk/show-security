from __future__ import annotations

from pathlib import Path
import re

REPORT_FILE = Path('report_md.md')
OUTPUT_FILE = Path('zap-summary.md')

RISK_PRIORITY = {
    'critical': 4,
    'high': 3,
    'medium': 2,
    'low': 1,
    'informational': 0,
    'info': 0,
}


def parse_summary_rows(report_text: str) -> list[tuple[str, int]]:
    table_match = re.search(
        r"Summary of Alerts\s*\n(?:.*?\n)*?\|\s*Risk Level\s*\|\s*Number of Alerts\s*\|\s*\n\|(?:[^\n]+)\|\s*\n((?:\|[^\n]+\n)+)",
        report_text,
        re.IGNORECASE,
    )
    if not table_match:
        return []

    rows: list[tuple[str, int]] = []
    for raw_line in table_match.group(1).splitlines():
        columns = [column.strip() for column in raw_line.strip().strip('|').split('|')]
        if len(columns) < 2:
            continue

        risk = columns[0]
        count_match = re.search(r'\d+', columns[1])
        if not count_match:
            continue

        rows.append((risk, int(count_match.group(0))))

    return rows


def format_highest_risk(rows: list[tuple[str, int]]) -> str:
    positive_rows = [(risk, count) for risk, count in rows if count > 0]
    if not positive_rows:
        return 'Kein Alert erkannt'

    highest_risk, _ = max(
        positive_rows,
        key=lambda row: (RISK_PRIORITY.get(row[0].strip().lower(), -1), row[1]),
    )
    return highest_risk


def build_summary() -> str:
    summary_lines = ['# OWASP ZAP-Auswertung', '']

    if not REPORT_FILE.exists():
        summary_lines.append(
            '- Der ZAP-Baseline-Scan hat in diesem Lauf keinen Markdown-Report (`report_md.md`) erzeugt.'
        )
        return '\n'.join(summary_lines) + '\n'

    report_text = REPORT_FILE.read_text(encoding='utf-8', errors='ignore')
    rows = parse_summary_rows(report_text)

    false_positive_match = re.search(r'False Positives:\s*(\d+)', report_text, re.IGNORECASE)
    false_positives = int(false_positive_match.group(1)) if false_positive_match else None

    total_alerts = sum(count for _, count in rows)
    highest_risk = format_highest_risk(rows)

    summary_lines.extend([
        f'- Alerts gesamt: **{total_alerts}**',
        f'- Höchstes gefundenes Risiko: **{highest_risk}**',
        f"- False Positives: **{false_positives if false_positives is not None else 'n/a'}**",
        '',
        '| Risk Level | Number of Alerts |',
        '| --- | ---: |',
    ])

    if rows:
        summary_lines.extend(f'| {risk} | {count} |' for risk, count in rows)
    else:
        summary_lines.append('| Summary unavailable | Report konnte nicht geparst werden |')

    return '\n'.join(summary_lines) + '\n'


OUTPUT_FILE.write_text(build_summary(), encoding='utf-8')
