# Funcionalidades del sistema — Autos Varela

## 1. Descripción general

Autos Varela es un sistema web destinado a facilitar la administración de un taller mecánico.

El sistema está organizado en cuatro módulos principales: clientes, vehículos, personal y reparaciones.

## 2. Gestión de clientes

Permite registrar y consultar la información de los clientes del taller.

Operaciones contempladas:

- Registrar clientes con sus datos personales y de contacto.
- Consultar el listado de clientes registrados.
- Buscar clientes por nombre, apellido o DNI.
- Consultar un cliente mediante su identificador.
- Validar los datos ingresados.
- Evitar el registro de clientes con DNI duplicado.

## 3. Gestión de vehículos

Permite registrar vehículos y asociarlos con sus respectivos propietarios.

Operaciones contempladas:

- Registrar vehículos con patente, marca, modelo, año, color y kilometraje.
- Consultar los vehículos registrados.
- Buscar vehículos por patente.
- Asociar cada vehículo con un cliente existente.
- Validar el formato de la patente y otros datos del vehículo.
- Evitar el registro de patentes duplicadas.

## 4. Gestión de personal

Permite administrar la información de los empleados del taller.

Operaciones contempladas:

- Registrar personal con nombre, apellido, DNI, especialidad y teléfono.
- Consultar el personal registrado.
- Buscar un empleado mediante su identificador.
- Validar los datos ingresados.
- Evitar registros con DNI duplicado.

## 5. Gestión de reparaciones

Permite registrar los trabajos realizados sobre los vehículos.

Cada reparación contiene:

- Fecha de ingreso y fecha de finalización, cuando corresponda.
- Descripción del trabajo.
- Diagnóstico.
- Costo.
- Estado de la reparación.
- Observaciones.
- Vehículo asociado.
- Personal responsable.

Los estados definidos son Pendiente, EnReparacion, Finalizada y Cancelada.

El servicio de reparaciones verifica la existencia del vehículo y del personal asociado antes de registrar un trabajo.

## 6. Validaciones

El sistema utiliza DataAnnotations y validaciones en los servicios para controlar los datos ingresados.

Entre las verificaciones se incluyen:

- Campos obligatorios y formatos válidos.
- DNI y patentes duplicadas.
- Existencia de las entidades relacionadas.
- Coherencia de los datos de las reparaciones.

## 7. Almacenamiento de información

Los datos se mantienen en memoria mediante MockData.

Esto permite trabajar con información de ejemplo y realizar operaciones sin configurar una base de datos.

La información no se conserva de manera permanente al reiniciar la aplicación.

## 8. Pruebas

El sistema cuenta con pruebas unitarias desarrolladas con xUnit y verificaciones manuales de funcionamiento.

Se comprueban situaciones como registros correctos, datos inválidos, duplicados y asociaciones inexistentes.

## 9. Alcance

Este documento describe las operaciones contempladas en los módulos y servicios del sistema. La disponibilidad de cada operación desde la interfaz web depende de los controladores y vistas implementados.
