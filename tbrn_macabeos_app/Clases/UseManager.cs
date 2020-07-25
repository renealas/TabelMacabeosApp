using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace tbrn_macabeos_app.Clases
{
    public class UseManager
    {
        //Servidor = 1 es Go Daddy, Servidor = 2 es Securitb.Freetzi
        const String URL = "http://hidraulicadelistmo.com/admin/";
        //const String URL = "http://securitb.freetzi.com/";

        HttpClientHandler hclient = new HttpClientHandler()
        {
            Proxy = null,
            UseProxy = false,
            PreAuthenticate = false
        };

        private HttpClient getClient()
        {
            HttpClient client = new HttpClient(hclient);

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        //Metodos de Usuarios y Servidores

        public async Task<IEnumerable<user>> userLogin(string username, string password)
        {
            HttpClient cliente = getClient();

            var result = await cliente.GetAsync(URL + "login.php?username=" + username + "&password=" + password);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<user>>(content);
            }
            return Enumerable.Empty<user>();
        }

        public async Task<IEnumerable<servidor>> servidorLog(int id)
        {
            HttpClient cliente = getClient();

            HttpResponseMessage result = await cliente.GetAsync(URL + "servidorLog.php?id=" + id);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<servidor>>(content);
            }
            return Enumerable.Empty<servidor>();
        }

        public async void cambiarPassword(string password, int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "updatePassword.php?password=" + password + "&id=" + id);
        }

        public async void registrarServidor(string nombre, string apellido, string dui, string fecha_nacimiento, string telefono, string lugar_trab_est, string telefono_trab_est, string contacto_emer, string telefono_emer, string fecha_ingreso, string foto, string radio_propio, int id_acceso)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "insert.php?nombre=" + nombre + "&apellido=" + apellido + "&dui=" + dui + "&fecha_nacimiento=" +
                fecha_nacimiento + "&telefono=" + telefono + "&lugar_trab_est=" + lugar_trab_est + "&telefono_trab_est=" + telefono_trab_est + "&contacto_emer=" +
                contacto_emer + "&telefono_emer=" + telefono_emer + "&fecha_ingreso=" + fecha_ingreso + "&foto=" + foto + "&radio_propio=" + radio_propio + "&id_acceso=" + id_acceso);
        }

        public async Task<IEnumerable<fullServidor>>listarServidores()
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarUsuarios.php");

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullServidor>>(content);
            }
            return Enumerable.Empty<fullServidor>();
        }

        public async void deshabilitarUsuario(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "desahabilitarUsuario.php?id=" + id);
        }

        public async Task<IEnumerable<fullServidor>> listarServidoresDes()
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarUsuariosDes.php");

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullServidor>>(content);
            }
            return Enumerable.Empty<fullServidor>();
        }

        public async void habilitarUsuario(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "habilitarUsuario.php?id=" + id);
        }

        public async void modificarServidor(int id, string nombre, string apellido, string dui, string fecha_nacimiento, string telefono, string lugar_trab_est, string telefono_trab_est, string contacto_emer, string telefono_emer, string fecha_ingreso, string radio_propio)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "updateServidor.php?id="+ id + "&nombre=" + nombre + "&apellido=" + apellido + "&dui=" + dui + "&fecha_nacimiento=" +
                fecha_nacimiento + "&telefono=" + telefono + "&lugar_trab_est=" + lugar_trab_est + "&telefono_trab_est=" + telefono_trab_est + "&contacto_emer=" +
                contacto_emer + "&telefono_emer=" + telefono_emer + "&fecha_ingreso=" + fecha_ingreso  + "&radio_propio=" + radio_propio);
        }

        //Metodos de Compromisos de Cultos

        public async Task<IEnumerable<fullCompriso>> compromisoLog(int id)
        {
            HttpClient cliente = getClient();

            HttpResponseMessage result = await cliente.GetAsync(URL + "listarCompromisoLog.php?id=" + id);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullCompriso>>(content);
            }
            return Enumerable.Empty<fullCompriso>();
        }

        public async void eliminarCompromiso(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "eliminarCompromiso.php?id=" + id);
        }

        public async void registrarCompromiso(int id_servidor, int id_culto)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "insertCompromiso.php?id_servidor=" + id_servidor + "&id_culto=" + id_culto);
        }

        public async Task<IEnumerable<fullCompriso>> compromisoLogDes(int id)
        {
            HttpClient cliente = getClient();

            HttpResponseMessage result = await cliente.GetAsync(URL + "listarCompromisoLogDes.php?id=" + id);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullCompriso>>(content);
            }
            return Enumerable.Empty<fullCompriso>();
        }

        public async void habilitarCompromiso(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "habilitarCompromiso.php?id=" + id);
        }

        //Metodo de Culto (Para Lista de Picker)

        public async Task<IEnumerable<cultos>> listarCultos()
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarCultos.php");

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<cultos>>(content);
            }
            return Enumerable.Empty<cultos>();
        }

        public async Task<IEnumerable<cultos>> listarCultosPorDia(int diaculto)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarCultosPorDia.php?dia_culto="+ diaculto);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<cultos>>(content);
            }
            return Enumerable.Empty<cultos>();
        }

        //Metodos de Equipos (Radios)

        public async void registrarEquipo(string serial_radio, int numero_radio, string estatus)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "insertEquipo.php?serial_radio=" + serial_radio + "&numero_radio=" + numero_radio + "&estatus=" + estatus);
        }

        public async Task<IEnumerable<equipos>> listarEquipos()
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarEquipos.php");

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<equipos>>(content);
            }
            return Enumerable.Empty<equipos>();
        }

        public async void eliminarEquipo(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "eliminarEquipo.php?id=" + id);
        }

        //Metodos de Ofrendas

        public async Task<IEnumerable<ofrendas>> listarOfrendas(string fecha1, string fecha2)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarOfrendas.php?fecha1="+ fecha1 + "&fecha2="+ fecha2);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ofrendas>>(content);
            }
            return Enumerable.Empty<ofrendas>();
        }

        public async Task<IEnumerable<ofrendas>> listarTotalOfrendas(string fecha1, string fecha2)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarTotalOfrendas.php?fecha1=" + fecha1 + "&fecha2=" + fecha2);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ofrendas>>(content);
            }
            return Enumerable.Empty<ofrendas>();
        }

        public async Task<IEnumerable<ofrendas>> listarTotalOfrendasServidor(string fecha1, string fecha2, int id_servidor)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarTotalOfrendasServidor.php?fecha1=" + fecha1 + "&fecha2=" + fecha2 + "&id_servidor=" + id_servidor);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ofrendas>>(content);
            }
            return Enumerable.Empty<ofrendas>();
        }

        public async void registrarOfrenda(string tipo_operacion, int id_servidor, string fecha, string concepto, float abono, float retiro)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "insertOfrenda.php?tipo_operacion=" + tipo_operacion + "&id_servidor=" + id_servidor + "&fecha=" + fecha + "&concepto=" + concepto + "&abono=" + abono + "&retiro=" + retiro);
        }

        public async void eliminarOfrenda(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "eliminarOfrenda.php?id=" + id);
        }

        // Metodos listar Puestos

        public async Task<IEnumerable<puestos>> listarPuestos()
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarPuestos.php");

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<puestos>>(content);
            }
            return Enumerable.Empty<puestos>();
        }

        //Metodos de Asistencia. 
        public async void registrarAsistencia(int id_servidor, string fecha, int id_culto, int dia_semana_culto, int id_puesto, int id_equipo)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "insertAsistencia.php?id_servidor="+ id_servidor +"&fecha="+ fecha + "&id_culto="+ id_culto +"&dia_semana_culto="+ dia_semana_culto + "&id_puesto="+ id_puesto +"&id_equipo="+ id_equipo);
        }

        public async Task<IEnumerable<fullAsistencia>> listarAsistenciasLider(string fecha, int id_culto)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarAsistenciaLider.php?fecha=" + fecha + "&id_culto=" + id_culto );

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullAsistencia>>(content);
            }
            return Enumerable.Empty<fullAsistencia>();
        }

        public async Task<IEnumerable<fullAsistencia>> listarAsistenciasServidor(int id_servidor)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarAsistenciaServidor.php?id_servidor=" + id_servidor);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullAsistencia>>(content);
            }
            return Enumerable.Empty<fullAsistencia>();
        }

        public async void eliminarAsistencia(int id)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "eliminarAsistencia.php?id=" + id);
        }

        public async void modificarAsistencia(int id, int id_servidor, string fecha, int id_culto, int dia_semana_culto, int id_puesto, int id_equipo)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "updateAsistencia.php?id=" + id + "&id_servidor=" + id_servidor + "&fecha=" + fecha + "&id_culto=" + id_culto + "&dia_semana_culto=" + dia_semana_culto + "&id_puesto=" + id_puesto + "&id_equipo=" + id_equipo);
        }

        public async Task<IEnumerable<asistencia>> listarAsistenciasMod(int id)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarAsistenciaMod.php?id=" + id);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<asistencia>>(content);
            }
            return Enumerable.Empty<asistencia>();
        }

        public async Task<IEnumerable<fullAsistencia>> listarAsistenciasInfoMod(int id)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "listarAsistenciaModInfo.php?id=" + id);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<fullAsistencia>>(content);
            }
            return Enumerable.Empty<fullAsistencia>();
        }
    }
}
