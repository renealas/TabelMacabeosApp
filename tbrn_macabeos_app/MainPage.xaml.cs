using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Threading.Tasks;
using System.Security.Cryptography;

using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public int servidor;
        public int acceso;
        public int usuario;

        private async void OnChangeUser(object sender, TextChangedEventArgs e)
        {
            var allowedchar = "0123456789";

            if (!txtUsuario.Text.All(allowedchar.Contains))
            {
                await DisplayAlert("Formato Erroneo", "Solo Introducir Numeros", "Aceptar");
                txtUsuario.Text = "";
            }

        }

        private async void btnIngresar_click(object sender, EventArgs e)
        {
            waitActivityIndicator.IsRunning = true;
            bntIngresar.IsEnabled = false;

            try
            {
                string input = txtPassword.Text;
                string encryptedPass;

                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                encryptedPass = sb.ToString();

                UseManager manager = new UseManager();
                var result = await manager.userLogin(txtUsuario.Text.ToString(), encryptedPass);

                if (result.Count() > 0)
                {
                    foreach (var nuser in result)
                    {
                        servidor = nuser.id_servidor;
                        acceso = nuser.id_acceso;
                        usuario = nuser.id;
                    }
                    //await Navigation.PushAsync(new Principal(servidor, acceso, usuario));
                    await Navigation.PushAsync(new SplashPage(servidor, acceso, usuario));
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o Contraseña Incorrectos", "Acceptar");
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Error de Conexion", "Conexion al Servidor no alcanzada. Trate de nuevo", "Acceptar");
                Console.WriteLine(e1.Message.ToString());
            }
            waitActivityIndicator.IsRunning = false;
            bntIngresar.IsEnabled = true;
        }
    }
}
