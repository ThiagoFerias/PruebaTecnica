using Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class BaseController : ApiController
    {
        public bool Verify(string token)
        {
            using (DB_PruebTecEntities db = new DB_PruebTecEntities())
            {
                if(db.Usuarios.Where(d=>d.Token==token && d.Estado == 1).Count() > 0)
                    return true;
            }
            return false;
        }
    }
}
