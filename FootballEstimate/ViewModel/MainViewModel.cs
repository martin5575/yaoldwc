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
using FootballEstimate.Model.OpenLiga;
using FootballEstimate.DesignModel;
using Infrastructure.Collections;

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
        private IOpenLigaService _openLigaService;
        private ILeagueAndSeasonInfoService _leagueAndSeasonInfoService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IOpenLigaService openLigaService, ILeagueAndSeasonInfoService leageAndSeasonInfoService)
        {
            _openLigaService = openLigaService;
            _leagueAndSeasonInfoService = leageAndSeasonInfoService;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                this.MessengerInstance.Register<ModalDialogMessage>(this, ShowDialog);
                this.MessengerInstance.Register<TabMessage>(this, HandleTab);
                // Code runs "for real"
            }

            Tabs.Add(CreateLeaguesTab());
        }

        private TabItemViewModel CreateLeaguesTab()
        {
            var leaguesViewModel = new LeaguesViewModel(_leagueAndSeasonInfoService);
            return new TabItemViewModel("main", "Leagues", "Main Tab containing all Leagues", leaguesViewModel, false);
        }


        private void HandleTab(TabMessage tabMessage)
        {
            string id = tabMessage.Id ?? tabMessage.ViewModel?.Id;
            var item = Tabs.FirstOrDefault(x => x.Id == id);
            switch(tabMessage.Action)
            {
                case TabMessageAction.BringToFront:
                    SelectedTab = item;
                    break;
                case TabMessageAction.Close:
                    Tabs.Remove(item);
                    break;
                case TabMessageAction.Create:
                    if (item == null)
                    {
                        item = tabMessage.ViewModel;
                        Tabs.Add(tabMessage.ViewModel);
                    }
                    SelectedTab = item;
                    break;
            }
        }

        private void ShowDialog(ModalDialogMessage modalDialogMessage)
        {
            var modalDialogService = SimpleIoc.Default.GetInstance<IModalDialogService>();
            var dailogResult = modalDialogService.ShowDialog(modalDialogMessage.ViewModel);
            modalDialogMessage.DialogResult = dailogResult;
        }


        private ObservableCollection<TabItemViewModel> _Tabs = new ObservableCollection<TabItemViewModel>();
        public ObservableCollection<TabItemViewModel> Tabs
        {
            get { return _Tabs; }
            set
            {
                _Tabs = value;
                this.RaisePropertyChanged(nameof(Tabs));
            }
        }

        private TabItemViewModel _SelectedTab;
        public TabItemViewModel SelectedTab
        {
            get { return _SelectedTab; }
            set
            {
                _SelectedTab = value;
                this.RaisePropertyChanged(nameof(SelectedTab));
            }
        }
    }
}