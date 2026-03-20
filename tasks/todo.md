## Plan
- [x] Inspect why the DAST report stopped being published on GitHub Pages after the workflow split
- [x] Restore GitHub Pages publication for the ZAP HTML report without removing the dedicated DAST workflow
- [x] Validate the workflow YAML, review the generated diff, and document the result

## Review
- Restored the GitHub Pages ZAP publication path by running the OWASP ZAP baseline scan again inside `tests-and-coverage.yml` for `main` builds, which lets the Pages deployment continue publishing a combined report site.
- Kept `web-security-scan-dast.yml` as the dedicated DAST workflow for Actions visibility and per-run artifacts while the Pages site now links to the latest HTML ZAP snapshot again.
- Validated the changed workflow files with Ruby's YAML parser and reviewed the resulting diff for the workflow, README, and task documentation updates.
