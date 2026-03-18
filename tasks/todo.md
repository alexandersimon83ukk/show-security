# Task Plan

- [x] Prüfe Repository-Anweisungen, Nutzerfeedback und aktuellen Stand.
- [x] Ergänze eine neue Klasse mit Nutzung von `System.Text.Json`.
- [x] Füge die gewünschte Paket-Referenz `System.Text.Json` in die Projektdatei ein.
- [x] Führe verfügbare Checks aus und dokumentiere Einschränkungen.
- [x] Dokumentiere das Ergebnis im Review.

## Review

- `Samples/SecurityTopicPayload.cs` verwendet `System.Text.Json` für eine kleine JSON-Zusammenfassung.
- `HelloWorld.csproj` enthält jetzt zusätzlich die gewünschte Paket-Referenz `System.Text.Json` in Version `8.0.4`.
- `README.md` listet die neue JSON-Demo-Datei in der Repo-Struktur auf.
- `HelloWorld.csproj` wurde per XML-Parser erfolgreich geprüft.
- `Samples/SecurityTopicPayload.cs` wurde auf die erwartete Verwendung von `JsonSerializer.Serialize` geprüft.
- `git diff --check` lief erfolgreich.
