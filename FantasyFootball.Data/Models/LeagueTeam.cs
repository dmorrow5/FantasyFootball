using System;
using System.Collections.Generic;

namespace FantasyFootball.Data.Models
{
    public partial class LeagueTeam
    {
        public LeagueTeam()
        {
            BasePlayer = new HashSet<BasePlayer>();
            Player = new HashSet<Player>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BasePlayer> BasePlayer { get; set; }
        public virtual ICollection<Player> Player { get; set; }
    }
}
