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
    /// 当true的时候，可见，当false的时候，不可见，不保留控件位置
    /// </summary>
   public  class BooleanToVisibleCollapsedConverter : MarkupExtension,IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null && (Visibility)value == Visibility.Visible) ? true : false;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new BooleanToVisibleCollapsedConverter();
        }
    }

}
