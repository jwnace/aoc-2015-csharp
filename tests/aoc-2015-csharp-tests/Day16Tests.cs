using aoc_2015_csharp.Day16;

namespace aoc_2015_csharp_tests;

public class Day16Tests
{
    [Test]
    public void Part1()
    {
        Day16.Part1().Should().Be(103);
    }

    [Test]
    public void Part2()
    {
        Day16.Part2().Should().Be(405);
    }
}
