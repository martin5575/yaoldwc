using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEstimate.Model.Data;

namespace FootballEstimate.ViewModel
{
    public class StatsByTeamViewModel : ViewModelBase
    {
        public TeamStats Stats { get; set; }

        public TeamViewModel Team { get; set; }


    }
}
