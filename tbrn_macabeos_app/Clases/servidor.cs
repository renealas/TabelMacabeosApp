using System;
using System.Collections.Generic;
using System.Text;

namespace tbrn_macabeos_app.Clases
{
    public class servidor
    {

        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String dui { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public String telefono { get; set; }
        public String lugar_trab_est { get; set; }
        public String telefono_trab_est { get; set; }
        public String contacto_emer { get; set; }
        public String telefono_emer { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public String foto { get; set; }
        public String radio_propio { get; set; }
    }
}
