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
    public partial class Principal : MasterDetailPage
    {
        public int servidor;
        public int acceso;
        public int usuario;

        public Principal(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();

            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;

            this.Master = new master(servidor,acceso,usuario);
            this.Detail = new NavigationPage(new Detail(servidor,acceso,usuario));

            App.MasterD = this;                       
        }

        

    }
}