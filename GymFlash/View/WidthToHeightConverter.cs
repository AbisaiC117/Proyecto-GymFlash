using System;
using System.Globalization;
using System.Windows.Data;

namespace GymFlash.View
{
    public class WidthToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width)
            {
                double ratio = 9.0 / 16; // Default
                if (parameter is string paramStr && double.TryParse(paramStr, out double customRatio))
                {
                    ratio = customRatio;
                }
                return width * ratio;
            }
            return 300;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
