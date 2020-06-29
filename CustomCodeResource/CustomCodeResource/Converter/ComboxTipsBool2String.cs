using System;
using System.Globalization;

using System.Windows.Data;
using System.Windows.Markup;

namespace Flash.Converter
{
   public  class ComboxTipsBool2String : MarkupExtension ,IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (bool)value ? "*" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ComboxTipsBool2String();
        }
    }
}
