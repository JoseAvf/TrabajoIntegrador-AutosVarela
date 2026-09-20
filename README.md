# TrabajoIntegrador-AutosVarela

//  AutosVarela - Sistema de Gestión para Taller Mecánico  //

AutosVarela es un sistema web diseñado para digitalizar y organizar la gestión de clientes, vehículos y reparaciones de un taller mecánico, permitiendo registrar trabajos, consultar historiales y controlar el estado de las reparaciones de manera centralizada.

// Planteamiento del Problema  //

Actualmente, los procesos de gestión de la información en el entorno del taller (administración de clientes, seguimiento de vehículos y control de reparaciones) se ejecutan de manera analógica y descentralizada, dependiendo principalmente de registros físicos y planillas independientes.

Objetivo General: Diseñar, desarrollar e implementar una aplicación web transaccional que centralice la información operativa del taller. 

Roles del Sistema

El sistema contempla los siguientes perfiles de usuario, cada uno con responsabilidades y niveles de acceso específicos:

Recepcionista (Perfil Administrativo):

Encargado del ingreso de datos maestros al sistema (Clientes y Vehículos).

Generación y apertura de Órdenes de Reparación.

Consulta global de información y estados.

Especificaciones Funcionales:

//El sistema soporta las siguientes operaciones fundamentales://

Gestión de Entidades Maestras: Operaciones CRUD (Crear, Leer, Actualizar, Borrar) para el manejo de Clientes.

Gestión de Activos: Asociación relacional de Vehículos a Entidades Cliente.

Gestión de Transacciones: Creación y seguimiento de Órdenes de Reparación.

Control de Flujo de Trabajo: Máquina de estados para el seguimiento del ciclo de vida de las reparaciones.

Trazabilidad e Historial: Módulo de consulta estructurada para recuperar el registro histórico de intervenciones por vehículo.

//Arquitectura y Stack Tecnológico//

El proyecto se sustenta en una arquitectura de software orientada a la separación de responsabilidades (Frontend/Backend) y el uso de componentes escalables:
Framework Principal & Backend: C# (.NET)
Arquitectura: Diseño por capas / Separación de responsabilidades lógicas.
Control de Versiones: Git y plataforma GitHub.

//  Ingeniería de Requisitos y Metodología de Trabajo  //

El desarrollo de este Trabajo Integrador se rige por un enfoque ágil y prácticas estandarizadas de Ingeniería de Software:

Marco de Trabajo: Scrum.

Gestión iterativa mediante Sprints.

Mantenimiento de Product Backlog y Sprint Backlog.

Herramienta de Gestión: Trello.

Artefactos de Documentación:

Modelado del Sistema (Diagramas UML).

Levantamiento mediante Historias de Usuario.

Especificación de Requerimientos Funcionales y No Funcionales.

Planificación y ejecución de Pruebas.

