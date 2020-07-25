using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tbrn_macabeos_app.Clases;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tbrn_macabeos_app.Asistencias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarAsistencia : ContentPage
    {
        public int asistenciaMod;
        public int servidor;
        public int acceso;
        public int usuario;
        public ModificarAsistencia(int idasistenciaMod, int parameter1, int parameter2, int parameter3)
        {
            InitializeComponent();
            asistenciaMod = idasistenciaMod;
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            fillBackgroundInfo();
            fillInfo();
            fillListaServidor();
            fillListaPuesto();
            fillListaRadio();
        }

        public int dia_semana_culto_original;
        public DateTime fecha_original;

        //Variables para picker Servidor
        public int id_servidor_original;        
        public List<fullServidor> Finallist;
        public List<fullServidor> Pickerlist;
        public int itemsedc;

        //Variables para picker Puesto
        public int id_puesto_original;        
        public List<puestos> Finallist1;
        public List<puestos> Pickerlist1;
        public int itemsedc1;

        //Variables para picker Culto
        public int id_culto_original;        
        public List<cultos> Finallist2;
        public List<cultos> Pickerlist2;
        public int itemsedc2;

        //Variables para picker Radios
        public int id_Radios_original;        
        public List<equipos> Finallist3;
        public List<equipos> Pickerlist3;
        public int itemsedc3;

        public string fecha;
        public int dianum;

        //Variables de la Informacion leible
        public int id_leible;
        public string fullname_leible;
        public DateTime fecha_leible;
        public string nombre_culto_leible;
        public int dia_semana_culto_leible;
        public string nombre_puesto_leible;
        public int numero_radio_leible;

        //Variables Finales
        public int id_servidor;
        public int id_puesto;
        public int id_culto;
        public int id_equipo;

        private async void fillBackgroundInfo()
        {
            UseManager manager = new UseManager();
            IEnumerable<asistencia> result = await manager.listarAsistenciasMod(asistenciaMod);

            if (result.Count() > 0)
            {
                foreach (var nuser in result)
                {
                    id_servidor_original = nuser.id_servidor;
                    DateTime dateOnly = nuser.fecha;
                    fecha_original = dateOnly.Date;
                    id_culto_original = nuser.id_culto;
                    dia_semana_culto_original = nuser.dia_semana_culto;
                    id_puesto_original = nuser.id_puesto;
                    id_Radios_original = nuser.id_equipo;
                }

                //txtRadioPropio.SelectedItem = radiopropio; Formato para poner la info
            }
        }

        private async void fillInfo()
        {
            UseManager manager = new UseManager();
            IEnumerable<fullAsistencia> result = await manager.listarAsistenciasInfoMod(asistenciaMod);

            if (result.Count() > 0)
            {
                foreach (var nuser in result)
                {
                    fullname_leible = nuser.fullname;
                    DateTime dateOnly1 = nuser.fecha;
                    fecha_leible = dateOnly1.Date;
                    nombre_culto_leible = nuser.nombre_culto;
                    nombre_puesto_leible = nuser.nombre_puesto;
                    numero_radio_leible = nuser.numero_radio;
                }

                txtServidor.SelectedItem = fullname_leible;
                txtFecha.Date = fecha_leible;
                txtCulto.SelectedItem = nombre_culto_leible;
                txtPuesto.SelectedItem = nombre_puesto_leible;
                txtRadio.SelectedItem = numero_radio_leible;
            }
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
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
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
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
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
                        var exit = Finallist3.Where(i => i.numero_radio == item.numero_radio).ToList();
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
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private void radioPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc3 = Finallist3[txtPuesto.SelectedIndex].id;
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
                await DisplayAlert("Error en Lista", "Favor vuelva a cargar Servidor no listo", "Aceptar");
                Console.WriteLine(e1.Message.ToString());
            }
        }

        private void cultoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsedc2 = Finallist2[txtPuesto.SelectedIndex].id;
        }

        private void fechaSelected_SelectedDateChanged(object sender, EventArgs e)
        {
            var diaconver = txtFecha.Date;
            dianum = (int)diaconver.DayOfWeek;

            fillListaCulto(dianum);
        }

        private async void bntUpdateServicio_click(object sender, EventArgs e)
        {
            try
            {
                //Aqui la variable Fecha sera la que se insertara en el Update. 
                var fechaUp = txtFecha.Date;
                if (fecha_original != fechaUp)
                {
                    fecha = fechaUp.ToString("yyyy-MM-dd");
                }
                else
                {
                    fecha = fecha_original.ToString("yyyy-MM-dd");
                }

                //Aqui Evaluaremos el Usuario Utilizaremos la variable id_servidor para update.
                if (id_servidor_original != itemsedc)
                {
                    id_servidor = itemsedc;
                }
                else
                {
                    id_servidor = id_servidor_original;
                }

                //Aqui Evaluaremos el Culto Utilizaremos la variable id_culto para update.
                if (id_culto_original != itemsedc2)
                {
                    id_culto = itemsedc2;
                }
                else
                {
                    id_culto = id_culto_original;
                }

                //Aqui Evaluaremos el Puesto Utilizaremos la variable id_puesto para update.
                if (id_puesto_original != itemsedc1)
                {
                    id_puesto = itemsedc1;
                }
                else
                {
                    id_puesto = id_puesto_original;
                }

                //Aqui Evaluaremos el Radio Utilizaremos la variable id_equipo para update.
                if (id_Radios_original != itemsedc3)
                {
                    id_equipo = itemsedc3;
                }
                else
                {
                    id_equipo = id_Radios_original;
                }

                //para la Variable Dia Semana Culto utilizaremos la variable dianum.

                UseManager manager = new UseManager();
                manager.modificarAsistencia(asistenciaMod, id_servidor, fecha, id_culto, dianum, id_puesto, id_equipo);

                await DisplayAlert("Modificacion", "Modificacion Exitosa", "Aceptar");

                await Navigation.PushAsync(new MenuAsistencia(servidor, acceso, usuario));
            }
            catch (Exception e1) { Console.WriteLine(e1.Message.ToString()); }
        }
    }
}