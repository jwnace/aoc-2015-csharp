using aoc_2015_csharp.Day05;

namespace aoc_2015_csharp_tests;

public class Day05Tests
{
    [Test]
    public void Part1()
    {
        Day05.Part1().Should().Be(255);
    }

    [Test]
    public void Part2()
    {
        Day05.Part2().Should().Be(55);
    }
}
