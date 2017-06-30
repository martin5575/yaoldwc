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
    public class SeasonLoader
    {
        private readonly DoubleCachedLoader<LeagueSeasonKey,IEnumerable<Match>> _cache; 

        private SeasonLoader()
        {
            _cache = new DoubleCachedLoader<LeagueSeasonKey,IEnumerable<Match>>(GetPath, LoadRemoteAsync);
        }

        public static SeasonLoader Instance => new SeasonLoader();

        public async Task<IEnumerable<Match>> LoadMatchesAsync(string leagueKey, string seasonKey)
        {
            var key = new LeagueSeasonKey(leagueKey, seasonKey);
            return await _cache.GetFromCacheOrLoadAsync(key);
        }

        private static async Task<IEnumerable<Match>> LoadRemoteAsync(LeagueSeasonKey key)
        {
            var adapter = new OpenLigaAdapter();
            var matchs = await adapter.GetMatchesAsync(key.League, key.Season);
            return matchs;
        }

        private static string GetPath(LeagueSeasonKey key)
        {
            return Path.Combine(Constants.DataFolder, key.League, key.Season, Constants.MatchsFile);
        }
    }
}
