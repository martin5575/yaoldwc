using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEstimate.Model.Data;
using OpenLigaApi;
using FootballEstimate.Model.Stats;

namespace FootballEstimate.Model.StatsAndProbs
{
    public class StatsAndProbService : IStatsAndProbService
    {
        public IEnumerable<TeamStats> CalculateStats(IEnumerable<Match> matches)
        {
            return new TeamStatsCalculator().CalculateStats(matches);
        }
    }
}
