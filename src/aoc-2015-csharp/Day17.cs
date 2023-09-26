namespace aoc_2015_csharp;

public static class Day17
{
    private record Container(string Name, int Size);

    public static int Part1()
    {
        var containers = File.ReadAllLines("../../../../../input/day17.txt")
            .OrderBy(int.Parse)
            // HACK: do I really need the name property? the combination logic depends on it for now...
            .Select((x, i) => new Container($"{(char)(65 + i)}", int.Parse(x)))
            .ToList();

        return GetCombinations(containers).Count(x => x.Sum(y => y.Size) == 150);
    }

    public static int Part2()
    {
        var containers = File.ReadAllLines("../../../../../input/day17.txt")
            .OrderBy(int.Parse)
            // HACK: do I really need the name property? the combination logic depends on it for now...
            .Select((x, i) => new Container($"{(char)(65 + i)}", int.Parse(x)))
            .ToList();

        var query = GetCombinations(containers)
            .Where(x => x.Sum(y => y.Size) == 150)
            .ToList();

        var minCount = query.Min(y => y.Count);

        return query.Count(x => x.Count == minCount);
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
                x => containers.Where(y => y.Name.CompareTo(x.Last().Name) > 0),
                (a, b) => a.Concat(new List<Container> { b }).ToList()
            ).ToList();
    }
}
