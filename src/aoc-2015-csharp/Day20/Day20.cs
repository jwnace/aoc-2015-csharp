namespace aoc_2015_csharp.Day20;

public static class Day20
{
    private static readonly int Input = int.Parse(File.ReadAllText("Day20/day20.txt"));

    public static int Part1() => Solve(10);

    public static int Part2() => Solve(11, 50);

    private static int Solve(int presentsPerElf, int housesPerElf = 0)
    {
        var max = Input / 20;
        var houses = new int[max];

        for (var elf = 1; elf < max; elf++)
        {
            for (var house = elf; house < max; house += elf)
            {
                if (housesPerElf > 0 && elf * housesPerElf < house)
                {
                    break;
                }

                houses[house] += elf * presentsPerElf;
            }
        }

        return houses.Select((presents, index) => (presents, index)).First(x => x.presents >= Input).index;
    }
}
