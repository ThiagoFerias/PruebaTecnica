using Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class RolesController : ApiController
    {
        DB_PruebTecEntities db = new DB_PruebTecEntities();
        // GET: api/Roles
        public IEnumerable<Roles> Get()
        {
            var listado = db.Roles.ToList();
            return listado;
        }

        // GET: api/Roles/5
        public Roles Get(int id)
        {
            var rol = db.Roles.FirstOrDefault(x => x.IdRol == id);
            return rol;
        }

        // POST: api/Roles
        [HttpPost]
        public bool Post(Roles rol)
        {
            db.Roles.Add(rol);
            return db.SaveChanges() > 0;
        }

        // PUT: api/Roles/5
        [HttpPut]
        public bool Put(Roles rol)
        {
            var rolUpdate = db.Roles.FirstOrDefault(x => x.IdRol == rol.IdRol);
            rolUpdate.NombreRol = rol.NombreRol;
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Roles/5
        [HttpDelete]
        public bool Delete(int id)
        {
            var rolEliminar = db.Roles.FirstOrDefault(X => X.IdRol == id);
            db.Roles.Remove(rolEliminar);
            return db.SaveChanges() > 0;
        }
    }
}
