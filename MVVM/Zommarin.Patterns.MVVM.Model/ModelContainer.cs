using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zommarin.MVVM.ContainerSupport;

namespace Zommarin.Patterns.MVVM.Model
{
    public class ModelContainer : ModelContainerBase
    {

        public ModelContainer()
        {
            
        }

        public Person Person { get { return Resolve<Person>(); }}
    }
}
