using aoc_2015_csharp.Day24;

namespace aoc_2015_csharp_tests;

public class Day24Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day24.Part1().Should().Be(11846773891);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day24.Part2().Should().Be(80393059);
    }
}
