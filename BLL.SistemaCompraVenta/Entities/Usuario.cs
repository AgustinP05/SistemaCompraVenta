using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Entities
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}
