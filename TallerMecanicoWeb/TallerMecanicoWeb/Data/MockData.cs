using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Data
{
    public class MockData
    {
        public List<Cliente> Clientes { get; set; } = new();
        public List<Vehiculo> Vehiculos { get; set; } = new();
        public List<Personal> Personal { get; set; } = new();
        public List<Reparacion> Reparaciones { get; set; } = new();

        public MockData()
        {
            Clientes.Add(new Cliente
            {
                IdCliente = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Dni = "30123456",
                Telefono = "2641234567",
                Email = "juan.perez@example.com",
                Direccion = "Av. Libertador 123"
            });

            Clientes.Add(new Cliente
            {
                IdCliente = 2,
                Nombre = "María",
                Apellido = "Gómez",
                Dni = "32987654",
                Telefono = "2647654321",
                Email = "maria.gomez@example.com",
                Direccion = "San Martín 456"
            });


            var vehiculo1 = new Vehiculo
            {
                IdVehiculo = 1,
                Patente = "AB123CD",
                Marca = "Toyota",
                Modelo = "Corolla",
                Anio = 2020,
                Color = "Blanco",
                Kilometraje = 45000,
                Cliente = Clientes[0]
            };

            var vehiculo2 = new Vehiculo
            {
                IdVehiculo = 2,
                Patente = "AC456EF",
                Marca = "Ford",
                Modelo = "Focus",
                Anio = 2018,
                Color = "Gris",
                Kilometraje = 78000,
                Cliente = Clientes[1]
            };


            Vehiculos.Add(vehiculo1);
            Vehiculos.Add(vehiculo2);

            Clientes[0].Vehiculos.Add(vehiculo1);
            Clientes[1].Vehiculos.Add(vehiculo2);


            var mecanico1 = new Personal
            {
                IdPersonal = 1,
                Nombre = "Carlos",
                Apellido = "Rodríguez",
                Dni = "28567890",
                Especialidad = "Mecánica general",
                Telefono = "2645551234"
            };

            var mecanico2 = new Personal
            {
                IdPersonal = 2,
                Nombre = "Lucas",
                Apellido = "Fernández",
                Dni = "33456789",
                Especialidad = "Electricidad automotriz",
                Telefono = "2645555678"
            };

            Personal.Add(mecanico1);
            Personal.Add(mecanico2);


            var reparacion1 = new Reparacion
            {
                IdReparacion = 1,
                FechaIngreso = new DateTime(2026, 10, 10),
                FechaFinalizacion = null,
                Descripcion = "Cambio de pastillas de freno",
                Diagnostico = "Desgaste de pastillas delanteras",
                Costo = 85000m,
                Estado = EstadoReparacion.EnReparacion,
                Observaciones = "Pendiente de finalizar el trabajo",
                Vehiculo = vehiculo1,
                Personal = mecanico1
            };

            var reparacion2 = new Reparacion
            {
                IdReparacion = 2,
                FechaIngreso = new DateTime(2026, 10, 12),
                FechaFinalizacion = null,
                Descripcion = "Revisión del sistema eléctrico",
                Diagnostico = "Falla en el alternador",
                Costo = 120000m,
                Estado = EstadoReparacion.Pendiente,
                Observaciones = "Esperando repuesto",
                Vehiculo = vehiculo2,
                Personal = mecanico2
            };


            Reparaciones.Add(reparacion1);
            Reparaciones.Add(reparacion2);

            // Asociar reparaciones con vehículos
            vehiculo1.Reparaciones.Add(reparacion1);
            vehiculo2.Reparaciones.Add(reparacion2);

            // Asociar reparaciones con mecánicos
            mecanico1.Reparaciones.Add(reparacion1);
            mecanico2.Reparaciones.Add(reparacion2);

        }

    }
}

