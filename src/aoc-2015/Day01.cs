namespace aoc_2015;

public static class Day01
{
    private static readonly string Input = File.ReadAllText("../../../../../input/day01.txt");

    public static int Part1()
    {
        return Input.Sum(c => c == '(' ? 1 : -1);
    }

    public static int Part2()
    {
        return Input.Select((c, i) => new { index = i, position = Input[..i].Sum(x => x == '(' ? 1 : -1) })
            .First(y => y.position < 0).index;
    }
}
