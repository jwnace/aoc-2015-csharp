namespace aoc_2015;

internal class Player
{
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }

    public Player(string name, int hitPoints, int damage, int armor)
    {
        Name = name;
        HitPoints = hitPoints;
        Damage = damage;
        Armor = armor;
    }

    public override string ToString()
    {
        return $"Name = {Name}, HitPoints = {HitPoints}, Damage = {Damage}, Armor = {Armor}";
    }
}

internal record Item(string Name, int Cost, int Damage, int Armor) : IComparable
{
    public int CompareTo(object? obj)
    {
        var other = obj as Item;
        return Cost - other!.Cost;
    }
}

public static class Day21
{
    public static int Part1()
    {
        var (weapons, armors, rings) = ParseShopItems();

        var temp = PermuteEquipment(weapons, armors, rings);

        foreach (var loadout in temp)
        {
            var boss = CreateBoss();
            var player = CreatePlayer();

            EquipPlayer(player, loadout);

            var winner = Fight(player, boss);

            var cost = loadout.Sum(x => x.Cost);

            if (winner.Name == "Player") return cost;
        }

        return -1;
    }

    public static int Part2()
    {
        var (weapons, armors, rings) = ParseShopItems();

        var temp = PermuteEquipment(weapons, armors, rings);

        foreach (var loadout in temp.OrderByDescending(x => x.Sum(y => y.Cost)))
        {
            var boss = CreateBoss();
            var player = CreatePlayer();

            EquipPlayer(player, loadout);

            var winner = Fight(player, boss);

            var cost = loadout.Sum(x => x.Cost);

            if (winner.Name == "Boss") return cost;
        }

        return -1;
    }

    private static void EquipPlayer(Player player, List<Item> loadout)
    {
        player.Armor += loadout.Sum(x => x.Armor);
        player.Damage += loadout.Sum(x => x.Damage);
    }

    private static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
    {
        if (length == 0)
        {
            return new List<List<T>> { new() };
        }

        if (length == 1)
        {
            return list.Select(t => new[] { t });
        }

        return GetKCombs(list, length - 1)
            .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0), (t1, t2) => t1.Concat(new[] { t2 }));
    }

    private static List<List<Item>> PermuteEquipment(List<Item> weapons, List<Item> armors, List<Item> rings)
    {
        var w = GetKCombs(weapons, 1)
            .Select(x => new { Cost = x.Sum(y => y.Cost), Set = x })
            .OrderBy(x => x.Cost)
            .ToList();

        var a1 = GetKCombs(armors, 0);
        var a2 = GetKCombs(armors, 1);
        var a = a1.Union(a2)
            .Select(x => new { Cost = x.Sum(y => y.Cost), Set = x })
            .OrderBy(x => x.Cost)
            .ToList();

        var r1 = GetKCombs(rings, 0);
        var r2 = GetKCombs(rings, 1);
        var r3 = GetKCombs(rings, 2);
        var r = r1.Union(r2.Union(r3))
            .Select(x => new { Cost = x.Sum(y => y.Cost), Set = x })
            .OrderBy(x => x.Cost)
            .ToList();

        var possibleEquipment = new List<List<Item>>();

        for (var i = 0; i < w.Count; i++)
        {
            for (var j = 0; j < a.Count; j++)
            {
                for (var k = 0; k < r.Count; k++)
                {
                    var wTemp = w[i];
                    var aTemp = a[j];
                    var rTemp = r[k];

                    var equipment = wTemp.Set.Union(aTemp.Set.Union(rTemp.Set)).ToList();
                    possibleEquipment.Add(equipment);
                }
            }
        }

        var query = possibleEquipment.Select(x => new { Cost = x.Sum(y => y.Cost), Set = x })
            .OrderBy(x => x.Cost)
            .Select(x => x.Set)
            .ToList();

        return query;
    }

    private static Player Fight(Player player, Player boss)
    {
        var attacker = player;
        var defender = boss;

        while (player.HitPoints > 0 && boss.HitPoints > 0)
        {
            var damage = attacker.Damage - defender.Armor;
            damage = damage <= 0 ? 1 : damage;

            defender.HitPoints -= damage;

            (attacker, defender) = (defender, attacker);
        }

        return new[] { player, boss }.MaxBy(x => x.HitPoints);
    }

    private static (List<Item>, List<Item>, List<Item>) ParseShopItems()
    {
        var shop = File.ReadAllText("../../../../../input/day21_shop.txt");

        var sections = shop.Split($"{Environment.NewLine}{Environment.NewLine}");

        var weapons = sections[0].Split(Environment.NewLine)
            .Skip(1)
            .Select(x => x.Split(null).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray())
            .Select(x => new Item(x[0], int.Parse(x[1]), int.Parse(x[2]), int.Parse(x[3])))
            .ToList();

        var armor = sections[1].Split(Environment.NewLine)
            .Skip(1)
            .Select(x => x.Split(null).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray())
            .Select(x => new Item(x[0], int.Parse(x[1]), int.Parse(x[2]), int.Parse(x[3])))
            .ToList();

        var rings = sections[2].Split(Environment.NewLine)
            .Skip(1)
            .Select(x => x.Split(null).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray())
            .Select(x => new Item($"{x[0]} {x[1]}", int.Parse(x[2]), int.Parse(x[3]), int.Parse(x[4])))
            .ToList();

        return (weapons, armor, rings);
    }

    private static Player CreateBoss()
    {
        var input = File.ReadAllLines("../../../../../input/day21_input.txt")
            .Select(line => int.Parse(line.Split(": ")[1])).ToArray();

        var hitPoints = input[0];
        var damage = input[1];
        var armor = input[2];

        return new Player("Boss", hitPoints, damage, armor);
    }

    private static Player CreatePlayer()
    {
        return new Player("Player", 100, 0, 0);
    }
}
