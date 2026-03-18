# Task Plan

- [x] Prüfe Repository-Anweisungen und aktuellen Stand.
- [x] Ersetze das reine Hello-World-Beispiel durch eine schematische Security-Demo.
- [x] Aktualisiere die Dokumentation für Nutzung und Sicherheitsbezug.
- [x] Versuche Build-/Run-Checks auszuführen (durch Umgebung blockiert: kein .NET SDK vorhanden).
- [x] Dokumentiere das Ergebnis.

## Review

- `Program.cs` zeigt jetzt mehrere Security-Prinzipien schematisch in einer konsolenfreundlichen Demo.
- `README.md` erklärt Nutzung, Ziele und Demo-Parameter.
- `SECURITY.md` beschreibt den Demo-Charakter und den Sicherheitsfokus des Repositories.
- Verifikation per `dotnet build`/`dotnet run` war in dieser Umgebung nicht möglich, weil `dotnet` nicht installiert ist.
