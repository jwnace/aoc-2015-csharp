namespace aoc_2015;

public static class Day22
{
    private record GameState(Player Player, Player Boss, List<Effect> Effects, List<GameState> Children);

    private record Spell(string Name, int Cost);

    private record Effect
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }

    private class Player
    {
        public string Name { get; }
        public int HitPoints { get; set; }
        public int Damage { get; }
        public int Armor { get; set; }
        public int Mana { get; set; }

        public Player(Player p)
        {
            Name = p.Name;
            HitPoints = p.HitPoints;
            Damage = p.Damage;
            Armor = p.Armor;
            Mana = p.Mana;
        }
        
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

    private static GameState Root { get; set; }

    public static int Part1()
    {
        // var boss = CreateBoss();

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
            new("Magic Missile", 53),
            new("Drain", 73),
            new("Shield", 113),
            new("Poison", 173),
            new("Recharge", 229)
        };

        // create the initial GameState
        Root = new GameState(new Player(player), new Player(boss), new List<Effect>(effects), new List<GameState>());
        var currentState = Root;
        
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

                // TODO: choose a spell to cast
                foreach (var spell in castableSpells)
                {
                    // TODO: split into multiple possible realities
                    // build a tree... root node is the initial state
                    // child nodes are all possible next states
                    // keep building out the tree until you reach a winner and a loser
                    // find the leaf where the player wins with the least mana used
                }

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
            
            currentState.Children.Add(new GameState(player, boss, effects, new List<GameState>()));
        }

        return new[] { player, boss }.MaxBy(x => x.HitPoints)!;
    }

    private static Player CreateBoss()
    {
        var input = File.ReadAllLines("../../../../../input/day22.txt")
            .Select(line => int.Parse(line.Split(": ")[1])).ToArray();

        var hitPoints = input[0];
        var damage = input[1];

        return new Player("Boss", hitPoints, damage, 0, 0);
    }
}
