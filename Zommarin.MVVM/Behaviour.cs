using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Zommarin.MVVM
{
    /// <summary>
    /// Base class that support support WinRt style behaviours
    /// </summary>
    public abstract class Behavior : FrameworkElement
    {

        private FrameworkElement _associatedObject;

        /// <summary>
        /// This is the object that this behaviour is attached to.
        /// </summary>
        public FrameworkElement AssociatedObject
        {
            get { return _associatedObject; }
            set
            {
                if (_associatedObject != null)
                    OnDetaching();
                DataContext = null;
                _associatedObject = value;
                if (_associatedObject == null)
                    return;
                OnAttached();
            }
        }

        private bool AssociatedObjectIsInVisualTree
        {
            get
            {
                if (_associatedObject != null && Window.Current.Content != null)
                    return Ancestors.Contains((DependencyObject) Window.Current.Content);
                else
                    return false;
            }
        }

        private IEnumerable<DependencyObject> Ancestors
        {
            get
            {
                if (_associatedObject != null)
                {
                    for (DependencyObject parent = VisualTreeHelper.GetParent(_associatedObject);
                         parent != null;
                         parent = VisualTreeHelper.GetParent(parent))
                        yield return parent;
                }
            }
        }

        protected virtual void OnAttached()
        {
            FrameworkElement associatedObject1 = AssociatedObject;
            WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(
                new Func<RoutedEventHandler, EventRegistrationToken>(associatedObject1.add_Unloaded),
                new Action<EventRegistrationToken>(associatedObject1.remove_Unloaded),
                new RoutedEventHandler(AssociatedObjectUnloaded));
            FrameworkElement associatedObject2 = AssociatedObject;
            WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(
                new Func<RoutedEventHandler, EventRegistrationToken>(associatedObject2.add_Loaded),
                new Action<EventRegistrationToken>(associatedObject2.remove_Loaded),
                new RoutedEventHandler(AssociatedObjectLoaded));
        }

        protected virtual void OnDetaching()
        {
            WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(
                new Action<EventRegistrationToken>(AssociatedObject.remove_Unloaded),
                new RoutedEventHandler(AssociatedObjectUnloaded));
            WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(
                new Action<EventRegistrationToken>(AssociatedObject.remove_Loaded),
                new RoutedEventHandler(AssociatedObjectLoaded));
        }

        private void AssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            ConfigureDataContext();
        }

        private void AssociatedObjectUnloaded(object sender, RoutedEventArgs e)
        {
            OnDetaching();
        }

        [AsyncStateMachine(typeof (Behavior.\u003CConfigureDataContext\u003Ed__1))]
        [DebuggerStepThrough]
        private void ConfigureDataContext()
        {
            // ISSUE: variable of a compiler-generated type
            Behavior.\u003CConfigureDataContext\u003Ed__1 stateMachine;
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003E4__this = this;
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003Et__builder = AsyncVoidMethodBuilder.Create();
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003E1__state = -1;
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003Et__builder.Start<Behavior.\u003CConfigureDataContext\u003Ed__1>(ref stateMachine);
        }

        [DebuggerStepThrough]
        [AsyncStateMachine(typeof (Behavior.\u003CWaitForLayoutUpdateAsync\u003Ed__a))]
        private Task WaitForLayoutUpdateAsync()
        {
            // ISSUE: variable of a compiler-generated type
            Behavior.\u003CWaitForLayoutUpdateAsync\u003Ed__a stateMachine;
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003E4__this = this;
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003E1__state = -1;
            // ISSUE: reference to a compiler-generated field
            stateMachine.\u003C\u003Et__builder.Start<Behavior.\u003CWaitForLayoutUpdateAsync\u003Ed__a>(
                ref stateMachine);
            // ISSUE: reference to a compiler-generated field
            return stateMachine.\u003C\u003Et__builder.Task;
        }
    }
}