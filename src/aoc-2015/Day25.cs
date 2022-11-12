using System.Diagnostics;

namespace aoc_2015;

public static class Day25
{
    private static readonly ulong Row = 2981;
    private static readonly ulong Col = 3075;
    private static readonly ulong StartingCode = 20151125;

    public static string Part1()
    {
        var code = GetCode(Row, Col);
        return code.ToString();
    }

    public static string Part2()
    {
        return "";
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

    private static ulong GetColumnOneValue(ulong row)
    {
        if (row == 1)
        {
            return 1;
        }

        return GetColumnOneValue(row - 1) + (row - 1);
    }

    private static ulong GetIndex(ulong row, ulong col)
    {
        if (col == 1)
        {
            return GetColumnOneValue(row);
        }

        return GetIndex(row, col - 1) + (row + col - 1);
    }
}
