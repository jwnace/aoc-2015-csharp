using aoc_2015_csharp.Day07;

namespace aoc_2015_csharp_tests;

public class Day07Tests
{
    [Test]
    public void Part1()
    {
        Day07.Part1().Should().Be(46065);
    }

    [Test]
    public void Part2()
    {
        Day07.Part2().Should().Be(14134);
    }
}
