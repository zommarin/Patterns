using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zommarin.MVVM
{
    /// <summary>
    /// Generic services offered by views that are windows
    /// </summary>
    public interface IWindowView {

        /// <summary>
        /// Close the window
        /// </summary>
        void Close();

        event EventHandler Closed;
    }
}
