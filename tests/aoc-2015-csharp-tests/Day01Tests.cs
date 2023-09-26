using aoc_2015_csharp.Day01;

namespace aoc_2015_csharp_tests;

public class Day01Tests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(280, Day01.Part1());
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(1797, Day01.Part2());
    }
}
