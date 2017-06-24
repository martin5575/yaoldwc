using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    class IconLoader
    {
        private IconLoader()
        { }

        public static IconLoader Instance => new IconLoader();

        public string GetIconSource(Team team)
        {
            try
            {
                return GetIconSourceIntern(team);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string GetIconSourceIntern(Team team)
        {
            var fileName = $"{team.TeamId}{Path.GetExtension(team.TeamIconUrl)}";
            string path = Path.Combine(Environment.CurrentDirectory, Constants.IconFolder);
            string fullPath = Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(team.TeamIconUrl, fullPath);
                }
            }
            return fullPath;
        }
    }
}
