# Security Showcase (C# Konsolenprojekt)

Dieses Repository ist kein reines `Hallo Welt` mehr, sondern eine **kleine schematische Demo für Security-Features** in einem .NET-Konsolenprogramm.

## Was gezeigt wird

Die Demo visualisiert bewusst einfach und nachvollziehbar:

- **Input Validation** für Benutzereingaben.
- **Secret Handling** mit maskierter Ausgabe statt Klartext.
- **Least Privilege** über einfache Rollen und erlaubte Aktionen.
- **Audit Logging** als nachvollziehbare Sicherheits-Spur.
- **Rate Limiting** als geplante nächste Ausbaustufe.

## Ausführen

1. Stelle sicher, dass ein .NET SDK installiert ist, z. B. .NET 8.
2. Im Verzeichnis mit `HelloWorld.csproj`:
   - `dotnet build`
   - `dotnet run`

### Optionale Demo-Parameter

Du kannst Rolle und Aktion direkt übergeben:

```bash
dotnet run -- admin approve-policy
dotnet run -- operator rotate-keys
dotnet run -- guest approve-policy
```

Die Demo validiert die Aktion, maskiert Secrets in der Ausgabe und zeigt, ob eine Aktion für die angegebene Rolle erlaubt wäre.

### Secret für die Demo setzen

Optional kannst du ein Secret über eine Umgebungsvariable setzen:

```bash
export SECURITY_DEMO_SECRET="prod-like-secret-9876"
dotnet run -- operator rotate-keys
```

In der Konsolenausgabe wird dieses Secret **nur maskiert** dargestellt.

## Ziel des Repos

Das Projekt ist absichtlich klein gehalten, damit Security-Konzepte schnell gezeigt, erklärt und später erweitert werden können, z. B. mit:

- echter Konfiguration aus `appsettings.json`
- strukturierter Protokollierung
- Rate Limiting
- Policy-basierter Autorisierung
