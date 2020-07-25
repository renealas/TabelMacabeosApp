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
    public partial class InsertarOfrenda : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public InsertarOfrenda(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            fillLista();
        }

        public string nombre;
        public string apellido;
        public string FullName;
        public int id_servidor;
        public List<fullServidor> Finallist;
        public List<fullServidor> Pickerlist;
        public int itemsedc;
        public string operacion;
        public float abono;
        public float retiro;
        public int valid = 0;

        private async void fillLista()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<fullServidor> result = await manager.listarServidores();

                if (result != null)
                {
                    txtServidor.ItemsSource = result.ToList();

                    Pickerlist = result.ToList();
                    Finallist = new List<fullServidor>();

                    foreach (var item in Pickerlist)
                    {
                        var exit = Finallist.Where(i => i.fullname == item.fullname).ToList();
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
                await DisplayAlert("Error en Lista", "Servidor no listo Trate nuevamente", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private async void OnChangeAbono(object sender, TextChangedEventArgs e)
        {
            var allowedchar = "0123456789.";

            ValidadorAbono.IsVisible = false;

            if (!txtAbono.Text.All(allowedchar.Contains))
            {
                await DisplayAlert("Formato Erroneo", "Solo Introducir Numeros", "Aceptar");
                txtAbono.Text = "";
            }

        }

        private async void OnChangeRetiro(object sender, TextChangedEventArgs e)
        {
            var allowedchar = "0123456789.";

            ValidadorRetiro.IsVisible = false;

            if (!txtRetiro.Text.All(allowedchar.Contains))
            {
                await DisplayAlert("Formato Erroneo", "Solo Introducir Numeros", "Aceptar");
                txtRetiro.Text = "";
            }

        }

        private void pickerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidadorServidor.IsVisible = false;
            itemsedc = Finallist[txtServidor.SelectedIndex].id;
        }

        private void pickerlist_SelectedIndexChanged1(object sender, EventArgs e)
        {
            operacion = txtOperacion.SelectedItem.ToString();
            var abon1 = "Abono";
            var retir1 = "Retiro";

            ValidadorOperacion.IsVisible = false;
                       
            if (String.Equals(operacion, abon1))
            {
                ValidadorAbono.Text = "Debe introducir un Abono";
                txtRetiro.IsEnabled = false;
                txtRetiro.Text = "0.00";
            }
            

            if (String.Equals(operacion, retir1))
            {
                ValidadorRetiro.Text = "Debe introducir un Retiro";
                txtAbono.IsEnabled = false;
                txtAbono.Text = "0.00";
            }            
        }

        //Opciones de validacion

        void cambioFecha(object sender, EventArgs e)
        {
            ValidadorFecha.IsVisible = false;
        }

        void cambioConcepto(object sender, TextChangedEventArgs e)
        {
            ValidadorConcepto.IsVisible = false;
        }

        private async void bntAgregarOfrenda_click(object sender, EventArgs e)
        {
            try
            {
                var abon1 = "Abono";
                var retir1 = "Retiro";
                var fecha = txtFechaOfrenda.Date.ToString("yyyy/M/d");

                id_servidor = itemsedc;

                var concepto = txtConcepto.Text.ToString();

                abono = float.Parse(txtAbono.Text.ToString());
                retiro = float.Parse(txtRetiro.Text.ToString());

                    UseManager manager = new UseManager();
                    manager.registrarOfrenda(operacion, id_servidor, fecha, concepto, abono, retiro);

                    await DisplayAlert("Registro", "Registro Exitoso", "Aceptar");

                    txtConcepto.Text = "";
                    txtAbono.Text = "0.00";
                    txtRetiro.Text = "0.00";

                    await Navigation.PushAsync(new MenuOfrenda(servidor, acceso, usuario));
                
            }
            catch (Exception e1) { }
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuOfrenda(servidor, acceso, usuario));
        }
    }
}