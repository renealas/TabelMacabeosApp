using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Threading.Tasks;
using System.Security.Cryptography;

using tbrn_macabeos_app.Clases;


namespace tbrn_macabeos_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambioContrasena : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;

        public CambioContrasena(int parameter1,int parameter2, int parameter3)
        {
            InitializeComponent();

            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
        }

        private async void bntChange_click(object sender, EventArgs e)
        {
            try
            {
                string input1 = txtPassword.Text;
                string input2 = txtPassword2.Text;
                int valid = 0;

                if (String.IsNullOrEmpty(input1))
                {
                    Validador1.Text = "Debe Agregar la contraseña";
                    valid = valid + 1;
                }

                if (String.IsNullOrEmpty(input2))
                {
                    Validador2.Text = "Debe Repetir la contraseña";
                    valid = valid + 1;
                }

                if (valid == 0)

                {
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
                        manager.cambiarPassword(encryptedPass, usuario);

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

                else
                {
                    await DisplayAlert("Registro", "No puede Cambiar la contraseña hasta llenar Valores Faltantes", "Aceptar");
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Contraseña", "La Contraseña no se Guardo", "Acceptar");
                txtPassword.Text = "";
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuUsuarios(servidor, acceso, usuario));
        }

    }
}