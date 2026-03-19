using ShowSecurity.Models;
using ShowSecurity.Samples;

namespace ShowSecurity.Services;

public sealed class ScannerDemoService : IScannerDemoService
{
    public RandomNumberResponse CreateRandomNumberResponse()
    {
        return new RandomNumberResponse(
            Random.Shared.Next(1000, 10000),
            "Refresh this button-driven DOM update during a GCP Web Security Scanner demo.");
    }

    public string CreateSecuritySummaryJson()
    {
        var payload = new SecurityTopicPayload();
        return payload.CreateJsonSummary();
    }
}
