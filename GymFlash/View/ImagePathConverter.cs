using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GymFlash.View
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imagePath && !string.IsNullOrWhiteSpace(imagePath))
            {
                try
                {
                    // Ruta relativa o absoluta
                    string fullPath = Path.GetFullPath(imagePath);
                    if (File.Exists(fullPath))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.UriSource = new Uri(fullPath, UriKind.Absolute);
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                        return image;
                    }
                }
                catch
                {
                    // Ignora errores, puedes registrar si deseas
                }
            }

            // Imagen predeterminada si no encuentra archivo
            return new BitmapImage(new Uri("pack://application:,,,/Assets/placeholder.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
