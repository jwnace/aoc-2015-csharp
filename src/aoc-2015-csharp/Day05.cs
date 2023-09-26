namespace aoc_2015_csharp;

public class Day05
{
    private static readonly string[] Input = File.ReadAllLines("../../../../../input/day05.txt");

    public static int Part1()
    {
        return Input.Count(IsNicePart1);
    }

    private static bool IsNicePart1(string s)
    {
        return ContainsThreeVowels(s) && ContainsRepeatedLetter(s) && DoesNotContainForbiddenSubstring(s);
    }

    private static bool ContainsThreeVowels(string s)
    {
        return s.Count(x => "aeiou".Contains(x)) >= 3;
    }

    private static bool ContainsRepeatedLetter(string s)
    {
        return s.Where((_, i) => i < s.Length - 1 && s[i] == s[i + 1]).Any();
    }

    private static bool DoesNotContainForbiddenSubstring(string s)
    {
        return !s.Contains("ab") && !s.Contains("cd") && !s.Contains("pq") && !s.Contains("xy");
    }

    public static int Part2()
    {
        return Input.Count(IsNicePart2);
    }

    private static bool IsNicePart2(string s)
    {
        return ContainsRepeatedPair(s) && ContainsThreeLetterAnagram(s);
    }

    private static bool ContainsRepeatedPair(string line)
    {
        for (var i = 0; i < line.Length - 3; i++)
        {
            var (a, b) = (line[i], line[i + 1]);

            for (var j = i + 2; j < line.Length - 1; j++)
            {
                var (c, d) = (line[j], line[j + 1]);

                if (a == c && b == d)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool ContainsThreeLetterAnagram(string line)
    {
        for (var i = 0; i < line.Length - 2; i++)
        {
            var (a, b) = (line[i], line[i + 2]);

            if (a == b)
            {
                return true;
            }
        }

        return false;
    }
}
