using System.Collections.Generic;

namespace FootballEstimate.Model
{
    public interface ILeagueAndSeasonInfoService
    {
        void SaveFile();
        string GetName(string key);
        LeagueAndSeasonInfo AddOrUpdateName(string key, string name);
        List<LeagueAndSeasonInfo> GetAllLeagueInfo();
        string GetSeasonName(string leagueKey, string seasonKey);
        void AddOrUpdateSeasonName(string leagueKey, string seasonKey, string name);
    }
}