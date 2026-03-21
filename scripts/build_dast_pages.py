#!/usr/bin/env python3
from __future__ import annotations

import argparse
import html
import re
from pathlib import Path


def parse_report(report_md: Path) -> tuple[list[tuple[str, str]], str, bool]:
    rows: list[tuple[str, str]] = []
    false_positives = 'n/a'
    parsed = False

    if not report_md.exists():
        return rows, false_positives, parsed

    report_text = report_md.read_text(encoding='utf-8', errors='ignore')
    table_match = re.search(
        r"Summary of Alerts\s*\n(?:.*?\n)*?\|\s*Risk Level\s*\|\s*Number of Alerts\s*\|\s*\n\|(?:[^\n]+)\|\s*\n((?:\|[^\n]+\n)+)",
        report_text,
        re.IGNORECASE,
    )
    if table_match:
        parsed = True
        for raw_line in table_match.group(1).splitlines():
            columns = [column.strip() for column in raw_line.strip().strip('|').split('|')]
            if len(columns) >= 2:
                rows.append((columns[0], columns[1]))

    false_positive_match = re.search(r"False Positives:\s*(\d+)", report_text, re.IGNORECASE)
    if false_positive_match:
        false_positives = false_positive_match.group(1)

    return rows, false_positives, parsed


def build_markdown(rows: list[tuple[str, str]], false_positives: str, html_available: bool, json_available: bool, report_exists: bool, parsed: bool) -> str:
    lines = ['# Web Security Scan (DAST)', '']

    if not report_exists:
        lines.append('- The ZAP baseline scan did not produce a Markdown report (`report_md.md`) in this run.')
    else:
        lines.extend([
            '| Risk Level | Number of Alerts |',
            '| --- | ---: |',
        ])
        if rows:
            lines.extend(f'| {risk} | {count} |' for risk, count in rows)
        elif parsed:
            lines.append('| No alerts parsed | 0 |')
        else:
            lines.append('| Summary unavailable | Report could not be parsed |')

        lines.extend([
            '',
            f'- False Positives: **{false_positives}**',
            f'- HTML report available: **{"yes" if html_available else "no"}**',
            f'- JSON report available: **{"yes" if json_available else "no"}**',
        ])

    return '\n'.join(lines) + '\n'


def build_html(rows: list[tuple[str, str]], false_positives: str, html_available: bool, json_available: bool, report_exists: bool, back_link: str) -> str:
    body = [
        '<!DOCTYPE html>',
        '<html lang="en">',
        '  <head>',
        '    <meta charset="utf-8" />',
        '    <meta name="viewport" content="width=device-width, initial-scale=1" />',
        '    <title>show-security DAST report</title>',
        '    <style>',
        '      body { font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif; margin: 2rem; line-height: 1.5; color: #1f2328; }',
        '      a { color: #0969da; }',
        '      table { border-collapse: collapse; margin-top: 1rem; min-width: 20rem; }',
        '      th, td { border: 1px solid #d0d7de; padding: 0.55rem 0.75rem; text-align: left; }',
        '      th { background: #f6f8fa; }',
        '      .muted { color: #57606a; }',
        '      .actions { display: flex; gap: 1rem; flex-wrap: wrap; margin: 1.5rem 0; }',
        '      .button { display: inline-block; padding: 0.7rem 1rem; border-radius: 999px; background: #0969da; color: white; text-decoration: none; }',
        '      .button.secondary { background: #f6f8fa; color: #1f2328; border: 1px solid #d0d7de; }',
        '      code { background: #f6f8fa; padding: 0.15rem 0.35rem; border-radius: 6px; }',
        '    </style>',
        '  </head>',
        '  <body>',
        f'    <p><a href="{html.escape(back_link, quote=True)}">← Back to reports overview</a></p>',
        '    <h1>DAST scan results</h1>',
        '    <p>This page publishes the latest OWASP ZAP baseline snapshot generated on the main branch.</p>',
        '    <div class="actions">',
    ]

    if html_available:
        body.append('      <a class="button" href="./report.html">Open full HTML report</a>')
    if json_available:
        body.append('      <a class="button secondary" href="./report_json.json">Download JSON report</a>')
    body.extend([
        '    </div>',
    ])

    if report_exists:
        body.append(f'    <p><strong>False Positives:</strong> {html.escape(false_positives)}</p>')
        if rows:
            body.extend([
                '    <table>',
                '      <thead><tr><th>Risk Level</th><th>Number of Alerts</th></tr></thead>',
                '      <tbody>',
            ])
            for risk, count in rows:
                body.append(f'        <tr><td>{html.escape(risk)}</td><td>{html.escape(count)}</td></tr>')
            body.extend([
                '      </tbody>',
                '    </table>',
            ])
        else:
            body.append('    <p class="muted">The Markdown summary could not be parsed for this run. Use the HTML report when available for the detailed findings.</p>')
    else:
        body.append('    <p class="muted">No Markdown report was produced for this run.</p>')

    body.extend([
        '    <p class="muted">Generated from <code>report_md.md</code>, <code>report_html.html</code>, and <code>report_json.json</code> when those files are available.</p>',
        '  </body>',
        '</html>',
    ])

    return '\n'.join(body) + '\n'


def main() -> None:
    parser = argparse.ArgumentParser(description='Build a GitHub Pages-friendly DAST report page from ZAP artifacts.')
    parser.add_argument('--output-dir', required=True)
    parser.add_argument('--back-link', default='../index.html')
    args = parser.parse_args()

    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)

    report_md = Path('report_md.md')
    report_html = Path('report_html.html')
    report_json = Path('report_json.json')

    rows, false_positives, parsed = parse_report(report_md)
    report_exists = report_md.exists()
    html_available = report_html.exists()
    json_available = report_json.exists()

    if html_available:
        (output_dir / 'report.html').write_text(report_html.read_text(encoding='utf-8', errors='ignore'), encoding='utf-8')
    if json_available:
        (output_dir / 'report_json.json').write_text(report_json.read_text(encoding='utf-8', errors='ignore'), encoding='utf-8')

    (output_dir / 'summary.md').write_text(
        build_markdown(rows, false_positives, html_available, json_available, report_exists, parsed),
        encoding='utf-8',
    )
    (output_dir / 'index.html').write_text(
        build_html(rows, false_positives, html_available, json_available, report_exists, args.back_link),
        encoding='utf-8',
    )


if __name__ == '__main__':
    main()
