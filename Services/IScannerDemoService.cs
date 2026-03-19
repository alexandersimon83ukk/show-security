using ShowSecurity.Models;

namespace ShowSecurity.Services;

public interface IScannerDemoService
{
    RandomNumberResponse CreateRandomNumberResponse();
    string CreateSecuritySummaryJson();
}
