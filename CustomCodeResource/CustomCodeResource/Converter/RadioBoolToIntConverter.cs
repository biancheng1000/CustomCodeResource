using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Flash.Converter
{
    public class RadioBoolToIntConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType().IsEnum)
            {
                var rawValue = value.GetHashCode().ToString();
                if (rawValue == parameter.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = Enum.Parse(targetType, parameter.ToString());
            //绑定源属性或转换器可以返回 Binding.DoNothing 以指示绑定引擎不执行任何操作
            var ret = (value != null && value.Equals(true)) ? enumValue : Binding.DoNothing;
            return ret;

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new RadioBoolToIntConverter();
        }
    }
}
