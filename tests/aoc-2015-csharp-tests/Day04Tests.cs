using aoc_2015_csharp.Day04;

namespace aoc_2015_csharp_tests;

public class Day04Tests
{
    [Test]
    public void Part1()
    {
        Day04.Part1().Should().Be(346386);
    }

    [Test]
    public void Part2()
    {
        Day04.Part2().Should().Be(9958218);
    }
}
