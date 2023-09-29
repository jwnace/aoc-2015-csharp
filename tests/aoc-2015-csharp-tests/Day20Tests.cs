using aoc_2015_csharp.Day20;

namespace aoc_2015_csharp_tests;

public class Day20Tests
{
    [Test]
    public void Part1()
    {
        Day20.Part1().Should().Be(831600);
    }

    [Test]
    public void Part2()
    {
        Day20.Part2().Should().Be(884520);
    }
}
