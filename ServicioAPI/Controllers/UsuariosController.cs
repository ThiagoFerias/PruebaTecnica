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
    public class UsuariosController : ApiController
    {
        DB_PruebTecEntities db = new DB_PruebTecEntities();
        // GET: api/Usuarios
        public IEnumerable<Usuarios> Get()
        {
            var listado = db.Usuarios.ToList();
            return listado;
        }

        // GET: api/Usuarios/5
        public Usuarios Get(int id)
        {
            var usuario = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public bool Post(Usuarios user)
        {
            db.Usuarios.Add(user);
            return db.SaveChanges() > 0;
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        public bool Put(Usuarios user)
        {
            var usuarioUpdate = db.Usuarios.FirstOrDefault(x => x.IdUsuario == user.IdUsuario);
            usuarioUpdate.PrimerNombre = user.PrimerNombre;
            usuarioUpdate.SegundoNombre = user.SegundoNombre;
            usuarioUpdate.PrimerApellido = user.PrimerApellido;
            usuarioUpdate.SegundoApellido = user.SegundoApellido;
            usuarioUpdate.NumCelular = user.NumCelular;
            usuarioUpdate.Email = user.Email;
            usuarioUpdate.Contrasenia = user.Contrasenia;
            usuarioUpdate.Estado = user.Estado;
            usuarioUpdate.IdRol = user.IdRol;
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        public bool Delete(int id)
        {
            var usuarioEliminar = db.Usuarios.FirstOrDefault(X => X.IdUsuario == id);
            db.Usuarios.Remove(usuarioEliminar);
            return db.SaveChanges() > 0;
        }

        
    }
}
