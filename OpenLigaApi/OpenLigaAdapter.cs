using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenLigaApi
{
    public class OpenLigaAdapter
    {

        const string baseUri = "https://www.openligadb.de/";

        public async Task<IEnumerable<Match>> GetCurrentMatchesAsync(string league)
        {
            //    https://www.openligadb.de/api/getmatchdata/bl1
            string request = $"api/getmatchdata/{league}";
            return await RunAsync<IEnumerable<Match>>(request);
        }

        public async Task<IEnumerable<Match>> GetMatchesAsync(string league, string season, int? matchDay=null)
        {
            //    https://www.openligadb.de/api/getmatchdata/bl1/2016/8
            //    https://www.openligadb.de/api/getmatchdata/bl1/2016
            string request = $"api/getmatchdata/{league}/{season}";
            if (matchDay.HasValue)
                request += $"/{matchDay}";
            return await RunAsync<IEnumerable<Match>>(request);
        }

        public async Task<Match> GetMatchAsync(int matchId)
        {
            //    https://www.openligadb.de/api/getmatchdata/39738
            string request = $"api/getmatchdata/{matchId}";
            return await RunAsync<Match>(request);
        }

        public async Task<DateTime> GetLastChangeDateAsync(string league, string season, int matchDay)
        {
            //    https://www.openligadb.de/api/getlastchangedate/bl1/2016/8
            string request = $"api/getmatchdata/{league}/{season}/{matchDay}";
            return await RunAsync<DateTime>(request);
        }

        public async Task<IEnumerable<Match>> GetCurrentMatchDayAsync(string league)
        {
            //    https://www.openligadb.de/api/getcurrentgroup/bl1
            string request = $"api/getcurrentgroup/{league}";
            return await RunAsync<IEnumerable<Match>>(request);
        }

        public async Task<IEnumerable<Match>> GetAllMatchDaysAsync(string league, string season)
        {
            //    https://www.openligadb.de/api/getavailablegroups/bl1/2016
            string request = $"api/getavailablegroups/{league}/{season}";
            return await RunAsync<IEnumerable<Match>>(request);
        }


        public async Task<IEnumerable<Match>> GetNextMatchForTeamAsync(string leagueId, string teamId)
        {
            //    https://www.openligadb.de/api/getnextmatchbyleagueteam/3005/7
            string request = $"api/getnextmatchbyleagueteam/{leagueId}/{teamId}";
            return await RunAsync<IEnumerable<Match>>(request);
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync(string league, string season)
        {
            //    https://www.openligadb.de/api/getavailableteams/bl1/2016
            string request = $"api/getavailableteams/{league}/{season}";
            return await RunAsync<IEnumerable<Team>>(request);
        }


        private async Task<T> RunAsync<T>(string request)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(request);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Request was not successfull: {response.ReasonPhrase}");

                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);

                //return await response.Content.ReadAsAsync<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Request failed: {request}", ex);
            }
        }

    }
}


//Api-Schema
//Nachfolgend wird das Api-Schema anhand von Beispielen dargestellt:
//Spiele des aktuellen Spieltages der ersten Bundesliga:
//    https://www.openligadb.de/api/getmatchdata/bl1
//Der aktuelle Spieltag wird jeweils zur Hälfte der Zeit zwischen dem letzten Spiel des letzten Spieltages und dem ersten Spiel des nächsten Spieltages erhöht.
//Spiele des 8. Spieltages der ersten Bundesliga 2016/2017:
//    https://www.openligadb.de/api/getmatchdata/bl1/2016/8
//Alle Spiele der ersten Bundesliga 2016/2017:
//    https://www.openligadb.de/api/getmatchdata/bl1/2016
//Spiel mit der Id 39738:
//    https://www.openligadb.de/api/getmatchdata/39738
//Die aktuelle Group (entspricht z.B.bei der Fussball-Bundesliga dem 'Spieltag') des als Parameter zu übergebenden leagueShortcuts(z.B. 'bl1'):
//    https://www.openligadb.de/api/getcurrentgroup/bl1
//Der aktuelle Spieltag wird jeweils zur Hälfte der Zeit zwischen dem letzten Spiel des letzten Spieltages und dem ersten Spiel des nächsten Spieltages erhöht.
//Eine Liste der Spiel-Einteilungen (Spieltag, Vorrunde, Finale, ...) der als Parameter zu übergebenden Liga + Saison zurueck
//    https://www.openligadb.de/api/getavailablegroups/bl1/2016
//Datum und Uhrzeit der letzten Änderung in den Daten des 8. Spieltages der ersten Bundesliga 2016/2017.
//    https://www.openligadb.de/api/getlastchangedate/bl1/2016/8
//Diese Methode dient zur Ermittlung der Änderung von Spieldaten, um unnötiges Pollen der o.g.Service-Methoden zu vermeiden.
//Das nächste anstehende Spiel des als Parameter zu übergebenden Teams der ebenfalls zu übergebenen Liga:
//    https://www.openligadb.de/api/getnextmatchbyleagueteam/3005/7
//    '3005' entspricht der LeagueId der 1. Fußball Bundesliga 2016/2017
//    '7' entspricht der TeamId von Borussia Dortmund
//Alle Teams einer Liga:
//    https://www.openligadb.de/api/getavailableteams/bl1/2016



