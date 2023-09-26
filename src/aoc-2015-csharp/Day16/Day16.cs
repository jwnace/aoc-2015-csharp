namespace aoc_2015_csharp.Day16;

public static class Day16
{
    private class Sue
    {
        public int Id { get; init; }
        public Dictionary<string, int> Properties { get; init; } = new();
    }

    public static int Part1()
    {
        var input = File.ReadAllLines("Day16/day16.txt");

        var sues = new List<Sue>();

        foreach (var line in input)
        {
            var values = line.Split(' ');

            var sue = new Sue
            {
                Id = int.Parse(values[1].Trim(':')),
                Properties = new Dictionary<string, int>
                {
                    { values[2].Trim(':'), int.Parse(values[3].Trim(',')) },
                    { values[4].Trim(':'), int.Parse(values[5].Trim(',')) },
                    { values[6].Trim(':'), int.Parse(values[7].Trim(',')) }
                }
            };

            sues.Add(sue);
        }

        var expected = new Sue
        {
            Id = 0,
            Properties = new Dictionary<string, int>
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 },
            }
        };

        return sues.First(actual =>
                actual.Properties.All(a =>
                    expected.Properties.ContainsKey(a.Key) && expected.Properties[a.Key] == a.Value))
            .Id;
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("Day16/day16.txt");

        var sues = new List<Sue>();

        foreach (var line in input)
        {
            var values = line.Split(' ');

            var sue = new Sue
            {
                Id = int.Parse(values[1].Trim(':')),
                Properties = new Dictionary<string, int>
                {
                    { values[2].Trim(':'), int.Parse(values[3].Trim(',')) },
                    { values[4].Trim(':'), int.Parse(values[5].Trim(',')) },
                    { values[6].Trim(':'), int.Parse(values[7].Trim(',')) }
                }
            };

            sues.Add(sue);
        }

        var expected = new Sue
        {
            Id = 0,
            Properties = new Dictionary<string, int>
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 },
            }
        };

        return sues.First(x => IsMatch(expected, x)).Id;
    }

    private static bool IsMatch(Sue expected, Sue actual)
    {
        foreach (var property in actual.Properties)
        {
            if (property.Key is "cats" or "trees")
            {
                // there are greater than that many
                if (property.Value <= expected.Properties[property.Key])
                {
                    return false;
                }
            }
            else if (property.Key is "pomeranians" or "goldfish")
            {
                // there are fewer than that many
                if (property.Value >= expected.Properties[property.Key])
                {
                    return false;
                }
            }
            else
            {
                // there are exactly that many
                if (property.Value != expected.Properties[property.Key])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
