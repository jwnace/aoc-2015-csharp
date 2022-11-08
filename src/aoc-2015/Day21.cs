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

internal record Item(string Name, int Cost, int Damage, int Armor);

public static class Day21
{
    public static int Part1()
    {
        var (weapons, armors, rings) = ParseShopItems();

        for (var g = 1; g < int.MaxValue; g++)
        {
            var boss = CreateBoss();
            var player = CreatePlayer();
            var gold = g;

            gold = BuyWeapon(weapons, player, gold);
            gold = BuyArmor(armors, player, gold);
            BuyRings(rings, player, gold);

            // var player = new Player("Player", 8, 5, 5);
            // var boss = new Player("Boss", 12, 7, 2);

            var attacker = player;
            var defender = boss;

            while (player.HitPoints > 0 && boss.HitPoints > 0)
            {
                var damage = attacker.Damage - defender.Armor;
                damage = damage <= 0 ? 1 : damage;

                defender.HitPoints -= damage;

                // Console.WriteLine(
                // $"{attacker.Name} deals {damage} damage, {defender.Name}'s HP goes to {defender.HitPoints}");

                (attacker, defender) = (defender, attacker);
            }

            var winner = new[] { player, boss }.MaxBy(x => x.HitPoints);
            Console.WriteLine($"gold: {g}, {winner.Name} wins!");

            if (winner.Name == "Player")
                return g;
        }

        return -1;
    }

    private static int BuyWeapon(List<Item> weapons, Player player, int gold)
    {
        // must buy EXACTLY ONE weapon

        // buy the most expensive weapon we can afford
        // TODO: this is probably too naive... we probably need to buy a lower priced weapon and save gold for something else
        var weapon = weapons.Where(x => x.Cost <= gold).MaxBy(x => x.Cost);

        gold -= weapon?.Cost ?? 0;

        player.Damage += weapon?.Damage ?? 0;

        return gold;
    }

    private static int BuyArmor(List<Item> armors, Player player, int gold)
    {
        // must buy ZERO OR ONE armor

        // buy the most expensive weapon we can afford
        // TODO: this is probably too naive... we probably need to buy a lower priced weapon and save gold for something else
        var armor = armors.Where(x => x.Cost <= gold).MaxBy(x => x.Cost);

        gold -= armor?.Cost ?? 0;

        player.Armor += armor?.Armor ?? 0;

        return gold;
    }

    private static void BuyRings(List<Item> rings, Player player, int gold)
    {
        // must buy ZERO, ONE, OR TWO rings

        // buy the most expensive weapon we can afford
        // TODO: this is probably too naive... we probably need to buy a lower priced weapon and save gold for something else
        var r = rings.Where(x => x.Cost <= gold).OrderByDescending(x => x.Cost).Take(2);
        var armor = r.Sum(x => x.Armor);
        var damage = r.Sum(x => x.Damage);

        if (r.Count() > 0)
        {
            var foo = "bar";
        }

        player.Armor += armor;
        player.Damage += damage;

        // gold -= armor?.Cost ?? 0;
        // player.Armor += armor?.Armor ?? 0;
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

    public static int Part2()
    {
        var input = File.ReadAllLines("../../../../../input/day21_input.txt");
        var shop = File.ReadAllLines("../../../../../input/day21_shop.txt");
        return shop.Length;
    }
}
