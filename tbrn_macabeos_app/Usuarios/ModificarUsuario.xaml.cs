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
    public partial class ModificarUsuario : ContentPage
    {
        public int usuarioMod;
        public int servidor;
        public int acceso;
        public int usuario;
        public ModificarUsuario(int idUsuarioMod, int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            usuarioMod = idUsuarioMod;
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            fillInfo();
        }

        public string nombre;
        public string apellido;
        public string dui;
        public DateTime fechanacimiento;
        public string telefono;
        public string lugartrab;
        public string telefonotrab;
        public string contacto;
        public string telcon;
        public DateTime fechaingreso;
        public string radiopropio;
        public string accesoUser;

        public string fechaNac;
        public string fechaIng;
        public string Radio;

        private async void fillInfo()
        {
            UseManager manager = new UseManager();
            IEnumerable<servidor> result = await manager.servidorLog(usuarioMod);

            if (result.Count() > 0)
            {
                foreach (var nuser in result)
                {
                    nombre = nuser.nombre;
                    apellido = nuser.apellido;
                    dui = nuser.dui;
                    DateTime dateOnly = nuser.fecha_nacimiento;
                    fechanacimiento = dateOnly.Date;
                    telefono = nuser.telefono;
                    lugartrab = nuser.lugar_trab_est;
                    telefonotrab = nuser.telefono_trab_est;
                    contacto = nuser.contacto_emer;
                    telcon = nuser.telefono_emer;
                    DateTime dateOnlyIngreso = nuser.fecha_ingreso;
                    fechaingreso = dateOnlyIngreso;
                    radiopropio = nuser.radio_propio;
                }

                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                txtDui.Text = dui;
                txtTelefono.Text = telefono;
                txtLugarTrabajo.Text = lugartrab;
                txtTelefonoTrabajo.Text = telefonotrab;
                txtContacto.Text = contacto;
                txtTelefonoContacto.Text = telcon;
                txtRadioPropio.SelectedItem = radiopropio;
                txtFechaIngreso.Date = fechanacimiento;
                txtFechaIngreso.Date = fechaingreso;
            }
        }

        private async void bntModificarServidor_click(object sender, EventArgs e)
        {
            try
            {
                var fec1 = txtFechaNacimiento.Date;

                if (fec1 != fechanacimiento)
                {
                    fechaNac = fec1.ToString("yyyy/M/d");
                }
                else
                {
                    fechaNac = fechanacimiento.ToString("yyyy/M/d");
                }

                var fec2 = txtFechaIngreso.Date;

                if (fec2 != fechaingreso)
                {
                    fechaIng = fec2.ToString("yyyy/M/d");
                }
                else
                {
                    fechaIng = fechaingreso.ToString("yyyy/M/d");
                }

                var radioProp1 = txtRadioPropio.SelectedItem.ToString();
                
                if (radioProp1 != radiopropio)
                {
                   Radio = radioProp1;
                }
                else
                {
                    Radio = radiopropio;
                }

                UseManager manager = new UseManager();
                manager.modificarServidor(usuarioMod, txtNombre.Text.ToString(), txtApellido.Text.ToString(), txtDui.Text.ToString(),
                    fechaNac, String.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.ToString(),
                    String.IsNullOrWhiteSpace(txtLugarTrabajo.Text) ? null : txtLugarTrabajo.Text.ToString(),
                    String.IsNullOrWhiteSpace(txtTelefonoTrabajo.Text) ? null : txtTelefonoTrabajo.Text.ToString(),
                    String.IsNullOrWhiteSpace(txtContacto.Text) ? null : txtContacto.Text.ToString(),
                    String.IsNullOrWhiteSpace(txtTelefonoContacto.Text) ? null : txtTelefonoContacto.Text.ToString(),
                    fechaIng, Radio);

                await DisplayAlert("Modificacion", "Modificacion Exitosa", "Aceptar");

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtDui.Text = "";
                txtTelefono.Text = "";
                txtLugarTrabajo.Text = "";
                txtTelefonoTrabajo.Text = "";
                txtContacto.Text = "";
                txtTelefonoContacto.Text = "";

                await Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));

            } catch (Exception e1) {
                Console.WriteLine(e1.Message.ToString());
            }
        }
    }
}