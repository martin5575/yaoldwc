using FootballEstimate.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Infrastructure.Collections;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel
{
    public class TeamViewModel : ViewModelBase
    {
        private Team _team;
        private IOpenLigaService _openLigaService;

        public TeamViewModel(IOpenLigaService openLigaService)
        {
            _openLigaService = openLigaService;
        }

        public static TeamViewModel FromTeam(Team team)
        {
            var service = SimpleIoc.Default.GetInstance<IOpenLigaService>();
            var result = new TeamViewModel(service) { _team = team };
            return result;
        }

        public static IEnumerable<TeamViewModel> FromTeams(IEnumerable<Team> result)
        {
            return result.Select(FromTeam);
        }

        public int? TeamId => _team?.TeamId;
        public string ShortName => _team?.ShortName;
        public string TeamName => _team?.TeamName;
        public string TeamIconUrl => _team?.TeamIconUrl;
        public string LocalIconSource => _openLigaService.GetIconSource(_team);

        
    }
}
