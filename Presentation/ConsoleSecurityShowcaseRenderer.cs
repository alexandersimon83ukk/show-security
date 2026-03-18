using ShowSecurity.Models;
using ShowSecurity.Services;

namespace ShowSecurity.Presentation;

public sealed class ConsoleSecurityShowcaseRenderer
{
    private readonly SecretMasker secretMasker;

    public ConsoleSecurityShowcaseRenderer(SecretMasker secretMasker)
    {
        this.secretMasker = secretMasker;
    }

    public void WriteHeader()
    {
        Console.WriteLine("Security Showcase für dieses Repo");
        Console.WriteLine(new string('=', 34));
        Console.WriteLine("Dieses Konsolenprojekt zeigt Security-Mechanismen bewusst schematisch.");
        Console.WriteLine();
    }

    public void WriteFeatureOverview(IEnumerable<SecurityFeature> features)
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

    public void WriteScenario(SecurityScenario scenario)
    {
        Console.WriteLine("Simulierter Sicherheits-Flow:");
        Console.WriteLine($"- Rolle: {scenario.Role}");
        Console.WriteLine($"- Angeforderte Aktion: {scenario.Action}");
        Console.WriteLine($"- Secret (maskiert): {secretMasker.Mask(scenario.Secret)}");
        Console.WriteLine($"- Entscheidung: {(scenario.ActionAllowed ? "erlaubt" : "abgelehnt")}");
        Console.WriteLine($"- Audit: {scenario.AuditEntry}");
        Console.WriteLine();

        if (!scenario.ActionAllowed)
        {
            Console.WriteLine("Hinweis: Diese Ablehnung demonstriert das Prinzip Least Privilege.");
            Console.WriteLine();
        }
    }

    public void WriteFooter()
    {
        Console.WriteLine("Nächste sinnvolle Ausbaustufen:");
        Console.WriteLine("- Konfiguration aus appsettings oder Umgebungsvariablen laden.");
        Console.WriteLine("- Rate Limiting mit echtem Zaehler ergänzen.");
        Console.WriteLine("- Structured Logging oder OpenTelemetry anbinden.");
    }
}
