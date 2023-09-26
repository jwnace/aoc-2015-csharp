namespace aoc_2015_csharp;

public static class Day07
{
    private static readonly string[] Input = File.ReadAllLines("../../../../../input/day07.txt");

    public static int Part1()
    {
        var wires = PopulateWires();
        return ProcessWire(wires, wires.Single(x => x.Name == "a"));
    }

    public static int Part2()
    {
        var wires = PopulateWires();

        var signalA = ProcessWire(wires, wires.Single(x => x.Name == "a"));

        wires = PopulateWires();

        var wireB = wires.Single(x => x.Name == "b");
        wireB.Signal = signalA;

        return ProcessWire(wires, wires.Single(x => x.Name == "a"));
    }

    private static List<Wire> PopulateWires()
    {
        var wires = new List<Wire>();

        foreach (var line in Input)
        {
            var values = line.Split(" -> ");
            var left = values[0];
            var right = values[1];

            wires.Add(new Wire
            {
                Name = right,
                Operation = left
            });
        }

        return wires;
    }

    private static int ProcessWire(List<Wire> wires, Wire w)
    {
        var parts = w.Operation.Split(' ');

        if (parts.Length == 1)
        {
            var a = parts[0];

            var aValue = int.TryParse(a, out var signal) ? signal : ProcessWire(wires, wires.Single(x => x.Name == a));

            w.Signal = aValue;
        }
        else if (parts.Length == 2)
        {
            var b = parts[1];

            var bValue = wires.Any(x => x.Name == b)
                ? wires.Single(x => x.Name == b).Signal ?? ProcessWire(wires, wires.Single(x => x.Name == b))
                : int.Parse(b);

            w.Signal = ~bValue;
        }
        else if (parts.Length == 3)
        {
            var (a, b, c) = (parts[0], parts[1], parts[2]);

            var aValue = wires.Any(x => x.Name == a)
                ? wires.Single(x => x.Name == a).Signal ?? ProcessWire(wires, wires.Single(x => x.Name == a))
                : int.Parse(a);

            var cValue = wires.Any(x => x.Name == c)
                ? wires.Single(x => x.Name == c).Signal ?? ProcessWire(wires, wires.Single(x => x.Name == c))
                : int.Parse(c);

            var signal = b switch
            {
                "AND" => aValue & cValue,
                "OR" => aValue | cValue,
                "LSHIFT" => aValue << cValue,
                "RSHIFT" => aValue >> cValue,
                _ => throw new ArgumentOutOfRangeException()
            };

            w.Signal = signal;
        }

        return w.Signal!.Value;
    }

    private record Wire
    {
        public string Name { get; init; } = "";
        public string Operation { get; init; } = "";
        public int? Signal { get; set; }
    }
}
