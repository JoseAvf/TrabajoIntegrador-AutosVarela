# UML — Modelo de dominio

Este diagrama representa las entidades principales del sistema Autos Varela, sus atributos y las relaciones entre ellas.

```mermaid
classDiagram
    direction TB

    class Cliente {
        +int IdCliente
        +string Nombre
        +string Apellido
        +string Dni
        +string Telefono
        +string Email
        +string Direccion
        +List~Vehiculo~ Vehiculos
    }

    class Vehiculo {
        +int IdVehiculo
        +string Patente
        +string Marca
        +string Modelo
        +int? Anio
        +string Color
        +int? Kilometraje
        +Cliente? Cliente
        +List~Reparacion~ Reparaciones
    }

    class Personal {
        +int IdPersonal
        +string Nombre
        +string Apellido
        +string Dni
        +string Especialidad
        +string Telefono
        +List~Reparacion~ Reparaciones
    }

    class Reparacion {
        +int IdReparacion
        +DateTime FechaIngreso
        +DateTime? FechaFinalizacion
        +string Descripcion
        +string? Diagnostico
        +decimal Costo
        +EstadoReparacion Estado
        +string? Observaciones
        +Vehiculo? Vehiculo
        +Personal? Personal
    }

    class EstadoReparacion {
        <<enumeration>>
        Pendiente
        EnReparacion
        Finalizada
        Cancelada
    }

    Cliente "1" --> "0..*" Vehiculo : posee
    Vehiculo "1" --> "0..*" Reparacion : tiene
    Personal "1" --> "0..*" Reparacion : realiza
    Reparacion --> EstadoReparacion : utiliza
```

## Descripción

- **Cliente:** contiene los datos de los clientes y sus vehículos.
- **Vehiculo:** representa los vehículos registrados y sus reparaciones.
- **Personal:** contiene los datos de los empleados del taller.
- **Reparacion:** registra los trabajos realizados, sus fechas, costos, estados y responsables.
- **EstadoReparacion:** enumeración con los estados Pendiente, EnReparacion, Finalizada y Cancelada.

Las multiplicidades representan las asociaciones de negocio establecidas durante el registro mediante los servicios. Las propiedades de navegación anulables permiten referencias nulas en los objetos C#.

La lógica de negocio se encuentra en los servicios, por lo que las entidades no incluyen métodos de registro, búsqueda o modificación.