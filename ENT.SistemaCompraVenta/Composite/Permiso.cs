using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ENT.SistemaCompraVenta // Namespace unificado de Entidades
{
    // Cambiamos a PUBLIC para que sea visible en todo el sistema
    public class Permiso : Componente
    {
        // Representa una "Patente" o acción simple (ej: "Vender", "Borrar")
        public override void Mostrar()
        {
            Console.WriteLine(Nombre);
        }
    }
}