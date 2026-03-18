using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowSecurity.Samples;

namespace ShowSecurity.Tests;

[TestClass]
public class SecurityTopicPayloadTests
{
    [TestMethod]
    public void CreateJsonSummary_ShouldContainRepositoryFocus()
    {
        var payload = new SecurityTopicPayload();
        var json = payload.CreateJsonSummary();

        StringAssert.Contains(json, "GitHub Security Themen via Actions");
    }

    [TestMethod]
    public void CreateJsonSummary_ShouldContainCodeQlTopic()
    {
        var payload = new SecurityTopicPayload();
        var json = payload.CreateJsonSummary();

        StringAssert.Contains(json, "CodeQL");
    }

    [TestMethod]
    public void CreateJsonSummary_ShouldContainDependencyReviewTopic()
    {
        var payload = new SecurityTopicPayload();
        var json = payload.CreateJsonSummary();

        StringAssert.Contains(json, "Dependency Review");
    }

    [TestMethod]
    public void CreateJsonSummary_ShouldContainDemoTarget()
    {
        var payload = new SecurityTopicPayload();
        var json = payload.CreateJsonSummary();

        StringAssert.Contains(json, "Samples/UserRepository.cs");
    }

    [TestMethod]
    public void CreateJsonSummary_ShouldRemainBuildable_AndContainCodeQl()
    {
        var payload = new SecurityTopicPayload();
        var json = payload.CreateJsonSummary();

        StringAssert.Contains(json, "CodeQL");
    }
}
