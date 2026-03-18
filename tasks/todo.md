# Task Plan

- [x] Prüfe Repository-Anweisungen, Nutzerfeedback und aktuellen Stand.
- [x] Erweitere das separate Testprojekt auf 5 Unit Tests mit 4 Erfolgen und 1 absichtlichem Fehler.
- [x] Ergänze eine GitHub-Actions-Auswertung für Test- und Code-Coverage-Ergebnisse.
- [x] Führe verfügbare Checks aus und dokumentiere Einschränkungen.
- [x] Dokumentiere das Ergebnis im Review.

## Review

- `HelloWorld.Tests/SecurityTopicPayloadTests.cs` enthält jetzt 5 Tests: 4 erfolgreich angelegte Assertions und 1 absichtlich fehlschlagende Assertion.
- `HelloWorld.Tests/HelloWorld.Tests.csproj` referenziert zusätzlich `coverlet.collector` für Coverage-Erfassung.
- `.github/workflows/tests-and-coverage.yml` führt Tests aus, sammelt Coverage und schreibt die Auswertung in die GitHub Job Summary.
- Beide Projektdateien wurden per XML-Parser erfolgreich geprüft.
- Die Testdatei wurde auf 5 Testmethoden, 4 positive Assertions und 1 absichtlich fehlerhafte Assertion geprüft.
- Die neue Workflow-Datei wurde per YAML-Parser erfolgreich geprüft.
- `git diff --check` lief erfolgreich.
