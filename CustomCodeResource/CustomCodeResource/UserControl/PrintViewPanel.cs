using FlashPrintHelper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlashPrintHelper.CustomControl
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FlashPrintHelper.CustomControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FlashPrintHelper.CustomControl;assembly=FlashPrintHelper.CustomControl"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:PrintViewPanel/>
    ///
    /// </summary>
    public class PrintViewPanel : RadioButton
    {
        public PrintViewPanel()
        {
            Image = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Label.png"));
        }
        static PrintViewPanel()
        {
           
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PrintViewPanel), new FrameworkPropertyMetadata(typeof(PrintViewPanel)));
        }

        public static readonly DependencyProperty PrintTypeProperty = DependencyProperty.Register("PrintType", typeof(PrintPaperType), typeof(PrintViewPanel), new PropertyMetadata(PrintPaperType.Label), null);
        /// <summary>
        /// 打印纸类型
        /// </summary>
        public PrintPaperType PrintType
        {
            get => (PrintPaperType)GetValue(PrintTypeProperty);
            set => SetValue(PrintTypeProperty, value);
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(PrintViewPanel), new PropertyMetadata(null), null);
        /// <summary>
        /// 预览的内容，通过图片直接显示
        /// </summary>
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        


    }
}
