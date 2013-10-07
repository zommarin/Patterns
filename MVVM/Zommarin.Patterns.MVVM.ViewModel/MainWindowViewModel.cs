using System.Windows.Input;
using Zommarin.MVVM;

namespace Zommarin.Patterns.MVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(PersonListViewModel personList)
        {
            PersonList = personList;
            CloseWindowCommand = new NoArgsRelayCommand(Close);
        }

        public IMainWindowView View { get; set; }

        public PersonListViewModel PersonList { get; private set; }

        public ICommand CloseWindowCommand { get; private set; }

        private void Close()
        {
            View.Close();
        }
    }

    public interface IMainWindowView : IWindowView
    {
    }
}