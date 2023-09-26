using aoc_2015_csharp.Day04;

namespace aoc_2015_csharp_tests;

public class Day04Tests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(346386, Day04.Part1());
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(9958218, Day04.Part2());
    }
}
