using aoc_2015_csharp.Day01;

namespace aoc_2015_csharp_tests;

public class Day01Tests
{
    [Test]
    public void Part1()
    {
        Day01.Part1().Should().Be(280);
    }

    [Test]
    public void Part2()
    {
        Day01.Part2().Should().Be(1797);
    }
}
