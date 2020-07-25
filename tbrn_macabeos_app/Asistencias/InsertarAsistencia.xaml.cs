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
    public partial class InsertarAsistencia : ContentPage
    {
        public int servidor;
        public int acceso;
        public int usuario;
        public InsertarAsistencia(int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
        }
        //Variables para picker Servidor
        public int id_servidor;
        public List<fullServidor> Finallist;
        public List<fullServidor> Pickerlist;
        public int itemsedc;

        //Variables para picker Puesto
        public int id_puesto;
        public List<puestos> Finallist1;
        public List<puestos> Pickerlist1;
        public int itemsedc1;

        //Variables para picker Culto
        public int id_culto;
        public List<cultos> Finallist2;
        public List<cultos> Pickerlist2;
        public int itemsedc2;

        //Variables para picker Radios
        public int id_Radios;
        public List<equipos> Finallist3;
        public List<equipos> Pickerlist3;
        public int itemsedc3;

        public string fecha;
        public int dianum;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            fillListaServidor();
            fillListaPuesto();
            fillListaRadio();
        }

        //Metodos de Llenado y Seleccion ID Servidor
        private async void fillListaServidor()
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
                Console.WriteLine("*************************************");
                Console.WriteLine(e1.ToString());
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
            }
        }

        private void servidorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc = Finallist[txtServidor.SelectedIndex].id;
        }

        //Metodos de Llenado y Seleccion ID Puesto
        private async void fillListaPuesto()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<puestos> result = await manager.listarPuestos();

                if (result != null)
                {
                    txtPuesto.ItemsSource = result.ToList();

                    Pickerlist1 = result.ToList();
                    Finallist1 = new List<puestos>();

                    foreach (var item in Pickerlist1)
                    {
                        var exit = Finallist1.Where(i => i.nombre_puesto == item.nombre_puesto).ToList();
                        if (exit.Count == 0)
                        {
                            Finallist1.Add(item);
                        }
                    }


                    //lstUsuarios.ItemsSource = result;
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("*************************************");
                Console.WriteLine(e1.ToString());
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
            }
        }

        private void puestoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc1 = Finallist1[txtPuesto.SelectedIndex].id;
        }

        //Metodos de Llenado y Seleccion ID Radio
        private async void fillListaRadio()
        {
            try
            {
                UseManager manager = new UseManager();
                IEnumerable<equipos> result = await manager.listarEquipos();

                if (result != null)
                {
                    txtRadio.ItemsSource = result.ToList();

                    Pickerlist3 = result.ToList();
                    Finallist3 = new List<equipos>();

                    foreach (var item in Pickerlist3)
                    {
                        var exit = Finallist3.Where(i => i.estatus == item.estatus).ToList();
                        if (exit.Count == 0)
                        {
                            Finallist3.Add(item);
                        }
                    }


                    //lstUsuarios.ItemsSource = result;
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("*************************************");
                Console.WriteLine(e1.ToString());
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
            }
        }

        private void radioPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc3 = Finallist3[txtRadio.SelectedIndex].id;
        }

        //Metodos de Llenado y Seleccion ID Radio
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
                Console.WriteLine("*************************************");
                Console.WriteLine(e1.ToString());
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
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

        private async void bntAgregarServicio_click(object sender, EventArgs e)
        {
            try
            {
                var valid = 0;
                id_servidor = itemsedc;
                id_puesto = itemsedc1;
                id_Radios = itemsedc3;
                id_culto = itemsedc2;
                fecha = txtFecha.Date.ToString("yyyy-MM-dd");
                var diaConvertir = txtFecha.Date;
                var diaenNum = (int)diaConvertir.DayOfWeek;

                if (id_servidor == 0)
                {
                    ValidadorServidor.Text = "Debe Seleccionar al Servidor";
                    valid = valid + 1;
                }
                if (id_puesto == 0)
                {
                    ValidadorPuesto.Text = "Debe Seleccionar el Puesto";
                    valid = valid + 1;
                }
                if (id_culto == 0)
                {
                    ValidadorCulto.Text = "Debe Seleccionar el Culto";
                    valid = valid + 1;
                }
                if (fecha == null)
                {
                    ValidadorFecha.Text = "Debe Seleccionar el Fecha";
                    valid = valid + 1;
                }
                if (id_Radios == 0)
                {
                    ValidadorRadio.Text = "Debe Seleccionar el Radio";
                    valid = valid + 1;
                }

                if (valid == 0)
                {
                    UseManager manager = new UseManager();
                    manager.registrarAsistencia(id_servidor, fecha, id_culto, diaenNum, id_puesto, id_Radios);

                    await DisplayAlert("Registro", "Registro Exitoso", "Aceptar");

                    await Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));
                }
                else
                {
                    await DisplayAlert("Registro", "No puede Insertar Asistencia hasta llenar Valores Faltantes", "Aceptar");
                }
            }
            catch (Exception e1) { Console.WriteLine(e1.Message.ToString()); }
        }

        private async void bntBack_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));
        }
    }
}