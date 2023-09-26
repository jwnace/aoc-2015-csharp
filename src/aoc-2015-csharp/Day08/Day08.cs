using System.Text.RegularExpressions;

namespace aoc_2015_csharp.Day08;

public static class Day08
{
    private static readonly string[] Input = File.ReadAllLines("Day08/day08.txt");

    public static int Part1() => GetCodeLength() - GetMemoryLength(Input);

    public static int Part2() => GetEncodedLength(Input) - GetCodeLength();

    private static int GetCodeLength() => Input.Sum(x => x.Length);

    private static int GetMemoryLength(string[] strings)
    {
        return strings
            .Select(x => x.Replace("\\\\", "_"))
            .Select(x => x.Replace("\\\"", "_"))
            .Select(x => Regex.Replace(x, @"\\x[0-9a-z][0-9a-z]", "_"))
            .Sum(x => x.Length - 2);
    }

    private static int GetEncodedLength(string[] strings)
    {
        return strings
            .Select(x => x.Replace("\\", "\\\\"))
            .Select(x => x.Replace("\"", "\\\""))
            .Sum(x => x.Length + 2);
    }
}
