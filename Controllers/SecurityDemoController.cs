using Microsoft.AspNetCore.Mvc;
using ShowSecurity.Services;

namespace ShowSecurity.Controllers;

[ApiController]
[Route("api")]
public sealed class SecurityDemoController : ControllerBase
{
    private readonly IScannerDemoService scannerDemoService;

    public SecurityDemoController(IScannerDemoService scannerDemoService)
    {
        this.scannerDemoService = scannerDemoService;
    }

    [HttpGet("random")]
    public IActionResult GetRandomNumber()
    {
        return Ok(scannerDemoService.CreateRandomNumberResponse());
    }

    [HttpGet("security-summary")]
    public ContentResult GetSecuritySummary()
    {
        return Content(scannerDemoService.CreateSecuritySummaryJson(), "application/json");
    }
}
