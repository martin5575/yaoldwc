using FootballEstimate.Model;
using GalaSoft.MvvmLight;
using Infrastructure.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel
{
    public class StatsViewModel : ViewModelBase
    {
        IStatsAndProbService _statsAndProbService;
        IOpenLigaService _openLigaService;

        public ObservableCollection<StatsByTeamViewModel> StatsByTeams { get; set; }


        public StatsViewModel(IStatsAndProbService statsAndProbService,
            IOpenLigaService openLigaService)
        {
            _statsAndProbService = statsAndProbService;
            _openLigaService = openLigaService;
            StatsByTeams = new ObservableCollection<StatsByTeamViewModel>();
        }

        public async Task CalulateForAsync(string league, string season)
        {
            var matches = await _openLigaService.LoadMatchesAsync(league, season);
            var teams = await _openLigaService.LoadTeamsAsync(league, season);
            var stats = _statsAndProbService.CalculateStats(matches).ToList();

            var teamLkp = teams.ToLookup(x => x.TeamId);

            stats.Select(x =>
            new StatsByTeamViewModel()
            {
                Team = TeamViewModel.FromTeam(teamLkp[x.TeamId].First()),
                Stats = x
            }).ForEach(StatsByTeams.Add);
        }

    }
}
