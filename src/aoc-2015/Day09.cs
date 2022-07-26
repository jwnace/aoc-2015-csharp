namespace aoc_2015;

public class Day09
{
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day09_sm.txt");
        var distances = new Dictionary<string[], int>();

        foreach (var line in input)
        {
            var values = line.Split(' ');
            var start = values[0];
            var end = values[2];
            var dist = int.Parse(values[4]);

            distances[new[] { start, end }] = dist;
        }

        var locations = distances.SelectMany(x => x.Key).Distinct().ToDictionary(x => x, _ => false).ToList();
        var minDistance = int.MaxValue;
        
        foreach (var start in locations)
        {
            // HACK: make a copy of `memo` and `locations` every time we travel
            var distance = Travel(new Dictionary<string[], int>(distances), new Dictionary<string, bool>(locations), start.Key);

            Console.WriteLine($"distance: {distance}");
            
            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }

        return minDistance;
    }

    private static int Travel(Dictionary<string[],int> memo, Dictionary<string, bool> visits, string start)
    {
        visits[start] = true;
        
        if (visits.All(x => x.Value))
        {
            return 0;
        }
        
        var next = memo
            .Where(x => x.Key.Contains(start))
            .Select(x => new
            {
                Location = x.Key.Single(y => y != start),
                Distance = x.Value
            })
            .Where(x => visits[x.Location] == false)
            .ToList();

        if (next.Count() != 1)
        {
            Console.WriteLine($"next.Count() = {next.Count()}");
        }
        
        var distances = new List<int>();
        
        foreach (var n in next)
        {
            distances.Add(n.Distance + Travel(memo, visits, n.Location));
        }

        return distances.Min();
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day09_sm.txt");
        return input.Length;
    }
}