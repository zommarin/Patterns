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

namespace Zommarin.WPF
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Zommarin.WPF"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Zommarin.WPF;assembly=Zommarin.WPF"
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
    ///     <MyNamespace:BusyProgressControl/>
    ///
    /// </summary>
    public class BusyProgressControl : Control
    {
        static BusyProgressControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(BusyProgressControl), 
                new FrameworkPropertyMetadata(typeof(BusyProgressControl)));
        }

        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register("StatusText", typeof (string), typeof (BusyProgressControl), new PropertyMetadata(default(string)));

        public string StatusText
        {
            get { return (string) GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        public static readonly DependencyProperty BusyProperty =
            DependencyProperty.Register("Busy", typeof (bool), typeof (BusyProgressControl), new PropertyMetadata(default(bool)));

        /// <summary>
        /// If true then the control should display its Busy appearence
        /// </summary>
        public bool Busy
        {
            get { return (bool) GetValue(BusyProperty); }
            set { SetValue(BusyProperty, value); }
        }0
    }
}
