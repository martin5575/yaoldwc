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
        public int GoalGetterID {get; set;}
        public string GoalGetterName {get; set;}
        public int GoalID {get; set;}
        public bool IsOvertime {get; set;}
        public bool IsOwnGoal {get; set;}
        public bool IsPenalty {get; set;}
        public int? MatchMinute {get; set;}
        public int ScoreTeam1 {get; set;}
        public int ScoreTeam2 {get; set;}
    }
}
