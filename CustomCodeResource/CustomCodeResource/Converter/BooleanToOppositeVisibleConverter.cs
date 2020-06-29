using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Flash.Converter
{
    /// <summary>
    /// Bool值和visible的转换
    /// 当true的时候，不可见并且不保留控件位置，当false的时候，可见
    /// </summary>
   public class BooleanToOppositeVisibleConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Hidden;
            }
            if (value is bool)
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Hidden;

            if (value is Visibility)
            {
                return ((Visibility)value == Visibility.Visible) ? false : true;
            }
            return true;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new BooleanToOppositeVisibleConverter();
        }
    }
}
