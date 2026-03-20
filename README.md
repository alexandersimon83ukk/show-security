# GitHub Security Themen via Actions

Dieses Repository zeigt **GitHub-Security-Themen direkt über GitHub Actions** statt über eine lokale Konsolen-Demo.

## Was dieses Repo demonstriert

Die zentralen Sicherheits-Themen werden über klar benannte Workflows in `.github/workflows/` sichtbar gemacht:

- **SAST / CodeQL** für C# und GitHub Actions.
- **SCA / CVE / Dependency Review** für Pull Requests.
- **Web Security Scan (DAST)** als OWASP-ZAP-Baseline-Scan nur auf `main`.
- **Quality / Tests and Coverage** für Tests, Coverage und GitHub Pages.
- **Minimale Workflow-Permissions** als Teil der Workflow-Härtung.
- **Ein absichtlich unsicheres SQL-Beispiel** in `Samples/UserRepository.cs`, damit CodeQL einen nachvollziehbaren Befund zeigen kann.

## Workflows

### `codeql.yml`

Der Workflow heißt im Actions-Tab **`SAST / CodeQL`** und zeigt GitHub Code Scanning mit CodeQL für zwei Bereiche:

- `C#`
- `GitHub Actions`

Zusätzlich werden enge Berechtigungen gesetzt und `security-extended` Queries aktiviert.

Als bewusst verwundbares Beispiel dient `Samples/UserRepository.cs`: Dort wird `userInputUsername` per String-Konkatenation direkt in ein SQL-Statement geschrieben, damit CodeQL einen SQL-Injection-nahen Befund markieren kann.

### `dependency-review.yml`

Der Workflow heißt im Actions-Tab **`SCA / CVE / Dependency Review`** und prüft Pull Requests auf riskante Dependency-Änderungen mit der offiziellen GitHub Dependency Review Action.

### `web-security-scan-dast.yml`

Der Workflow heißt im Actions-Tab **`Web Security Scan (DAST)`** und führt einen OWASP-ZAP-Baseline-Scan gegen die bereitgestellte Demo-URL aus. Er wird nur für `push` auf `main` oder manuell per `workflow_dispatch` gestartet.

### `tests-and-coverage.yml`

Der Workflow heißt im Actions-Tab **`Quality / Tests and Coverage`**. Er führt die .NET-Tests aus, erzeugt einen Coverage-Report und veröffentlicht den HTML-Report auf GitHub Pages.

## So zeigst du die Themen auf GitHub

1. Repository nach GitHub pushen.
2. Im Tab **Actions** die Workflows ausführen bzw. bei PRs triggern.
3. Die Namen sind jetzt direkt nach Security-Kategorie gegliedert:
   - `SAST / CodeQL`
   - `SCA / CVE / Dependency Review`
   - `Web Security Scan (DAST)`
   - `Quality / Tests and Coverage`

## Repo-Struktur

- `.github/workflows/codeql.yml` – SAST mit CodeQL für C# und GitHub Actions
- `.github/workflows/dependency-review.yml` – SCA/CVE-Check für PRs
- `.github/workflows/web-security-scan-dast.yml` – dedizierter DAST-Workflow nur für `main`
- `.github/workflows/tests-and-coverage.yml` – Testlauf plus Coverage-Auswertung im GitHub-UI
- `Samples/UserRepository.cs` – absichtlich unsicheres SQL-Beispiel für CodeQL
- `Samples/SecurityTopicPayload.cs` – kleine JSON-Demo mit `System.Text.Json`
- `HelloWorld.Tests/` – separates Testprojekt mit 5 erfolgreichen Unit Tests
- `Program.cs` – nur ein minimaler Hinweis auf den Actions-Fokus

## Lokale UI für den GCP Web Security Scanner

Zusätzlich zur GitHub-Actions-Demo startet das Projekt jetzt eine **minimale Weboberfläche**:

- Eine Seite mit genau **einem Button**
- Ein zufälliger Zahlenwert, der per Klick über `/api/random` neu geladen wird
- Ein bewusst einfacher Flow, damit sich die Anwendung leicht mit einem **Web Security Scanner** vorführen lässt
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

Der Workflow `tests-and-coverage.yml` verwendet ebenfalls `dotnet test`, sammelt Test- und Coverage-Daten und veröffentlicht anschließend den Coverage-Report auf GitHub Pages.

Der Workflow `web-security-scan-dast.yml` erzeugt den separaten DAST-Report als Workflow-Artefakt, sodass SAST / SCA / CVE und DAST im Actions-Tab auf den ersten Blick getrennt sichtbar bleiben.

## Hinweis

Die eigentliche Demonstration passiert in GitHub selbst. Lokal ist dieses Repo absichtlich minimal gehalten.
