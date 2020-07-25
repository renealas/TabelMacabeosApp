using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace tbrn_macabeos_app.Clases
{
    public class fullAsistencia
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha { get; set; }
        public string nombre_culto { get; set; }
        public string nombre_puesto { get; set; }
        public int numero_radio { get; set; }

        public string fullname
        {
            get { return this.nombre + " " + this.apellido; }
        }

        public string fechaString
        {
            get { return this.fecha.Date.ToString("dd-MMMM-yyyy", new CultureInfo("es-ES")); }
        }
    }
}
