using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel.Messages
{
    public class ModalDialogMessage
    {
        public ViewModelBase ViewModel { get; set; }
        public bool? DialogResult { get; set; }
    }
}
