using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    public class LeagueAndSeasonInfo
    {

        public LeagueAndSeasonInfo(LeagueInfo leagueInfo)
        {
            League = leagueInfo;
            Seasons = new List<SeasonInfo>();
        }

        public LeagueInfo League { get; set; }
        public List<SeasonInfo> Seasons { get; set; }
    }
}
