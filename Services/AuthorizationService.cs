using ShowSecurity.Models;

namespace ShowSecurity.Services;

public sealed class AuthorizationService
{
    public bool IsAllowed(UserRole role, string action) => role switch
    {
        UserRole.Admin => true,
        UserRole.Operator => action is "read-dashboard" or "rotate-keys",
        UserRole.Guest => action == "read-dashboard",
        _ => false
    };
}
