## Plan
- [x] Inspect startup/runtime issue
- [x] Implement container fix for PORT=8080
- [x] Validate locally
- [x] Review and summarize

## Review
- Root cause 1: `Dockerfile` only ran `echo`, so the container never launched the web app.
- Root cause 2: the ASP.NET app listened on `localhost:5000` when only `PORT=8080` was provided.
- Fix: publish and run the ASP.NET app in Docker, and map `PORT` to `0.0.0.0` in `Program.cs` when platform URL settings are absent.
