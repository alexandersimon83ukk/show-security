## Plan
- [x] Inspect the current DAST job summary behavior in the affected workflows
- [x] Reuse the ZAP high-level summary generation in the Build, Scan & Push workflow
- [x] Validate the updated workflows and document the result

## Review
- Extracted the ZAP markdown parsing into `.github/scripts/generate-zap-summary.py`, so both workflows now render the same high-level alert summary with total alerts, highest risk, false positives, and the per-risk table.
- Added the reusable summary step to the `dast-scan` job in `build-and-push.yml`, so the job summary no longer only shows the SARIF fallback note.
- Kept the existing SARIF upload fallback note intact, but it now appears alongside the actual DAST evaluation instead of replacing it.
