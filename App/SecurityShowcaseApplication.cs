using ShowSecurity.Models;
using ShowSecurity.Presentation;
using ShowSecurity.Services;

namespace ShowSecurity.App;

public sealed class SecurityShowcaseApplication
{
    private readonly SecurityScenarioFactory securityScenarioFactory;
    private readonly ConsoleSecurityShowcaseRenderer renderer;
    private readonly SecurityFeatureCatalog securityFeatureCatalog;

    public SecurityShowcaseApplication()
        : this(
            new SecurityScenarioFactory(
                new RoleParser(),
                new ActionSanitizer(),
                new AuthorizationService(),
                new AuditEntryFactory()),
            new ConsoleSecurityShowcaseRenderer(new SecretMasker()),
            new SecurityFeatureCatalog())
    {
    }

    public SecurityShowcaseApplication(
        SecurityScenarioFactory securityScenarioFactory,
        ConsoleSecurityShowcaseRenderer renderer,
        SecurityFeatureCatalog securityFeatureCatalog)
    {
        this.securityScenarioFactory = securityScenarioFactory;
        this.renderer = renderer;
        this.securityFeatureCatalog = securityFeatureCatalog;
    }

    public void Run(string[] args)
    {
        var features = securityFeatureCatalog.GetFeatures();
        var secret = Environment.GetEnvironmentVariable("SECURITY_DEMO_SECRET") ?? "demo-secret-key-1234";
        var scenario = securityScenarioFactory.Create(args, secret);

        renderer.WriteHeader();
        renderer.WriteFeatureOverview(features);
        renderer.WriteScenario(scenario);
        renderer.WriteFooter();
    }
}
