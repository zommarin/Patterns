using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zommarin.MVVM;

namespace Zommarin.Patterns.MVVM.ViewModel
{
    public class AppViewModel : ViewModelBase
    {
        public AppViewModel()
        {
            var list = new PersonListViewModel();
            MainWindowViewModel = new MainWindowViewModel(list);
        }

        public MainWindowViewModel MainWindowViewModel { get; private set; }
    }
}
