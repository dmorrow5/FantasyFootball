using System;
using System.Collections.Generic;

namespace FantasyFootball.Data.Models
{
    public partial class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Team { get; set; }
        public int? Position { get; set; }
        public int? Gp { get; set; }
        public int? Bye { get; set; }
        public double? FanPts { get; set; }
        public int? PassingYards { get; set; }
        public int? RushingYards { get; set; }
        public int? ReceivingYards { get; set; }
        public int? Fumbles { get; set; }

        public virtual SportsTeam TeamNavigation { get; set; }
    }
}
