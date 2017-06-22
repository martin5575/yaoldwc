using FootballEstimate.Model;
using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FootballEstimate.ValueConverter
{
    public class TeamImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var team = value as Team;
            if (team == null)
                return null;
            return IconLoader.Instance.GetIconSource(team);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
