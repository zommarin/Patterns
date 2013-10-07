using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zommarin.Patterns.MVVM.ViewModel
{
    public class PersonListViewModel {

        public PersonListViewModel()
        {
            
        }

        public IPersonListView View { get; set; }

    }
}
