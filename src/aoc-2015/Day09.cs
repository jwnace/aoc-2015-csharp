using System.Linq;

namespace aoc_2015;

public class Day09
{
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day09.txt");
        var distances = new Dictionary<string[], int>();
        var locations = new Dictionary<string, bool>();

        foreach (var line in input)
        {
            var values = line.Split(' ');
            var start = values[0];
            var end = values[2];
            var dist = int.Parse(values[4]);

            distances[new[] { start, end }] = dist;
            locations[start] = false;
            locations[end] = false;
        }

        var paths = GetPermutations(locations.ToArray()).ToList();

        var minDistance = int.MaxValue;
        
        foreach (var path in paths)
        {
            var distance = 0;
            
            for (int i = 0; i < path.Length - 1; i++)
            {
                var d = distances
                    .Where(x => x.Key.Contains(path[i].Key) && x.Key.Contains(path[i + 1].Key))
                    .Select(x => x.Value)
                    .Single();
                
                distance += d;
            }

            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }
        
        return minDistance;
    }
    
    private static IEnumerable<T[]> GetPermutations<T>(T[] values)
    {
        if (values.Length == 1)
            return new[] {values};

        return values.SelectMany(v => GetPermutations(values.Except(new[] {v}).ToArray()),
            (v, p) => new[] {v}.Concat(p).ToArray());
    }
    

    public static int Part2()
    {var input = File.ReadAllLines("../../../../../input/day09.txt");
        var distances = new Dictionary<string[], int>();
        var locations = new Dictionary<string, bool>();

        foreach (var line in input)
        {
            var values = line.Split(' ');
            var start = values[0];
            var end = values[2];
            var dist = int.Parse(values[4]);

            distances[new[] { start, end }] = dist;
            locations[start] = false;
            locations[end] = false;
        }

        var paths = GetPermutations(locations.ToArray()).ToList();

        var maxDistance = 0;
        
        foreach (var path in paths)
        {
            var distance = 0;
            
            for (int i = 0; i < path.Length - 1; i++)
            {
                var d = distances
                    .Where(x => x.Key.Contains(path[i].Key) && x.Key.Contains(path[i + 1].Key))
                    .Select(x => x.Value)
                    .Single();
                
                distance += d;
            }

            if (distance > maxDistance)
            {
                maxDistance = distance;
            }
        }
        
        return maxDistance;
    }
}