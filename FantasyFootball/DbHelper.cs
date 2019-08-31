using FantasyFootball.Data;
using FantasyFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFootball
{
    public static class DbHelper
    {
        public static List<Player> GetPlayers()
        {
            using (var context = new FantasyFootballContext())
            {
                return context.Player.ToList();
            }
        }

        public static List<SportsTeam> GetTeams()
        {
            using (var context = new FantasyFootballContext())
            {
                return context.SportsTeam.ToList();
            }
        }

        public static void AddPlayer(BasePlayer player)
        {
            using (var context = new FantasyFootballContext())
            {
                context.BasePlayer.Add(player);
                context.SaveChanges();
            }
        }

        public static void AddTeam(SportsTeam sportsTeam)
        {
            using (var context = new FantasyFootballContext())
            {
                context.SportsTeam.Add(sportsTeam);
                context.SaveChanges();
            }
        }

        public static void ClearDatabase()
        {
            using (var context = new FantasyFootballContext())
            {
                context.BasePlayer.RemoveRange(context.BasePlayer.ToList());
                context.Player.RemoveRange(context.Player.ToList());
                //context.SportsTeam.RemoveRange(context.SportsTeam.ToList());
                context.SaveChanges();
            }
        }

        public static void TestDatabase()
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
                        Console.WriteLine("Adding a new Player");
                        BasePlayer newPlayer = new BasePlayer();

                        Console.Write("League Team: ");
                        newPlayer.LeagueTeam = GetLeagueId(Console.ReadLine());

                        Console.Write("Name: ");
                        newPlayer.Name = Console.ReadLine();

                        Console.Write("Team: ");
                        newPlayer.Team = GetTeamId(Console.ReadLine());

                        Console.Write("Position: ");
                        newPlayer.Position = (int)PositionToEnum(Console.ReadLine());

                        Console.Write("Status: ");
                        newPlayer.Status = Console.ReadLine();

                        Console.Write("Bye Week: ");
                        newPlayer.Bye = int.Parse(Console.ReadLine());

                        Console.Write("Fantasy Points: ");
                        newPlayer.FanPts = double.Parse(Console.ReadLine());

                        switch ((Position)newPlayer.Position)
                        {
                            case Position.QB:
                            case Position.WR:
                            case Position.RB:
                            case Position.TE:
                                Console.Write("Passing Yards (Yds): ");
                                newPlayer.PassingYards = int.Parse(Console.ReadLine());

                                Console.Write("Passing Touchdowns (TD): ");
                                newPlayer.PassingTouchdowns = int.Parse(Console.ReadLine());

                                Console.Write("Interceptions (Int): ");
                                newPlayer.PassingInterceptions = int.Parse(Console.ReadLine());

                                Console.Write("Rushing Attempts (Att): ");
                                newPlayer.RushingAttempts = int.Parse(Console.ReadLine());

                                Console.Write("Rushing Yards (Yds): ");
                                newPlayer.RushingYards = int.Parse(Console.ReadLine());

                                Console.Write("Rushing Touchdowns (TD): ");
                                newPlayer.RushingTouchdowns = int.Parse(Console.ReadLine());

                                Console.Write("Targets (Tgt): ");
                                newPlayer.Targets = int.Parse(Console.ReadLine());

                                Console.Write("Receptions (Rec): ");
                                newPlayer.Receptions = int.Parse(Console.ReadLine());

                                Console.Write("Receiving Yards (Yds): ");
                                newPlayer.ReceivingYards = int.Parse(Console.ReadLine());

                                Console.Write("Receiving Touchdowns (TD): ");
                                newPlayer.ReceivingTouchdowns = int.Parse(Console.ReadLine());

                                Console.Write("Return Touchdowns (TD): ");
                                newPlayer.ReturnTouchdowns = int.Parse(Console.ReadLine());

                                Console.Write("2 Point Conversions (2PT): ");
                                newPlayer.TwoPointConversions = int.Parse(Console.ReadLine());

                                Console.Write("Fumbles Lost (LOST): ");
                                newPlayer.Fumbles = int.Parse(Console.ReadLine());
                                break;

                            case Position.K:
                                Console.Write("0-19: ");
                                newPlayer.FieldGoals019 = int.Parse(Console.ReadLine());

                                Console.Write("20-29: ");
                                newPlayer.FieldGoals2029 = int.Parse(Console.ReadLine());

                                Console.Write("30-39: ");
                                newPlayer.FieldGoals3039 = int.Parse(Console.ReadLine());

                                Console.Write("40-49: ");
                                newPlayer.FieldGoals4049 = int.Parse(Console.ReadLine());

                                Console.Write("50+: ");
                                newPlayer.FieldGoals50 = int.Parse(Console.ReadLine());

                                Console.Write("Made: ");
                                newPlayer.Made = int.Parse(Console.ReadLine());
                                break;

                            case Position.DEF:
                                Console.Write("Points Allowed (Pts vs.): ");
                                newPlayer.PointsAllowed = int.Parse(Console.ReadLine());

                                Console.Write("Sack: ");
                                newPlayer.Sack = int.Parse(Console.ReadLine());

                                Console.Write("Safety (Safe): ");
                                newPlayer.Safety = int.Parse(Console.ReadLine());

                                Console.Write("Interceptions (Int): ");
                                newPlayer.Interceptions = int.Parse(Console.ReadLine());

                                Console.Write("Fumble Recovery (Fum Rec): ");
                                newPlayer.FumbleRecovery = int.Parse(Console.ReadLine());

                                Console.Write("Touchdowns (TD): ");
                                newPlayer.Touchdowns = int.Parse(Console.ReadLine());

                                Console.Write("Block Kick (Blk Kick): ");
                                newPlayer.BlockKick = int.Parse(Console.ReadLine());

                                Console.Write("Kickoff and Punt Return Touchdowns (TD): ");
                                newPlayer.KickoffAndPuntReturnTouchdown = int.Parse(Console.ReadLine());
                                break;
                        }

                        AddPlayer(newPlayer);
                        break;
                    case 2:
                        Console.WriteLine("Adding a new Team");
                        var newTeam = new SportsTeam();

                        Console.Write("Name: ");
                        newTeam.Name = Console.ReadLine();

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

        private static Guid GetLeagueId(string team)
        {
            Guid leagueTeamId = Constants.UnassignedTeamId;

            using (var context = new FantasyFootballContext())
            {
                leagueTeamId = context.LeagueTeam.FirstOrDefault(sportsTeam =>
                sportsTeam.Name.Contains(team, StringComparison.OrdinalIgnoreCase) ||
                team.Contains(sportsTeam.Name, StringComparison.OrdinalIgnoreCase))
                .Id;
            }

            return leagueTeamId;
        }

        private static Guid? GetTeamId(string team)
        {
            using (var context = new FantasyFootballContext())
            {
                return context.SportsTeam.FirstOrDefault(sportsTeam => 
                sportsTeam.Name.Contains(team, StringComparison.OrdinalIgnoreCase) || 
                team.Contains(sportsTeam.Name, StringComparison.OrdinalIgnoreCase))
                ?.Id;
            }
        }

        private static Position PositionToEnum(string position)
        {
            switch (position.ToUpper())
            {
                case "QB":
                    return Position.QB;
                case "WR":
                    return Position.WR;
                case "RB":
                    return Position.RB;
                case "TE":
                    return Position.TE;
                case "K":
                    return Position.K;
                case "DEF":
                    return Position.DEF;
                default:
                    return Position.Unknown;
            }
        }
    }
}
