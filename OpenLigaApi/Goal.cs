using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLigaApi
{
    public class Goal
    {
        public string Comment {get; set;}
        public string GoalGetterID {get; set;}
        public string GoalGetterName {get; set;}
        public string GoalID {get; set;}
        public string IsOvertime {get; set;}
        public string IsOwnGoal {get; set;}
        public string IsPenalty {get; set;}
        public string MatchMinute {get; set;}
        public string ScoreTeam1 {get; set;}
        public string ScoreTeam2 {get; set;}
    }
}
