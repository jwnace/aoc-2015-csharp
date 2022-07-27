using System.Text.RegularExpressions;

namespace aoc_2015;

public static class Day12
{
    public static int Part1()
    {
        var input = File.ReadAllText("../../../../../input/day12.txt");
        var matches = Regex.Matches(input, @"[-]{0,1}\d+");
        return matches.Sum(x => int.Parse(x.Value));
    }

    public static int Part2()
    {
        var input = File.ReadAllText("../../../../../input/day12.txt");
        return 0;
    }
}
