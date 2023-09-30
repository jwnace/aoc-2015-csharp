using aoc_2015_csharp.Day25;

namespace aoc_2015_csharp_tests;

public class Day25Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day25.Part1().Should().Be(9132360);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day25.Part2().Should().Be("Merry Christmas!");
    }
}
