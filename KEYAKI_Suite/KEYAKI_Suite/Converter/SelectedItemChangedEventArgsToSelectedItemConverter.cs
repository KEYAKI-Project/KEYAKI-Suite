using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace KEYAKI_Suite.Converter
{
    public class SelectedItemChangedEventArgsToSelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedItemChangedEventArgs = (SelectedItemChangedEventArgs) value;
            return selectedItemChangedEventArgs.SelectedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
