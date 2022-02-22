using Datos.Model;
using Datos.Model.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class AccessController : ApiController
    {
        [HttpPost]
        public Reply Login([FromBody] AccessViewModel model)
        {
            Reply oR = new Reply();
            oR.result = 0;
            try
            {
                using (DB_PruebTecEntities db = new DB_PruebTecEntities())
                {
                    var lst = db.Usuarios.Where(d => d.Email == model.email && d.Contrasenia == model.password && d.Estado == 1);

                    if (lst.Count() > 0)
                    {
                        oR.result = 1;
                        oR.data = Guid.NewGuid().ToString();

                        Usuarios oUser = lst.First();
                        oUser.Token = (string)oR.data;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        oR.message = "Datos incorrectos";
                    }
                }

            }
            catch (Exception ex)
            {
                oR.result = 0;
                oR.message = "Ocurrio un error - autenticación";
            }
            return oR;
        }
    }
}
