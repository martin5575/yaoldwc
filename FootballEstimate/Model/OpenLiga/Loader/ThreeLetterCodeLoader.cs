using FootballEstimate.Model.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model.OpenLiga.Loader
{
    public class ThreeLetterCodeLoader 
    {
        private readonly Dictionary<int, ThreeLetterCode> _Dict;

        public static readonly ThreeLetterCodeLoader Instance = new ThreeLetterCodeLoader();

        private ThreeLetterCodeLoader()
        {
            var path = Path.Combine(Constants.DataFolder, Constants.ThreeLetterCodeFile);
            var dict = SettingsReader.ReadData<List<ThreeLetterCode>>(path)?.ToDictionary(x => x.TeamId);
            _Dict = dict ?? new Dictionary<int, ThreeLetterCode>();
        }

        public string Get3LetteCode(int teamId)
        {
            ThreeLetterCode result;
            if(_Dict.TryGetValue(teamId, out result))
                return result.Code;
            return null;
        }

        public void Set3LetterCode(int teamId, string threeLetterCode)
        {
            ThreeLetterCode result;
            if (!_Dict.TryGetValue(teamId, out result))
                _Dict.Add(teamId, new ThreeLetterCode { TeamId = teamId, Code = threeLetterCode });
            else
                result.Code = threeLetterCode;

            SaveToFile();
        }

        private void SaveToFile()
        {
            var path = Path.Combine(Constants.DataFolder, Constants.ThreeLetterCodeFile);
            SettingsReader.WriteData(path, _Dict.Values.ToList());
        }
    }
}
