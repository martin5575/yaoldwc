using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLigaApi
{
    public class Match
    {
        public int MatchID { get; set; }
        public int LeagueId { get; set; }

        public DateTime MatchDateTime { get; set; }
        public string TimeZoneID {get; set;}
        public string MatchDateTimeUTC { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public DateTime LastUpdateDateTime {get; set;}

        public Location Location {get; set;}
        public bool MatchIsFinished {get; set;}
        public string NumberOfViewers {get; set;}

        public Goal[] Goals {get; set;}

        public Group Group {get; set;}

        public MatchResult[] MatchResults{get; set;}


    }
}