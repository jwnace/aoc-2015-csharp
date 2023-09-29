using aoc_2015_csharp.Day11;

namespace aoc_2015_csharp_tests;

public class Day11Tests
{
    [Test]
    public void Part1()
    {
        Day11.Part1().Should().Be("hxbxxyzz");
    }

    [Test]
    public void Part2()
    {
        Day11.Part2().Should().Be("hxcaabcc");
    }
}
