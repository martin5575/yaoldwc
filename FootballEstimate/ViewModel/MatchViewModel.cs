using GalaSoft.MvvmLight;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Collections;

namespace FootballEstimate.ViewModel
{
    public class MatchViewModel : ViewModelBase
    {
        private Match _match;

        public static MatchViewModel FromMatch(Match match)
        {
            var groupViewModel = GroupViewModel.GetOrCreate(match.Group);
            var result = new MatchViewModel
            {
                _match = match,
                _Group = groupViewModel
            };

            GoalViewModel.FromGoals(match.Goals)
                .OrderBy(x=>x.GoalID)
                .ForEach(result.Goals.Add);

            MatchResultViewModel.FromMatchResults(match.MatchResults)
                .OrderBy(x=>x.ResultOrderID)
                .ForEach(result.MatchResults.Add);
            return result;
        }

        public static IEnumerable<MatchViewModel> FromMatchs(IEnumerable<Match> matchs)
        {
            return matchs.Select(FromMatch);
        }

        public int? MatchID => _match?.MatchID;
        public DateTime? MatchDateTime => _match?.MatchDateTime;
        public Team Team1 => _match?.Team1;
        public Team Team2 => _match?.Team2;
        public DateTime? LastUpdateDateTime => _match?.LastUpdateDateTime;
        public int? LeagueId => _match?.LeagueId;
        public string LocationName => _match?.Location.LocationCity;
        public string MatchDateTimeUTC => _match?.MatchDateTimeUTC;
        public bool MatchIsFinished => _match?.MatchIsFinished ?? false;
        public string NumberOfViewers => _match?.NumberOfViewers;
        public string TimeZoneID => _match?.TimeZoneID;

        public string Result => $"{MatchResults.LastOrDefault()?.DisplayString??""} ({MatchResults.FirstOrDefault()?.DisplayString??""})";

        //public MatchResult[][] matchResults { get; set; }

        private ObservableCollection<MatchResultViewModel> _MatchResults = new ObservableCollection<MatchResultViewModel>();
        public ObservableCollection<MatchResultViewModel> MatchResults
        {
            get { return _MatchResults; }
            set
            {
                _MatchResults = value;
                this.RaisePropertyChanged(nameof(MatchResults));
            }
        }

        private ObservableCollection<GoalViewModel> _Goals = new ObservableCollection<GoalViewModel>();
        public ObservableCollection<GoalViewModel> Goals
        {
            get { return _Goals; }
            set
            {
                _Goals = value;
                this.RaisePropertyChanged(nameof(Goals));
            }
        }

        private GroupViewModel _Group = new GroupViewModel();
        public GroupViewModel Group
        {
            get { return _Group; }
            set
            {
                _Group = value;
                this.RaisePropertyChanged(nameof(Group));
            }
        }

    }
}
