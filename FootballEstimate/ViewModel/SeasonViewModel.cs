using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Infrastructure.Collections;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using FootballEstimate.ViewModel.Messages;
using Microsoft.Practices.ServiceLocation;

namespace FootballEstimate.ViewModel
{
    public class SeasonViewModel : ViewModelBase
    {
        public SeasonViewModel()
        {
            Groups = new ObservableCollection<GroupViewModel>();
            MatchsOfGroup = new ObservableCollection<MatchViewModel>();
        }

        private string _leagueKey;
        private string _seasonKey;

        public static SeasonViewModel From(IEnumerable<MatchViewModel> matchViewModels, string leagueKey, string seasonKey)
        {
            var season = new SeasonViewModel
            {
                Matchs = matchViewModels.ToList(),
                _leagueKey = leagueKey,
                _seasonKey = seasonKey
            };

            matchViewModels.Select(x => x.Group)
            .Distinct()
            .Where(x=>x.GroupID.HasValue)
            .OrderBy(x => x.GroupOrderID)
            .ForEach(season.Groups.Add);

            season.SelectedGroup = season.Groups.FirstOrDefault();
            return season;
        }

        private List<MatchViewModel> Matchs { get; set; }

        #region Live
        public ICommand LiveCommand => new RelayCommand(ShowLive);
        private void ShowLive() { SimpleIoc.Default.GetInstance<IDialogService>().ShowMessageBox("Show live scores", "Live score"); }
        #endregion

        #region Stats
        public ICommand StatsCommand => new RelayCommand(ShowStatsAsync);
        private async void ShowStatsAsync()
        {
            var statsViewModel = ServiceLocator.Current.GetInstance<StatsViewModel>();
            var task = statsViewModel.CalulateForAsync(_leagueKey, _seasonKey);
            string caption = $"stats-{_leagueKey}-{_seasonKey}";
            string tooltip = "Stats for season ...";
            var tabViewModel = new TabItemViewModel(caption, caption, tooltip, statsViewModel);

            var message = new TabMessage
            {
               Action = TabMessageAction.Create,
               ViewModel = tabViewModel, 
            };
            await task;
            this.MessengerInstance.Send(message);
        }
        #endregion


        #region Model and probs

        public ObservableCollection<GoalModelViewModel> GoalModels { get; set; }

        private GoalModelViewModel _SelectedGoalModel;
        public GoalModelViewModel SelectedGoalModel
        {
            get { return _SelectedGoalModel; }
            set
            {
                _SelectedGoalModel = value;
                RaisePropertyChanged(nameof(SelectedGoalModel));
            }
        }

        #endregion

        #region Groups

        public ObservableCollection<GroupViewModel> Groups { get; set; }

        private GroupViewModel _SelectedGroup;
        public GroupViewModel SelectedGroup
        {
            get { return _SelectedGroup; }
            set
            {
                _SelectedGroup = value;
                RaisePropertyChanged(nameof(SelectedGroup));
            }
        }

        public ICommand Previous => new RelayCommand(GotoPrevious, CanGotPrevious);

        private bool CanGotPrevious()
        {
            return Groups.IndexOf(SelectedGroup) > 0;
        }

        private void GotoPrevious()
        {
            int index = Groups.IndexOf(SelectedGroup);
            SelectedGroup = Groups[index - 1];
        }

        public ICommand Next => new RelayCommand(GotoNext, CanGoNext);

        private bool CanGoNext()
        {
            return Groups.IndexOf(SelectedGroup) < Groups.Count-1;
        }

        private void GotoNext()
        {
            int index = Groups.IndexOf(SelectedGroup);
            SelectedGroup = Groups[index + 1];
        }

        #endregion

        #region matchs for Group

        private ObservableCollection<MatchViewModel> _MatchsOfGroup;
        public ObservableCollection<MatchViewModel> MatchsOfGroup
        {
            get { return _MatchsOfGroup; }
            set
            {
                _MatchsOfGroup = value;
                RaisePropertyChanged(nameof(MatchsOfGroup));
            }
        }

        private MatchViewModel _SelectedMatch;
        public MatchViewModel SelectedMatch
        {
            get { return _SelectedMatch; }
            set
            {
                _SelectedMatch = value;
                RaisePropertyChanged(nameof(SelectedMatch));
            }
        }

        #endregion

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);

            if (propertyName == nameof(SelectedGroup))
                UpdateMatchesForGroup();
        }

        private void UpdateMatchesForGroup()
        {
            int? groupId = SelectedGroup?.GroupID;
            MatchsOfGroup.Clear();
            Matchs.Where(x => x.Group.GroupID == groupId).ForEach(MatchsOfGroup.Add);
        }

    }
}
