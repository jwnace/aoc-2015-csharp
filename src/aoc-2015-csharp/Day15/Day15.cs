namespace aoc_2015_csharp.Day15;

public static class Day15
{
    private record Ingredient
    {
        public string Name { get; init; } = "";
        public int Capacity { get; init; }
        public int Durability { get; init; }
        public int Flavor { get; init; }
        public int Texture { get; init; }
        public int Calories { get; init; }
    }

    public static int Part1()
    {
        var input = File.ReadAllLines("Day15/day15.txt");

        var ingredients = input
            .Select(x => x.Split(' '))
            .Select(x => new Ingredient
            {
                Name = x[0].Trim(':'),
                Capacity = int.Parse(x[2].Trim(',')),
                Durability = int.Parse(x[4].Trim(',')),
                Flavor = int.Parse(x[6].Trim(',')),
                Texture = int.Parse(x[8].Trim(',')),
                Calories = int.Parse(x[10])
            }).ToArray();

        var maxScore = 0;

        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; j <= 100 - i; j++)
            {
                for (int k = 0; k <= 100 - i - j; k++)
                {
                    var l = 100 - i - j - k;

                    var score = CalculateScore(ingredients[0], ingredients[1], ingredients[2], ingredients[3], i, j, k, l);
                    if (score > maxScore)
                    {
                        maxScore = score;
                    }
                }
            }
        }

        return maxScore;
    }

    private static int CalculateScore(Ingredient a, Ingredient b, Ingredient c, Ingredient d, int i, int j, int k, int l, int maxCalories = Int32.MaxValue)
    {
        var calories = a.Calories * i + b.Calories * j + c.Calories * k + d.Calories * l;

        if (calories > maxCalories)
        {
            return 0;
        }

        var a1 = a.Capacity * i;
        var a2 = a.Durability * i;
        var a3 = a.Flavor * i;
        var a4 = a.Texture * i;

        var b1 = b.Capacity * j;
        var b2 = b.Durability * j;
        var b3 = b.Flavor * j;
        var b4 = b.Texture * j;

        var c1 = c.Capacity * k;
        var c2 = c.Durability * k;
        var c3 = c.Flavor * k;
        var c4 = c.Texture * k;

        var d1 = d.Capacity * l;
        var d2 = d.Durability * l;
        var d3 = d.Flavor * l;
        var d4 = d.Texture * l;

        var v1 = a1 + b1 + c1 + d1;
        v1 = v1 > 0 ? v1 : 0;
        var v2 = a2 + b2 + c2 + d2;
        v2 = v2 > 0 ? v2 : 0;
        var v3 = a3 + b3 + c3 + d3;
        v3 = v3 > 0 ? v3 : 0;
        var v4 = a4 + b4 + c4 + d4;
        v4 = v4 > 0 ? v4 : 0;

        var result = v1 * v2 * v3 * v4;
        return result;
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("Day15/day15.txt");

        var ingredients = input
            .Select(x => x.Split(' '))
            .Select(x => new Ingredient
            {
                Name = x[0].Trim(':'),
                Capacity = int.Parse(x[2].Trim(',')),
                Durability = int.Parse(x[4].Trim(',')),
                Flavor = int.Parse(x[6].Trim(',')),
                Texture = int.Parse(x[8].Trim(',')),
                Calories = int.Parse(x[10])
            }).ToArray();

        var maxScore = 0;

        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; j <= 100 - i; j++)
            {
                for (int k = 0; k <= 100 - i - j; k++)
                {
                    var l = 100 - i - j - k;

                    var score = CalculateScore(ingredients[0], ingredients[1], ingredients[2], ingredients[3], i, j, k, l, maxCalories: 500);
                    if (score > maxScore)
                    {
                        maxScore = score;
                    }
                }
            }
        }

        return maxScore;
    }
}
