# Task Plan

- [x] Prüfe Repository-Anweisungen, Nutzerfeedback und aktuellen Stand.
- [x] Ergänze ein absichtlich verwundbares `UserRepository`-Beispiel für CodeQL.
- [x] Dokumentiere die neue Demo-Datei in den GitHub-Actions-Unterlagen.
- [x] Führe verfügbare Checks aus und dokumentiere Einschränkungen.
- [x] Dokumentiere das Ergebnis im Review.

## Review

- `Samples/UserRepository.cs` enthält jetzt eine absichtlich unsichere SQL-String-Konkatenation für die CodeQL-Demo.
- `HelloWorld.csproj` referenziert `System.Data.SqlClient`, damit das Beispiel mit den verwendeten SQL-Typen vollständig im Projekt liegt.
- `README.md`, `SECURITY.md` und die Actions-Übersicht verweisen jetzt explizit auf die Demo-Datei.
- Die Workflow-YAMLs wurden mit Ruby (`YAML.load_file`) erfolgreich geparst.
- `HelloWorld.csproj` wurde per XML-Parser erfolgreich geprüft.
- `git diff --check` lief erfolgreich.
- Die eigentliche Visualisierung des Befunds passiert weiterhin nach dem Push in GitHub Code Scanning.
