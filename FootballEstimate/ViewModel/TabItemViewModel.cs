using FootballEstimate.ViewModel.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootballEstimate.ViewModel
{
    public class TabItemViewModel : ViewModelBase
    {
        public TabItemViewModel(string id, string caption, string tooltip, ViewModelBase viewModel, bool canClose=true)
        {
            Id = id;
            _Caption = caption;
            _ToolTip = tooltip;
            _ContentViewModel = viewModel;
            CanClose = canClose;
        }

        public ICommand CloseCommand => new RelayCommand(Close);

        private void Close()
        {
            var message = new TabMessage { Id = this.Id, Action = TabMessageAction.Close };
            this.MessengerInstance.Send(message);
        }

        public bool CanClose { get; }
        public string Id { get; }

        private string _Caption;
        public string Caption
        {
            get { return _Caption; }
            set
            {
                _Caption = value;
                this.RaisePropertyChanged();
            }
        }

        private string _ToolTip;
        public string ToolTip
        {
            get { return _ToolTip; }
            set
            {
                _ToolTip = value;
                this.RaisePropertyChanged();
            }
        }

        private ViewModelBase _ContentViewModel;
        public ViewModelBase ContentViewModel
        {
            get { return _ContentViewModel; }
            set
            {
                _ContentViewModel = value;
                this.RaisePropertyChanged();
            }
        }


    }
}
