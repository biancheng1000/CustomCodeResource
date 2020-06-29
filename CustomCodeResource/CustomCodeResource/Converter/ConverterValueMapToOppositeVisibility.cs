using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows;

namespace Flash.Converter
{
    /// <summary>
    /// 用于字符值和Visibility值的相互转换
    /// 转换原理是两个值调用ToString()方法，比较输出的字符串是否相等。
    /// </summary>
    public class ConverterValueMapToOppositeVisibility : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
                return DependencyProperty.UnsetValue;
            bool equal = string.Equals(value.ToString(), parameter.ToString());

            //true = Visible
            if (equal)
                return this.Parameter != null && this.Parameter.ToString().ToLower() == Visibility.Hidden.ToString().ToLower() ? Visibility.Hidden : Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterValueMapToOppositeVisibility
            {
                FromType = this.FromType ?? typeof(char),
                TargetType = this.TargetType ?? typeof(bool),
                Parameter = this.Parameter
            };
        }
        public object Parameter
        {
            get;
            set;
        }
        public Type TargetType
        {
            get;
            set;
        }
        public Type FromType
        {
            get;
            set;
        }
    }
}
