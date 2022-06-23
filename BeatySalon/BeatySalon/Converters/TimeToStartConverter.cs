using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BeatySalon.Converters
{
    internal class TimeToStartConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;
            var time=dateTime-DateTime.Now;
            return $"До записи {time.Days} дней, {time.Hours} часов, {time.Minutes} минут";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
