using FootballEstimate.ViewModel.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace FootballEstimate.View.Service
{
    class ModalDialogService : IModalDialogService
    {
        public bool? ShowDialog(ViewModelBase viewModel)
        {
            var view = new EditLeagueAndSeasonWindow();
            view.DataContext = viewModel;
            return view.ShowDialog();
        }

    }
}
