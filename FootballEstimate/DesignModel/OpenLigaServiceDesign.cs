using FootballEstimate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLigaApi;
using System.IO;

namespace FootballEstimate.DesignModel
{
    public class OpenLigaServiceDesign : IOpenLigaService
    {
        static readonly Team Team1 = new Team { ShortName = "1FC", TeamName = "1.FC Köln", TeamId = 1 };
        static readonly Team Team2 = new Team { ShortName = "FCB", TeamName = "FC Bayern München", TeamId = 2 };
        static readonly Team Team3 = new Team { ShortName = "BVB", TeamName = "Borussia Dortmund", TeamId = 3 };
        static readonly Team Team4 = new Team { ShortName = "SGE", TeamName = "Eintracht Frankfurt", TeamId = 4 };

        static readonly Group Group1 = new Group { GroupID = 1, GroupName = "1. Spieltag", GroupOrderID = 1 };
        static readonly Group Group2 = new Group { GroupID = 2, GroupName = "2. Spieltag", GroupOrderID = 2 };
        static readonly Group Group3 = new Group { GroupID = 3, GroupName = "3. Spieltag", GroupOrderID = 3 };

        static readonly Location Location1 = new Location { LocationID = 1, LocationCity = "Köln", LocationStadium = "Rheinenergie Stadion" };
        static readonly Location Location2 = new Location { LocationID = 2, LocationCity = "München", LocationStadium = "Allianzarena" };
        static readonly Location Location3 = new Location { LocationID = 3, LocationCity = "Dortmund", LocationStadium = "Signal Iduna Park" };
        static readonly Location Location4 = new Location { LocationID = 4, LocationCity = "Frankfurt", LocationStadium = "Commerzbankarena" };

        public static MatchResult[] CreateMatchResults(int idFull, int team1Full, int team2Full, int idHalf, int team1Half, int team2Half)
        {
            return new MatchResult[]
            {
                new MatchResult {
                    ResultID = idFull,
                    PointsTeam1 =team1Full,PointsTeam2=team2Full,
                    ResultDescription ="Beschreibung des Endergebnisses",
                    ResultName = "Endergebnis",
                    ResultOrderID=2,
                    ResultTypeID=1,
                },
                new MatchResult {
                    ResultID = idHalf,
                    PointsTeam1 =team1Half,PointsTeam2=team2Half,
                    ResultDescription ="Beschreibung des Halbzeitergebnisses",
                    ResultName = "Halbzeitergebnis",
                    ResultOrderID=1,
                    ResultTypeID=2,
                }
            };
        }


        public string GetIconSource(Team team)
        {
            return Path.Combine(Environment.CurrentDirectory, "DesignModel", "Icons", team.TeamId + ".gif");
        }

        public Task<IEnumerable<Match>> LoadMatchesAsync(string league, string season)
        {
            IEnumerable<Match> result = new Match[]
            {
                new Match
                {
                    Goals = new []
                    {
                        new Goal {GoalID=1,ScoreTeam1=1,ScoreTeam2=0,GoalGetterID=1,GoalGetterName="Marcel Risse",MatchMinute=5 },
                    },
                    Group = Group1,
                    LastUpdateDateTime = DateTime.Now,
                    Team1 = Team1,
                    Team2 = Team2,
                    Location = Location1,
                    LeagueId = 1,
                    MatchID = 1,
                    MatchIsFinished = true,
                    MatchDateTime = new DateTime(2017,1,1,19,0,0),
                    MatchResults = CreateMatchResults(1,1,0,2,1,0),
                    NumberOfViewers ="40.000",
                },
            };
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Team>> LoadTeamsAsync(string league, string season)
        {
            IEnumerable<Team> result = new[] {Team1, Team2,Team3,Team4};
            return Task.FromResult(result);
        }

        public string Get3LetterCode(int teamId)
        {
            throw new NotImplementedException();
        }

        public void Set3LetterCode(int teamId, string code)
        {
            throw new NotImplementedException();
        }
    }
}
