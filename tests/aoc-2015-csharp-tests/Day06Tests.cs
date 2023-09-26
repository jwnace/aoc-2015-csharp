using aoc_2015_csharp;

namespace aoc_2015_csharp_tests;

public class Day06Tests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(569999, Day06.Part1());
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(17836115, Day06.Part2());
    }
}
