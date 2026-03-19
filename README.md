# GitHub Security Themen via Actions

Dieses Repository zeigt **GitHub-Security-Themen direkt über GitHub Actions** statt über eine lokale Konsolen-Demo.

## Was dieses Repo demonstriert

Die zentralen Sicherheits-Themen werden über Workflows in `.github/workflows/` sichtbar gemacht:

- **Code Scanning mit CodeQL** für C# und GitHub Actions.
- **Dependency Review** für Pull Requests.
- **Sicherheits-Übersicht als Workflow Summary** mit den wichtigsten GitHub-Security-Themen.
- **Minimale Workflow-Permissions** als Teil der Workflow-Härtung.
- **Ein absichtlich unsicheres SQL-Beispiel** in `Samples/UserRepository.cs`, damit CodeQL einen nachvollziehbaren Befund zeigen kann.

## Workflows

### `codeql.yml`

Zeigt GitHub Code Scanning mit CodeQL für zwei Bereiche:

- `csharp`
- `actions`

Zusätzlich werden enge Berechtigungen gesetzt und `security-extended` Queries aktiviert.

Als bewusst verwundbares Beispiel dient `Samples/UserRepository.cs`: Dort wird `userInputUsername` per String-Konkatenation direkt in ein SQL-Statement geschrieben, damit CodeQL einen SQL-Injection-nahen Befund markieren kann.

### `dependency-review.yml`

Prüft Pull Requests auf riskante Dependency-Änderungen mit der offiziellen GitHub Dependency Review Action.

### `security-topics.yml`

Schreibt bei `workflow_dispatch` oder Push auf `main` eine gut lesbare Übersicht in die GitHub Actions Job Summary. Damit kann man die Sicherheits-Themen direkt im Actions-Tab präsentieren.

## So zeigst du die Themen auf GitHub

1. Repository nach GitHub pushen.
2. Im Tab **Actions** die Workflows ausführen bzw. bei PRs triggern.
3. Die Job Summaries und Security-Ergebnisse in GitHub zeigen:
   - CodeQL / Code scanning
   - Dependency Review in Pull Requests
   - Workflow Summary mit den Security-Themen

## Repo-Struktur

- `.github/workflows/codeql.yml` – CodeQL Analyse
- `.github/workflows/dependency-review.yml` – Dependency Review für PRs
- `.github/workflows/security-topics.yml` – Präsentations-Workflow für Security-Themen
- `Samples/UserRepository.cs` – absichtlich unsicheres SQL-Beispiel für CodeQL
- `Samples/SecurityTopicPayload.cs` – kleine JSON-Demo mit `System.Text.Json`
- `HelloWorld.Tests/` – separates Testprojekt mit 5 erfolgreichen Unit Tests
- `.github/workflows/tests-and-coverage.yml` – Testlauf plus Coverage-Auswertung im GitHub-UI
- `Program.cs` – nur ein minimaler Hinweis auf den Actions-Fokus


## Lokale UI für den GCP Web Security Scanner

Zusätzlich zur GitHub-Actions-Demo startet das Projekt jetzt eine **minimale Weboberfläche**:

- Eine Seite mit genau **einem Button**
- Ein zufälliger Zahlenwert, der per Klick über `/api/random` neu geladen wird
- Ein bewusst einfacher Flow, damit sich die Anwendung leicht mit dem **GCP Web Security Scanner** vorführen lässt
- Die API ist bewusst in **Controller- und Service-Struktur** aufgeteilt, damit die Demo näher an einer realen Web-App ist

Lokal startest du die UI mit:

```bash
dotnet run --project HelloWorld.csproj
```

Danach ist die Demo standardmäßig unter `http://localhost:5000` oder der von ASP.NET ausgegebenen URL erreichbar.

## Tests

Das zusätzliche Projekt `HelloWorld.Tests/` enthält jetzt **5 erfolgreiche Unit Tests**, damit das Repository buildbar bleibt und trotzdem Test- sowie Coverage-Daten im CI zeigt.

Lokal ist der relevante Testbefehl:

```bash
dotnet test HelloWorld.Tests/HelloWorld.Tests.csproj
```

Der Workflow `tests-and-coverage.yml` verwendet ebenfalls `dotnet test`, sammelt Test- und Coverage-Daten und schreibt eine kompakte Coverage-Auswertung direkt in die GitHub Job Summary.

## Hinweis

Die eigentliche Demonstration passiert in GitHub selbst. Lokal ist dieses Repo absichtlich minimal gehalten.
