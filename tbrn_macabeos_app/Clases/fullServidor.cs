using System;
using System.Collections.Generic;
using System.Text;

namespace tbrn_macabeos_app.Clases
{
    public class fullServidor
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String username { get; set; }
        public String activo { get; set; }
        public String tipo_acceso { get; set; }
        public String imgsource { get; set; }

        public string fullname
        {
            get { return this.nombre + " " + this.apellido; }
        }

    }
}
