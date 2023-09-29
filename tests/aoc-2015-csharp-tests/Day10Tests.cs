using aoc_2015_csharp.Day10;

namespace aoc_2015_csharp_tests;

public class Day10Tests
{
    [Test]
    public void Part1()
    {
        Day10.Part1().Should().Be(329356);
    }

    [Test]
    public void Part2()
    {
        Day10.Part2().Should().Be(4666278);
    }
}
