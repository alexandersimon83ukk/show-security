using System.Text.Json;

namespace ShowSecurity.Samples;

public sealed class SecurityTopicPayload
{
    public string CreateJsonSummary()
    {
        var payload = new
        {
            RepositoryFocus = "GitHub Security Themen via Actions",
            Topics = new[]
            {
                "CodeQL",
                "Dependency Review",
                "Workflow Hardening",
                "CodeQL Demo Sample"
            },
            DemoTarget = "Samples/UserRepository.cs"
        };

        return JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
