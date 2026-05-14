using System;
using System.Collections.Generic;

namespace ENT.SistemaCompraVenta // Namespace unificado
{
    // Cambiamos a PUBLIC para que la BLL y la UI puedan usarla
    public class FamiliaPermisos : Componente
    {
        // La lista de hijos ahora guarda objetos 'Componente' que también están en ENT
        private List<Componente> hijos = new List<Componente>();

        public void AgregarHijo(Componente componente)
        {
            hijos.Add(componente);
        }

        // Propiedad para acceder a los hijos (útil para la BLL)
        public List<Componente> ObtenerHijos => hijos;

        public override void Mostrar()
        {
            // Lógica de visualización simple para consola/depuración
            Console.WriteLine(Nombre);

            foreach (var hijo in hijos)
            {
                hijo.Mostrar();
            }
        }
    }
}