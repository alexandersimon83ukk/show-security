using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowSecurity.Samples;

namespace ShowSecurity.Tests;

[TestClass]
public class SecurityTopicPayloadTests
{
    [TestMethod]
    public void CreateJsonSummary_ShouldFail_ToShowABrokenUnitTest()
    {
        var payload = new SecurityTopicPayload();
        var json = payload.CreateJsonSummary();

        StringAssert.DoesNotContain(json, "CodeQL");
    }
}
