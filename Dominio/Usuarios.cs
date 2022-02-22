using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public long Cedula { get; set; }
        public string Email { get; set; }
        public long NumCelular { get; set; }
        public string Contrasenia { get; set; }
        public int? Estado { get; set; }
        public string Token { get; set; }
        public int IdRol { get; set; }

        public virtual Rolles Roles { get; set; }
    }
}
