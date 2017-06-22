using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    public class TeamLoader
    {
        private TeamLoader()
        { }

        public static TeamLoader Instance => new TeamLoader();

        private readonly Dictionary<Tuple<string, string>, IEnumerable<Team>> _cache = 
            new Dictionary<Tuple<string, string>, IEnumerable<Team>>();

        public async Task<IEnumerable<Team>> LoadTeamsAsync(string leagueKey, string seasonKey)
        {
            var key = new Tuple<string,string>(leagueKey, seasonKey);
            IEnumerable<Team> teams;
            if (_cache.TryGetValue(key, out teams))
                return await Task.FromResult(teams);

            var path = Path.Combine(Constants.DataFolder, leagueKey, seasonKey);
            teams = SettingsReader.ReadData<IEnumerable<Team>>(path, Constants.TeamsFile);
            if (teams != null)
            {
                _cache.Add(key, teams);
                return await Task.FromResult(teams);
            }

            var adapter = new OpenLigaAdapter();
            teams = await adapter.GetTeamsAsync(leagueKey, seasonKey);
            SettingsReader.WriteData(path, Constants.TeamsFile, teams);
            _cache.Add(key, teams);
            return teams;
        }
    }
}
