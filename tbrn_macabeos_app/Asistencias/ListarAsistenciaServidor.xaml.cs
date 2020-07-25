using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app.Asistencias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarAsistenciaServidor : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public ListarAsistenciaServidor(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            fillListaAsistenciaServidor();
        }

        public string nombre;
        public string apellido;
        public string FullName;

        private async void fillListaAsistenciaServidor()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<fullAsistencia> result = await manager.listarAsistenciasServidor(servidor);
                if (result != null)
                {
                    lstAsistencia.ItemsSource = result;
                }

                if (result.Count() > 0)
                {
                    foreach (var nuser in result)
                    {
                        nombre = nuser.nombre;
                        apellido = nuser.apellido;
                        FullName = nombre + " " + apellido;
                    }
                    LblUser.Text = "Hermano: " + FullName;
                }
            }
            catch (Exception e1)
            {
                //await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar", "Cancelar");
                await Navigation.PushAsync(new ListarAsistenciaServidor(servidor, acceso, usuario));
                Console.WriteLine(e1.Message.ToString());
            }

        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));
        }
    }
}