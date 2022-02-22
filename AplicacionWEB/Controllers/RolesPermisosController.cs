using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWEB.Controllers
{
    public class RolesPermisosController : Controller
    {
        // GET: RolesPermisos
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/RolesPermisos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Roles_Permisos>>(resultString);

                return View(listado);
            }
            return View(new List<Roles_Permisos>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Roles_Permisos dato)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PostAsync("api/RolesPermisos", dato, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(dato);
            }

            return View(dato);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/RolesPermisos/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<Roles_Permisos>(resultString);

                return View(listado);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.DeleteAsync("api/RolesPermisos/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/RolesPermisos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<Roles_Permisos>(resultString);

                return View(info);
            }
            return View();
        }
    }
}