using aoc_2015_csharp.Day21;

namespace aoc_2015_csharp_tests;

public class Day21Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day21.Part1().Should().Be(91);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day21.Part2().Should().Be(158);
    }
}
