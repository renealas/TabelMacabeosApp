using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace tbrn_macabeos_app.Clases
{
    public class ofrendas
    {
        public int id { get; set; }
        public string tipo_operacion { get; set; }
        public int id_servidor { get; set; }
        public DateTime fecha { get; set; }
        public string concepto { get; set; }
        public float abono { get; set; }
        public float retiro { get; set; }
        public float total { get; set; }
        public float total_de_mes { get; set; }

        public string fechaString
        {
            get { return this.fecha.Date.ToString("dd-MMMM-yyyy", new CultureInfo("es-ES"));}
        }

        public string Dinero
        {
            get { return "$ " + this.total.ToString(); }
        }
    }

    
}
