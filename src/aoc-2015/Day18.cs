namespace aoc_2015;

public static class Day18
{
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day18.txt");
        var grid = new Dictionary<(int, int), bool>();

        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                grid[(row, col)] = input[row][col] == '#';
            }
        }

        for (var i = 0; i < 100; i++)
        {
            var temp = new Dictionary<(int, int), bool>(grid);

            for (var row = 0; row < 100; row++)
            {
                for (var col = 0; col < 100; col++)
                {
                    var a = (row - 1, col - 1);
                    var b = (row - 1, col);
                    var c = (row - 1, col + 1);
                    var d = (row, col - 1);
                    var e = (row, col + 1);
                    var f = (row + 1, col - 1);
                    var g = (row + 1, col);
                    var h = (row + 1, col + 1);

                    var a1 = grid.ContainsKey(a) && grid[a];
                    var b1 = grid.ContainsKey(b) && grid[b];
                    var c1 = grid.ContainsKey(c) && grid[c];
                    var d1 = grid.ContainsKey(d) && grid[d];
                    var e1 = grid.ContainsKey(e) && grid[e];
                    var f1 = grid.ContainsKey(f) && grid[f];
                    var g1 = grid.ContainsKey(g) && grid[g];
                    var h1 = grid.ContainsKey(h) && grid[h];

                    var count = new[] { a1, b1, c1, d1, e1, f1, g1, h1 }.Count(x => x);

                    if (grid[(row, col)] && count is not (2 or 3))
                    {
                        temp[(row, col)] = false;
                    }

                    if (!grid[(row, col)] && (count == 3))
                    {
                        temp[(row, col)] = true;
                    }
                }
            }

            grid = temp;
        }

        return grid.Count(x => x.Value);
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day18.txt");
        var grid = new Dictionary<(int, int), bool>();

        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                switch (row, col)
                {
                    case (0, 0):
                    case (0, 99):
                    case (99, 99):
                    case (99, 0):
                        grid[(row, col)] = true;
                        break;
                    default:
                        grid[(row, col)] = input[row][col] == '#';
                        break;
                }
            }
        }

        for (var i = 0; i < 100; i++)
        {
            var temp = new Dictionary<(int, int), bool>(grid);

            for (var row = 0; row < 100; row++)
            {
                for (var col = 0; col < 100; col++)
                {
                    switch (row, col)
                    {
                        case (0, 0):
                        case (0, 99):
                        case (99, 99):
                        case (99, 0):
                            grid[(row, col)] = true;
                            continue;
                    }

                    var a = (row - 1, col - 1);
                    var b = (row - 1, col);
                    var c = (row - 1, col + 1);
                    var d = (row, col - 1);
                    var e = (row, col + 1);
                    var f = (row + 1, col - 1);
                    var g = (row + 1, col);
                    var h = (row + 1, col + 1);

                    var a1 = grid.ContainsKey(a) && grid[a];
                    var b1 = grid.ContainsKey(b) && grid[b];
                    var c1 = grid.ContainsKey(c) && grid[c];
                    var d1 = grid.ContainsKey(d) && grid[d];
                    var e1 = grid.ContainsKey(e) && grid[e];
                    var f1 = grid.ContainsKey(f) && grid[f];
                    var g1 = grid.ContainsKey(g) && grid[g];
                    var h1 = grid.ContainsKey(h) && grid[h];

                    var count = new[] { a1, b1, c1, d1, e1, f1, g1, h1 }.Count(x => x);

                    if (grid[(row, col)] && count is not (2 or 3))
                    {
                        temp[(row, col)] = false;
                    }

                    if (!grid[(row, col)] && count == 3)
                    {
                        temp[(row, col)] = true;
                    }
                }
            }

            grid = temp;
        }

        return grid.Count(x => x.Value);
    }
}
