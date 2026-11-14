\# Documentación — Autos Varela



\## Descripción del proyecto



Autos Varela es una aplicación web desarrollada como trabajo práctico integrador universitario, destinada a gestionar la información de un taller mecánico.



El sistema permite administrar clientes, vehículos, personal y reparaciones, facilitando la organización y el seguimiento de los trabajos realizados.



\## Tecnologías utilizadas



\- C#

\- ASP.NET Core MVC (.NET 10)

\- Bootstrap

\- Datos en memoria mediante MockData

\- xUnit para pruebas unitarias

\- Git y GitHub para control de versiones



\## Arquitectura del sistema



El proyecto utiliza el patrón Modelo-Vista-Controlador (MVC), junto con una capa de servicios que implementa la lógica de negocio.



Se utilizan interfaces e inyección de dependencias para separar responsabilidades y facilitar el mantenimiento y las pruebas.



Los datos se almacenan temporalmente en colecciones en memoria, sin utilizar una base de datos persistente.



\## Documentación disponible



\### Diagramas UML



\- \[UML del modelo de dominio](UML\_Modelo\_Dominio.md): clases principales, atributos y relaciones del sistema.

\- \[UML de interfaces y servicios](UML\_Servicios.md): interfaces, implementaciones y dependencias entre servicios.



\### Documentación técnica y funcional



\- \[Arquitectura del sistema](Arquitectura.md): organización del proyecto, servicios e inyección de dependencias.

\- \[Funcionalidades implementadas](Funcionalidades.md): descripción de las operaciones disponibles en la aplicación.



\## Metodología de trabajo



El desarrollo se organizó mediante Scrum, utilizando un Product Backlog y cuatro sprints.



Se utilizó Trello para gestionar las tareas y GitHub para el control de versiones, mediante ramas, commits y pull requests.



\## Pruebas



El proyecto incluye pruebas unitarias desarrolladas con xUnit y verificaciones manuales de las principales funcionalidades e interfaces de usuario.

