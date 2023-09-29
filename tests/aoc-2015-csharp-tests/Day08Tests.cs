using aoc_2015_csharp.Day08;

namespace aoc_2015_csharp_tests;

public class Day08Tests
{
    [Test]
    public void Part1()
    {
        Day08.Part1().Should().Be(1333);
    }

    [Test]
    public void Part2()
    {
        Day08.Part2().Should().Be(2046);
    }
}
