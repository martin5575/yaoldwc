using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLigaApi
{
    public class MatchResult
    {
        public int PointsTeam1 { get; set; }
        public int PointsTeam2 { get; set; }
        public string ResultDescription { get; set; }
        public int ResultID { get; set; }
        public string ResultName { get; set; }
        public int ResultOrderID { get; set; }
        public int ResultTypeID { get; set; }
    }
}
