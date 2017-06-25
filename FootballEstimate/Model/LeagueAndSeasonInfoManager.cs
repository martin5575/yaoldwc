using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    public class LeagueAndSeasonInfoManager
    {
        private readonly Dictionary<string, LeagueAndSeasonInfo> _Dictionary;

        public static readonly LeagueAndSeasonInfoManager Instance;
        
        static LeagueAndSeasonInfoManager()
        {
            Instance = new LeagueAndSeasonInfoManager();
        }

        private LeagueAndSeasonInfoManager()
        {
            var path = Path.Combine(Constants.DataFolder, Constants.LeaguesFile);
            var leagueInfoList = SettingsReader.ReadData<List<LeagueAndSeasonInfo>>(path) 
                ?? new List<LeagueAndSeasonInfo>(); 
            _Dictionary = leagueInfoList.ToDictionary(x => x.League.Key);
        }


        public void SaveFile()
        {
            var leagueInfoList = _Dictionary.Values.ToList();
            var path = Path.Combine(Constants.DataFolder, Constants.LeaguesFile);
            SettingsReader.WriteData(path, leagueInfoList);
        }


        public string GetName(string key)
        {
            LeagueAndSeasonInfo leagueAndSeasonInfo;
            if (_Dictionary.TryGetValue(key, out leagueAndSeasonInfo))
                return leagueAndSeasonInfo.League.Name;
            return null;
        }

        public LeagueAndSeasonInfo AddOrUpdateName(string key, string name)
        {
            LeagueAndSeasonInfo leagueAndSeasonInfo;
            if (!_Dictionary.TryGetValue(key, out leagueAndSeasonInfo))
            {
                var leagueInfo = new LeagueInfo(key, name);
                leagueAndSeasonInfo = new LeagueAndSeasonInfo(leagueInfo);
                _Dictionary.Add(key, leagueAndSeasonInfo);
            }
            else
                leagueAndSeasonInfo.League.Name = name;
            return leagueAndSeasonInfo;
        }

        public List<LeagueAndSeasonInfo> GetAllLeagueInfo()
        {
            return _Dictionary.Values.ToList();
        }

        public string GetSeasonName(string leagueKey, string seasonKey)
        {
            LeagueAndSeasonInfo leagueAndSeasonInfo;
            if (_Dictionary.TryGetValue(leagueKey, out leagueAndSeasonInfo))
                return leagueAndSeasonInfo.Seasons.FirstOrDefault(x=>x.Key==seasonKey)?.Name;
            return null;
        }

        public void AddOrUpdateSeasonName(string leagueKey, string seasonKey, string name)
        {
            LeagueAndSeasonInfo leagueAndSeasonInfo;
            if (!_Dictionary.TryGetValue(leagueKey, out leagueAndSeasonInfo))
                leagueAndSeasonInfo = AddOrUpdateName(leagueKey, null);

            var seasonInfo = leagueAndSeasonInfo.Seasons.FirstOrDefault(x => x.Key == seasonKey);
            if (seasonInfo == null)
            {
                seasonInfo = new SeasonInfo(seasonKey, name);
                leagueAndSeasonInfo.Seasons.Add(seasonInfo);
            }
            else
                seasonInfo.Name = name;

        }
    }
}
