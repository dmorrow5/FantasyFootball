using System;
using System.Collections.Generic;

namespace FantasyFootball.Data.Models
{
    public partial class BasePlayer
    {
        public Guid Id { get; set; }
        public Guid LeagueTeam { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Guid? Team { get; set; }
        public int Position { get; set; }
        public int? Bye { get; set; }
        public double? FanPts { get; set; }
        public int? PassingYards { get; set; }
        public int? PassingTouchdowns { get; set; }
        public int? PassingInterceptions { get; set; }
        public int? RushingAttempts { get; set; }
        public int? RushingYards { get; set; }
        public int? RushingTouchdowns { get; set; }
        public int? Targets { get; set; }
        public int? Receptions { get; set; }
        public int? ReceivingYards { get; set; }
        public int? ReceivingTouchdowns { get; set; }
        public int? ReturnTouchdowns { get; set; }
        public int? TwoPointConversions { get; set; }
        public int? Fumbles { get; set; }
        public int? FieldGoals019 { get; set; }
        public int? FieldGoals2029 { get; set; }
        public int? FieldGoals3039 { get; set; }
        public int? FieldGoals4049 { get; set; }
        public int? FieldGoals50 { get; set; }
        public int? Made { get; set; }
        public int? PointsAllowed { get; set; }
        public int? Sack { get; set; }
        public int? Safety { get; set; }
        public int? Interceptions { get; set; }
        public int? FumbleRecovery { get; set; }
        public int? Touchdowns { get; set; }
        public int? BlockKick { get; set; }
        public int? KickoffAndPuntReturnTouchdown { get; set; }

        public virtual LeagueTeam LeagueTeamNavigation { get; set; }
        public virtual SportsTeam TeamNavigation { get; set; }
        public virtual Player Player { get; set; }
    }
}
