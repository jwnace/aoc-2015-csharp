using System.Security.AccessControl;

namespace aoc_2015;

public static class Day17
{
    private record Container(int Size);
    
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day17.txt")
            .Select(x => new Container(int.Parse(x)))
            .ToList();

        // var temp = new List<int> { 1, 2, 3 };
        // var combinations = input.GetKCombs(input.Count - 1).ToList();

        return 0;
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day17.txt");
        return 0;
    }
}
