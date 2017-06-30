using GalaSoft.MvvmLight;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel
{
    public class GoalViewModel : ViewModelBase
    {
        private Goal _goal;

        public static GoalViewModel FromGoal(Goal goal)
        {
            return new GoalViewModel() { _goal = goal };
        }

        public static IEnumerable<GoalViewModel> FromGoals(Goal[] goals)
        {
            return goals.Select(FromGoal);
        }

        public string Comment => _goal?.Comment;
        public int? GoalGetterID => _goal?.GoalGetterID;
        public string GoalGetterName => _goal?.GoalGetterName;
        public int? GoalID => _goal?.GoalID;
        public bool IsOvertime => _goal?.IsOvertime ?? false;
        public bool IsOwnGoal => _goal?.IsOwnGoal ?? false;
        public bool IsPenalty => _goal?.IsPenalty ?? false;
        public int? MatchMinute => _goal?.MatchMinute;
        public int? ScoreTeam1 => _goal?.ScoreTeam1;
        public int? ScoreTeam2 => _goal?.ScoreTeam2;

        public string GoalProperties => string.Join(", ",
            new []{ IsOvertime ? "OT" : string.Empty,
                IsOwnGoal ? "OG" : string.Empty,
                IsPenalty ? "P" : string.Empty }.Where(x=>!string.IsNullOrEmpty(x)) );
    }
}
