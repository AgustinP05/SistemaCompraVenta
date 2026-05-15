# Sport UPE - Sistema de Gestión Administrativa 👟🔨

**Sport UPE** es una solución integral de software diseñada para la comercialización minorista de calzado y vestimenta deportiva. El sistema permite gestionar de manera eficiente el circuito de compras y ventas, el control de inventario y la administración de usuarios mediante una arquitectura robusta y escalable.

## 📌 Requerimientos de la Entrega (1ra Etapa)

Este proyecto cumple con los hitos establecidos para la primera presentación de la cátedra:

* 
**Gestión de Usuarios:** Implementación de 4 perfiles con acceso restringido según el rol.

* 
**Arquitectura:** Diseño basado en Programación Orientada a Objetos (POO) estructurado en 4 capas (UI, BLL, DAL, Entidades).

* 
**Simulación Funcional:** Producto software operativo desde Visual Studio con datos en memoria (sin conexión a DB obligatoria en esta fase).



## 👥 Perfiles y Actores

El sistema contempla los siguientes roles de usuario:

| Actor | Descripción | Funciones Clave |
| --- | --- | --- |
| **Administrador** | Gestión global del sistema.

 | Alta/Baja de usuarios y asignación de permisos.

 |
| **Vendedor** | Atención al cliente y transacciones.

 | Registro de ventas y gestión de base de clientes.

 |
| **Encargado de Stock** | Control de logística e inventario.

 | Monitoreo de stock y compras a proveedores.

 |
| **Gerente** | Supervisión estratégica.

 | Visualización de reportes y estadísticas de venta.

 |

## 🛠️ Tecnologías y Arquitectura

* **Lenguaje:** C# (.NET Framework)
* **Interfaz:** Windows Forms (WinForms)
* **Patrones de Diseño Implementados:**
* 
**Singleton:** Utilizado para la gestión de la sesión de usuario actual.


* 
**Composite:** Implementado para la estructura jerárquica de permisos y roles.




* **Estructura de Capas:**
1. **UI (User Interface):** Presentación visual y captura de eventos.
2. **BLL (Business Logic Layer):** Validación de reglas de negocio.
3. **DAL (Data Access Layer):** Gestión de persistencia (simulada en 1ra entrega).
4. **Entidades:** Objetos de negocio que transitan entre capas.



## 🚀 Instalación y Ejecución

1. Clonar el repositorio: `git clone https://github.com/AgustinP05/SistemaCompraVenta.git`
2. Abrir el archivo `.sln` en **Visual Studio 2022** o superior.
3. Establecer el proyecto **UI.SistemaCompraVentas** como "Proyecto de inicio".
4. Presionar `F5` para compilar y ejecutar.

## 📄 Casos de Uso Documentados

El proyecto incluye especificaciones detalladas para los procesos críticos:

* 
**CU-VTA0001:** Registrar Venta (Flujo normal y alternativos de stock/cliente).


* 
**CU-VTA0002:** Crear Cliente (Alta y validación de DNI).


* 
**CU-GER0001:** Generar Reporte de Ventas (Filtrado y visualización de KPIs).



---

**Integrantes del Equipo (Grupo 1):**

* Agustín Perea 


* 
**Sofía Inés Schenone** 


* Agostina Villamayor 


* Julieta Lázaro 


