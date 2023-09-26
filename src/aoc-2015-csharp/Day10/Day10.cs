using System.Diagnostics;
using System.Text.RegularExpressions;

namespace aoc_2015_csharp.Day10;

public static class Day10
{
    public static int Part1()
    {
        var input = File.ReadAllText("Day10/day10.txt");
        var temp = input;

        var t = new Stopwatch();
        t.Start();
        for (int i = 0; i < 40; i++)
        {
            temp = SayWithRegex(temp);
        }

        t.Stop();
        Console.WriteLine($"{nameof(SayWithRegex)} took {t.Elapsed.TotalSeconds}");

        return temp.Length;
    }

    public static int Part2()
    {
        var input = File.ReadAllText("Day10/day10.txt");
        var temp = input;

        var t = new Stopwatch();
        t.Start();
        for (int i = 0; i < 50; i++)
        {
            temp = SayWithRegex(temp);
        }

        t.Stop();
        Console.WriteLine($"{nameof(SayWithRegex)} took {t.Elapsed.TotalSeconds}");

        return temp.Length;
    }

    private static string SayWithRegex(string input)
    {
        var matches = Regex.Matches(input, @"(\d)\1*");
        return string.Concat(matches.Select(x => x.Value.Length.ToString() + x.Value[0]));

        // TODO: figure out why this is way faster than my own implementation
        // var captures = Regex.Match(input, @"((.)\2*)+").Groups[1].Captures;
        //
        // var temp = string.Concat(
        //     captures
        //         .Select(capture => new { capture, capture.Value })
        //         .Select(x => x.Value.Length + x.Value.Substring(0, 1))
        // );
        //
        // return temp;
    }
}
