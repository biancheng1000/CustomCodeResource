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
    ///     <MyNamespace:GotoButton/>
    ///
    /// </summary>
    public class GotoButton:Button
    {
        static GotoButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GotoButton), new FrameworkPropertyMetadata(typeof(GotoButton)));
        }

        //Image image=null;
        //public GotoButton()
        //{
        //    image = this.GetTemplateChild("image") as Image;
        //}

        //public Image GetImage()
        //{
        //    return image;
        //}

        public static readonly DependencyProperty IsTopPropery = DependencyProperty.Register("IsTop", typeof(bool), typeof(GotoButton), new PropertyMetadata(true));

        ///// <summary>
        ///// 当属性发生变化的时候，更新图标
        ///// </summary>
        ///// <param name="d"></param>
        ///// <param name="e"></param>
        //private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var sender = d as GotoButton;
        //    if (sender == null)
        //    {
        //        return;
        //    }

        //   var image=  sender.GetImage();
        //    if ((bool)e.NewValue)
        //    {
        //        image.RenderTransform = null;
        //    }
        //    else
        //    {
        //        image.RenderTransform = new RotateTransform(180);
        //    }
        //}

        /// <summary>
        /// 是否向上
        /// </summary>
        public bool IsTop
        {
            get => (bool)GetValue(IsTopPropery);
            set => SetValue(IsTopPropery, value);
        }

    }
}
