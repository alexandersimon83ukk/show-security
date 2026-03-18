namespace ShowSecurity.Models;

public sealed record SecurityScenario(UserRole Role, string Action, string Secret, bool ActionAllowed, string AuditEntry);
