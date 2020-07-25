using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tbrn_macabeos_app.Ofrendas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuOfrenda : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public MenuOfrenda(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;

            if (acceso >= 3)
            {
                btnAportaciones.IsVisible = false;
                btnInsertarOfrenda.IsVisible = false;
            }
            else
            {
                btnAportaciones.IsVisible = true;
                btnInsertarOfrenda.IsVisible = true;
            }
        }

        private async void btnAportacionesServ_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new OfrendaServidor(servidor, acceso, usuario));
        }

        private async void btnAportaciones_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new OfrendaLider(servidor, acceso, usuario));
        }
        private async void btnInsertarOfrenda_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new InsertarOfrenda(servidor, acceso, usuario));
        }
        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Principal(servidor, acceso, usuario));
        }
    }
}