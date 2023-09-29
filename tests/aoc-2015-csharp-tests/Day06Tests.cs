using aoc_2015_csharp.Day06;

namespace aoc_2015_csharp_tests;

public class Day06Tests
{
    [Test]
    public void Part1()
    {
        Day06.Part1().Should().Be(569999);
    }

    [Test]
    public void Part2()
    {
        Day06.Part2().Should().Be(17836115);
    }
}
