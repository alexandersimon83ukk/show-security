using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var securityFeatures = new List<SecurityFeature>
{
    new(
        "Input Validation",
        "Benutzereingaben werden normalisiert und auf erlaubte Zeichen geprüft.",
        DemoState.Active,
        new[]
        {
            "Trimmt Eingaben vor der weiteren Verarbeitung.",
            "Blockiert Zeichen ausserhalb eines definierten Whitelists.",
            "Verhindert typische Injection-Muster im Demo-Flow."
        }),
    new(
        "Secret Handling",
        "Secrets werden niemals im Klartext ausgegeben und nur maskiert dargestellt.",
        DemoState.Active,
        new[]
        {
            "API-Schluessel werden auf die letzten vier Zeichen reduziert.",
            "Logs enthalten nur redigierte Werte.",
            "Die Demo macht sichtbar, wo Secrets herkommen sollten: Umgebung statt Code."
        }),
    new(
        "Least Privilege",
        "Zugriffe werden anhand einer Rolle gegen erlaubte Aktionen geprüft.",
        DemoState.Active,
        new[]
        {
            "Gast darf nur lesen.",
            "Operator darf lesen und rotieren.",
            "Admin darf zusätzlich Policies freigeben."
        }),
    new(
        "Audit Logging",
        "Jede sicherheitsrelevante Aktion erzeugt einen nachvollziehbaren Audit-Eintrag.",
        DemoState.Active,
        new[]
        {
            "Zeitpunkt, Rolle und Ergebnis werden protokolliert.",
            "Erfolgreiche und abgelehnte Aktionen sind klar unterscheidbar.",
            "Beispielausgaben zeigen das Format einer Audit-Trail-Zeile."
        }),
    new(
        "Rate Limiting",
        "Wiederholte sensible Aktionen werden gedrosselt, um Missbrauch sichtbar zu machen.",
        DemoState.Planned,
        new[]
        {
            "Konzeptuell als Schutz gegen Brute-Force oder API-Missbrauch.",
            "Noch nicht als echter Counter implementiert, bewusst nur schematisch.",
            "Kann spaeter fuer eine interaktive Demo erweitert werden."
        })
};

var simulatedSecret = Environment.GetEnvironmentVariable("SECURITY_DEMO_SECRET") ?? "demo-secret-key-1234";
var role = ParseRole(args.FirstOrDefault());
var action = args.Skip(1).FirstOrDefault() ?? "rotate-keys";
var sanitizedAction = SanitizeAction(action);
var actionAllowed = IsAllowed(role, sanitizedAction);
var auditEntry = BuildAuditEntry(role, sanitizedAction, actionAllowed);

WriteHeader();
WriteFeatureOverview(securityFeatures);
WriteDemoScenario(role, sanitizedAction, simulatedSecret, actionAllowed, auditEntry);
WriteFooter();

static void WriteHeader()
{
    Console.WriteLine("Security Showcase für dieses Repo");
    Console.WriteLine(new string('=', 34));
    Console.WriteLine("Dieses Konsolenprojekt zeigt Security-Mechanismen bewusst schematisch.");
    Console.WriteLine();
}

static void WriteFeatureOverview(IEnumerable<SecurityFeature> features)
{
    Console.WriteLine("Security Features im Überblick:");

    foreach (var feature in features)
    {
        Console.WriteLine($"- {feature.Name} [{feature.StateLabel}]");
        Console.WriteLine($"  {feature.Description}");

        foreach (var detail in feature.Details)
        {
            Console.WriteLine($"  • {detail}");
        }

        Console.WriteLine();
    }
}

static void WriteDemoScenario(UserRole role, string action, string secret, bool actionAllowed, string auditEntry)
{
    Console.WriteLine("Simulierter Sicherheits-Flow:");
    Console.WriteLine($"- Rolle: {role}");
    Console.WriteLine($"- Angeforderte Aktion: {action}");
    Console.WriteLine($"- Secret (maskiert): {MaskSecret(secret)}");
    Console.WriteLine($"- Entscheidung: {(actionAllowed ? "erlaubt" : "abgelehnt")}");
    Console.WriteLine($"- Audit: {auditEntry}");
    Console.WriteLine();

    if (!actionAllowed)
    {
        Console.WriteLine("Hinweis: Diese Ablehnung demonstriert das Prinzip Least Privilege.");
        Console.WriteLine();
    }
}

static void WriteFooter()
{
    Console.WriteLine("Nächste sinnvolle Ausbaustufen:");
    Console.WriteLine("- Konfiguration aus appsettings oder Umgebungsvariablen laden.");
    Console.WriteLine("- Rate Limiting mit echtem Zaehler ergänzen.");
    Console.WriteLine("- Structured Logging oder OpenTelemetry anbinden.");
}

static UserRole ParseRole(string? rawRole) => rawRole?.Trim().ToLowerInvariant() switch
{
    "admin" => UserRole.Admin,
    "operator" => UserRole.Operator,
    _ => UserRole.Guest
};

static string SanitizeAction(string? rawAction)
{
    var candidate = (rawAction ?? "read-dashboard").Trim().ToLowerInvariant();
    var allowedCharacters = candidate.Where(c => char.IsLetterOrDigit(c) || c is '-' or '_').ToArray();
    var sanitized = new string(allowedCharacters);

    return string.IsNullOrWhiteSpace(sanitized)
        ? "read-dashboard"
        : sanitized;
}

static bool IsAllowed(UserRole role, string action) => role switch
{
    UserRole.Admin => true,
    UserRole.Operator => action is "read-dashboard" or "rotate-keys",
    UserRole.Guest => action == "read-dashboard",
    _ => false
};

static string BuildAuditEntry(UserRole role, string action, bool actionAllowed)
{
    var result = actionAllowed ? "SUCCESS" : "DENIED";
    return $"{DateTimeOffset.UtcNow:O} role={role} action={action} result={result}";
}

static string MaskSecret(string secret)
{
    if (string.IsNullOrWhiteSpace(secret))
    {
        return "[not-set]";
    }

    return secret.Length <= 4
        ? new string('*', secret.Length)
        : $"{new string('*', secret.Length - 4)}{secret[^4..]}";
}

enum DemoState
{
    Active,
    Planned
}

enum UserRole
{
    Guest,
    Operator,
    Admin
}

sealed record SecurityFeature(string Name, string Description, DemoState State, IReadOnlyList<string> Details)
{
    public string StateLabel => State switch
    {
        DemoState.Active => "aktiv",
        DemoState.Planned => "geplant",
        _ => "unbekannt"
    };
}
