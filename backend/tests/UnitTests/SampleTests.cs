using Xunit;
using FluentAssertions;

namespace UnitTests;

public class SampleTests
{
    [Fact]
    public void TestEnvironment_ShouldBeHealthy()
    {
        true.Should().BeTrue();
    }
}
