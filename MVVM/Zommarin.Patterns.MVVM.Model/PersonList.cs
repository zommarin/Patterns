using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zommarin.Patterns.MVVM.Model
{
    public class PersonList
    {
        public PersonList()
        {
            Persons = new List<Person>();
        }
        
        public IList<Person> Persons { get; private set; }
    }
}
