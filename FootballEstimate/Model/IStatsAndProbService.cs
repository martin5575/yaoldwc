using FootballEstimate.Model.Data;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    public interface IStatsAndProbService
    {
        IEnumerable<TeamStats> CalculateStats(IEnumerable<Match> matches);
    }
}
