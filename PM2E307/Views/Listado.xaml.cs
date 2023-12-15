using PM2E307.Controllers;
using PM2E307.Models;
using System.Windows.Input;

namespace PM2E307.Views;

public partial class Listado : ContentPage
{
  




    public Listado() { 
		InitializeComponent();
        
    }


    protected override async void OnAppearing() {
        base.OnAppearing();
        viewListado.Header = "Cargando...";
        viewListado.ItemsSource = await App.db.SelectAll();
        viewListado.Header = string.Empty;
    }






    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) {
        Notas nota = args.SelectedItem as Notas;
        await Navigation.PushAsync(new Detalle(nota));
    }

}