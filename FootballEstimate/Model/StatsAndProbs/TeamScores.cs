using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model.Stats
{
    class TeamScores
    {
        public int TeamId { get; set; }

        public int GamesHome { get; set; }
        public int GamesAway { get; set; }
        public int GamesTotal => GamesAway + GamesHome;


        public int GoalsForHome { get; set; }
        public int GoalsForAway { get; set; }
        public int GoalsForTotal => GoalsForAway + GoalsForHome;

        public int GoalsAgainstHome { get; set; }
        public int GoalsAgainstAway { get; set; }
        public int GoalsAgainstTotal => GoalsAgainstAway + GoalsAgainstHome;

        public void AddHomeGame(int goalsFor, int goalsAgainst)
        {
            GamesHome += 1;
            GoalsForHome += goalsFor;
            GoalsAgainstHome += goalsAgainst;
        }

        public void AddAwayGame(int goalsFor, int goalsAgainst)
        {
            GamesAway += 1;
            GoalsForAway += goalsFor;
            GoalsAgainstAway += goalsAgainst;
        }
    }
}
