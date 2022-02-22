using Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class PermisosController : ApiController
    {
        DB_PruebTecEntities db = new DB_PruebTecEntities();
        // GET: api/Permisos
        public IEnumerable<Permisos> Get()
        {
            var listado = db.Permisos.ToList();
            return listado;
        }

        // GET: api/Permisos/5
        public Permisos Get(int id)
        {
            var permiso = db.Permisos.FirstOrDefault(x => x.IdPermiso == id);
            return permiso;
        }

        // POST: api/Permisos
        [HttpPost]
        public bool Post(Permisos permiso)
        {
            db.Permisos.Add(permiso);
            return db.SaveChanges() > 0;
        }

        // PUT: api/Permisos/5
        [HttpPut]
        public bool Put(Permisos perm)
        {
            var permisoUpdate = db.Permisos.FirstOrDefault(x => x.IdPermiso == perm.IdPermiso);
            permisoUpdate.Vista = perm.Vista;
            permisoUpdate.Ubicacion = perm.Ubicacion;
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Permisos/5
        [HttpDelete]
        public bool Delete(int id)
        {
            var permisoEliminar = db.Permisos.FirstOrDefault(X => X.IdPermiso == id);
            db.Permisos.Remove(permisoEliminar);
            return db.SaveChanges() > 0;
        }
    }
}
