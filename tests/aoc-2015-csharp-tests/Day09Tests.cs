using aoc_2015_csharp.Day09;

namespace aoc_2015_csharp_tests;

public class Day09Tests
{
    [Test]
    public void Part1()
    {
        Day09.Part1().Should().Be(251);
    }

    [Test]
    public void Part2()
    {
        Day09.Part2().Should().Be(898);
    }
}
