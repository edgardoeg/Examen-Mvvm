using Examen_Mvvm.ViewModels;
using Examen_Mvvm.Views;

namespace Examen_Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainView(new MainViewModel());
        }
    }

}

