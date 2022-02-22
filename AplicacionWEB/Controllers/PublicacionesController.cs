using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWEB.Controllers
{
    public class PublicacionesController : Controller
    {
        // GET: Publicaciones
        public ActionResult Index()
        {
            /*var httpClient  = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:55079/api/Publicaciones/Get");

            return View();*/
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/Publicaciones").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Publicaciones>>(resultString);

                return View(listado);
            }
            return View(new List<Publicaciones>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Publicaciones publicacion)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PostAsync("api/Publicaciones", publicacion, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(publicacion);
            }

            return View(publicacion);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.GetAsync("api/Publicaciones/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<Publicaciones>(resultString);

                return View(listado);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Publicaciones publicacion)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PutAsync("api/Publicaciones", publicacion, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var confirm = JsonConvert.DeserializeObject<bool>(resultString);

                if (confirm)
                {
                    return RedirectToAction("Index");
                }
                return View(publicacion);
            }

            return View(publicacion);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.DeleteAsync("api/Publicaciones/" + id).Result;

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

            var request = clienteHttp.GetAsync("api/Publicaciones?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<Publicaciones>(resultString);

                return View(info);
            }
            return View();
        }
    }
}