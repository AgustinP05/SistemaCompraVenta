using ENT.SistemaCompraVenta; 
using System;
using System.Collections.Generic;

namespace BLL.SistemaCompraVenta.Sesion
{
    public class Sesion
    {

        private static Sesion instancia;

        public Usuario UsuarioActual { get; set; }

        private Sesion() { } 
       
        //Antes de iniciar sesion es null. Se instancia una sesion y se retorna
        public static Sesion ObtenerInstancia() 
        {
            if (instancia == null)
                instancia = new Sesion();

            return instancia;
        }

        //Vuelve a ser null
        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}