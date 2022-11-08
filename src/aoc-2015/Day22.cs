using System.Security.Cryptography;

namespace aoc_2015;

public static class Day22
{
    private record Spell(string Name, int Cost);

    private class Effect
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }

    private class Player
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Mana { get; set; }

        public Player(string name, int hitPoints, int damage, int armor, int mana)
        {
            Name = name;
            HitPoints = hitPoints;
            Damage = damage;
            Armor = armor;
            Mana = mana;
        }

        public override string ToString()
        {
            return $"Name = {Name}, HitPoints = {HitPoints}, Damage = {Damage}, Armor = {Armor}, Mana = {Mana}";
        }
    }

    public static int Part1()
    {
        var player = new Player("Player", 10, 0, 0, 250);
        var boss = new Player("Boss", 13, 8, 0, 0);

        var winner = Fight(player, boss);
        Console.WriteLine($"{winner.Name} wins!");

        return -1;
    }

    public static int Part2()
    {
        return -2;
    }

    private static Player Fight(Player player, Player boss)
    {
        var attacker = player;
        var defender = boss;

        var effects = new List<Effect>
        {
            new() { Name = "Shield", Duration = 0 },
            new() { Name = "Poison", Duration = 0 },
            new() { Name = "Recharge", Duration = 0 }
        };

        var spells = new List<Spell>
        {
            new Spell("Magic Missile", 53),
            new Spell("Drain", 73),
            new Spell("Shield", 113),
            new Spell("Poison", 173),
            new Spell("Recharge", 229)
        };

        while (player.HitPoints > 0 && boss.HitPoints > 0)
        {
            Console.WriteLine($"Player has {player.HitPoints} hit points, {player.Armor} armor, {player.Mana} mana");
            Console.WriteLine($"Boss has {boss.HitPoints} hit points");

            var isShieldActive = effects.Single(x => x.Name == "Shield").Duration > 0;
            var isPoisonActive = effects.Single(x => x.Name == "Poison").Duration > 0;
            var isRechargeActive = effects.Single(x => x.Name == "Recharge").Duration > 0;

            player.Armor = isShieldActive ? 7 : 0;

            if (isPoisonActive)
            {
                boss.HitPoints -= 3;
            }

            if (isRechargeActive)
            {
                player.Mana += 101;
            }

            foreach (var effect in effects)
            {
                effect.Duration--;

                if (effect.Duration < 0)
                {
                    effect.Duration = 0;
                }
            }

            if (boss.HitPoints <= 0)
            {
                break;
            }

            if (player.Mana < 53)
            {
                player.HitPoints = 0;
                break;
            }

            if (attacker.Name == "Player")
            {
                var castableSpells = spells.Where(x => x.Cost <= player.Mana).ToList();
                
                // magic missile
                attacker.Mana -= 53;
                defender.HitPoints -= 4;

                // drain
                attacker.Mana -= 73;
                defender.HitPoints -= 2;
                attacker.HitPoints += 2;

                // shield
                attacker.Mana -= 113;
                effects.Single(x => x.Name == "Shield").Duration = 6;

                // poison
                attacker.Mana -= 173;
                effects.Single(x => x.Name == "Poison").Duration = 6;

                // recharge
                attacker.Mana -= 229;
                effects.Single(x => x.Name == "Recharge").Duration = 5;
            }

            if (attacker.Name == "Boss")
            {
                var damage = attacker.Damage - defender.Armor;
                damage = damage <= 0 ? 1 : damage;
                defender.HitPoints -= damage;
            }

            (attacker, defender) = (defender, attacker);
        }

        return new[] { player, boss }.MaxBy(x => x.HitPoints)!;
    }

    private static Player CreateBoss()
    {
        var input = File.ReadAllLines("../../../../../input/day22.txt")
            .Select(line => int.Parse(line.Split(": ")[1])).ToArray();

        var hitPoints = input[0];
        var damage = input[1];
        var armor = input[2];

        return new Player("Boss", hitPoints, damage, armor, 0);
    }
}
