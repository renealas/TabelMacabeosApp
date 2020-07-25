using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuUsuarios : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public MenuUsuarios(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;

            if (acceso >= 3)
            {
                btnAgregarServidor.IsVisible = false;
                btnListadoUsuarios.IsVisible = false;
                btnListadoInactivos.IsVisible = false;
            }
            else
            {
                btnAgregarServidor.IsVisible = true;
                btnListadoUsuarios.IsVisible = true;
                btnListadoInactivos.IsVisible = true;
            }
        }

        private async void btnPerfil_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new Perfil(servidor, acceso, usuario));
        }
        private async void btnCambiarContrasena_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new CambioContrasena(servidor, acceso, usuario));
        }
        
        private async void btnAgregarServidor_Clicked(object sender, EventArgs e)
        {
            
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new CrearServidor(servidor, acceso, usuario));
            
        }      

        private async void btnListadoUsuarios_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarUsuarios(servidor, acceso, usuario));
        }

        private async void btnListadoInactivos_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarDesactivados(servidor, acceso, usuario));
        }
        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Principal(servidor, acceso, usuario));
        }
    }
}