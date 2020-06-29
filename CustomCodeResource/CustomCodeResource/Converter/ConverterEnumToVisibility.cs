using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Flash.Converter
{
    /// <summary>
    /// 比较枚举类型的值,主要用于枚举值和RadioButton之间的转换。
    /// </summary>
    public class ConverterEnumToVisibility : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterEnumToVisibility { FromType = this.FromType ?? typeof(Enum), TargetType = this.TargetType ?? typeof(bool), Parameter = this.Parameter };
        }

        public object Parameter { get; set; }
        public Type TargetType { get; set; }
        public Type FromType { get; set; }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ParameterString = parameter as string;
            if (ParameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            object paramvalue = Enum.Parse(value.GetType(), ParameterString) ?? new object();

            return paramvalue.Equals(value) ? Visibility.Visible : Visibility.Hidden;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
