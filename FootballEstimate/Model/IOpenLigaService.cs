using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    public interface IOpenLigaService
    {
        string Get3LetterCode(int teamId);
        void Set3LetterCode(int teamId, string code);
        string GetIconSource(Team team);

        Task<IEnumerable<Match>> LoadMatchesAsync(string league, string season);
        Task<IEnumerable<Team>> LoadTeamsAsync(string league, string season);

        //Task<IEnumerable<Match>> GetCurrentMatchesAsync(string league);
        //Task<IEnumerable<Match>> GetMatchesAsync(string league, string season, int? matchDay = null);
        //Task<Match> GetMatchAsync(int matchId);
        //Task<DateTime> GetLastChangeDateAsync(string league, string season, int matchDay);
        //Task<IEnumerable<Match>> GetCurrentMatchDayAsync(string league);
        //Task<IEnumerable<Match>> GetAllMatchDaysAsync(string league, string season);
        //Task<IEnumerable<Match>> GetNextMatchForTeamAsync(string leagueId, string teamId);
    }
}
