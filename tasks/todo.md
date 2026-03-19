# Task Plan

- [x] Prüfe Repository-Anweisungen, vorhandene Workflows und den aktuellen Git-Status.
- [x] Lege das angeforderte `Dockerfile` im Repository-Root an.
- [x] Lege den GitHub-Workflow `.github/workflows/build-and-push.yml` mit den bereitgestellten GCP-/GAR-Werten an.
- [x] Prüfe die neuen Dateien mit einfachen Datei-/Diff-Checks und dokumentiere das Ergebnis.
- [x] Committe die Änderungen und erstelle PR-Metadaten.

## Review

- `Dockerfile` wurde im Repository-Root mit dem bereitgestellten Alpine-Basisimage und dem Demo-`CMD` angelegt.
- `.github/workflows/build-and-push.yml` wurde mit dem gewünschten OIDC-, Trivy- und GAR-Push-Workflow angelegt.
- Eine kleine Dateiprüfung per Python bestätigte, dass beide neuen Dateien lesbar sind und mit einem Zeilenumbruch enden.
- `git diff --check -- Dockerfile .github/workflows/build-and-push.yml tasks/todo.md` lief ohne Beanstandungen.
- Das bereits unversionierte `dotnet-install.sh` blieb unverändert und wurde nicht für diesen Task angefasst.
