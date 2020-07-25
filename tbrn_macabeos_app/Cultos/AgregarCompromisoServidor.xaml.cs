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
    public partial class AgregarCompromisoServidor : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public int idservidorMod;
        public AgregarCompromisoServidor(int parameter1, int parameter2, int parameter3, int parameter4)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            idservidorMod = parameter4;
            init();
            fillLista();
        }

        public string nombre;
        public string apellido;
        public string FullName;
        public int id_culto;
        public List<cultos> Finallist;
        public List<cultos> Pickerlist;
        public int itemsedc;

        private async void init()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<servidor> result = await manager.servidorLog(idservidorMod);

                if (result.Count() > 0)
                {
                    foreach (var nuser in result)
                    {
                        nombre = nuser.nombre;
                        apellido = nuser.apellido;
                        FullName = nombre + " " + apellido;
                    }
                    txtNombre.Text = FullName;
                }
                else
                {
                    txtNombre.Text = servidor.ToString();
                }
            }
            catch (Exception e1)
            {

            }
        }

        private async void fillLista()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<cultos> result = await manager.listarCultos();

                if (result != null)
                {
                    txtCulto.ItemsSource = result.ToList();

                    Pickerlist = result.ToList();
                    Finallist = new List<cultos>();

                    foreach (var item in Pickerlist)
                    {
                        var exit = Finallist.Where(i => i.nombre_culto == item.nombre_culto).ToList();
                        if (exit.Count == 0)
                        {
                            Finallist.Add(item);
                        }
                    }


                    //lstUsuarios.ItemsSource = result;
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private void pickerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc = Finallist[txtCulto.SelectedIndex].id;
        }

        private async void bntCrearCompromiso_click(object sender, EventArgs e)
        {
            //var accesoAsignado = txtCulto.SelectedItem.ToString();

            //var domingo7 = "Dominical 7 AM";
            //var domingo9 = "Dominical 9 AM";
            //var domingo11 = "Dominical 11 AM";
            //var domingo2 = "Dominical 2 PM";
            //var domingo4 = "Dominical 4 PM";
            //var lunes = "Familias en Victoria";
            //var martes = "Torre de Oracion";
            //var miercolesam = "Amanceciendo con Dios";
            //var miercolespm = "Noche de Amigos";
            //var jueves = "Noche de Discipulado";
            //var viernes = "Viernes de Milagros";
            //var sabado = "Sabado de Milagros";

            //if (String.Equals(domingo7, accesoAsignado))
            //{
            //    id_culto = 1;
            //}
            //if (String.Equals(domingo9, accesoAsignado))
            //{
            //    id_culto = 2;
            //}
            //if (String.Equals(domingo11, accesoAsignado))
            //{
            //    id_culto = 3;
            //}
            //if (String.Equals(domingo2, accesoAsignado))
            //{
            //    id_culto = 4;
            //}
            //if (String.Equals(domingo4, accesoAsignado))
            //{
            //    id_culto = 5;
            //}
            //if (String.Equals(lunes, accesoAsignado))
            //{
            //    id_culto = 6;
            //}
            //if (String.Equals(martes, accesoAsignado))
            //{
            //    id_culto = 7;
            //}
            //if (String.Equals(miercolesam, accesoAsignado))
            //{
            //    id_culto = 8;
            //}
            //if (String.Equals(miercolespm, accesoAsignado))
            //{
            //    id_culto = 9;
            //}
            //if (String.Equals(jueves, accesoAsignado))
            //{
            //    id_culto = 10;
            //}
            //if (String.Equals(viernes, accesoAsignado))
            //{
            //    id_culto = 11;
            //}
            //if (String.Equals(sabado, accesoAsignado))
            //{
            //    id_culto = 12;
            //}

            id_culto = itemsedc;

            try
            {
                var valid = 0;

                if (id_culto == 0)
                {
                    ValidadorCulto.Text = "Debe Seleccionar el Culto";
                    valid = valid + 1;
                }

                if (valid == 0)
                {
                    UseManager manager = new UseManager();
                    manager.registrarCompromiso(idservidorMod, id_culto);

                    await DisplayAlert("Registro", "Registro Exitoso", "Aceptar");

                    await Navigation.PushAsync(new MenuCompromiso(servidor, acceso, usuario));
                }
                else
                {
                    await DisplayAlert("Registro", "No puede Insertar Compromiso hasta llenar Valores Faltantes", "Aceptar");
                }
            }
            catch (Exception e1) { }
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuCompromiso(servidor, acceso, usuario));
        }
    }
}