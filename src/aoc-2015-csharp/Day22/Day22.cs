namespace aoc_2015_csharp.Day22;

public static class Day22
{
    private record Player(string Name, int HitPoints, int Damage, int Armor, int Mana);

    private record Spell(string Name, int Cost);

    private static readonly List<Spell> Spells = new()
    {
        new Spell("Magic Missile", 53),
        new Spell("Drain", 73),
        new Spell("Shield", 113),
        new Spell("Poison", 173),
        new Spell("Recharge", 229)
    };

    private record GameState(Player Player, Player Boss, int ShieldDuration, int PoisonDuration, int RechargeDuration,
        bool IsPlayersTurn, int ManaCost, Player? Winner, List<string> Spells);

    private static readonly List<GameState> PossibleGameStates = new();

    private static GameState GetInitialGameState()
    {
        // var player = new Player("Player", 10, 0, 0, 250);
        // var boss = new Player("Boss", 13, 8, 0, 0);
        // var boss = new Player("Boss", 14, 8, 0, 0);

        var player = new Player("Player", 50, 0, 0, 500);
        var boss = CreateBoss();

        return new GameState(player, boss, 0, 0, 0, true, 0, null, new List<string>());
    }

    public static int Part1()
    {
        var gameState = GetInitialGameState();

        TakeTurn(gameState, false);

        var playerWins = PossibleGameStates.Count(x => x.Winner!.Name == "Player");
        var bossWins = PossibleGameStates.Count(x => x.Winner!.Name == "Boss");

        // Console.WriteLine($"Player Wins: {playerWins}, Boss Wins: {bossWins}");

        return playerWins > 0
            ? PossibleGameStates
                .Where(x => x.Winner!.Name == "Player")
                .Min(x => x.ManaCost)
            : -1;
    }

    private static void TakeTurn(GameState gameState, bool partTwo)
    {
        var (player, boss, shieldDuration, poisonDuration, rechargeDuration, isPlayersTurn, manaCost, winner, spells) =
            gameState;

        if (PossibleGameStates.Count > 0 && manaCost > PossibleGameStates.Min(x => x.ManaCost))
        {
            return;
        }

        if (partTwo && isPlayersTurn)
        {
            player = player with { HitPoints = player.HitPoints - 1 };

            // TODO: figure out when is the appropriate time to do these checks
            if (player.HitPoints <= 0 || player.Mana < Spells.Min(x => x.Cost))
            {
                // PossibleGameStates.Add(
                //     new GameState(
                //         player, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn, manaCost, winner, spells));

                // Console.WriteLine(player);
                // Console.WriteLine(boss);
                // Console.WriteLine("boss wins!");
                // Console.WriteLine();
                return;
            }
        }

        spells = new List<string>(spells);

        if (shieldDuration > 0)
        {
            player = player with { Armor = 7 };
            shieldDuration--;
        }
        else
        {
            player = player with { Armor = 0 };
        }

        if (poisonDuration > 0)
        {
            boss = boss with { HitPoints = boss.HitPoints - 3 };
            poisonDuration--;
        }

        if (rechargeDuration > 0)
        {
            player = player with { Mana = player.Mana + 101 };
            rechargeDuration--;
        }

        // TODO: figure out when is the appropriate time to do these checks
        if (boss.HitPoints <= 0)
        {
            winner = player;

            PossibleGameStates.Add(
                new GameState(
                    player, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn, manaCost, winner, spells));

            // Console.WriteLine(player);
            // Console.WriteLine(boss);
            // Console.WriteLine("player wins!");
            // Console.WriteLine();
            return;
        }

        // TODO: figure out when is the appropriate time to do these checks
        if (player.HitPoints <= 0 || player.Mana < Spells.Min(x => x.Cost))
        {
            // PossibleGameStates.Add(
            //     new GameState(
            //         player, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn, manaCost, winner, spells));

            // Console.WriteLine(player);
            // Console.WriteLine(boss);
            // Console.WriteLine("boss wins!");
            // Console.WriteLine();
            return;
        }

        var attacker = isPlayersTurn ? player : boss;
        var defender = isPlayersTurn ? boss : player;

        if (attacker == player)
        {
            foreach (var spell in Spells)
            {
                if (spell.Name == "Magic Missile")
                {
                    if (boss.HitPoints <= 0)
                    {
                        winner = player;

                        PossibleGameStates.Add(
                            new GameState(
                                player with { Mana = player.Mana - spell.Cost },
                                boss with { HitPoints = boss.HitPoints - 4 },
                                shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn,
                                manaCost + spell.Cost,
                                winner,
                                spells.Concat(new List<string> { spell.Name }).ToList()));

                        // Console.WriteLine(player);
                        // Console.WriteLine(boss);
                        // Console.WriteLine("player wins!");
                        // Console.WriteLine();
                        return;
                    }

                    TakeTurn(
                        new GameState(
                            player with { Mana = player.Mana - spell.Cost },
                            boss with { HitPoints = boss.HitPoints - 4 },
                            shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn,
                            manaCost + spell.Cost,
                            winner,
                            spells.Concat(new List<string> { spell.Name }).ToList()), partTwo);
                }

                if (spell.Name == "Drain")
                {
                    if (boss.HitPoints <= 0)
                    {
                        winner = player;

                        PossibleGameStates.Add(
                            new GameState(
                                player with { Mana = player.Mana - spell.Cost, HitPoints = player.HitPoints + 2 },
                                boss with { HitPoints = boss.HitPoints - 2 },
                                shieldDuration, poisonDuration, rechargeDuration,
                                !isPlayersTurn,
                                manaCost + spell.Cost, winner, spells.Concat(new List<string> { spell.Name }).ToList()));

                        // Console.WriteLine(player);
                        // Console.WriteLine(boss);
                        // Console.WriteLine("player wins!");
                        // Console.WriteLine();
                        return;
                    }

                    TakeTurn(
                        new GameState(
                            player with { Mana = player.Mana - spell.Cost, HitPoints = player.HitPoints + 2 },
                            boss with { HitPoints = boss.HitPoints - 2 },
                            shieldDuration, poisonDuration, rechargeDuration,
                            !isPlayersTurn,
                            manaCost + spell.Cost, winner, spells.Concat(new List<string> { spell.Name }).ToList()), partTwo);
                }

                if (spell.Name == "Shield")
                {
                    // only cast it if it's not already active
                    if (shieldDuration <= 0)
                    {
                        if (boss.HitPoints <= 0)
                        {
                            winner = player;

                            PossibleGameStates.Add(
                                new GameState(
                                    player with { Mana = player.Mana - spell.Cost },
                                    boss,
                                    6,
                                    poisonDuration, rechargeDuration, !isPlayersTurn, manaCost + spell.Cost,
                                    winner, spells.Concat(new List<string> { spell.Name }).ToList()));

                            // Console.WriteLine(player);
                            // Console.WriteLine(boss);
                            // Console.WriteLine("player wins!");
                            // Console.WriteLine();
                            return;
                        }

                        TakeTurn(
                            new GameState(
                                player with { Mana = player.Mana - spell.Cost },
                                boss,
                                6,
                                poisonDuration, rechargeDuration, !isPlayersTurn, manaCost + spell.Cost,
                                winner, spells.Concat(new List<string> { spell.Name }).ToList()), partTwo);
                    }
                }

                if (spell.Name == "Poison")
                {
                    // only cast it if it's not already active
                    if (poisonDuration <= 0)
                    {
                        if (boss.HitPoints <= 0)
                        {
                            winner = player;

                            PossibleGameStates.Add(
                                new GameState(
                                    player with { Mana = player.Mana - spell.Cost }, boss, shieldDuration, 6, rechargeDuration,
                                    !isPlayersTurn, manaCost + spell.Cost,
                                    winner, spells.Concat(new List<string> { spell.Name }).ToList()));

                            // Console.WriteLine(player);
                            // Console.WriteLine(boss);
                            // Console.WriteLine("player wins!");
                            // Console.WriteLine();
                            return;
                        }

                        TakeTurn(
                            new GameState(
                                player with { Mana = player.Mana - spell.Cost }, boss, shieldDuration, 6, rechargeDuration,
                                !isPlayersTurn, manaCost + spell.Cost,
                                winner, spells.Concat(new List<string> { spell.Name }).ToList()), partTwo);
                    }
                }

                if (spell.Name == "Recharge")
                {
                    // only cast it if it's not already active
                    if (rechargeDuration <= 0)
                    {
                        if (boss.HitPoints <= 0)
                        {
                            winner = player;

                            PossibleGameStates.Add(
                                new GameState(
                                    player with { Mana = player.Mana - spell.Cost }, boss, shieldDuration, poisonDuration, 5,
                                    !isPlayersTurn, manaCost + spell.Cost,
                                    winner, spells.Concat(new List<string> { spell.Name }).ToList()));

                            // Console.WriteLine(player);
                            // Console.WriteLine(boss);
                            // Console.WriteLine("player wins!");
                            // Console.WriteLine();
                            return;
                        }

                        TakeTurn(
                            new GameState(
                                player with { Mana = player.Mana - spell.Cost }, boss, shieldDuration, poisonDuration, 5,
                                !isPlayersTurn, manaCost + spell.Cost,
                                winner, spells.Concat(new List<string> { spell.Name }).ToList()), partTwo);
                    }
                }
            }
        }

        if (attacker == boss)
        {
            var damage = attacker.Damage - defender.Armor;
            player = player with { HitPoints = player.HitPoints - damage };

            if (player.HitPoints <= 0)
            {
                // PossibleGameStates.Add(
                //     new GameState(
                //         player, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn, manaCost, winner,
                //         spells));

                // Console.WriteLine(player);
                // Console.WriteLine(boss);
                // Console.WriteLine("boss wins!");
                // Console.WriteLine();
                return;
            }

            TakeTurn(
                new GameState(
                    player, boss, shieldDuration, poisonDuration, rechargeDuration, !isPlayersTurn, manaCost, winner, spells), partTwo);
        }
    }

    public static int Part2()
    {
        // HACK: do this a better way... this is bad
        PossibleGameStates.Clear();

        var gameState = GetInitialGameState();

        TakeTurn(gameState, true);

        var playerWins = PossibleGameStates.Count(x => x.Winner!.Name == "Player");
        var bossWins = PossibleGameStates.Count(x => x.Winner!.Name == "Boss");

        // Console.WriteLine($"Player Wins: {playerWins}, Boss Wins: {bossWins}");

        return playerWins > 0
            ? PossibleGameStates
                .Where(x => x.Winner!.Name == "Player")
                .Min(x => x.ManaCost)
            : -1;
    }

    private static Player CreateBoss()
    {
        var input = File.ReadAllLines("Day22/day22.txt")
            .Select(line => int.Parse(line.Split(": ")[1])).ToArray();

        var hitPoints = input[0];
        var damage = input[1];

        return new Player("Boss", hitPoints, damage, 0, 0);
    }
}
