using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenLigaApi
{
    public interface IOpenLigaAdapter
    {
        Task<IEnumerable<Match>> GetCurrentMatchesAsync(string league);
        Task<IEnumerable<Match>> GetMatchesAsync(string league, string season, int? matchDay = null);
        Task<Match> GetMatchAsync(int matchId);
        Task<DateTime> GetLastChangeDateAsync(string league, string season, int matchDay);
        Task<IEnumerable<Match>> GetCurrentMatchDayAsync(string league);
        Task<IEnumerable<Match>> GetAllMatchDaysAsync(string league, string season);
        Task<IEnumerable<Match>> GetNextMatchForTeamAsync(string leagueId, string teamId);
        Task<IEnumerable<Team>> GetTeamsAsync(string league, string season);
    }
}