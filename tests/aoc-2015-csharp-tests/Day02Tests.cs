using aoc_2015_csharp.Day02;

namespace aoc_2015_csharp_tests;

public class Day02Tests
{
    [Test]
    public void Part1()
    {
        Day02.Part1().Should().Be(1586300);
    }

    [Test]
    public void Part2()
    {
        Day02.Part2().Should().Be(3737498);
    }
}
