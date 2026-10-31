using Xunit;
using FluentAssertions;

namespace ContractTests;

public class SampleTests
{
    [Fact]
    public void TestEnvironment_ShouldBeHealthy()
    {
        true.Should().BeTrue();
    }
}
