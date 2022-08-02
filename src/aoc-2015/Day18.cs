namespace aoc_2015;

public static class Day18
{
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day18.txt");
        var memo = new Dictionary<(int, int), bool>();

        for (int r = 0; r < input.Length; r++)
        {
            for (int c = 0; c < input[r].Length; c++)
            {
                memo[(r, c)] = input[r][c] == '#';
            }
        }

        for (int i = 0; i < 100; i++)
        {
            var memo2 = new Dictionary<(int, int), bool>(memo);

            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    var a = (row - 1, col - 1);
                    var b = (row - 1, col);
                    var c = (row - 1, col + 1);
                    var d = (row, col - 1);
                    var e = (row, col + 1);
                    var f = (row + 1, col - 1);
                    var g = (row + 1, col);
                    var h = (row + 1, col + 1);

                    var a1 = memo.ContainsKey(a) && memo[a];
                    var b1 = memo.ContainsKey(b) && memo[b];
                    var c1 = memo.ContainsKey(c) && memo[c];
                    var d1 = memo.ContainsKey(d) && memo[d];
                    var e1 = memo.ContainsKey(e) && memo[e];
                    var f1 = memo.ContainsKey(f) && memo[f];
                    var g1 = memo.ContainsKey(g) && memo[g];
                    var h1 = memo.ContainsKey(h) && memo[h];

                    var count = new[] { a1, b1, c1, d1, e1, f1, g1, h1 }.Count(x => x);

                    if (memo[(row, col)])
                    {
                        if (count is 2 or 3)
                        {
                            memo2[(row, col)] = true;
                        }
                        else
                        {
                            memo2[(row, col)] = false;
                        }
                    }

                    if (!memo[(row, col)])
                    {
                        if (count == 3)
                        {
                            memo2[(row, col)] = true;
                        }
                    }
                }
            }

            memo = memo2;
        }

        return memo.Count(x => x.Value);
    }

    public static int Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day18.txt");
        var memo = new Dictionary<(int, int), bool>();

        for (int r = 0; r < input.Length; r++)
        {
            for (int c = 0; c < input[r].Length; c++)
            {
                if (r == 0 && c == 0)
                {
                    memo[(r, c)] = true;
                }
                else if (r == 0 && c == 99)
                {
                    memo[(r, c)] = true;
                }
                else if (r == 99 && c == 99)
                {
                    memo[(r, c)] = true;
                }
                else if (r == 99 && c == 0)
                {
                    memo[(r, c)] = true;
                }
                else
                {
                    memo[(r, c)] = input[r][c] == '#';
                }
            }
        }

        for (int i = 0; i < 100; i++)
        {
            var memo2 = new Dictionary<(int, int), bool>(memo);

            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        memo[(row, col)] = true;
                        continue;
                    }
                    else if (row == 0 && col == 99)
                    {
                        memo[(row, col)] = true;
                        continue;
                    }
                    else if (row == 99 && col == 99)
                    {
                        memo[(row, col)] = true;
                        continue;
                    }
                    else if (row == 99 && col == 0)
                    {
                        memo[(row, col)] = true;
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

                    var a1 = memo.ContainsKey(a) && memo[a];
                    var b1 = memo.ContainsKey(b) && memo[b];
                    var c1 = memo.ContainsKey(c) && memo[c];
                    var d1 = memo.ContainsKey(d) && memo[d];
                    var e1 = memo.ContainsKey(e) && memo[e];
                    var f1 = memo.ContainsKey(f) && memo[f];
                    var g1 = memo.ContainsKey(g) && memo[g];
                    var h1 = memo.ContainsKey(h) && memo[h];

                    var count = new[] { a1, b1, c1, d1, e1, f1, g1, h1 }.Count(x => x);

                    if (memo[(row, col)])
                    {
                        if (count is 2 or 3)
                        {
                            memo2[(row, col)] = true;
                        }
                        else
                        {
                            memo2[(row, col)] = false;
                        }
                    }

                    if (!memo[(row, col)])
                    {
                        if (count == 3)
                        {
                            memo2[(row, col)] = true;
                        }
                    }
                }
            }

            memo = memo2;
        }

        return memo.Count(x => x.Value);
    }
}
