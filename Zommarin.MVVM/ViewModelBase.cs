using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Zommarin.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected ViewModelBase(string modelName)
        {
            ModelName = modelName;
        }

        protected ViewModelBase()
        {
            ModelName = GetType().FullName;
        }

        /// <summary>
        ///     Returns true if we are in a design-time container
        /// </summary>
        public static bool IsDesignTime
        {
            get { return (Application.Current == null) || (Application.Current.GetType() == typeof (Application)); }
        }

        /// <summary>
        /// The name of this model
        /// </summary>
        public string ModelName { get; private set; }

        /// <summary>
        ///     Controls if invalid property names should trigger an exception or not.
        /// </summary>
        public static bool ThrowOnInvalidPropertyName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //protected void SetStaticProperty<TValue>(ref TValue storedValue, TValue newValue, string name)
        //    where TValue : class
        //{
        //    if (storedValue != newValue)
        //    {
        //        storedValue = newValue;
        //        OnPropertyChanged(name);
        //    }
        //}

        protected void SetProperty<TValue>(ref TValue storedValue, TValue newValue, [CallerMemberName] string name = null)
         //   where TValue : struct
        {
            if (!EqualityComparer<TValue>.Default.Equals(storedValue, newValue))
            {
                storedValue = newValue;
                OnPropertyChanged(name);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        /// <summary>
        ///     Verify that the given property exist in this class
        /// </summary>
        /// This is so that refactorings that fails to update property names in strings
        /// are discovered.
        /// Code is fetched from article: http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
        /// <param name="propertyName">The name of the property</param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }
                Debug.Fail(msg);
            }
        }
    }

}