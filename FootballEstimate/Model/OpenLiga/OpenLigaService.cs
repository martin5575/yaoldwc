using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLigaApi;
using FootballEstimate.Model.Loader;
using FootballEstimate.Model.Data;
using FootballEstimate.Model.OpenLiga.Loader;

namespace FootballEstimate.Model.OpenLiga
{
    class OpenLigaService : IOpenLigaService
    {
        public string Get3LetterCode(int teamId)
        {
            return ThreeLetterCodeLoader.Instance.Get3LetteCode(teamId);
        }

        public void Set3LetterCode(int teamId, string code)
        {
            ThreeLetterCodeLoader.Instance.Set3LetterCode(teamId, code);
        }

        public string GetIconSource(Team team)
        {
            return IconLoader.Instance.GetIconSource(team);
        }

        public Task<IEnumerable<Match>> LoadMatchesAsync(string league, string season)
        {
            return SeasonLoader.Instance.LoadMatchesAsync(league, season);
        }

        public Task<IEnumerable<Team>> LoadTeamsAsync(string league, string season)
        {
            return TeamLoader.Instance.LoadTeamsAsync(league, season);
        }

    }
}
