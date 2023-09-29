using aoc_2015_csharp.Day14;

namespace aoc_2015_csharp_tests;

public class Day14Tests
{
    [Test]
    public void Part1()
    {
        Day14.Part1().Should().Be(2696);
    }

    [Test]
    public void Part2()
    {
        Day14.Part2().Should().Be(1084);
    }
}
