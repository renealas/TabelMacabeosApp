using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tbrn_macabeos_app.Equipos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuEquipos : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public MenuEquipos(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
        }

        private async void btnAgregarEquipo_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new AgregarEquipo(servidor, acceso, usuario));
        }

        private async void btnListarEquipo_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarEquipos(servidor, acceso, usuario));
        }
        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Principal(servidor, acceso, usuario));
        }
    }
}