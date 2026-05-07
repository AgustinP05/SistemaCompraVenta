using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Entities
{
    // Enum que define los distintos roles del sistema.
    // Se utiliza para evitar errores con strings y mejorar la legibilidad.
    public enum Rol //La variable Rol solo puede ser uno de los siguientes
    {
        Administrador,
        Vendedor,
        Stock,
        Gerente
    }
}
