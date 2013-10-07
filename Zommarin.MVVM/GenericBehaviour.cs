using System.Reflection;
using System.Windows;

namespace Zommarin.MVVM
{
    public class CallMethodOnLoadBehavior : Behavior<FrameworkElement>
    {
        #region Properties
        public string MethodName
        {
            get { return (string)GetValue(MethodNameProperty); }
            set { SetValue(MethodNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodNameProperty =
            DependencyProperty.Register("MethodName", typeof(string), typeof(CallMethodOnLoadBehavior), new PropertyMetadata(null));

        public object TargetObject
        {
            get { return (object)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(object), typeof(CallMethodOnLoadBehavior), new PropertyMetadata(null));
        #endregion

        #region Methods
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject == null || string.IsNullOrWhiteSpace(MethodName) || TargetObject == null || DesignMode.DesignModeEnabled) return;
            MethodInfo minfo = TargetObject.GetType().GetTypeInfo().GetDeclaredMethod(MethodName);
            if (minfo == null) return;
            minfo.Invoke(TargetObject, null);
        }
        #endregion
    }
}