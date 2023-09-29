using aoc_2015_csharp.Day03;

namespace aoc_2015_csharp_tests;

public class Day03Tests
{
    [Test]
    public void Part1()
    {
        Day03.Part1().Should().Be(2081);
    }

    [Test]
    public void Part2()
    {
        Day03.Part2().Should().Be(2341);
    }
}
