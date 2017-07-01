using FootballEstimate.Model.Data;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model.Stats
{
    public class TeamStatsCalculator
    {
        public IEnumerable<TeamStats> CalculateStats(IEnumerable<Match> matchs)
        {
            var scores = CalculateScores(matchs);

            //int goalsForHomeSume = scores.Sum(x => x.GoalsForHome);
            //int goalsForAwaySum = scores.Sum(x => x.GoalsForAway);
            int goalsAgainstHomeSum = scores.Sum(x => x.GoalsAgainstHome);
            int goalsAgainstAwaySum = scores.Sum(x => x.GoalsAgainstAway);
            int goalsAgainstTotalSum = goalsAgainstAwaySum + goalsAgainstHomeSum;

            double goalsAgainstHomeAvg = goalsAgainstHomeSum / (double)scores.Count;
            double goalsAgainstAwayAvg = goalsAgainstAwaySum / (double)scores.Count;
            double goalsAgainstTotalAvg = goalsAgainstTotalSum / (double)scores.Count;

            return scores.Select(x => new TeamStats
            {
                TeamId = x.TeamId,
                LambdaTotal = x.GoalsForTotal / (double)x.GamesTotal,
                LambdaHome = x.GoalsForHome / (double)x.GamesHome,
                LambdaAway = x.GoalsForAway / (double)x.GamesAway,

                DefenseFactorTotal = x.GoalsAgainstTotal / goalsAgainstTotalAvg,
                DefenseFactorHome = x.GoalsAgainstHome / goalsAgainstHomeAvg,
                DefenseFactorAway = x.GoalsAgainstAway / goalsAgainstAwayAvg,
            });
        }

        private List<TeamScores> CalculateScores(IEnumerable<Match> matchs)
        {
            var scores = new Dictionary<int, TeamScores>();
            foreach (var match in matchs)
            {
                var result = match.MatchResults.OrderBy(x => x.ResultOrderID).LastOrDefault();
                if (result == null)
                    continue;

                TeamScores team1Scores;
                int team1Id = match.Team1.TeamId;
                if (!scores.TryGetValue(team1Id, out team1Scores))
                {
                    team1Scores = new TeamScores { TeamId = team1Id };
                    scores.Add(team1Id, team1Scores);
                }
                team1Scores.AddHomeGame(result.PointsTeam1, result.PointsTeam2);


                TeamScores team2Scores;
                int team2Id = match.Team2.TeamId;
                if (!scores.TryGetValue(team2Id, out team2Scores))
                {
                    team2Scores = new TeamScores { TeamId = team2Id };
                    scores.Add(team2Id, team2Scores);
                }
                team2Scores.AddAwayGame(result.PointsTeam2, result.PointsTeam1);
            }
            return scores.Values.ToList();
        }
    }
}
