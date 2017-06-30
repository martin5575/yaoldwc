using FootballEstimate.Model.Loader;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model.Loader
{
    public class TeamLoader
    {
        private readonly DoubleCachedLoader<LeagueSeasonKey,IEnumerable<Team>> _cache; 

        private TeamLoader()
        {
            _cache = new DoubleCachedLoader<LeagueSeasonKey,IEnumerable<Team>>(GetPath, LoadRemoteAsync);
        }

        public static TeamLoader Instance => new TeamLoader();

        public async Task<IEnumerable<Team>> LoadTeamsAsync(string leagueKey, string seasonKey)
        {
            var key = new LeagueSeasonKey(leagueKey, seasonKey);
            return await _cache.GetFromCacheOrLoadAsync(key);
        }

        private static async Task<IEnumerable<Team>> LoadRemoteAsync(LeagueSeasonKey key)
        {
            var adapter = new OpenLigaAdapter();
            var teams = await adapter.GetTeamsAsync(key.League, key.Season);
            return teams;
        }

        private static string GetPath(LeagueSeasonKey key)
        {
            return Path.Combine(Constants.DataFolder, key.League, key.Season, Constants.TeamsFile);
        }
    }
}
