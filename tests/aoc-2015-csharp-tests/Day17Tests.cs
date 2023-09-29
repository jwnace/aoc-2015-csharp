using aoc_2015_csharp.Day17;

namespace aoc_2015_csharp_tests;

public class Day17Tests
{
    [Test]
    public void Part1()
    {
        Day17.Part1().Should().Be(1304);
    }

    [Test]
    public void Part2()
    {
        Day17.Part2().Should().Be(18);
    }
}
