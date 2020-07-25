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
    public partial class ListarAsistenciaLider : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public ListarAsistenciaLider(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
        }

        public int id_culto;
        public List<cultos> Finallist2;
        public List<cultos> Pickerlist2;
        public int itemsedc2;

        public int dianum;

        private async void fillListaCulto(int diaculto)
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<cultos> result = await manager.listarCultosPorDia(diaculto);

                if (result != null)
                {
                    txtCulto.ItemsSource = result.ToList();

                    Pickerlist2 = result.ToList();
                    Finallist2 = new List<cultos>();

                    foreach (var item in Pickerlist2)
                    {
                        var exit = Finallist2.Where(i => i.nombre_culto == item.nombre_culto).ToList();
                        if (exit.Count == 0)
                        {
                            Finallist2.Add(item);
                        }
                    }


                    //lstUsuarios.ItemsSource = result;
                }
            }
            catch (Exception e1)
            {
                //await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar", "Cancelar");
                await Navigation.PushAsync(new ListarAsistenciaLider(servidor, acceso, usuario));
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private void cultoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc2 = Finallist2[txtCulto.SelectedIndex].id;
        }

        private void fechaSelected_SelectedDateChanged(object sender, EventArgs e)
        {
            var diaconver = txtFecha.Date;
            dianum = (int)diaconver.DayOfWeek;

            fillListaCulto(dianum);
        }

        private async void bntReporteAsistencia_click(object sender, EventArgs e)
        {
            var fecha = txtFecha.Date.ToString("yyyy/M/d");

            //Aqui llenamos el data Table de las contribuciones del servidor para el periodo. 

            try
            {
                UseManager manager = new UseManager();
                var result = await manager.listarAsistenciasLider(fecha, itemsedc2);

                if (result != null)
                {
                    lstAsistencia.ItemsSource = result;
                }
            }
            catch (Exception e1)
            {
                //await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar", "Cancelar");
                await Navigation.PushAsync(new ListarAsistenciaLider(servidor, acceso, usuario));
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private async void Modificar_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            fullAsistencia asistenciaVar = (fullAsistencia)item.CommandParameter;

            await Navigation.PushAsync(new ModificarAsistencia(servidor, acceso, usuario, asistenciaVar.id));

        }

        private async void Eliminar_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            fullAsistencia equipoVar = (fullAsistencia)item.CommandParameter;

            UseManager manager = new UseManager();
            manager.eliminarAsistencia(equipoVar.id);

            await Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));

        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));
        }
    }
}