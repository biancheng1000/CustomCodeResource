using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CustomCode
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TraceGenerator.MainControler.CustomControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TraceGenerator.MainControler.CustomControl;assembly=TraceGenerator.MainControler.CustomControl"
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
    ///     <MyNamespace:CanvasItemsControl/>
    ///
    /// </summary>
    public class CanvasItemsControl : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(
                       DependencyObject element,
                       object item)
        {
                Binding leftBinding = new Binding() { Path = new PropertyPath("ShowPosition.X") };

                leftBinding.RelativeSource = new RelativeSource(RelativeSourceMode.Self);
                leftBinding.Mode = BindingMode.OneWay;
                leftBinding.NotifyOnSourceUpdated = true;

                Binding topBinding = new Binding() { Path = new PropertyPath("ShowPosition.Y") };
                topBinding.RelativeSource = new RelativeSource(RelativeSourceMode.Self);

                FrameworkElement  contentControl = (FrameworkElement)element;
                contentControl.SetBinding(Canvas.LeftProperty, leftBinding);
                contentControl.SetBinding(Canvas.TopProperty, topBinding);

                base.PrepareContainerForItemOverride(element, item);
        }
    }
}
