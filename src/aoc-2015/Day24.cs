using System.Diagnostics;

namespace aoc_2015;

public static class Day24
{
    // divide the packages into three groups of equal WEIGHT

    // the first group needs to have as few packages as possible

    // the first group needs to have the smallest quantum entanglement

    // the quantum entanglement of a group of packages is the product of their weights

    // Only consider quantum entanglement if the first group has the fewest possible number of packages in it and all groups weigh the same amount.

    public static long Part1()
    {
        var weights = File.ReadAllLines("../../../../../input/day24.txt").Select(long.Parse).ToList();
        var goalWeight = GetGoalWeight(weights);
        // var largestGroupSize = GetLargestGroupSize(weights, goalWeight);
        // var smallestGroupSize = GetSmallestGroupSize(weights, goalWeight);

        var smallestGroupSize = 6;
        var largestGroupSize = smallestGroupSize;
        
        var validCombinations = GetValidCombinations(weights, goalWeight, smallestGroupSize, largestGroupSize)
            .Select(x => new PackageGroup(x, x.Sum(y => y), x.Product())).ToList();

        return validCombinations.Min(x => x.QuantumEntanglement);
        
        // HACK: this will throw an exception if any of the combinations have duplicate QuantumEntanglement values
        var foo = validCombinations.GroupBy(x => x.QuantumEntanglement).ToDictionary(g => g.Key, g => g.Count());

        var possibleGroupings = validCombinations.GetCombinations(3);

        // get all of the groupings that contain all of the packages
        var bar = possibleGroupings.Where(g =>
            g.ElementAt(0).Weights.Concat(g.ElementAt(1).Weights.Concat(g.ElementAt(2).Weights)).OrderBy(x => x).SequenceEqual(weights)
        ).ToList();

        var min = bar.Min(x => x.Min(g => g.Weights.Count()));
        var max = bar.Max(x => x.Max(g => g.Weights.Count()));
        var query = bar.Where(x => x.Min(g => g.Weights.Count()) == min).ToList();

        var minQuantumEntanglement = query.Min(x => x.Min(g => g.QuantumEntanglement));
        var fuck = query.Where(x => x.Min(g => g.QuantumEntanglement) == minQuantumEntanglement).ToList();

        return minQuantumEntanglement;
    }

    private static int GetLargestGroupSize(List<int> weights, int goalWeight)
    {
        var count = 1;
        var sum = 0;

        foreach (var weight in weights)
        {
            sum += weight;

            if (sum >= goalWeight)
            {
                break;
            }

            count++;
        }

        return count;
    }

    private static int GetSmallestGroupSize(List<int> weights, int goalWeight)
    {
        var count = 1;
        var sum = 0;

        foreach (var weight in weights.OrderByDescending(x => x))
        {
            sum += weight;

            if (sum >= goalWeight)
            {
                break;
            }

            count++;
        }

        return count;
    }

    public static long Part2()
    {
        var weights = File.ReadAllLines("../../../../../input/day24.txt").Select(long.Parse).ToList();
        var goalWeight = GetGoalWeightForPart2(weights);

        var smallestGroupSize = 4;
        var largestGroupSize = smallestGroupSize;
        
        var validCombinations = GetValidCombinations(weights, goalWeight, smallestGroupSize, largestGroupSize)
            .Select(x => new PackageGroup(x, x.Sum(y => y), x.Product())).ToList();

        return validCombinations.Min(x => x.QuantumEntanglement);
    }

    private static long GetGoalWeight(List<long> weights)
    {
        var totalWeight = weights.Sum(x => x);

        if (totalWeight % 3 != 0)
        {
            throw new InvalidOperationException($"Invalid total weight: {totalWeight}");
        }

        var goalWeight = totalWeight / 3;
        return goalWeight;
    }
    
    private static long GetGoalWeightForPart2(List<long> weights)
    {
        var totalWeight = weights.Sum(x => x);

        if (totalWeight % 4 != 0)
        {
            throw new InvalidOperationException($"Invalid total weight: {totalWeight}");
        }

        var goalWeight = totalWeight / 4;
        return goalWeight;
    }

    private static List<List<long>> GetValidCombinations(List<long> weights, long goalWeight, int smallestGroupSize, int largestGroupSize)
    {
        var validCombinations = new List<List<long>>();

        for (var i = smallestGroupSize; i <= largestGroupSize; i++)
        {
            Console.WriteLine($"Getting combinations of length {i}...");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var combinations = weights.GetCombinations(i)
                .Where(x => x.Sum(y => y) == goalWeight)
                .Select(x => x.ToList())
                .ToList();

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed}");

            validCombinations.AddRange(combinations);
        }

        return validCombinations;
    }

    private static long Product(this IEnumerable<long> collection) => collection.Aggregate((a, b) => a * b);

    private static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> enumerable, int length) where T : IComparable
    {
        // if (length == 0)
        // {
        // return new List<List<T>> { new() };
        // }

        if (length == 1)
        {
            return enumerable.Select(x => new[] { x });
        }

        // var list = enumerable.ToList();

        return GetCombinations(enumerable, length - 1)
            .SelectMany(x =>
                    enumerable.Where(y => y.CompareTo(x.Last()) > 0),
                (a, b) => a.Concat(new[] { b }).ToList()
            );
    }

    private record PackageGroup(List<long> Weights, long TotalWeight, long QuantumEntanglement) : IComparable
    {
        public int CompareTo(object? obj)
        {
            var difference = this.QuantumEntanglement - (obj as PackageGroup)!.QuantumEntanglement;

            return difference switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
        }
    }
}
