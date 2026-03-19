# Task Plan

- [x] Prüfe Repository-Anweisungen, vorhandene Workflow-Warnungen und den aktuellen Git-Status.
- [x] Pinne Drittanbieter-Actions im GAR-Workflow auf Commit-SHAs, um die CodeQL-Warnung zu beheben.
- [x] Ergänze `tasks/lessons.md` um die Erkenntnis aus der Nutzerkorrektur.
- [x] Prüfe den aktualisierten Workflow per Datei-/Diff-Checks und dokumentiere das Ergebnis.
- [x] Committe die Korrektur und aktualisiere die PR-Metadaten.

## Review

- `google-github-actions/auth` wurde von `@v2` auf den Commit `c200f3691d83b41bf9bbd8638997a462592937ed` gepinnt, um die gemeldete CodeQL-Warnung zu beheben.
- `aquasecurity/trivy-action` wurde zusätzlich von `@master` auf den Commit `57a97c7e7821a5776cebc9bb87c984fa69cba8f1` gepinnt, damit der Workflow konsistent ohne bewegliche Drittanbieter-Refs auskommt.
- Eine Python-Prüfung bestätigte, dass die gepinnten Action-Refs vorhanden sind und die alten unpinned Refs nicht mehr im Workflow stehen.
- `git diff --check -- .github/workflows/build-and-push.yml tasks/todo.md tasks/lessons.md` lief ohne Beanstandungen.
- Das bereits unversionierte `dotnet-install.sh` blieb unverändert und wurde nicht in diese Korrektur aufgenommen.
