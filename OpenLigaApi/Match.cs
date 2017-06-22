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
        public DateTime MatchDateTime { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public string LastUpdateDateTime{get; set;}
        public string LeagueId{get; set;}
        public string Location{get; set;}
        public string MatchDateTimeUTC{get; set;}
        public string MatchIsFinished{get; set;}
        public string NumberOfViewers{get; set;}
        public string TimeZoneID{get; set;}

        public Goal[][] goals{get; set;}

        public Group[] group{get; set;}

        public MatchResult[][] matchResults{get; set;}


    }
}