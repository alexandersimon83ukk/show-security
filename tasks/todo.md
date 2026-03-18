# Task Plan

- [x] Prüfe Repository-Anweisungen, Nutzerfeedback und aktuellen Stand.
- [x] Entferne die lokale Security-Showcase-App-Struktur.
- [x] Ersetze die Demo durch GitHub-Action-Workflows für Security-Themen.
- [x] Führe verfügbare Checks aus und dokumentiere Einschränkungen.
- [x] Dokumentiere das Ergebnis im Review.

## Review

- Die bisherige App-Struktur in `App`, `Models`, `Services` und `Presentation` wurde entfernt.
- Das Repo zeigt Security-Themen jetzt über GitHub Actions in `.github/workflows/`.
- `Program.cs` ist wieder minimal und verweist nur noch auf den Actions-Fokus.
- Die Workflow-YAMLs wurden mit Ruby (`YAML.load_file`) erfolgreich geparst.
- `git diff --check` lief erfolgreich.
- Eine lokale Ausführung der eigentlichen GitHub-Features ist in dieser Umgebung naturgemäß nicht möglich; die Demonstration passiert nach dem Push in GitHub.
