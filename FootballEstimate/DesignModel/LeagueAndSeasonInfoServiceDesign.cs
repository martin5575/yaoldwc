using FootballEstimate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.DesignModel
{
    class LeagueAndSeasonInfoServiceDesign : ILeagueAndSeasonInfoService
    {
        public LeagueAndSeasonInfo AddOrUpdateName(string key, string name)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateSeasonName(string leagueKey, string seasonKey, string name)
        {
            throw new NotImplementedException();
        }

        public List<LeagueAndSeasonInfo> GetAllLeagueInfo()
        {
            return new List<LeagueAndSeasonInfo>
            {
                new LeagueAndSeasonInfo (new LeagueInfo("bl","1. Bundesliga"))
                { Seasons =
                    {
                        new SeasonInfo("2017","2017/2018")
                    } }
            };
        }

        public string GetName(string key)
        {
            return "1. Bundesliga";
        }

        public string GetSeasonName(string leagueKey, string seasonKey)
        {
            return "2016/2017";
        }

        public void SaveFile()
        {
            throw new NotImplementedException();
        }
    }
}
