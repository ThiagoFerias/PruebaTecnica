using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Roles_Permisos
    {
        public int IdRolPermiso { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
        public bool Estado { get; set; }
    }
}
