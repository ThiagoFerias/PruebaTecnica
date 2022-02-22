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
    public class PermisosController : Controller
    {
        // GET: Permisos
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/Permisos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Permisos>>(resultString);

                return View(listado);
            }
            return View(new List<Permisos>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Permisos perm)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PostAsync("api/Permisos", perm, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(perm);
            }

            return View(perm);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/Permisos/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<Permisos>(resultString);

                return View(listado);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Permisos perm)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PutAsync("api/Permisos", perm, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(perm);
            }

            return View(perm);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.DeleteAsync("api/Permisos/" + id).Result;

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

            var request = clienteHttp.GetAsync("api/Permisos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<Permisos>(resultString);

                return View(info);
            }
            return View();
        }
    }
}