using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Composite
{
    public class Permiso : Componente       //Representa un permiso individual/simple ej:Registrar venta o Editar producto
    {
        public override void Mostrar()
        {
            Console.WriteLine(Nombre);
        }
    }
}
