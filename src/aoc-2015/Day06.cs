namespace aoc_2015;

public static class Day06
{
    private static readonly string[] Input = File.ReadAllLines("../../../../../input/day06.txt");

    public static int Part1()
    {
        var memo = new Dictionary<(int x, int y), bool>();

        foreach (var line in Input)
        {
            var turnOn = line.Contains("turn on");
            var turnOff = line.Contains("turn off");
            var toggle = line.Contains("toggle");

            if (turnOn)
            {
                var temp = line.Replace("turn on ", "");
                var values = temp.Split(" through ");
                var a = values[0].Split(',');
                var (x1, y1) = (int.Parse(a[0]), int.Parse(a[1]));
                var b = values[1].Split(',');
                var (x2, y2) = (int.Parse(b[0]), int.Parse(b[1]));

                for (var x = x1; x <= x2; x++)
                {
                    for (var y = y1; y <= y2; y++)
                    {
                        memo[(x, y)] = true;
                    }
                }
            }
            else if (turnOff)
            {
                var temp = line.Replace("turn off ", "");
                var values = temp.Split(" through ");
                var a = values[0].Split(',');
                var (x1, y1) = (int.Parse(a[0]), int.Parse(a[1]));
                var b = values[1].Split(',');
                var (x2, y2) = (int.Parse(b[0]), int.Parse(b[1]));

                for (var x = x1; x <= x2; x++)
                {
                    for (var y = y1; y <= y2; y++)
                    {
                        memo[(x, y)] = false;
                    }
                }
            }
            else
            {
                var temp = line.Replace("toggle ", "");
                var values = temp.Split(" through ");
                var a = values[0].Split(',');
                var (x1, y1) = (int.Parse(a[0]), int.Parse(a[1]));
                var b = values[1].Split(',');
                var (x2, y2) = (int.Parse(b[0]), int.Parse(b[1]));

                for (var x = x1; x <= x2; x++)
                {
                    for (var y = y1; y <= y2; y++)
                    {
                        memo[(x, y)] = memo.ContainsKey((x, y)) ? !memo[(x, y)] : true;
                    }
                }
            }
        }

        return memo.Count(x => x.Value);
    }

    public static int Part2()
    {
        var memo = new Dictionary<(int x, int y), int>();

        foreach (var line in Input)
        {
            var turnOn = line.Contains("turn on");
            var turnOff = line.Contains("turn off");
            var toggle = line.Contains("toggle");

            if (turnOn)
            {
                var temp = line.Replace("turn on ", "");
                var values = temp.Split(" through ");
                var a = values[0].Split(',');
                var (x1, y1) = (int.Parse(a[0]), int.Parse(a[1]));
                var b = values[1].Split(',');
                var (x2, y2) = (int.Parse(b[0]), int.Parse(b[1]));

                for (var x = x1; x <= x2; x++)
                {
                    for (var y = y1; y <= y2; y++)
                    {
                        memo[(x, y)] = memo.ContainsKey((x, y)) ? memo[(x, y)] + 1 : 1;
                    }
                }
            }
            else if (turnOff)
            {
                var temp = line.Replace("turn off ", "");
                var values = temp.Split(" through ");
                var a = values[0].Split(',');
                var (x1, y1) = (int.Parse(a[0]), int.Parse(a[1]));
                var b = values[1].Split(',');
                var (x2, y2) = (int.Parse(b[0]), int.Parse(b[1]));

                for (var x = x1; x <= x2; x++)
                {
                    for (var y = y1; y <= y2; y++)
                    {
                        memo[(x, y)] = memo.ContainsKey((x, y)) ? memo[(x, y)] - 1 : 0;
                        memo[(x, y)] = memo[(x, y)] >= 0 ? memo[(x, y)] : 0;
                    }
                }
            }
            else
            {
                var temp = line.Replace("toggle ", "");
                var values = temp.Split(" through ");
                var a = values[0].Split(',');
                var (x1, y1) = (int.Parse(a[0]), int.Parse(a[1]));
                var b = values[1].Split(',');
                var (x2, y2) = (int.Parse(b[0]), int.Parse(b[1]));

                for (var x = x1; x <= x2; x++)
                {
                    for (var y = y1; y <= y2; y++)
                    {
                        memo[(x, y)] = memo.ContainsKey((x, y)) ? memo[(x, y)] + 2 : 2;
                    }
                }
            }
        }

        return memo.Sum(x => x.Value);
    }
}
