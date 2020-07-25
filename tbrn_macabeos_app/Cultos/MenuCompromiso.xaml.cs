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
    public partial class MenuCompromiso : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public MenuCompromiso(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
        }

        private async void btnCultos_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarCompromisos(servidor, acceso, usuario));
        }

        private async void btnAgregarCultos_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new AgregarCompromiso(servidor, acceso, usuario));
        }

        private async void btnCultosEliminados_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarCompromisosDes(servidor, acceso, usuario));
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Principal(servidor, acceso, usuario));
        }
    }
}