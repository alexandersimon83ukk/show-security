## Plan
- [x] Inspect the existing workflow summary generation for coverage and ZAP scan outputs
- [x] Add a ZAP high-level risk summary to the GitHub Action step summary in the same style as the coverage section
- [x] Validate the workflow changes and update the review notes

## Review
- Added a dedicated workflow step after the OWASP ZAP baseline action that parses `report_md.md` and appends a high-level risk table plus false-positive count to `$GITHUB_STEP_SUMMARY`.
- Kept the summary generation scoped to `main`, matching the existing ZAP execution behavior and avoiding noise on pull requests.
- Validated the regex parsing against a representative ZAP markdown sample and confirmed the workflow still parses as YAML with Ruby's standard library.
