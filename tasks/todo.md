## Plan
- [x] Review the current Pages/DAST workflows and identify the duplicated report-generation path
- [x] Refactor the workflows so coverage and DAST are each produced once and both are published on GitHub Pages
- [x] Validate the workflow/scripts changes, review the diff, and document the result

## Review
- Removed the redundant ZAP execution from `tests-and-coverage.yml`; that workflow now only builds the coverage report and uploads it as a dedicated Pages artifact for `main`.
- Updated `web-security-scan-dast.yml` to reuse a shared Python helper that converts the ZAP outputs into a Pages-friendly DAST site fragment and uploads both the Actions artifact and the Pages artifact from the same scan run.
- Added `publish-reports-pages.yml` so GitHub Pages is deployed from the latest successful coverage and DAST artifacts together, keeping both reports visible without regenerating either one in the other workflow.
