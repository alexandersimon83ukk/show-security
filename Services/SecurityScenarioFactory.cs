using ShowSecurity.Models;

namespace ShowSecurity.Services;

public sealed class SecurityScenarioFactory
{
    private readonly RoleParser roleParser;
    private readonly ActionSanitizer actionSanitizer;
    private readonly AuthorizationService authorizationService;
    private readonly AuditEntryFactory auditEntryFactory;

    public SecurityScenarioFactory(
        RoleParser roleParser,
        ActionSanitizer actionSanitizer,
        AuthorizationService authorizationService,
        AuditEntryFactory auditEntryFactory)
    {
        this.roleParser = roleParser;
        this.actionSanitizer = actionSanitizer;
        this.authorizationService = authorizationService;
        this.auditEntryFactory = auditEntryFactory;
    }

    public SecurityScenario Create(string[] args, string secret)
    {
        var role = roleParser.Parse(args.FirstOrDefault());
        var requestedAction = args.Skip(1).FirstOrDefault() ?? "rotate-keys";
        var action = actionSanitizer.Sanitize(requestedAction);
        var actionAllowed = authorizationService.IsAllowed(role, action);
        var auditEntry = auditEntryFactory.Create(role, action, actionAllowed);

        return new SecurityScenario(role, action, secret, actionAllowed, auditEntry);
    }
}
