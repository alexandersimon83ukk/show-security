## Plan
- [x] Inspect existing GitHub Pages, coverage, and ZAP workflow setup
- [x] Add main-branch publication for the ZAP scan report analogous to the coverage report
- [x] Update documentation/overview links so both published reports are discoverable
- [x] Validate workflow syntax/behavior and summarize results

## Review
- Extended `.github/workflows/tests-and-coverage.yml` so pushes to `main` now build a combined GitHub Pages artifact containing a landing page, the coverage report, and a published OWASP ZAP baseline report.
- Kept PR behavior safe by limiting Pages upload/deploy and the ZAP scan to `refs/heads/main`.
- Updated the security overview workflow and README so both report URLs are visible in GitHub and repository documentation.
- Validated the changed workflow YAML structure with Ruby's YAML parser and re-ran the .NET test suite locally.
