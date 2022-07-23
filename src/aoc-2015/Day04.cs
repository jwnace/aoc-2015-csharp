using System.Security.Cryptography;
using System.Text;

namespace aoc_2015;

public static class Day04
{
    private static readonly string Input = File.ReadAllText("../../../../../input/day04.txt");

    public static int Part1()
    {
        for (int i = 1; i < int.MaxValue; i++)
        {
            var value = $"{Input}{i}";
            var hashString = CreateMD5(value);

            if (hashString.StartsWith("00000"))
            {
                return i;
            }
        }

        return 0;
    }

    public static int Part2()
    {
        for (int i = 1; i < int.MaxValue; i++)
        {
            var value = $"{Input}{i}";
            var hashString = CreateMD5(value);

            if (hashString.StartsWith("000000"))
            {
                return i;
            }
        }

        return 0;
    }

    private static string CreateMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
