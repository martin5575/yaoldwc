using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using FootballEstimate.Model;
using FootballEstimate.ViewModel.Messages;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace FootballEstimate.ViewModel
{
    public class LeagueViewModel : ViewModelBase, ICloneable
    {
        IOpenLigaService _openLigaService;
        public LeagueViewModel(IOpenLigaService openLigaService)
        {
            _openLigaService = openLigaService;
        }

        #region Buttons for PopUp
        public RelayCommand<Window> OkCommand => new RelayCommand<Window>(DoOk,CanDoOk);

        private bool CanDoOk(Window arg)
        {
            return !string.IsNullOrWhiteSpace(LeagueKey) 
                && !string.IsNullOrWhiteSpace(SeasonKey);
        }

        private void DoOk(Window arg)
        {
            LeagueAndSeasonInfoService.Instance.SaveFile();
            arg.DialogResult = true;
        }
        #endregion

        #region Buttons on Card
        public ICommand LoadTeams => new RelayCommand(LoadTeamsActionAsync);

        private async void LoadTeamsActionAsync()
        {
            var teamsViewModel = ServiceLocator.Current.GetInstance<TeamsOfLeagueViewModel>();
            var task = teamsViewModel.LoadTeamsAsync(this);

            var label = $"Teams-{ShortDisplayName}";
            var tooltip = $"Teams of {LongDisplayName}";
            var tabViewModel = new TabItemViewModel(label, label, tooltip, teamsViewModel, true);
            var tabMessage = new TabMessage
            {
                ViewModel = tabViewModel,
                Action = TabMessageAction.Create,
            };

            await task;
            this.MessengerInstance.Send(tabMessage);
        }

        public ICommand EditSeason => new RelayCommand(EditSeasonAction);

        public void EditSeasonAction()
        {
            var old = (LeagueViewModel)this.Clone();
            var message = new ModalDialogMessage { ViewModel = this };
            this.MessengerInstance.Send(message);
            if (message.DialogResult != true)
            {
                //int index = Leagues.IndexOf(SelectedLeague);
                //Leagues[index] = old;
                //SelectedLeague = old;
                this.LeagueKey = old.LeagueKey;
                this.LeagueName = old.LeagueName;
                this.SeasonKey = old.SeasonKey;
                this.SeasonName = old.SeasonName;
            }
        }

        public ICommand OpenSeason => new RelayCommand(OpenSeasonActionAsync);

        public async void OpenSeasonActionAsync()
        {
            var league = this;
            var matchs = await _openLigaService.LoadMatchesAsync(league.LeagueKey, league.SeasonKey);
            var matchViewModels = MatchViewModel.FromMatchs(matchs);
            var seasonViewModel = SeasonViewModel.From(matchViewModels, league.LeagueKey, league.SeasonKey);
            var tabViewModel = new TabItemViewModel(league.ShortDisplayName,
                league.ShortDisplayName, league.LongDisplayName,
                seasonViewModel, true);

            var message = new TabMessage { Action=TabMessageAction.Create, ViewModel = tabViewModel };
            this.MessengerInstance.Send(message);
        }

        public ICommand RemoveSeason => new RelayCommand(RemoveSeasonAction);

        public void RemoveSeasonAction()
        {
            var dialogService = SimpleIoc.Default.GetInstance<IDialogService>();
            dialogService.ShowError("Not implemented yet.", "Error", "OK", null);
        }

        #endregion


        #region properties 
        private string _LeagueKey;
        public string LeagueKey
        {
            get { return _LeagueKey; }
            set
            {
                _LeagueKey = value;
                this.RaisePropertyChanged(nameof(LeagueKey));
            }
        }

        private string _LeagueName;
        public string LeagueName
        {
            get { return _LeagueName; }
            set
            {
                _LeagueName = value;
                this.RaisePropertyChanged(nameof(LeagueName));
            }
        }

        private string _SeasonKey;
        public string SeasonKey
        {
            get { return _SeasonKey; }
            set
            {
                _SeasonKey = value;
                this.RaisePropertyChanged(nameof(SeasonKey));
            }
        }

        private string _SeasonName;

        public static LeagueViewModel Create(LeagueInfo league, SeasonInfo season)
        {
            return new LeagueViewModel(SimpleIoc.Default.GetInstance<IOpenLigaService>())
            {
                LeagueKey = league.Key,
                LeagueName = league.Name,
                SeasonKey = season.Key,
                SeasonName = season.Name
            };
        }

        public string SeasonName
        {
            get { return _SeasonName; }
            set
            {
                _SeasonName = value;
                this.RaisePropertyChanged(nameof(SeasonName));
            }
        }
        #endregion


        public string LongDisplayName => $"{_LeagueName??_LeagueKey}({_SeasonName??_SeasonKey})";
        public string ShortDisplayName => $"{_LeagueKey}({_SeasonKey})";


        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);

            if (propertyName==nameof(LeagueKey))
            {
                var name = LeagueAndSeasonInfoService.Instance.GetName(LeagueKey);
                if (name != null)
                    LeagueName = name;
            }

                if (propertyName == nameof(LeagueName) && 
                !string.IsNullOrWhiteSpace(LeagueKey))
            {
                var name = LeagueAndSeasonInfoService.Instance.GetName(LeagueKey);
                if (string.IsNullOrEmpty(name))
                    LeagueAndSeasonInfoService.Instance.AddOrUpdateName(LeagueKey, LeagueName);
            }

            if (propertyName == nameof(SeasonKey))
            {
                var name = LeagueAndSeasonInfoService.Instance.GetSeasonName(LeagueKey,SeasonKey);
                if (name != null)
                    SeasonName = name;
            }

            if (propertyName == nameof(SeasonName) &&
                !string.IsNullOrWhiteSpace(SeasonKey))
            {
                var name = LeagueAndSeasonInfoService.Instance.GetSeasonName(LeagueKey,SeasonKey);
                if (name == null)
                    LeagueAndSeasonInfoService.Instance.AddOrUpdateSeasonName(LeagueKey, SeasonKey, SeasonName);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
