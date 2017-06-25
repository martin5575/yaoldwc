using FootballEstimate.Model;
using FootballEstimate.ViewModel.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using OpenLigaApi;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using FootballEstimate.View;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using FootballEstimate.Model.Loader;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using FootballEstimate.View.Service;

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
                this.MessengerInstance.Register<ModalDialogMessage>(this, ShowDialog);
                this.MessengerInstance.Register<TabMessage>(this, AddTab);
                // Code runs "for real"
                foreach(var league in LeagueAndSeasonInfoManager.Instance.GetAllLeagueInfo())
                    foreach(var season in league.Seasons)
                        Leagues.Add(SeasonLeagueViewModel.Create(league.League, season));
            }
        }

        private void AddTab(TabMessage tabMessage)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.NavigateTo("Tab", tabMessage.ViewModel);
        }

        private void ShowDialog(ModalDialogMessage modalDialogMessage)
        {
            var modalDialogService = SimpleIoc.Default.GetInstance<IModalDialogService>();
            var dailogResult = modalDialogService.ShowDialog(modalDialogMessage.ViewModel);
            modalDialogMessage.DialogResult = dailogResult;
        }

        public RelayCommand LoadTeams => new RelayCommand(LoadTeamsAsync);

        public async void LoadTeamsAsync()
        {
            var league = SelectedLeague;

            IEnumerable<Team> teams = league==null ? new Team[0] 
                : await TeamLoader.Instance.LoadTeamsAsync(league.LeagueKey, league.SeasonKey);

            Teams.Clear();
            teams.ToList().ForEach(x => Teams.Add(x));
        }


        public RelayCommand AddSeason => new RelayCommand(AddSeasonAction);

        public void AddSeasonAction()
        {
            var vm = new SeasonLeagueViewModel();
            var message = new ModalDialogMessage { ViewModel = vm };
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
            var message = new ModalDialogMessage { ViewModel = SelectedLeague };
            this.MessengerInstance.Send(message);
            if (message.DialogResult != true)
            {
                int index = Leagues.IndexOf(SelectedLeague);
                Leagues[index] = old;
                SelectedLeague = old;
            }
        }

        public RelayCommand OpenSeason => new RelayCommand(OpenSeasonActionAsync, CanOpenSeason);

        private bool CanOpenSeason()
        {
            return SelectedLeague != null;
        }

        public async void OpenSeasonActionAsync()
        {
            var league = SelectedLeague;
            var matchs = await SeasonLoader.Instance.LoadMatchsAsync(league.LeagueKey, league.SeasonKey);
            var matchViewModels = MatchViewModel.FromMatchs(matchs);
            var seasonViewModel = SeasonViewModel.From(matchViewModels);

            // work with Observable Collection instead. Bind like in https://csharp.christiannagel.com/2016/12/19/tabcontrolwpf/
            var message = new TabMessage { ViewModel = seasonViewModel };
            this.MessengerInstance.Send(message);
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


        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            if (propertyName == nameof(SelectedLeague))
                this.LoadTeamsAsync();
        }

    }
}