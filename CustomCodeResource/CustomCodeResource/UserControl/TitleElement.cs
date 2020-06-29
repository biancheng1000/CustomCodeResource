using System.Windows;
using HandyControl.Data;

namespace FlashPrintHelper.CustomControl
{
    public class TitleElement
    {
        public static string GetRightTitle(DependencyObject element)
        {
            return (string)element.GetValue(RightTitleProperty);
        }

        public static void SetRightTitle(DependencyObject element, string value)
        {
            element.SetValue(RightTitleProperty, value);
        }

        // Using a DependencyProperty as the backing store for RightTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightTitleProperty =
            DependencyProperty.RegisterAttached("RightTitle", typeof(string), typeof(TitleElement), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.Inherits));


        public static readonly DependencyProperty RightTitleAlignmenttProperty = DependencyProperty.RegisterAttached(
           "RightTitleAlignment", typeof(TitleAlignment), typeof(TitleElement), new FrameworkPropertyMetadata(TitleAlignment.Left, FrameworkPropertyMetadataOptions.Inherits));

        public static void SetRightTitleAlignment(DependencyObject element, TitleAlignment value)
            => element.SetValue(RightTitleAlignmenttProperty, value);

        public static TitleAlignment GetRightTitleAlignment(DependencyObject element)
            => (TitleAlignment)element.GetValue(RightTitleAlignmenttProperty);

        /// <summary>
        ///     标题宽度
        /// </summary>
        public static readonly DependencyProperty RightTitleWidthProperty = DependencyProperty.RegisterAttached(
            "RightTitleWidth", typeof(GridLength), typeof(TitleElement), new FrameworkPropertyMetadata(new GridLength(0), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetRightTitleWidth(DependencyObject element, GridLength value) => element.SetValue(RightTitleWidthProperty, value);

        public static GridLength GetRightTitleWidth(DependencyObject element) => (GridLength)element.GetValue(RightTitleWidthProperty);
    }
}
