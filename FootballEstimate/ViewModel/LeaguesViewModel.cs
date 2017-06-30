using FootballEstimate.Model;
using FootballEstimate.ViewModel.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootballEstimate.ViewModel
{
    public class LeaguesViewModel : ViewModelBase
    {

        private ILeagueAndSeasonInfoService _leagueAndSeasonInfoService;

        public LeaguesViewModel(ILeagueAndSeasonInfoService leagueAndSeasonInfoService)
        {
            _leagueAndSeasonInfoService = leagueAndSeasonInfoService;
            AddAllLeagues();
        }

        public ICommand AddSeason => new RelayCommand(AddSeasonAction);

        public void AddSeasonAction()
        {
            var vm = new LeagueViewModel(SimpleIoc.Default.GetInstance<IOpenLigaService>());
            var message = new ModalDialogMessage { ViewModel = vm };
            this.MessengerInstance.Send(message);
            if (message.DialogResult == true)
                Leagues.Add(vm);
        }

        private void AddAllLeagues()
        {
            foreach (var league in _leagueAndSeasonInfoService.GetAllLeagueInfo())
                foreach (var season in league.Seasons)
                    Leagues.Add(LeagueViewModel.Create(league.League, season));

            if (Leagues.Count > 0)
                SelectedLeague = Leagues[0];
        }

        private ObservableCollection<LeagueViewModel> _Leagues = new ObservableCollection<LeagueViewModel>();
        public ObservableCollection<LeagueViewModel> Leagues
        {
            get { return _Leagues; }
            set
            {
                _Leagues = value;
                this.RaisePropertyChanged(nameof(Leagues));
            }
        }

        private LeagueViewModel _SelectedLeague;
        public LeagueViewModel SelectedLeague
        {
            get { return _SelectedLeague; }
            set
            {
                _SelectedLeague = value;
                this.RaisePropertyChanged(nameof(SelectedLeague));
            }
        }
    }
}
