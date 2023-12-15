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
		viewListado.ItemsSource = await App.db.SelectAll();
    }




    private async void ItemSelected(object sender, SelectionChangedEventArgs e) {
        Notas nota = e.CurrentSelection as Notas;
        await Navigation.PushAsync(new Detalle(nota));
    }

}