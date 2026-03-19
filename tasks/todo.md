- [x] Inspect current web app and refactor scope
- [x] Introduce controller and service layers for the scanner demo
- [x] Verify tests/runtime behavior and update docs
- [x] Commit changes and refresh PR metadata

## Review

- Replaced inline minimal API handlers with a controller mapped under `/api`.
- Added a dedicated scanner demo service plus a response model to keep the endpoint logic out of `Program.cs`.
- Kept the single-button front-end flow intact so the GCP Web Security Scanner demo still behaves the same from the browser.
