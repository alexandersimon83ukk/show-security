# Security Policy

## Charakter dieses Repositories

Dieses Repository ist eine **Demonstration für GitHub-Security-Themen über GitHub Actions**. Der Schwerpunkt liegt auf der Sichtbarkeit von Security-Funktionen in GitHub und nicht auf einer produktionsreifen Applikation.

## Gezeigte Security-Themen

- Code Scanning mit CodeQL
- Dependency Review bei Pull Requests
- Gehärtete Workflow-Permissions
- Sichtbare Security-Zusammenfassung über GitHub Actions Job Summaries
- Eine absichtlich unsichere SQL-Datei als Demo-Ziel für CodeQL

## Supported Versions

Dieses Repository ist eine laufende Demo. Änderungen und Verbesserungen erfolgen auf dem aktuellen Stand des Default-Branches.

| Version | Supported |
| ------- | --------- |
| main    | ✅ |

## Reporting a Vulnerability

Wenn dir in diesem Demo-Repository eine unsichere Konfiguration oder ein problematischer Workflow auffällt, eröffne bitte ein Issue oder informiere die Maintainer des Repositories. Die absichtlich verwundbare Demo-Datei unter `Samples/UserRepository.cs` ist nur für die Visualisierung von CodeQL-Befunden gedacht.
