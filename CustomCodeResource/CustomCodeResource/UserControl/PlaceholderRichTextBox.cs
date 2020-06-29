using System.Windows.Controls;
using System.Windows;

namespace FlashPrintHelper.CustomControl
{
    class PlaceholderRichTextBox : RichTextBox
    {
        public static DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
            "Placeholder",typeof(string),typeof(PlaceholderRichTextBox),new FrameworkPropertyMetadata(default(string),FrameworkPropertyMetadataOptions.Inherits));

        public static void SetPlaceholder(DependencyObject element, string value) => element.SetValue(PlaceholderProperty,value);
        public static void GetPlaceholder(DependencyObject element, string value) => element.GetValue(PlaceholderProperty);
    }
}
