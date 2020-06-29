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
    /// 一个带图标的按钮
    /// </summary>
    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageButton), null);

        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        /// <summary>
        /// 图标的缩放属性
        /// </summary>
        public static readonly DependencyProperty ImageTransfromProperty = DependencyProperty.Register("ImageTransfrom", typeof(Transform), typeof(ImageButton), new PropertyMetadata(new ScaleTransform(1,1)));

        public Transform ImageTransfrom
        {
            get => (Transform)GetValue(ImageTransfromProperty);
            set => SetValue(ImageTransfromProperty, value);
        }


        /// <summary>
        /// 边框的 角弧度
        /// </summary>
        public static readonly DependencyProperty ImageCornerRadiusProperty = DependencyProperty.Register("ImageCornerRadius", typeof(CornerRadius), typeof(ImageButton), null);

        public CornerRadius ImageCornerRadius
        {
            get => (CornerRadius)GetValue(ImageCornerRadiusProperty);
            set => SetValue(ImageCornerRadiusProperty, value);
        }
    }
}
