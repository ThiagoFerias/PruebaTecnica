using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.WS
{
    public class ListPublicacionesViewModel
    {
        public int IdPublicacion { get; set; }
        public string NombrePublicacion { get; set; }
        public string DescripcionPublicacion { get; set; }
        public string ImgPublicacion { get; set; }
        public bool? Visible { get; set; }
    }
}
