using FootballEstimate.Model;
using GalaSoft.MvvmLight;
using Infrastructure.Collections;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel
{
    public class TeamsOfLeagueViewModel : ViewModelBase
    {

        private IOpenLigaService _openLigaService;
        public TeamsOfLeagueViewModel(IOpenLigaService openLigaService)
        {
            _openLigaService = openLigaService;
        }

        private ObservableCollection<TeamViewModel> _Teams = new ObservableCollection<TeamViewModel>();
        public ObservableCollection<TeamViewModel> Teams
        {
            get { return _Teams; }
            set
            {
                _Teams = value;
                this.RaisePropertyChanged(nameof(Teams));
            }
        }

        public async void LoadTeamsAsync(LeagueViewModel league)
        {
            IEnumerable<Team> teams = league == null ? new Team[0]
                : await _openLigaService.LoadTeamsAsync(league.LeagueKey, league.SeasonKey);

            Teams.Clear();
            TeamViewModel.FromTeams(teams).ForEach(x => Teams.Add(x));
        }
    }
}
