# Task Plan

- [x] Prüfe Repository-Anweisungen, Nutzerfeedback und aktuellen Stand.
- [x] Räume `Program.cs` auf und verschiebe die Demo-Logik in Ordner mit eigenen Klassen-Dateien.
- [x] Halte die Security-Demo funktional gleich, aber strukturiere sie sauberer in Models, Services und Presentation.
- [x] Führe verfügbare Checks aus und dokumentiere Einschränkungen.
- [x] Dokumentiere das Ergebnis im Review.

## Review

- `Program.cs` enthält jetzt nur noch den Einstiegspunkt und den Aufruf der Anwendung.
- Die Demo-Logik ist in `App`, `Models`, `Services` und `Presentation` aufgeteilt.
- Die bestehende Security-Showcase-Funktionalität wurde dabei beibehalten.
- `dotnet build` und `dotnet run` konnten weiterhin nicht geprüft werden, weil das .NET SDK in der Umgebung fehlt.
- `git diff --check` lief erfolgreich und zeigte keine Whitespace-/Patch-Probleme.
