namespace aoc_2015_csharp;

public class Day23
{
    public static int Part1()
    {
        var input = File.ReadAllLines("../../../../../input/day23.txt");
        var registers = new Dictionary<string, int>
        {
            { "a", 0 },
            { "b", 0 }
        };

        for (var i = 0; i < input.Length; i++)
        {
            var values = input[i].Split(" ");
            var instruction = values[0];
            var register = values[1].Replace(",", "");

            switch (instruction)
            {
                case "hlf":
                    registers[register] /= 2;
                    continue;
                case "tpl":
                    registers[register] *= 3;
                    continue;
                case "inc":
                    registers[register]++;
                    continue;
                case "jmp":
                    var jmpOffset = int.Parse(values[1]);
                    i += jmpOffset - 1;
                    continue;
                case "jie":
                    var jieOffset = int.Parse(values[2]);
                    i += registers[register] % 2 == 0 ? jieOffset - 1 : 0;
                    continue;
                case "jio":
                    var jioOffset = int.Parse(values[2]);
                    i += registers[register] == 1 ? jioOffset - 1 : 0;
                    continue;
                default:
                    throw new NotImplementedException();
            }
        }

        return registers["b"];
    }

    public static long Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day23.txt");
        var registers = new Dictionary<string, long>
        {
            { "a", 1 },
            { "b", 0 }
        };

        for (var i = 0; i < input.Length; i++)
        {
            var values = input[i].Split(" ");
            var instruction = values[0];
            var register = values[1].Replace(",", "");

            switch (instruction)
            {
                case "hlf":
                    registers[register] /= 2;
                    continue;
                case "tpl":
                    registers[register] *= 3;
                    continue;
                case "inc":
                    registers[register]++;
                    continue;
                case "jmp":
                    var jmpOffset = int.Parse(values[1]);
                    i += jmpOffset - 1;
                    continue;
                case "jie":
                    var jieOffset = int.Parse(values[2]);
                    i += registers[register] % 2 == 0 ? jieOffset - 1 : 0;
                    continue;
                case "jio":
                    var jioOffset = int.Parse(values[2]);
                    i += registers[register] == 1 ? jioOffset - 1 : 0;
                    continue;
                default:
                    throw new NotImplementedException();
            }
        }

        return registers["b"];
    }
}
