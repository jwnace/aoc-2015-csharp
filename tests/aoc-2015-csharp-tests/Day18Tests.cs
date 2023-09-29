using aoc_2015_csharp.Day18;

namespace aoc_2015_csharp_tests;

public class Day18Tests
{
    [Test]
    public void Part1()
    {
        Day18.Part1().Should().Be(814);
    }

    [Test]
    public void Part2()
    {
        Day18.Part2().Should().Be(924);
    }
}
