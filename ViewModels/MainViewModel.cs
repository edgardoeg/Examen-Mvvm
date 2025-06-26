using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Examen_Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string producto1;
    [ObservableProperty] private string producto2;
    [ObservableProperty] private string producto3;
    [ObservableProperty] private string subtotal;
    [ObservableProperty] private string descuento;
    [ObservableProperty] private string total;

    private void Alerta(string Titulo, string Mensaje)
    {
        MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
    }

    [RelayCommand]
    private void Calcular()
    {
        if (double.TryParse(Producto1, out double p1) &&
            double.TryParse(Producto2, out double p2) &&
            double.TryParse(Producto3, out double p3))
        {
            double suma = p1 + p2 + p3;
            Subtotal = suma.ToString("F2");

            double desc = 0;
            if (suma >= 10000) desc = 0.30;
            else if (suma >= 5000) desc = 0.20;
            else if (suma >= 1000) desc = 0.10;

            double descuentoCalculado = suma * desc;
            Descuento = descuentoCalculado.ToString("F2");
            Total = (suma - descuentoCalculado).ToString("F2");
        }
        else
        {
            Application.Current.MainPage?.DisplayAlert("Error", "Ingrese valores numéricos válidos.", "OK");
        }
        
    }

    [RelayCommand]
    private void Limpiar()
    {
        {
            Producto1 = Producto2 = Producto3 = Subtotal = Descuento = Total = string.Empty;
        }
    }
}
