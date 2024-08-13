# Ecommerce API + JWT Tokens + SQLite

# Características del sistema. (Desarrollado por Francisco Urquiza y José Daniele)
- Implementación de la arquitectura en capas MVC.
- Patrón de capa Servicio para la lógica de negocio.
- Patrón DTO para crear, listar y actualizar datos.
- AutoMapper para la mapear de manera más eficiente los DTOs a modelos y separar la lógica de mapeo del servicio.
- Inyección de dependencia para servicios, mappers, etc.
- Validación de modelos DTOs con Regular Expressions.
- Model First (creación, migración y versionamiento de la base de datos a partir del modelo).
- Interfaces de Servicio.

# Auth para autenticación y autorización
El sistema de Auth cuenta de controlador y servicio. Permite gestionar permisos y roles de acceso a lo endpoints contando con:
- Login.- Genera Token de Acceso.
- 
# Usuarios
Gestión de usuarios con Jwt y diferentes roles y permisos:
- Obtener usuario por Id.
- Eliminar Usuario por Email (solo SuperAdmin).
- Eliminar usuario por Id (solo Administrador).

# SuperAdmin
Gestión de SuperAdmins:
- Obtener todos los SuperAdmins (Solo SuperAdmin).
- Obtener SuperAdmin por Email (Solo SuperAdmin).
- Crear SuperAdmin (Solo SuperAdmin).
- Editar SuperAdmin (solo SuperAdmin logeado en su cuenta).

# Admin
Gestión de Admins:
- Obtener todos los Admins (Solo SuperAdmin).
- Obtener Admin por Email (Solo SuperAdmin).
- Crear Admin (Solo SuperAdmin).
- Editar Admin (solo Administrador logeado en su cuenta).

# Client
El sistema permite una gestión completa para los clientes.
- Crear cuenta de cliente.- 
    - Email
    - Nombre
    - Apellido
    - Número de teléfono
    - Contraseña
    - Estado o Provincia
    - Ciudad
    - Dirección
    - DNI
- Listar cliente por email.
- Listar todos los clientes (Únicamente Administradores).
- Editar cliente (Únicamente pueden hacerlo el propietario de cada cuenta).

# Order
Permite realizar órdenes de compra de los diferentes productos existentes
- Obtener todas las órdenes (Admin o Client).
- Obtener orden por Id (Solo Admin).
- Obtener el historial de órdenes realizadas (Solo los clientes logeados en sus cuentas).
- Obtener las órdenes pendientes a ser enviadas (Solo los Admins).
- Crear una orden de compra (Solo Client y no pueden realizar la orden si el producto no posee stock, o si el mismo es menor a la cantidad que se está solicitando).
- Editar el estado de una orden, es decir, si fue enviada o sigue pendiente (Solo los Admins).
- Cancelar una orden (Solo Client).

# Product
La sección de productos permite gestionar los mismos y visualizarlos
- Obtener todos los productos (Cualquiera puede acceder).
- Obtener producto por Id (Cualquiera puede acceder).
- Crear Producto (Solo Admin).
- Editar Producto (Solo Admin).
- Editar Stock y Precio de un Producto (Solo Admin).
- Borrado lógico de producto (solo Administrador) (IsDelete = true)

# DTO para la administración de entrata y salida de datos
Para este sistema se cuenta con 12 DTOs.

# Dependencias
- Entity Framework
- Entity Framwork SQLite
- Entity Framwork Core
- Entity Framwork Tools
- AutoMapper
- FluentValidation
- Jwt Bearer
- Tokens

Desarrollado por Francisco Urquiza y José Daniele.
