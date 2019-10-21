using AppCaballeroCinema.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaballeroCinema.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarteleraPage : ContentPage
    {
        public CarteleraPage()
        {
            InitializeComponent();
            CargarPeliculas();
        }

        private async void CargarPeliculas()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var request = await client.GetAsync("/api/Cartelera");

            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var listado = JsonConvert.DeserializeObject<List<Pelicula>>(responseJson);
                ListPeliculas.ItemsSource = listado;
            }
            else
            {
                await DisplayAlert("¡Error!", "Algo salio mal", "OK");
            }
        }

        private async void Pelicula_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var pelicula = (Pelicula)e.SelectedItem;
            await Navigation.PushAsync(new FuncionesPage(pelicula));
        }
    }
}