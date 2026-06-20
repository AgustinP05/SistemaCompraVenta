using System;
using System.Collections.Generic;

namespace ENT.SistemaCompraVenta
{
    // Nodo compuesto del Composite. Representa un rol-familia: agrupa permisos (hojas)
    // y/o otros roles-familia. ID_Familia lleva el ID del rol que representa.
    public class FamiliaPermisos : Componente
    {
        private int idFamilia;
        private List<Componente> hijos = new List<Componente>();

        public int ID_Familia
        {
            get { return idFamilia; }
            set { idFamilia = value; }
        }

        public void AgregarHijo(Componente componente)
        {
            hijos.Add(componente);
        }

        public List<Componente> ObtenerHijos => hijos;

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

        // ¿Contiene (directa o indirectamente) al rol indicado? Se usa para evitar
        // composiciones cíclicas (A→B→A).
        public bool ContieneRol(int idRol)
        {
            foreach (var hijo in hijos)
                if (hijo is FamiliaPermisos sub)
                    if (sub.ID_Familia == idRol || sub.ContieneRol(idRol))
                        return true;
            return false;
        }

        // Permisos hoja efectivos (sin repetir), bajando por los sub-roles en cascada.
        public List<Permiso> ObtenerPermisosEfectivos()
        {
            var acumulado = new Dictionary<int, Permiso>();
            Recolectar(this, acumulado);
            return new List<Permiso>(acumulado.Values);
        }

        private static void Recolectar(FamiliaPermisos familia, Dictionary<int, Permiso> acumulado)
        {
            foreach (var hijo in familia.hijos)
            {
                if (hijo is Permiso p) acumulado[p.ID_Permiso] = p;
                else if (hijo is FamiliaPermisos sub) Recolectar(sub, acumulado);
            }
        }

        // Etiqueta para mostrarse en listas (la distingue de un permiso individual).
        public override string ToString() => "[Rol] " + Nombre;
    }
}

/*
 * Lógica (La recursividad): 
 * Su método TienePermiso implementa una búsqueda en cascada. 
 * No se fija solo en su nombre, sino que le pregunta a todos sus "hijos": 
 * "¿Alguno de ustedes tiene este permiso?". 
 * Si un hijo es a su vez una FamiliaPermisos, este vuelve a preguntar a sus hijos, 
 * creando una búsqueda profunda en toda la estructura.*/
