using FluentAssertions;
using Xunit.Abstractions;

namespace Challenge;

public class Tests(ITestOutputHelper testOutputHelper)
{
    private readonly ITestOutputHelper testOutputHelper = testOutputHelper;
    private readonly Solution sut = new();

    [Fact]
    public void SimpleCase()
    {
        sut.MinWindowSubstring(["qweetcs", "qwe"]).Should().Be("qwe");
    }

    [Fact]
    public void ComplexCase()
    {
        sut.MinWindowSubstring(["ahffaksfajeeubsne", "jefaa"]).Should().Be("aksfaje");
    }

    [Fact]
    public void ComplexCase2()
    {
        sut.MinWindowSubstring(["aaffhkksemckelloe", "fhea"]).Should().Be("affhkkse");
    }
    
    [Fact]
    public void ComplexCase3()
    {
        sut.MinWindowSubstring(["caae", "cae"]).Should().Be("caae");
    }
}