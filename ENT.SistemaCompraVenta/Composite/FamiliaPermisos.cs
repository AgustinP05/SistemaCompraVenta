using System;
using System.Collections.Generic;

namespace ENT.SistemaCompraVenta
{
    public class FamiliaPermisos : Componente
    {
        private List<Componente> hijos = new List<Componente>();

        public void AgregarHijo(Componente componente)
        {
            hijos.Add(componente);
        }

        public List<Componente> ObtenerHijos => hijos;

        public override string Mostrar()
        {
            string resultado = "[Familia] " + Nombre + Environment.NewLine;

            foreach (var hijo in hijos)
            {
                resultado += "   " + hijo.Mostrar();
            }

            return resultado;
        }
        // REQUERIDO: Busca en cascada dentro de toda la familia
        public override bool TienePermiso(string nombrePermiso)
        {
            foreach (var hijo in hijos)
            {
                if (hijo.TienePermiso(nombrePermiso))
                    return true;
            }
            return false;
        }
    }
}

/*
 * Lógica (La recursividad): 
 * Su método TienePermiso implementa una búsqueda en cascada. 
 * No se fija solo en su nombre, sino que le pregunta a todos sus "hijos": 
 * "¿Alguno de ustedes tiene este permiso?". 
 * Si un hijo es a su vez una FamiliaPermisos, este vuelve a preguntar a sus hijos, 
 * creando una búsqueda profunda en toda la estructura.*/
