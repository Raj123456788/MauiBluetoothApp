using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MauiBluetoothApp.Helpers
{
    /// <summary>
    /// Helper class that Provides the color based off status.
    /// </summary>
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (string)value;


            if (status == nameof(BleStatus.Connecting))
            {
                return Color.FromRgb(255, 255, 0);

            }
            else if (status == nameof(BleStatus.Connected))
            {
                return Color.FromRgb(0, 255, 0);
            }
            else
            {
                return Color.FromArgb("FF6A00");

            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    enum BleStatus
    {

        Connected,

        Connecting,
        [Description("Not Connected")]
        NotConnected,


    }
}
