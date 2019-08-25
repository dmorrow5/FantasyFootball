using System;
using System.Collections.Generic;

namespace FantasyFootball.Data.Models
{
    public partial class SportsTeam
    {
        public SportsTeam()
        {
            Player = new HashSet<Player>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Points { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Ties { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
