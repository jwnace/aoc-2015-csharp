using aoc_2015_csharp.Day22;

namespace aoc_2015_csharp_tests;

public class Day22Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day22.Part1().Should().Be(953);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day22.Part2().Should().Be(1289);
    }
}
