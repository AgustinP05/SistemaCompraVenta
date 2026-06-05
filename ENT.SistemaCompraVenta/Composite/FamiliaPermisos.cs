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
    }
}