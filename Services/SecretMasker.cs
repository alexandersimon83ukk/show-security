namespace ShowSecurity.Services;

public sealed class SecretMasker
{
    public string Mask(string secret)
    {
        if (string.IsNullOrWhiteSpace(secret))
        {
            return "[not-set]";
        }

        return secret.Length <= 4
            ? new string('*', secret.Length)
            : $"{new string('*', secret.Length - 4)}{secret[^4..]}";
    }
}
