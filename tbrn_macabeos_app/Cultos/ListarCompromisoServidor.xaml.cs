using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarCompromisoServidor : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public int idservidorMod;
        public ListarCompromisoServidor(int parameter1, int parameter2, int parameter3, int parameter4)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            idservidorMod = parameter4;
            fillLista();
        }

        private async void fillLista()
        {
            try
            {
                UseManager manager = new UseManager();
                var result = await manager.compromisoLog(idservidorMod);

                if (result != null)
                {
                    lstUsuarios.ItemsSource = result;
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private async void Eliminar_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            fullCompriso compromisoVar = (fullCompriso)item.CommandParameter;

            UseManager manager = new UseManager();
            manager.eliminarCompromiso(compromisoVar.id);

            await Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));

        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));
        }
    }
}