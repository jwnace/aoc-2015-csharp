using aoc_2015_csharp.Day13;

namespace aoc_2015_csharp_tests;

public class Day13Tests
{
    [Test]
    public void Part1()
    {
        Day13.Part1().Should().Be(733);
    }

    [Test]
    public void Part2()
    {
        Day13.Part2().Should().Be(725);
    }
}
