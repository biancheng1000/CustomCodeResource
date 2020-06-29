using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace Flash.Converter
{
    /// <summary>
    /// 忽略显示0
    /// </summary>
    public class IntToStringIgnorceZeroConvert : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(int))
            {
                int ivalue =(int)value;
                if (ivalue <= 0)
                {
                    return "";
                }
                else
                {
                    return value;
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int reuslt = 0;
            if (value != null)
            {
                string temp = value.ToString().Replace(",", "");
               int.TryParse(temp, out reuslt);
            }
            return reuslt;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new IntToStringIgnorceZeroConvert();
        }

    }
}
