using aoc_2015_csharp.Day12;

namespace aoc_2015_csharp_tests;

public class Day12Tests
{
    [Test]
    public void Part1()
    {
        Day12.Part1().Should().Be(191164);
    }

    [Test]
    public void Part2()
    {
        Day12.Part2().Should().Be(87842);
    }
}
