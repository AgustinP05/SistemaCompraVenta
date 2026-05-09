using BLL.SistemaCompraVenta.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Entities
{

    public class Rol
    {
        public string Nombre { get; set; }              //Guarda el nombre del rol -> Ej: "Administrador"

        public List<Componente> Permisos { get; set; }  //Guardamos los permisos que tiene el rol -> Ej: Administrador:{CrearUsuario,EditarUsuario, etc...}

        public Rol()                                    //Es el constructor. Inicializa la lista vacia para luego agregar los permisos
        {
            Permisos = new List<Componente>();
        }

        public bool TienePermiso(string permiso)        //Funcion que verifica si el rol tiene el permiso (en string) pasado por parametro. Devuelve true o alse
        {
            foreach (var p in Permisos)
            {
                if (p.Nombre == permiso)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
