using ENT.SistemaCompraVenta; 
using System;
using System.Collections.Generic;

namespace BLL.SistemaCompraVenta.Sesion
{
    public class Sesion
    {
        //esta variable pertenece a la clase y
        //no a un objeto específico,
        //por lo que vive durante toda la ejecución del programa.
        private static Sesion instancia;

        // Ahora Visual Studio va a encontrar 'Usuario' porque está en el using de arriba
        public Usuario UsuarioActual { get; set; }

        private Sesion() { } // Constructor privado: nadie puede hacer "new Sesion()"
       
        public static Sesion ObtenerInstancia() 
        {
            if (instancia == null)
                instancia = new Sesion();

            return instancia;
        }

        public void Login(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}