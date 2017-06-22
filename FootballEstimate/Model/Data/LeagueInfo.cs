using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    public class LeagueInfo
    {
        public LeagueInfo(string key, string name)
        {
            Key = key;
            Name = name;
        }

        public string Key { get; set; }
        public string Name { get; set; }
    }
}
