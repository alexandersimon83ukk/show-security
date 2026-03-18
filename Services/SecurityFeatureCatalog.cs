using ShowSecurity.Models;

namespace ShowSecurity.Services;

public sealed class SecurityFeatureCatalog
{
    public IReadOnlyList<SecurityFeature> GetFeatures() =>
    [
        new(
            "Input Validation",
            "Benutzereingaben werden normalisiert und auf erlaubte Zeichen geprüft.",
            DemoState.Active,
            [
                "Trimmt Eingaben vor der weiteren Verarbeitung.",
                "Blockiert Zeichen ausserhalb eines definierten Whitelists.",
                "Verhindert typische Injection-Muster im Demo-Flow."
            ]),
        new(
            "Secret Handling",
            "Secrets werden niemals im Klartext ausgegeben und nur maskiert dargestellt.",
            DemoState.Active,
            [
                "API-Schluessel werden auf die letzten vier Zeichen reduziert.",
                "Logs enthalten nur redigierte Werte.",
                "Die Demo macht sichtbar, wo Secrets herkommen sollten: Umgebung statt Code."
            ]),
        new(
            "Least Privilege",
            "Zugriffe werden anhand einer Rolle gegen erlaubte Aktionen geprüft.",
            DemoState.Active,
            [
                "Gast darf nur lesen.",
                "Operator darf lesen und rotieren.",
                "Admin darf zusätzlich Policies freigeben."
            ]),
        new(
            "Audit Logging",
            "Jede sicherheitsrelevante Aktion erzeugt einen nachvollziehbaren Audit-Eintrag.",
            DemoState.Active,
            [
                "Zeitpunkt, Rolle und Ergebnis werden protokolliert.",
                "Erfolgreiche und abgelehnte Aktionen sind klar unterscheidbar.",
                "Beispielausgaben zeigen das Format einer Audit-Trail-Zeile."
            ]),
        new(
            "Rate Limiting",
            "Wiederholte sensible Aktionen werden gedrosselt, um Missbrauch sichtbar zu machen.",
            DemoState.Planned,
            [
                "Konzeptuell als Schutz gegen Brute-Force oder API-Missbrauch.",
                "Noch nicht als echter Counter implementiert, bewusst nur schematisch.",
                "Kann spaeter fuer eine interaktive Demo erweitert werden."
            ])
    ];
}
