using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Composite
{
    public class FamiliaPermisos : Componente                           //Representa un grupo de permisos
    {
        private List<Componente> hijos = new List<Componente>();        //Una lista llamada hijos que hereda las caracteristicas de Componente. Asi poder hacer que un tipo de usuario tenga varios permisos 

        public void AgregarHijo(Componente componente)
        {
            hijos.Add(componente);
        }

        public override void Mostrar()
        {
            Console.WriteLine(Nombre);

            foreach (var hijo in hijos)
            {
                hijo.Mostrar();
            }
        }
    }
}
