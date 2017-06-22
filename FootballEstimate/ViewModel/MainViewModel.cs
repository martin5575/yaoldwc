using FootballEstimate.Model;
using FootballEstimate.ViewModel.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using OpenLigaApi;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using FootballEstimate.View;

namespace FootballEstimate.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                this.MessengerInstance.Register<DialogMessage>(this, ShowDialog);
                // Code runs "for real"
                foreach(var league in LeagueAndSeasonInfoManager.Instance.GetAllLeagueInfo())
                    foreach(var season in league.Seasons)
                        Leagues.Add(SeasonLeagueViewModel.Create(league.League, season));
            }
        }

        private void ShowDialog(DialogMessage obj)
        {
            var view = new EditLeagueAndSeasonWindow();
            view.Grid.DataContext = obj.ViewModel;
            obj.DialogResult = view.ShowDialog();
        }

        public RelayCommand LoadTeams => new RelayCommand(LoadTeamsAsync);

        public async void LoadTeamsAsync()
        {
            var league = SelectedLeague; 
            var teams = await TeamLoader.Instance.LoadTeamsAsync(league.LeagueKey, league.SeasonKey);
            Teams.Clear();
            teams.ToList().ForEach(x => Teams.Add(x));
        }


        public RelayCommand AddSeason => new RelayCommand(AddSeasonAction);

        public void AddSeasonAction()
        {
            var vm = new SeasonLeagueViewModel();
            var message = new DialogMessage { ViewModel = vm };
            this.MessengerInstance.Send(message);
            if (message.DialogResult == true)
                Leagues.Add(vm);
        }

        public RelayCommand EditSeason => new RelayCommand(EditSeasonAction,CanEditSeason);

        private bool CanEditSeason()
        {
            return SelectedLeague!=null;
        }

        public void EditSeasonAction()
        {
            var old = (SeasonLeagueViewModel)SelectedLeague.Clone();
            var message = new DialogMessage { ViewModel = SelectedLeague };
            this.MessengerInstance.Send(message);
            if (message.DialogResult != true)
            {
                int index = Leagues.IndexOf(SelectedLeague);
                Leagues[index] = old;
                SelectedLeague = old;
            }
        }

        private ObservableCollection<SeasonLeagueViewModel> _Leagues = new ObservableCollection<SeasonLeagueViewModel>();
        public ObservableCollection<SeasonLeagueViewModel> Leagues
        {
            get { return _Leagues; }
            set {
                _Leagues = value;
                this.RaisePropertyChanged(nameof(Leagues));
            }
        }

        private SeasonLeagueViewModel _SelectedLeague;
        public SeasonLeagueViewModel SelectedLeague
        {
            get { return _SelectedLeague; }
            set
            {
                _SelectedLeague = value;
                this.RaisePropertyChanged(nameof(SelectedLeague));
            }
        }

        private ObservableCollection<Team> _Teams = new ObservableCollection<Team>();
        public ObservableCollection<Team> Teams
        {
            get { return _Teams; }
            set
            {
                _Teams = value;
                this.RaisePropertyChanged(nameof(Teams));
            }
        }


        

    }
}