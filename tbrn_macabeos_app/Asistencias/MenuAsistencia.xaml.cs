using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tbrn_macabeos_app.Asistencias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuAsistencia : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public MenuAsistencia(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;

            if (acceso >= 3)
            {
                btnAsistenciaLider.IsVisible = false;
                btnAgregarAsistencia.IsVisible = false;
            }
            else
            {
                btnAsistenciaLider.IsVisible = true;
                btnAgregarAsistencia.IsVisible = true;
            }
        }

        private async void btnAsistenciaServidor_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarAsistenciaServidor(servidor, acceso, usuario));
        }
        private async void btnAgregarAsistencia_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new InsertarAsistencia(servidor, acceso, usuario));
        }

        private async void btnAsistenciaLider_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListarAsistenciaLider(servidor, acceso, usuario));
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Principal(servidor, acceso, usuario));
        }
    }
}