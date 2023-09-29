using aoc_2015_csharp.Day19;

namespace aoc_2015_csharp_tests;

public class Day19Tests
{
    [Test]
    public void Part1()
    {
        Day19.Part1().Should().Be(509);
    }

    [Test]
    public void Part2()
    {
        Day19.Part2().Should().Be(195);
    }
}
