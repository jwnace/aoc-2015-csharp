namespace aoc_2015_csharp.Day01;

public static class Day01
{
    private static readonly string Input = File.ReadAllText("Day01/day01.txt");

    public static int Part1()
    {
        return Input.Sum(c => c == '(' ? 1 : -1);
    }

    public static int Part2()
    {
        return Input.Select((_, i) => new { index = i, position = Input[..i].Sum(x => x == '(' ? 1 : -1) })
            .First(y => y.position < 0).index;
    }
}
