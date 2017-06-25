using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model.Loader
{
    public class LeagueSeasonKey
    {
        public LeagueSeasonKey(string league, string season)
        {
            League = league;
            Season = season;
        }

        public string Season { get; }
        public string League { get; }

        public override bool Equals(object obj)
        {
            var other = obj as LeagueSeasonKey;
            if (obj == null) return false;
            if (League != other.League) return false;
            if (Season != other.Season) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return Season.GetHashCode() ^ League.GetHashCode();
        }
    }
}
