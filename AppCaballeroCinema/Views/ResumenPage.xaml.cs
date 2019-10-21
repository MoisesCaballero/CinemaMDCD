using AppCaballeroCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaballeroCinema.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResumenPage : ContentPage
    {
        public ResumenPage(Pelicula pelicula, Funcion funcion, int cantidad)
        {
            InitializeComponent();
            gridPelicula.BindingContext = pelicula;
            gridFuncion.BindingContext = funcion;
            Cantidad.Text = cantidad.ToString();
            TotalPagar.Text = (cantidad * funcion.Precio).ToString();
        }

        private async void Finalizar_Click(object sender, EventArgs e)
        {
            await DisplayAlert("¡Enohorabuena!", "Has reservado tu boleta", "ok");
        }
    }
}