namespace aoc_2015_csharp.Day20;

public static class Day20
{
    public static int Part1()
    {
        var input = int.Parse(File.ReadAllText("Day20/day20.txt"));

        // HACK: there has to be a sane way to speed this up...
        for (int i = 800000; i < int.MaxValue; i++)
        {
            var presents = GetPresents(i);

            if (presents >= input)
            {
                return i;
            }
        }

        return 0;
    }

    public static int Part2()
    {
        var input = int.Parse(File.ReadAllText("Day20/day20.txt"));

        // HACK: there has to be a sane way to speed this up...
        for (int i = 800000; i < int.MaxValue; i++)
        {
            var presents = GetPresentsPart2(i);

            if (presents >= input)
            {
                return i;
            }
        }

        return 0;
    }

    private static IEnumerable<int> GetFactors(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                yield return i;
            }
        }
    }

    private static int GetPresents(int i)
    {
        var factors = GetFactors(i);
        return factors.Sum(x => x * 10);
    }

    private static IEnumerable<int> GetFactorsPart2(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0 && number / i <= 50)
            {
                yield return i;
            }
        }
    }

    private static int GetPresentsPart2(int i)
    {
        var factors = GetFactorsPart2(i);
        return factors.Sum(x => x * 11);
    }
}
