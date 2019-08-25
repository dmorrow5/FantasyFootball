using FantasyFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FantasyFootball
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDatabase();
        }

        private static List<Player> GetPlayers()
        {
            using (var context = new FantasyFootballContext())
            {
                return context.Player.ToList();
            }
        }

        private static List<SportsTeam> GetTeams()
        {
            using (var context = new FantasyFootballContext())
            {
                return context.SportsTeam.ToList();
            }
        }

        private static void AddPlayer(Player player)
        {
            using (var context = new FantasyFootballContext())
            {
                context.Player.Add(player);
                context.SaveChanges();
            }
        }

        private static void AddTeam(SportsTeam sportsTeam)
        {
            using (var context = new FantasyFootballContext())
            {
                context.SportsTeam.Add(sportsTeam);
                context.SaveChanges();
            }
        }

        private static void ClearDatabase()
        {
            using (var context = new FantasyFootballContext())
            {
                context.Player.RemoveRange(context.Player.ToList());
                context.SportsTeam.RemoveRange(context.SportsTeam.ToList());
                context.SaveChanges();
            }
        }

        private static void TestDatabase()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a Player");
                Console.WriteLine("2. Add a Team");
                Console.WriteLine("3. View Database");
                Console.WriteLine("4. Clear Database");
                Console.WriteLine("5. Exit");
                var response = int.Parse(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        var newPlayer = new Player
                        {
                            Id = Guid.NewGuid(),
                            Name = "Player" + (int)(new Random().NextDouble() * 1000),
                            Team = GetTeams().First().Id
                        };
                        AddPlayer(newPlayer);
                        break;
                    case 2:
                        var newTeam = new SportsTeam
                        {
                            Id = Guid.NewGuid(),
                            Name = "Team" + (int)(new Random().NextDouble() * 1000),
                        };
                        AddTeam(newTeam);
                        break;
                    case 3:
                        Console.WriteLine("Players:");
                        foreach (var player in GetPlayers())
                        {
                            Console.WriteLine(player.Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Sports Teams:");
                        foreach (var team in GetTeams())
                        {
                            Console.WriteLine(team.Name);
                        }
                        break;
                    case 4:
                        ClearDatabase();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
