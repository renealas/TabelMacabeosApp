using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Threading.Tasks;

using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public Detail(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            init();
        }

        public string nombre;
        public string apellido;
        public string FullName;

        private async void init()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<servidor> result = await manager.servidorLog(servidor);

                if (result.Count() > 0)
                {
                    foreach (var nuser in result)
                    {
                        nombre = nuser.nombre;
                        apellido = nuser.apellido;
                        FullName = nombre + " " + apellido;
                    }
                    Nombre_Completo.Text = FullName;
                }
                else
                {
                    Nombre_Completo.Text = servidor.ToString();
                }
            }
            catch (Exception e1)
            {

            }
        }
    }
}