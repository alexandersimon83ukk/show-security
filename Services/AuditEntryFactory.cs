using ShowSecurity.Models;

namespace ShowSecurity.Services;

public sealed class AuditEntryFactory
{
    public string Create(UserRole role, string action, bool actionAllowed)
    {
        var result = actionAllowed ? "SUCCESS" : "DENIED";
        return $"{DateTimeOffset.UtcNow:O} role={role} action={action} result={result}";
    }
}
