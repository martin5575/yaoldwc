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

namespace FootballEstimate.ViewModel
{
    public class SeasonViewModel : ViewModelBase
    {
        public SeasonViewModel()
        {
            Groups = new ObservableCollection<GroupViewModel>();
            MatchsOfGroup = new ObservableCollection<MatchViewModel>();
        }

        public static SeasonViewModel From(IEnumerable<MatchViewModel> matchViewModels)
        {
            var season = new SeasonViewModel
            {
                Matchs = matchViewModels.ToList(),
            };

            matchViewModels.Select(x => x.Group)
            .Distinct()
            .Where(x=>x.GroupID.HasValue)
            .OrderBy(x => x.GroupOrderID)
            .ForEach(season.Groups.Add);
            return season;
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


        private List<MatchViewModel> Matchs { get; set; }

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
