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

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

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

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SeasonLeagueViewModel>();
            SimpleIoc.Default.Register<GoalViewModel>();
            SimpleIoc.Default.Register<GroupViewModel>();
            SimpleIoc.Default.Register<MatchResultViewModel>();
            SimpleIoc.Default.Register<MatchViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public SeasonLeagueViewModel SeasonLeagueForDesign
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SeasonLeagueViewModel>();
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

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}