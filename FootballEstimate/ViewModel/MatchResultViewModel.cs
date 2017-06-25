using GalaSoft.MvvmLight;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel
{
    public class MatchResultViewModel : ViewModelBase
    {
        private MatchResult _matchResult;

        public static MatchResultViewModel FromMatchResult(MatchResult matchResult)
        {
            return new MatchResultViewModel() { _matchResult = matchResult };
        }

        public static IEnumerable<MatchResultViewModel> FromMatchResults(MatchResult[] matchResults)
        {
            return matchResults.Select(FromMatchResult);
        }

        public int? PointsTeam1 => _matchResult?.PointsTeam1;
        public int? PointsTeam2 => _matchResult?.PointsTeam2;
        public string ResultDescription => _matchResult?.ResultDescription;
        public int? ResultID => _matchResult?.ResultID;
        public string ResultName => _matchResult?.ResultName;
        public int? ResultOrderID => _matchResult?.ResultOrderID;
        public int? ResultTypeID => _matchResult?.ResultTypeID;

        public string DisplayString => $"{PointsTeam1.GetValueOrDefault(0)}:{PointsTeam1.GetValueOrDefault(1)}";
    }
}
