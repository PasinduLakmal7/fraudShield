using Xunit;
using FluentAssertions;

namespace IntegrationTests;

public class SampleTests
{
    [Fact]
    public void TestEnvironment_ShouldBeHealthy()
    {
        true.Should().BeTrue();
    }
}
