namespace aoc_2015;

public static class Day02
{
    private static readonly string[] Input = File.ReadAllLines("../../../../../input/day02.txt");

    public static int Part1()
    {
        var result = 0;

        foreach (var line in Input)
        {
            var values = line.Split('x').Select(int.Parse).ToArray();
            var (l, w, h) = (values[0], values[1], values[2]);
            var (a, b, c) = (l * w, w * h, h * l);

            result += 2 * a + 2 * b + 2 * c + new[] { a, b, c }.Min();
        }

        return result;
    }

    public static int Part2()
    {
        var result = 0;

        foreach (var line in Input)
        {
            var values = line.Split('x').Select(int.Parse).OrderBy(x => x).ToArray();
            var (a, b, c) = (values[0], values[1], values[2]);
            var (p1, p2) = (a + a, b + b);

            result += p1 + p2 + a * b * c;
        }

        return result;
    }
}
