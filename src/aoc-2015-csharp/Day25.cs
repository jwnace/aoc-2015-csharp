namespace aoc_2015_csharp;

public static class Day25
{
    private const ulong Row = 2981;
    private const ulong Col = 3075;
    private const ulong StartingCode = 20151125;

    public static ulong Part1()
    {
        return GetCode(Row, Col);
    }

    public static string Part2()
    {
        return "Merry Christmas!";
    }

    private static ulong GetIndex(ulong row, ulong col)
    {
        if (col == 1)
        {
            return GetColumnOneIndex(row);
        }

        return GetIndex(row, col - 1) + (row + col - 1);
    }

    private static ulong GetColumnOneIndex(ulong row)
    {
        if (row == 1)
        {
            return 1;
        }

        return GetColumnOneIndex(row - 1) + (row - 1);
    }

    private static ulong GetCode(ulong row, ulong col)
    {
        var index = GetIndex(row, col);
        return GetCode(index);
    }

    private static ulong GetCode(ulong index)
    {
        var code = StartingCode;

        for (ulong i = 1; i < index; i++)
        {
            code = code * 252533 % 33554393;
        }

        return code;
    }
}
