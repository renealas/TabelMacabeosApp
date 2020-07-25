using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography;
using tbrn_macabeos_app.Clases;

namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambiarContrasenaServidor : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public int idusuarioMod;
        public CambiarContrasenaServidor(int parameter1, int parameter2, int parameter3,int parameter4)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            idusuarioMod = parameter4;
        }

        private async void bntChange_click(object sender, EventArgs e)
        {
            try
            {
                string input1 = txtPassword.Text;
                string input2 = txtPassword2.Text;

                if (input1 == input2)
                {
                    string encryptedPass;

                    MD5 md5 = MD5.Create();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(input1);
                    byte[] hash = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }

                    encryptedPass = sb.ToString();

                    UseManager manager = new UseManager();
                    manager.cambiarPassword(encryptedPass, idusuarioMod);

                    await DisplayAlert("Contraseña", "Su Contraseña a sido cambiada con exito", "Aceptar");
                    await Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));
                }
                else
                {
                    await DisplayAlert("Contraseña", "Su Contraseña no Coincide Trate nuevamente", "Aceptar");
                    txtPassword.Text = "";
                    txtPassword2.Text = "";
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Contraseña", "La Contraseña no se Guardo", "Acceptar");
                txtPassword.Text = "";
                Console.WriteLine(e1.Message.ToString());
            }
        }
    }
}