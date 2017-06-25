using FootballEstimate.ViewModel.Messages;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.View.Service
{
    public interface IModalDialogService
    {
        bool? ShowDialog(ViewModelBase viewModel);

    }
}
