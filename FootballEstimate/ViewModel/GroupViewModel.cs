using GalaSoft.MvvmLight.CommandWpf;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.ViewModel
{
    public class GroupViewModel
    {
        private static readonly Dictionary<int, GroupViewModel> Cache = new Dictionary<int, GroupViewModel>();

        private Group _group;

        public static GroupViewModel GetOrCreate(Group group)
        {
            GroupViewModel result;
            if (!Cache.TryGetValue(group.GroupID, out result))
            {
                result = new GroupViewModel { _group = group };
                Cache.Add(group.GroupID, result);
            }
            return result;
        }

        public static IEnumerable<GroupViewModel> FromGroups(IEnumerable<Group> groups)
        {
            return groups.Select(GetOrCreate);
        }


        public int? GroupID => _group?.GroupID;
        public string GroupName => _group?.GroupName;
        public int? GroupOrderID => _group.GroupOrderID;
    }
}
