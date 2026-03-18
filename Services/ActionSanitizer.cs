using System.Text;

namespace ShowSecurity.Services;

public sealed class ActionSanitizer
{
    public string Sanitize(string? rawAction)
    {
        var candidate = (rawAction ?? "read-dashboard").Trim().ToLowerInvariant();
        var builder = new StringBuilder(candidate.Length);

        foreach (var character in candidate)
        {
            if (char.IsLetterOrDigit(character) || character is '-' or '_')
            {
                builder.Append(character);
            }
        }

        return builder.Length == 0
            ? "read-dashboard"
            : builder.ToString();
    }
}
