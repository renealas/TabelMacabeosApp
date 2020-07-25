using System;
using System.Collections.Generic;
using System.Text;

namespace tbrn_macabeos_app.Clases
{
    public class asistencia
    {
        public int id { get; set; }
        public int id_servidor { get; set; }
        public DateTime fecha { get; set; }
        public int id_culto { get; set; }
        public int dia_semana_culto { get; set; }
        public int id_puesto { get; set; }
        public int id_equipo { get; set; }

    }
}
