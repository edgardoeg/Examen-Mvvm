
using Examen_Mvvm.ViewModels;

namespace Examen_Mvvm.Views;

public partial class MainView : ContentPage
{
    public MainView(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}