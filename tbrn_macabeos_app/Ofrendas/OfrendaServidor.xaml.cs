using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app.Ofrendas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfrendaServidor : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public OfrendaServidor(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
        }

        public float totalFondos;

        private async void bntReporteOfrenda_click(object sender, EventArgs e)
        {
            var fechaInicio = txtFechaInicio.Date.ToString("yyyy/M/d");
            var fechaFin = txtFechaFin.Date.ToString("yyyy/M/d");

            //Aqui llenamos la Variable de Fondos para el periodo del Ministerio
            try
            {
                UseManager manager = new UseManager();
                var result = await manager.listarTotalOfrendas(fechaInicio, fechaFin);

                if (result.Count() > 0)
                {
                    foreach (var nuser in result)
                    {
                        totalFondos = nuser.total_de_mes;
                    }
                    txtTotalFondos.Text = "$"+totalFondos.ToString();
                }
                else
                {
                    txtTotalFondos.Text = servidor.ToString();
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
            }

            //Aqui llenamos el data Table de las contribuciones del servidor para el periodo. 

            try
            {
                UseManager manager = new UseManager();
                var result = await manager.listarTotalOfrendasServidor(fechaInicio, fechaFin, servidor);

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

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuOfrenda(servidor, acceso, usuario));
        }
    }
}