using Dominio.WS;
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
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccessViewModel model)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:55079/");

            var request = clienteHttp.PostAsync("api/Access/Login", model, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;

                Reply restult = JsonConvert.DeserializeObject<Reply>(resultString);

                if (restult.result > 0)
                {
                    return RedirectToAction("../Home/Manage");
                }
                return View(model);
            }

            return View(model);
        }
        
    }
}