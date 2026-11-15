# Arquitectura del sistema — Autos Varela

## 1. Descripción general

Autos Varela es una aplicación web desarrollada en C# utilizando ASP.NET Core MVC sobre .NET 10.

El sistema organiza sus responsabilidades mediante el patrón Modelo-Vista-Controlador (MVC), complementado con una capa de servicios e interfaces para implementar la lógica de negocio.

Los datos se almacenan en memoria mediante la clase MockData, sin utilizar una base de datos persistente.

## 2. Patrón MVC

La aplicación utiliza tres componentes principales:

### Modelo (Model)

Representa las entidades del dominio y sus datos.

Las entidades principales son:

- Cliente
- Vehiculo
- Personal
- Reparacion
- EstadoReparacion (enumeración)

Las entidades contienen propiedades, relaciones y atributos de validación mediante DataAnnotations. La lógica de negocio se mantiene separada en los servicios.

### Vista (View)

Representa la interfaz visual con la que interactúa el usuario.

Las vistas están desarrolladas con Razor y Bootstrap, y permiten visualizar información, completar formularios y realizar operaciones desde el navegador.

### Controlador (Controller)

Recibe las solicitudes del usuario, coordina las operaciones con los servicios y devuelve las vistas correspondientes.

Los controladores utilizan interfaces de servicios para acceder a la lógica de negocio, evitando implementarla directamente en las acciones MVC.

## 3. Capa de servicios

La capa de servicios contiene las operaciones y reglas de negocio del sistema.

Se encuentra organizada mediante las siguientes interfaces e implementaciones:

| Interfaz | Implementación | Responsabilidad |
|---|---|---|
| IClienteService | ClienteService | Gestión y búsqueda de clientes |
| IVehiculoService | VehiculoService | Gestión de vehículos y asociación con clientes |
| IPersonalService | PersonalService | Gestión del personal del taller |
| IReparacionService | ReparacionService | Registro y gestión de reparaciones |

Los servicios realizan validaciones, verifican duplicados cuando corresponde, asignan identificadores y establecen relaciones entre entidades.

## 4. Interfaces

Las interfaces definen los contratos que deben cumplir los servicios.

Su utilización permite separar las implementaciones concretas de los componentes que las consumen.

Entre sus beneficios se encuentran:

- Separación de responsabilidades.
- Menor acoplamiento entre componentes.
- Mayor facilidad para modificar implementaciones.
- Mejor organización de las pruebas unitarias.

## 5. Inyección de dependencias

ASP.NET Core proporciona un contenedor de inyección de dependencias que permite registrar y resolver automáticamente los servicios.

En Program.cs se utiliza la siguiente configuración:

```csharp
builder.Services.AddSingleton<MockData>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IPersonalService, PersonalService>();
builder.Services.AddScoped<IReparacionService, ReparacionService>();
```

AddSingleton permite compartir una misma instancia de MockData durante la ejecución de la aplicación.

AddScoped crea una instancia del servicio por ámbito de solicitud HTTP, de acuerdo con el ciclo de vida habitual de ASP.NET Core MVC.

Las dependencias se reciben mediante los constructores de los servicios y controladores.

## 6. Almacenamiento de datos: MockData

La clase MockData contiene colecciones de objetos de las entidades principales:

- Clientes
- Vehiculos
- Personal
- Reparaciones

Estas colecciones permiten simular el almacenamiento y la recuperación de información sin incorporar una base de datos.

Los cambios realizados se mantienen en memoria mientras se conserva la instancia de MockData. Al reiniciar la aplicación, los datos vuelven a inicializarse.

## 7. Validaciones

Se utilizan atributos DataAnnotations para validar las propiedades de las entidades.

Además, los servicios realizan verificaciones relacionadas con las reglas de negocio, como evitar DNI o patentes duplicadas y comprobar la existencia de las entidades asociadas.

## 8. Pruebas unitarias

El proyecto incluye pruebas unitarias desarrolladas con xUnit.

Las pruebas permiten verificar el comportamiento de los servicios, incluyendo operaciones válidas, validaciones y situaciones de error.

La separación mediante interfaces y servicios facilita comprobar la lógica de negocio sin depender de las vistas MVC.

## 9. Diagramas UML

La arquitectura se complementa con los siguientes diagramas:

- [Modelo de dominio](UML_Modelo_Dominio.md)
- [Interfaces y servicios](UML_Servicios.md)
