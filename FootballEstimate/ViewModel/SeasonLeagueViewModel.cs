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

namespace FootballEstimate.ViewModel
{
    public class SeasonLeagueViewModel : ViewModelBase, ICloneable
    {
        #region Buttons
        public RelayCommand<Window> OkCommand => new RelayCommand<Window>(DoOk,CanDoOk);

        private bool CanDoOk(Window arg)
        {
            return !string.IsNullOrWhiteSpace(LeagueKey) 
                && !string.IsNullOrWhiteSpace(SeasonKey);
        }

        private void DoOk(Window arg)
        {
            LeagueAndSeasonInfoManager.Instance.SaveFile();
            arg.DialogResult = true;
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

        public static SeasonLeagueViewModel Create(LeagueInfo league, SeasonInfo season)
        {
            return new SeasonLeagueViewModel
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
                var name = LeagueAndSeasonInfoManager.Instance.GetName(LeagueKey);
                if (name != null)
                    LeagueName = name;
            }

                if (propertyName == nameof(LeagueName) && 
                !string.IsNullOrWhiteSpace(LeagueKey))
            {
                var name = LeagueAndSeasonInfoManager.Instance.GetName(LeagueKey);
                if (string.IsNullOrEmpty(name))
                    LeagueAndSeasonInfoManager.Instance.AddOrUpdateName(LeagueKey, LeagueName);
            }

            if (propertyName == nameof(SeasonKey))
            {
                var name = LeagueAndSeasonInfoManager.Instance.GetSeasonName(LeagueKey,SeasonKey);
                if (name != null)
                    SeasonName = name;
            }

            if (propertyName == nameof(SeasonName) &&
                !string.IsNullOrWhiteSpace(SeasonKey))
            {
                var name = LeagueAndSeasonInfoManager.Instance.GetSeasonName(LeagueKey,SeasonKey);
                if (name == null)
                    LeagueAndSeasonInfoManager.Instance.AddOrUpdateSeasonName(LeagueKey, SeasonKey, SeasonName);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
