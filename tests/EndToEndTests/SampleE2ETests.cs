using Xunit;
using FluentAssertions;

namespace EndToEndTests;

public class SampleE2ETests
{
    [Fact]
    public void E2E_Environment_ShouldBeConfigured()
    {
        true.Should().BeTrue();
    }
}
