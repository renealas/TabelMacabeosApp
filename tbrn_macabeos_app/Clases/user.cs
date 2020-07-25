using System;
using System.Collections.Generic;
using System.Text;

namespace tbrn_macabeos_app.Clases
{
    public class user
    {
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String activo { get; set; }
        public int id_acceso { get; set; }
        public int id_servidor { get; set; }
    }
}
