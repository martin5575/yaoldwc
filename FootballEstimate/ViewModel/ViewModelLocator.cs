/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:FootballEstimate"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using FootballEstimate.DesignModel;
using FootballEstimate.Model;
using FootballEstimate.Model.OpenLiga;
using FootballEstimate.View.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;

namespace FootballEstimate.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IOpenLigaService, OpenLigaServiceDesign>();
                SimpleIoc.Default.Register<ILeagueAndSeasonInfoService, LeagueAndSeasonInfoServiceDesign>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IOpenLigaService, OpenLigaService>();
                SimpleIoc.Default.Register<ILeagueAndSeasonInfoService>(()=> LeagueAndSeasonInfoService.Instance);
            }

            SimpleIoc.Default.Register<IModalDialogService, ModalDialogService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<INavigationService, View.Service.NavigationService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LeagueViewModel>();
            SimpleIoc.Default.Register<GoalViewModel>();
            SimpleIoc.Default.Register<GroupViewModel>();
            SimpleIoc.Default.Register<MatchResultViewModel>();
            SimpleIoc.Default.Register<MatchViewModel>();
            SimpleIoc.Default.Register<SeasonViewModel>();
            SimpleIoc.Default.Register<TeamViewModel>();
            SimpleIoc.Default.Register<TeamsOfLeagueViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LeagueViewModel SeasonLeagueForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LeagueViewModel>();
            }
        }

        public SeasonViewModel SeasonViewModelForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SeasonViewModel>();
            }
        }

        public GoalViewModel GoalForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GoalViewModel>();
            }
        }

        public GroupViewModel GroupForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GroupViewModel>();
            }
        }

        public MatchViewModel MatchForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MatchViewModel>();
            }
        }

        public MatchResultViewModel MatchResultForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MatchResultViewModel>();
            }
        }

        public TeamViewModel TeamForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TeamViewModel>();
            }
        }

        public IEnumerable<TeamViewModel> TeamsForDesign
        {
            get
            {
                var service = ServiceLocator.Current.GetInstance<IOpenLigaService>();
                return TeamViewModel.FromTeams(service.LoadTeamsAsync(null, null).Result);
            }
        }

        public TabItemViewModel TabItemForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TabItemViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}