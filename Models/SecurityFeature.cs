namespace ShowSecurity.Models;

public sealed record SecurityFeature(string Name, string Description, DemoState State, IReadOnlyList<string> Details)
{
    public string StateLabel => State switch
    {
        DemoState.Active => "aktiv",
        DemoState.Planned => "geplant",
        _ => "unbekannt"
    };
}
