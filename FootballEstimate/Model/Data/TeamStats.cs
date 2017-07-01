using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model.Data
{
    public class TeamStats : ObservableObject
    {
        public int TeamId { get; set; }

        public double LambdaTotal { get; set; }
        public double LambdaHome { get; set; }
        public double LambdaAway { get; set; }

        public double DefenseFactorTotal { get; set; }
        public double DefenseFactorHome { get; set; }
        public double DefenseFactorAway { get; set; }
    }
}
