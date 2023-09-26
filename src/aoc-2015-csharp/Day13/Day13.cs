namespace aoc_2015_csharp.Day13;

public static class Day13
{
    public static int Part1()
    {
        var input = File.ReadAllLines("Day13/day13.txt");

        var pairings = input
            .Select(x => x.Replace("lose ", "-"))
            .Select(x => x.Replace("gain ", ""))
            .Select(x => x.Replace(".", ""))
            .Select(x => x.Split(" "))
            .Select(x => new Pairing(new[] { x[0], x[9] }, int.Parse(x[2])))
            .ToArray();

        var people = pairings.SelectMany(x => x.People).Distinct().ToArray();

        // TODO: refactor this to use Combinations instead of Permutations since the order doesn't matter
        var permutations = GetPermutations(people).ToArray();

        var maxHappiness = 0;

        foreach (var permutation in permutations)
        {
            var happiness = CalculateHappiness(permutation, pairings);

            if (happiness > maxHappiness)
            {
                maxHappiness = happiness;
            }
        }

        return maxHappiness;
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("Day13/day13.txt");

        var pairings = input
            .Select(x => x.Replace("lose ", "-"))
            .Select(x => x.Replace("gain ", ""))
            .Select(x => x.Replace(".", ""))
            .Select(x => x.Split(" "))
            .Select(x => new Pairing(new[] { x[0], x[9] }, int.Parse(x[2])))
            .ToList();

        var people = pairings.SelectMany(x => x.People).Distinct().ToList();
        people.Add("Joe");

        foreach (var person in people)
        {
            if (person == "Joe")
            {
                continue;
            }

            pairings.Add(new Pairing(new[] { "Joe", person }, 0));
        }

        // TODO: refactor this to use Combinations instead of Permutations since the order doesn't matter
        var permutations = GetPermutations(people.ToArray()).ToArray();

        var maxHappiness = 0;

        foreach (var permutation in permutations)
        {
            var happiness = CalculateHappiness(permutation, pairings.ToArray());

            if (happiness > maxHappiness)
            {
                maxHappiness = happiness;
            }
        }

        return maxHappiness;
    }

    private record Pairing(string[] People, int Happiness);

    private static IEnumerable<T[]> GetPermutations<T>(T[] values)
    {
        if (values.Length == 1)
            return new[] { values };

        return values.SelectMany(v => GetPermutations(values.Except(new[] { v }).ToArray()),
            (v, p) => new[] { v }.Concat(p).ToArray());
    }

    private static int CalculateHappiness(string[] permutation, Pairing[] pairings)
    {
        var sum = 0;

        for (int i = 0; i < permutation.Length; i++)
        {
            var a = permutation[i];
            var b = i == permutation.Length - 1 ? permutation[0] : permutation[i + 1];

            sum += pairings.Where(x => x.People.Contains(a) && x.People.Contains(b)).Sum(x => x.Happiness);
        }

        return sum;
    }
}
