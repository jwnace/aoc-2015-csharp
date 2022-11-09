namespace aoc_2015;

public static class Day22
{
    private record Player(string Name, int HitPoints, int Damage, int Armor, int Mana);

    private record Spell(string Name, int Cost);

    private static readonly List<Spell> Spells = new List<Spell>
    {
        new("Magic Missile", 53),
        new("Drain", 73),
        new("Shield", 113),
        new("Poison", 173),
        new("Recharge", 229)
    };

    private record GameState(Player Player, Player Boss, int ShieldDuration, int PoisonDuration, int RechargeDuration, bool IsPlayersTurn);

    private static GameState GetInitialGameState()
    {
        var player = new Player("Player", 10, 0, 0, 250);
        var boss = new Player("Boss", 13, 8, 0, 0);

        return new GameState(player, boss, 0, 0, 0, true);
    }

    public static int Part1()
    {
        var gameState = GetInitialGameState();

        TakeTurn(gameState);

        return -1;
    }

    private static void TakeTurn(GameState gameState)
    {
        var (player, boss, shieldDuration, poisonDuration, rechargeDuration, isPlayersTurn) = gameState;

        if (player.HitPoints <= 0 || player.Mana < Spells.Min(x => x.Cost))
        {
            // the boss wins
            Console.WriteLine("boss wins!");
            Console.WriteLine();
            Console.WriteLine(gameState);
            Console.WriteLine();

            return;
        }

        if (boss.HitPoints <= 0)
        {
            // the player wins
            Console.WriteLine("player wins!");
            return;
        }

        var attacker = isPlayersTurn ? player : boss;
        var defender = isPlayersTurn ? boss : player;

        if (attacker == player)
        {
            var updatedState = new GameState(player, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn);
            TakeTurn(updatedState);
        }

        if (attacker == boss)
        {
            var damage = attacker.Damage - defender.Armor;
            var updatedPlayer = player with { HitPoints = player.HitPoints - damage };
            var updatedState = new GameState(updatedPlayer, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn);
            TakeTurn(updatedState);
        }
    }

    public static int Part2()
    {
        return -2;
    }
}
