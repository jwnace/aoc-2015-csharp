namespace aoc_2015;

public static class Day03
{
    private static readonly string Input = File.ReadAllText("../../../../../input/day03.txt");

    public static int Part1()
    {
        var memo = new Dictionary<(int x, int y), int> { [(0, 0)] = 1 };
        var position = (x: 0, y: 0);

        foreach (var c in Input)
        {
            position = c switch
            {
                '^' => (position.x, position.y + 1),
                'v' => (position.x, position.y - 1),
                '>' => (position.x + 1, position.y),
                '<' => (position.x - 1, position.y),
                _ => throw new ArgumentOutOfRangeException()
            };

            memo[position] = memo.ContainsKey(position) ? memo[position]++ : 1;
        }

        return memo.Count;
    }

    public static int Part2()
    {
        var memo = new Dictionary<(int x, int y), int> { [(0, 0)] = 1 };
        var positions = new[] { (x: 0, y: 0), (x: 0, y: 0) };

        for (var i = 0; i < Input.Length; i++)
        {
            var index = i % 2 == 0 ? 0 : 1;

            positions[index] = Input[i] switch
            {
                '^' => (positions[index].x, positions[index].y + 1),
                'v' => (positions[index].x, positions[index].y - 1),
                '>' => (positions[index].x + 1, positions[index].y),
                '<' => (positions[index].x - 1, positions[index].y),
                _ => throw new ArgumentOutOfRangeException()
            };

            memo[positions[index]] = memo.ContainsKey(positions[index]) ? memo[positions[index]]++ : 1;
        }

        return memo.Count;
    }
}
