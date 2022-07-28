using System.Text.RegularExpressions;

namespace aoc_2015;

public static class Day11
{
    public static string Part1()
    {
        var input = File.ReadAllText("../../../../../input/day11.txt");
        return GetNextPassword(input);
    }
    
    public static string Part2()
    {
        var input = File.ReadAllText("../../../../../input/day11.txt");
        return GetNextPassword(GetNextPassword(input));
    }

    private static string GetNextPassword(string password)
    {
        while (true)
        {
            password = Increment(password);

            if (IsValid(password))
            {
                return password;
            }
        }
    }
    
    private static bool IsValid(string password)
    {
        // must contain one increasing straight of 3+ letters
        var straights = new string[]
        {
            "abc", "bcd", "cde", "def", "efg", "fgh", "pqr", "qrs", 
            "rst", "stu", "tuv", "uvw", "vwx", "wxy", "xyz"
        };

        if (!straights.Any(x => password.Contains(x)))
        {
            return false;
        }

        // must not contain the letters `i`, `o`, or `l`
        var bannedLetters = new string[] { "i", "o", "l" };

        if (bannedLetters.Any(x => password.Contains(x)))
        {
            return false;
        }
        
        // must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz
        var matches = Regex.Matches(password, @"(.)\1{1}");
        
        if (matches.Count() < 2)
        {
            return false;
        }

        return true;
    }

    private static string Increment(string password)
    {
        var c = (char)(password[^1] + 1);

        var temp = "";

        if (c > 'z')
        {
            c = 'a';

            temp = Increment(password.Substring(0, password.Length - 1));
        }

        return (temp != "" ? temp : password.Substring(0, password.Length - 1)) + c;
    }
}
