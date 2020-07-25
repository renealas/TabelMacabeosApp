using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Globalization;

using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;

        public Perfil(int parameter1, int parameter2, int parameter3)
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
        public string dui;
        public string fecha_nacimiento;
        public string telefono;
        public string trabajo;
        public string tel_trabajo;
        public string contacto;
        public string tel_contacto;
        public string fecha_ingreso;
        public string foto;
        public string radio_propio;

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
                        var duiNum = Int64.Parse(nuser.dui);
                        dui = duiNum.ToString("00000000-0");
                        fecha_nacimiento = nuser.fecha_nacimiento.ToString("dd MMMM yyyy",CultureInfo.CreateSpecificCulture("es-SV"));
                        telefono = nuser.telefono;
                        trabajo = nuser.lugar_trab_est;
                        tel_trabajo = nuser.telefono_trab_est;
                        contacto = nuser.contacto_emer;
                        tel_contacto = nuser.telefono_emer;
                        fecha_ingreso = nuser.fecha_ingreso.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-SV"));
                        foto = nuser.foto;
                        radio_propio = nuser.radio_propio;
                        FullName = nombre + " " + apellido;                      
                    }
                    Fotografia.Source = ImageSource.FromUri(new Uri(foto));
                    Nombre_Completo.Text = FullName;
                    DUI.Text = dui;
                    Fecha_de_Nacimiento.Text = fecha_nacimiento;
                    Telefono.Text = telefono;
                    Trabajo.Text = trabajo;
                    Telefono_Trabajo.Text = tel_trabajo;
                    Contacto.Text = contacto;
                    Telefono_Contacto.Text = tel_contacto;
                    Fecha_Ingreso.Text = fecha_ingreso;
                    Radio_Propio.Text = radio_propio;
                }
                else
                {
                    Nombre_Completo.Text = servidor.ToString();
                    DUI.Text = servidor.ToString();
                    Fecha_de_Nacimiento.Text = servidor.ToString();
                    Telefono.Text = servidor.ToString();
                    Trabajo.Text = servidor.ToString();
                    Telefono_Trabajo.Text = servidor.ToString();
                    Contacto.Text = servidor.ToString();
                    Telefono_Contacto.Text = servidor.ToString();
                    Fecha_Ingreso.Text = servidor.ToString();
                    Radio_Propio.Text = servidor.ToString();
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message.ToString());

            }
        }

        public ImageSource ProductImage
        {
            get
            {
                var source = new Uri(foto);
                return source;
            }
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));
        }
    }
}