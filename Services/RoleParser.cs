using ShowSecurity.Models;

namespace ShowSecurity.Services;

public sealed class RoleParser
{
    public UserRole Parse(string? rawRole) => rawRole?.Trim().ToLowerInvariant() switch
    {
        "admin" => UserRole.Admin,
        "operator" => UserRole.Operator,
        _ => UserRole.Guest
    };
}
