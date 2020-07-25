using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tbrn_macabeos_app.Equipos;
using tbrn_macabeos_app.Ofrendas;
using tbrn_macabeos_app.Asistencias;

namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class master : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public master(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;

            if (acceso >= 3)
            {
                btnRadios.IsVisible = false;
            }
            else
            {
                btnRadios.IsVisible = true;
            }
        }

        private async void btnUsuarios_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));
        }

        private async void btnCultos_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MenuCompromiso(servidor, acceso, usuario));
        }

        private async void btnRadios_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MenuEquipos(servidor, acceso, usuario));
        }
        private async void btnOfrendas_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MenuOfrenda(servidor, acceso, usuario));
        }

        private async void btnAsistencia_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage.Navigation.PopModalAsync();
            //App.MasterD.IsPresented = false;
            //await App.MasterD.Detail.Navigation.PushAsync(new MainPage()); 
            await Navigation.PushAsync(new MainPage());
        }
    }
}