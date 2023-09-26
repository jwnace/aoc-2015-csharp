using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace aoc_2015_csharp.Day12;

public static class Day12
{
    public static int Part1()
    {
        var input = File.ReadAllText("Day12/day12.txt");
        return GetSum(input);
    }

    public static int Part2()
    {
        var input = File.ReadAllText("Day12/day12.txt");
        var filtered = FilterInput(input);
        return GetSum(filtered);
    }

    private static int GetSum(string json)
    {
        var matches = Regex.Matches(json, @"[-]{0,1}\d+");
        return matches.Sum(x => int.Parse(x.Value));
    }

    private static string FilterInput(string input)
    {
        var root = JsonConvert.DeserializeObject<JToken>(input);
        var tokensToRemove = GetTokensToRemove(root);
        RemoveTokens(tokensToRemove);
        return JsonConvert.SerializeObject(root);
    }

    private static List<JToken> GetTokensToRemove(JToken node)
    {
        var tokensToRemove = new List<JToken>();

        if (node is JProperty property && property.Value.ToString() == "red")
        {
            tokensToRemove.Add(property.Parent);
        }

        foreach (var item in node)
        {
            tokensToRemove.AddRange(GetTokensToRemove(item));
        }

        return tokensToRemove;
    }

    private static void RemoveTokens(List<JToken> tokensToRemove)
    {
        foreach (var token in tokensToRemove)
        {
            try
            {
                if (token.Parent is JProperty)
                {
                    token.Parent.Remove();
                }
                else
                {
                    token.Remove();
                }
            }
            catch (InvalidOperationException ex)
            {
                // HACK: since we're removing elements from the structure, the parent may have already been removed
                if (!ex.Message.Contains("The parent is missing"))
                {
                    throw;
                }
            }
        }
    }
}
