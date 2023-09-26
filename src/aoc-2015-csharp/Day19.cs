using System.Text.RegularExpressions;

namespace aoc_2015_csharp;

public static class Day19
{
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day19.txt");
        var replacements = new List<(string, string)>();

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var values = line.Split(" => ");

            replacements.Add((values[0], values[1]));
        }

        var molecule = input.Last();

        return DoReplacements(molecule, replacements).Distinct().Count();
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day19.txt");
        var replacements = new List<(string, string)>();

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var values = line.Split(" => ");

            replacements.Add((values[0], values[1]));
        }

        var molecule = input.Last();
        var step = 0;

        while (molecule != "e")
        {
            foreach (var replacement in replacements)
            {
                if (molecule.Contains(replacement.Item2))
                {
                    Regex regex = new Regex(replacement.Item2);
                    molecule = regex.Replace(molecule, replacement.Item1, 1);
                    step++;
                }
            }
        }

        return step;
    }

    private static IEnumerable<string> DoReplacements(string molecule, List<(string, string)> replacements)
    {
        foreach (var replacement in replacements)
        {
            var matches = Regex.Matches(molecule, replacement.Item1).ToList();

            foreach (var match in matches)
            {
                yield return molecule.Substring(0, match.Index) +
                             replacement.Item2 +
                             molecule.Substring(match.Index + replacement.Item1.Length);
            }
        }
    }
}
