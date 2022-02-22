using Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class RolesPermisosController : ApiController
    {
        DB_PruebTecEntities db = new DB_PruebTecEntities();
        // GET: RolesPermisos
        public IEnumerable<Roles_Permisos> Get()
        {
            var listado = db.Roles_Permisos.ToList();
            return listado;
        }

        // GET: api/Roles/5
        public Roles_Permisos Get(int id)
        {
            var info = db.Roles_Permisos.FirstOrDefault(x => x.IdRolPermiso == id);
            return info;
        }

        // POST: api/Roles
        [HttpPost]
        public bool Post(Roles_Permisos dato)
        {
            db.Roles_Permisos.Add(dato);
            return db.SaveChanges() > 0;
        }


        // PUT: api/RolesPermisos/5
        [HttpPut]
        public bool Put(Roles_Permisos dato)
        {
            var rpUpdate = db.Roles_Permisos.FirstOrDefault(x => x.IdRolPermiso == dato.IdRolPermiso);
            rpUpdate.Estado = dato.Estado;
            return db.SaveChanges() > 0;
        }

        // DELETE: api/RolesPermisos/5
        [HttpDelete]
        public bool Delete(int id)
        {
            var rpEliminar = db.Roles_Permisos.FirstOrDefault(X => X.IdRolPermiso == id);
            db.Roles_Permisos.Remove(rpEliminar);
            return db.SaveChanges() > 0;
        }
    }
}
