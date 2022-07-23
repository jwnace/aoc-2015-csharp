namespace aoc_2015;

public static class Day07
{
    private static readonly string[] SmallInput = File.ReadAllLines("../../../../../input/day07_sm.txt");
    private static readonly string[] Input = File.ReadAllLines("../../../../../input/day07.txt");

    private static List<Wire> Wires = new List<Wire>();

    private record Wire
    {
        public string Name { get; set; } = "";
        public string InputString { get; set; } = "";
        public int? Output { get; set; }
    }

    public static int Part1()
    {
        Wires = new List<Wire>();
        foreach (var line in Input)
        {
            var leftAndRight = line.Split(" -> ");
            var left = leftAndRight[0];
            var right = leftAndRight[1];

            Wires.Add(new Wire
            {
                Name = right,
                InputString = left
            });
        }

        return ProcessWire(Wires.Single(x => x.Name == "a"));
    }

    private static int ProcessWire(Wire w)
    {
        var left = w.InputString.Split(' ');

        if (left.Length == 1)
        {
            // the only value is a value
            var a = left[0];
            if (a is "RSHIFT" or "OR" or "LSHIFT" or "AND" or "NOT")
            {
                throw new Exception("Received an operator where a value was expected.");
            }

            // the value `a` can be a number or a string
            if (int.TryParse(left.Single(), out var signal))
            {
                w.Output = signal;
            }
            else
            {
                w.Output = ProcessWire(Wires.Single(x => x.Name == left.Single()));
            }
        }
        else if (left.Length == 2)
        {
            // the left value is an operator, and the right value is a value
            var (a, b) = (left[0], left[1]);
            if (a != "RSHIFT" && a != "OR" && a != "LSHIFT" && a != "AND" && a != "NOT")
            {
                throw new Exception("Received a value where an operator was expected.");
            }

            if (b is "RSHIFT" or "OR" or "LSHIFT" or "AND" or "NOT")
            {
                throw new Exception("Received an operator where a value was expected.");
            }

            // the value `b` can be a number or a string
            var bValue = Wires.Any(x => x.Name == b)
                ? (int)(Wires.Single(x => x.Name == b).Output ?? ProcessWire(Wires.Single(x => x.Name == b)))
                : int.Parse(b);

            if (a == "NOT")
            {
                var signal = (ushort) (~bValue);
                w.Output = signal;
            }
        }
        else if (left.Length == 3)
        {
            // the middle value is an operator, and the left and right values are values
            var (a, b, c) = (left[0], left[1], left[2]);
            if (a is "RSHIFT" or "OR" or "LSHIFT" or "AND" or "NOT")
            {
                throw new Exception("Received an operator where a value was expected.");
            }

            if (b != "RSHIFT" && b != "OR" && b != "LSHIFT" && b != "AND" && b != "NOT")
            {
                throw new Exception("Received a value where an operator was expected.");
            }

            if (c is "RSHIFT" or "OR" or "LSHIFT" or "AND" or "NOT")
            {
                throw new Exception("Received an operator where a value was expected.");
            }

            // the values `a` and `c` can be a number or a string
            var aValue = Wires.Any(x => x.Name == a)
                ? (int)(Wires.Single(x => x.Name == a).Output ?? ProcessWire(Wires.Single(x => x.Name == a)))
                : int.Parse(a);
            var cValue = Wires.Any(x => x.Name == c)
                ? (int)(Wires.Single(x => x.Name == c).Output ?? ProcessWire(Wires.Single(x => x.Name == c)))
                : int.Parse(c);

            if (b == "AND")
            {
                var signal = aValue & cValue;
                w.Output = signal;
            }
            else if (b == "OR")
            {
                var signal = aValue | cValue;
                w.Output = signal;
            }
            else if (b == "LSHIFT")
            {
                var signal = aValue << cValue;
                w.Output = signal;
            }
            else if (b == "RSHIFT")
            {
                var signal = aValue >> cValue;
                w.Output = signal;
            }
        }

        return (int)w.Output!;
    }

    public static int Part2()
    {
        Wires = new List<Wire>();
        foreach (var line in Input)
        {
            var leftAndRight = line.Split(" -> ");
            var left = leftAndRight[0];
            var right = leftAndRight[1];

            Wires.Add(new Wire
            {
                Name = right,
                InputString = left
            });
        }

        var temp = ProcessWire(Wires.Single(x => x.Name == "a"));

        Wires = new List<Wire>();
        foreach (var line in Input)
        {
            var leftAndRight = line.Split(" -> ");
            var left = leftAndRight[0];
            var right = leftAndRight[1];

            Wires.Add(new Wire
            {
                Name = right,
                InputString = left
            });
        }

        var b = Wires.Single(x => x.Name == "b");
        b.Output = temp;
        
        return ProcessWire(Wires.Single(x => x.Name == "a"));
    }
}
