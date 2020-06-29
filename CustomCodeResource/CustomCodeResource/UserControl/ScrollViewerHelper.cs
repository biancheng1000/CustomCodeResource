using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlashPrintHelper.CustomControl
{
    /// <summary>
    /// 带滚动条的视图，附加属性，控制滚动到顶部或底部
    /// </summary>
    public static class ScrollViewerHelper
    {
        public static readonly DependencyProperty IsScrollTopProperty =
            DependencyProperty.RegisterAttached("IsScrollTop", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(false, AutoScrollPropertyChanged));


        public static void AutoScrollPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var scrollViewer = obj as ScrollViewer;
            if (scrollViewer == null) return;

            if ((bool)args.NewValue)
            {
                scrollViewer.ScrollToTop();
            }
            else
            {
                scrollViewer.ScrollToBottom();
            }
        }



        public static bool GetIsScrollTop(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsScrollTopProperty);
        }

        public static void SetIsScrollTop(DependencyObject obj, bool value)
        {
            obj.SetValue(IsScrollTopProperty, value);
        }
    }
}
