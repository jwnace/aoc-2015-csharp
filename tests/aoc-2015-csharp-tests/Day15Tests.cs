using aoc_2015_csharp.Day15;

namespace aoc_2015_csharp_tests;

public class Day15Tests
{
    [Test]
    public void Part1()
    {
        Day15.Part1().Should().Be(18965440);
    }

    [Test]
    public void Part2()
    {
        Day15.Part2().Should().Be(15862900);
    }
}
