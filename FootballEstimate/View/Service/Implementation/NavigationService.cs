using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.View.Service
{
    class NavigationService : INavigationService
    {
        public string CurrentPageKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            switch(pageKey)
            {
                case "Tab":
                    OpenOrCreateTab(parameter);
                    break;
                default:
                    throw new NotSupportedException($"pageKey is not supported '{pageKey}'.");
            }
        }

        private void OpenOrCreateTab(object viewModel)
        {
            // need to check if there is a view for the view Model already!
            MainWindow.Instance.CreateTab(viewModel);
        }
    }
}
