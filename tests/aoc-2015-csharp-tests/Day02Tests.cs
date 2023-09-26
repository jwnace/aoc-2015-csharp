using aoc_2015_csharp.Day02;

namespace aoc_2015_csharp_tests;

public class Day02Tests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(1586300, Day02.Part1());
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(3737498, Day02.Part2());
    }
}
