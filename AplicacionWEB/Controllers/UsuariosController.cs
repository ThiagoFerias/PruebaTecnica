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
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/Usuarios").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Usuarios>>(resultString);

                return View(listado);
            }
            return View(new List<Usuarios>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
             
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Usuarios usuario)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PostAsync("api/Usuarios", usuario, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/Usuarios/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<Usuarios>(resultString);

                return View(listado);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Usuarios usu)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PutAsync("api/Usuarios", usu, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(usu);
            }

            return View(usu);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.DeleteAsync("api/Usuarios/" + id).Result;

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

            var request = clienteHttp.GetAsync("api/Usuarios?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<Usuarios>(resultString);

                return View(info);
            }
            return View();
        }

       
    }
}