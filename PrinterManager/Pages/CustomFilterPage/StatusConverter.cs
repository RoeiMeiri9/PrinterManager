using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager.Pages.CustomFilterPage 
{
    // מחלקה שתחזיק גם את הרקע וגם את צבע הטקסט
    public class StatusColors
    {
        public required Brush Background { get; set; }
        public required Brush Foreground { get; set; }
    }

    public class StatusColorsNames
    {
        public required String Background { get; set; }
        public required String Foreground { get; set; }
    }

    public partial class StatusConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, string language)
        {

            var status = value?.ToString();

            var names = status switch
            {
                "Ready" => new StatusColorsNames
                {
                    Background = "StatusGreenBrush",
                    Foreground = "SystemFillColorSuccessBrush"
                },
                "Pending" => new StatusColorsNames
                {
                    Background = "StatusOrangeBrush",
                    Foreground = "SystemFillColorCautionBrush"
                },
                "Offline" => new StatusColorsNames
                {
                    Background = "StatusRedBrush",
                    Foreground = "SystemFillColorCriticalBrush"
                },
                _ => new StatusColorsNames
                {
                    Background = "StatusDefaultBrush",
                    Foreground = "SystemFillColorSolidNeutralBrush"
                }
            };

            string resourceKey = parameter?.ToString() == "Foreground"
                            ? names.Foreground
                            : names.Background;

            

            if (Application.Current.Resources.TryGetValue(resourceKey, out object resource) && resource is Brush brush)
            {
                return brush;
            }
            return new SolidColorBrush(Microsoft.UI.Colors.Gray);
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
