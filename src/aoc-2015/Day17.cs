using System.Diagnostics;

namespace aoc_2015;

public static class Day17
{
    private static readonly int TARGET_SIZE = 150;

    private record Container(string Name, int Size);

    public static int Part1()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var containers = File.ReadAllLines("../../../../../input/day17.txt")
            .OrderBy(int.Parse)
            .Select((x, i) => new Container($"{(char) (65 + i)}", int.Parse(x)))
            .ToList();

        stopwatch.Stop();
        Console.WriteLine($"Parsing the input took {stopwatch.Elapsed.TotalSeconds} seconds.");
        stopwatch.Reset();

        stopwatch.Start();

        var combinations = GetCombinations(containers);

        stopwatch.Stop();
        Console.WriteLine($"GetCombinations() took {stopwatch.Elapsed.TotalSeconds} seconds.");
        stopwatch.Reset();

        stopwatch.Start();

        var query = combinations.Where(x => x.Sum(y => y.Size) == TARGET_SIZE).ToList();

        stopwatch.Stop();
        Console.WriteLine($"The query took {stopwatch.Elapsed.TotalSeconds} seconds.");
        stopwatch.Reset();

        return query.Count();
    }

    public static int Part2()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var containers = File.ReadAllLines("../../../../../input/day17.txt")
            .OrderBy(int.Parse)
            .Select((x, i) => new Container($"{(char) (65 + i)}", int.Parse(x)))
            .ToList();

        stopwatch.Stop();
        Console.WriteLine($"Parsing the input took {stopwatch.Elapsed.TotalSeconds} seconds.");
        stopwatch.Reset();

        stopwatch.Start();

        var combinations = GetCombinations(containers);

        stopwatch.Stop();
        Console.WriteLine($"GetCombinations() took {stopwatch.Elapsed.TotalSeconds} seconds.");
        stopwatch.Reset();

        stopwatch.Start();

        var query = combinations
            .Where(x => x.Sum(y => y.Size) == TARGET_SIZE)
            .ToList();

        var minCount = query.Min(y => y.Count);

        var result = query.Where(x => x.Count == minCount).ToList();

        stopwatch.Stop();
        Console.WriteLine($"The query took {stopwatch.Elapsed.TotalSeconds} seconds.");
        stopwatch.Reset();

        return result.Count();
    }

    private static List<List<Container>> GetCombinations(List<Container> containers)
    {
        List<List<Container>> combinations = null;

        for (int i = 1; i <= containers.Count(); i++)
        {
            var temp = GetCombinations(containers, i);
            combinations = combinations == null ? temp : combinations.Concat(temp).ToList();
        }

        return combinations;
    }

    private static List<List<Container>> GetCombinations(List<Container> containers, int length)
    {
        if (length == 1)
        {
            return containers.Select(x => new List<Container> { x }).ToList();
        }

        return GetCombinations(containers, length - 1)
            .SelectMany(
                x => containers.Where(c => c.Name.CompareTo(x.Last().Name) > 0),
                (t1, t2) => t1.Concat(new List<Container> { t2 }).ToList()
            ).ToList();
    }
}
