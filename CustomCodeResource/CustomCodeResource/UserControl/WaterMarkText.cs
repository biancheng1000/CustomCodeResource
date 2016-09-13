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

namespace CustomCode
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DWM_UI"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DWM_UI;assembly=DWM_UI"
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
    ///     <MyNamespace:WaterMarkText/>
    ///
    /// </summary>
    public class WaterMarkText : TextBox
    {
        static WaterMarkText()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WaterMarkText), new FrameworkPropertyMetadata(typeof(WaterMarkText)));
        }
     

        public string Watermark
        {
            get
            {
                return (string)GetValue(WaterMarkProperty);
            }
            set
            {
                SetValue(WaterMarkProperty, value);
            }
        }

        public static readonly DependencyProperty WaterMarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(WaterMarkText), new PropertyMetadata(new PropertyChangedCallback(OnWatermarkChanged)));


        public static  DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius", typeof(System.Windows.CornerRadius), typeof(WaterMarkText),new PropertyMetadata (new System.Windows.CornerRadius(1)));

        public System.Windows.CornerRadius CornerRadius
        {
            get { return (System.Windows.CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        private bool _isWatermarked = false;
        private Binding _textBinding = null;

        public WaterMarkText()
        {
            Loaded += (s, ea) => ShowWatermark();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            HideWatermark();
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            ShowWatermark();
        }

        private static void OnWatermarkChanged(DependencyObject sender, DependencyPropertyChangedEventArgs ea)
        {
            var tbw = sender as WaterMarkText;
            if (tbw == null || !tbw.IsLoaded)
                return; //needed to check IsLoaded so that we didn't dive into the ShowWatermark() routine before initial Bindings had been made
            tbw.ShowWatermark();
        }

        private void ShowWatermark()
        {
            if (String.IsNullOrEmpty(Text) && !String.IsNullOrEmpty(Watermark))
            {
                _isWatermarked = true;

                //save the existing binding so it can be restored
                _textBinding = BindingOperations.GetBinding(this, TextProperty);

                //blank out the existing binding so we can throw in our Watermark
                BindingOperations.ClearBinding(this, TextProperty);

                //set the signature watermark gray
                Foreground = new SolidColorBrush(Colors.Gray);

                //display our watermark text
                Text = Watermark;
            }
        }

        private void HideWatermark()
        {
            if (_isWatermarked)
            {
                _isWatermarked = false;
                ClearValue(ForegroundProperty);
                Text = "";
                if (_textBinding != null)
                    SetBinding(TextProperty, _textBinding);
            }
        }
    }
}