using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Composite
{
    public abstract class Componente        //Esta es una clase que sirve como base para sus herederos
    {
        public string Nombre { get; set; }  //Todos los componentes tienen Nombre

        public abstract void Mostrar();     //Todas las clases hijas estan obligadas a tener la funcion Mostrar()
    }
}
