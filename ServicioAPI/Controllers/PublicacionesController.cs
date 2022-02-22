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
    public class PublicacionesController : BaseController
    {
        DB_PruebTecEntities db = new DB_PruebTecEntities();
        /*[HttpPost]
        public Reply Get([FromBody]SecurityViewModel model)
        {
            Reply oR = new Reply();
            oR.result = 0;
            if (!Verify(model.token))
            {
                oR.message = "No autorizado";
                return oR;
            }
                
            try
            {
                using (DB_PruebTecEntities db = new DB_PruebTecEntities())
                {

                    List<ListPublicacionesViewModel> lst = (from d in db.Publicaciones
                                                            select new ListPublicacionesViewModel
                                                            {
                                                                IdPublicacion = d.IdPublicacion,
                                                                NombrePublicacion = d.NombrePublicacion,
                                                                DescripcionPublicacion = d.DescripcionPublicacion,
                                                                ImgPublicacion = d.ImgPublicacion,
                                                                Visible = d.Visible
                                                            }).ToList();
                    oR.data = lst;
                    oR.result = 1; 
                }
            }
            catch (Exception ex)
            {
                oR.message = "Error! - Error en el servidor";
            }
            return oR;
        }
        */
        // GET: api/Publicaciones
        [HttpGet]
        public IEnumerable<Publicaciones> Get()
        {
            var listado = db.Publicaciones.ToList();
            return listado;
        }

        // GET: api/Publicaciones/5
        [HttpGet]
        public Publicaciones Get(int id)
        {
            var publicacion = db.Publicaciones.FirstOrDefault(x => x.IdPublicacion == id);
            return publicacion;
        }
        // POST: api/Publicaciones
        [HttpPost]
        public bool Post(Publicaciones publicacion)
        {
            db.Publicaciones.Add(publicacion);
            return db.SaveChanges() > 0;
        }

        // PUT: api/Publicaciones/5
        [HttpPut]
        public bool Put(Publicaciones publicacion)
        {
            var publicacionUpdate = db.Publicaciones.FirstOrDefault(x => x.IdPublicacion == publicacion.IdPublicacion);
            publicacionUpdate.NombrePublicacion = publicacion.NombrePublicacion;
            publicacionUpdate.DescripcionPublicacion = publicacion.DescripcionPublicacion;
            publicacionUpdate.ImgPublicacion = publicacion.ImgPublicacion;
            publicacionUpdate.Visible = publicacion.Visible;
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete]
        public bool Delete(int id)
        {
            var publicacionEliminar = db.Publicaciones.FirstOrDefault(X => X.IdPublicacion == id);
            db.Publicaciones.Remove(publicacionEliminar);
            return db.SaveChanges() > 0;
        }
        
    }
}
