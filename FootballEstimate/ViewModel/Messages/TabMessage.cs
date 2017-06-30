using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel.Messages
{
    public enum TabMessageAction { BringToFront, Close,
        Create
    }

    public class TabMessage
    {
        public string Id { get; set; }
        public TabMessageAction Action { get; set; }
        public TabItemViewModel ViewModel { get; internal set; }
    }
}
