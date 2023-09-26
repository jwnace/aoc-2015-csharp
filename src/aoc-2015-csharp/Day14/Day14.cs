namespace aoc_2015_csharp.Day14;

public static class Day14
{
    private record Reindeer
    {
        public string Name { get; init; } = "";
        public int Speed { get; init; }
        public int FlyTime { get; init; }
        public int RestTime { get; init; }

        public int Fly(int seconds)
        {
            var cycleTime = FlyTime + RestTime;
            var completedCycles = seconds / cycleTime;
            var remainder = seconds % cycleTime;
            remainder = remainder <= FlyTime ? remainder : FlyTime;

            var d1 = completedCycles * Speed * FlyTime;
            var d2 = remainder * Speed;

            return d1 + d2;
        }
    }

    public static int Part1()
    {
        var input = File.ReadAllLines("Day14/day14.txt");

        var reindeers = input.Select(x => x.Split(" "))
            .Select(x => new Reindeer
            {
                Name = x[0],
                Speed = int.Parse(x[3]),
                FlyTime = int.Parse(x[6]),
                RestTime = int.Parse(x[13])
            })
            .Select(x => new { x.Name, Distance = x.Fly(2503) })
            .ToList();

        return reindeers.Max(x => x.Distance);
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("Day14/day14.txt");
        var scores = new Dictionary<string, int>();

        var reindeers = input.Select(x => x.Split(" "))
            .Select(x => new Reindeer
            {
                Name = x[0],
                Speed = int.Parse(x[3]),
                FlyTime = int.Parse(x[6]),
                RestTime = int.Parse(x[13])
            })
            .ToList();

        for (var i = 1; i <= 2503; i++)
        {
            var sim = reindeers.Select(x => new { x.Name, Distance = x.Fly(i) }).ToList();
            var max = sim.Max(x => x.Distance);
            var leaders = sim.Where(x => x.Distance == max).ToList();

            foreach (var leader in leaders)
            {
                scores[leader.Name] = scores.TryGetValue(leader.Name, out var score) ? score + 1 : 1;
            }
        }

        return scores.Values.Max();
    }
}
