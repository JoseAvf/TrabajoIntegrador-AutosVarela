using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Models;
using TallerMecanicoWeb.Services;

namespace TallerMecanicoWeb.Tests
{
    public class ReparacionServiceTests
    {
        [Fact]
        public void AgregarReparacion_VehiculoInexistente_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Vehiculos.Clear();
            mockData.Personal.Clear();
            mockData.Reparaciones.Clear();

            // Crear las dependencias del servicio
            var clienteService = new ClienteService(mockData);
            var vehiculoService = new VehiculoService(
                mockData,
                clienteService
            );
            var personalService = new PersonalService(mockData);

            var servicio = new ReparacionService(
                mockData,
                vehiculoService,
                personalService
            );

            // Crear una reparación con datos válidos
            var reparacion = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Descripcion = "Cambio de aceite",
                Diagnostico = "Mantenimiento preventivo",
                Costo = 15000,
                Estado = EstadoReparacion.Pendiente,
                Observaciones = "Sin observaciones"
            };

            // ACT: Intentar registrar la reparación
            // El vehículo con ID 999 no existe

            bool resultado = servicio.AgregarReparacion(
                reparacion,
                idVehiculo: 999,
                idPersonal: 1
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Reparaciones);
        }

        [Fact]
        public void AgregarReparacion_MecanicoInexistente_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Vehiculos.Clear();
            mockData.Personal.Clear();
            mockData.Reparaciones.Clear();

            // Crear las dependencias
            var clienteService = new ClienteService(mockData);
            var vehiculoService = new VehiculoService(
                mockData,
                clienteService
            );
            var personalService = new PersonalService(mockData);

            var servicio = new ReparacionService(
                mockData,
                vehiculoService,
                personalService
            );

            // Crear un vehículo existente
            var vehiculo = new Vehiculo
            {
                IdVehiculo = 1,
                Patente = "AB123CD",
                Marca = "Ford",
                Modelo = "Fiesta",
                Anio = 2018,
                Color = "Blanco",
                Kilometraje = 85000
            };

            mockData.Vehiculos.Add(vehiculo);

            // Crear una reparación válida
            var reparacion = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Descripcion = "Cambio de frenos",
                Diagnostico = "Pastillas desgastadas",
                Costo = 25000,
                Estado = EstadoReparacion.Pendiente,
                Observaciones = "Sin observaciones"
            };

            // ACT: Intentar registrar la reparación
            // El vehículo existe, pero el mecánico 999 no

            bool resultado = servicio.AgregarReparacion(
                reparacion,
                idVehiculo: 1,
                idPersonal: 999
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Reparaciones);
            Assert.Empty(vehiculo.Reparaciones);
        }

        [Fact]
        public void AgregarReparacion_DatosValidos_DebeRegistrar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Vehiculos.Clear();
            mockData.Personal.Clear();
            mockData.Reparaciones.Clear();

            // Crear las dependencias
            var clienteService = new ClienteService(mockData);
            var vehiculoService = new VehiculoService(
                mockData,
                clienteService
            );
            var personalService = new PersonalService(mockData);

            var servicio = new ReparacionService(
                mockData,
                vehiculoService,
                personalService
            );

            // Crear un vehículo existente
            var vehiculo = new Vehiculo
            {
                IdVehiculo = 1,
                Patente = "AB123CD",
                Marca = "Ford",
                Modelo = "Fiesta",
                Anio = 2018,
                Color = "Blanco",
                Kilometraje = 85000
            };

            mockData.Vehiculos.Add(vehiculo);

            // Crear un mecánico existente
            var mecanico = new Personal
            {
                IdPersonal = 1,
                Nombre = "Carlos",
                Apellido = "Gómez",
                Dni = "35123456",
                Especialidad = "Mecánica general",
                Telefono = "2641234567"
            };

            mockData.Personal.Add(mecanico);

            // Crear la reparación
            var reparacion = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Descripcion = "Cambio de aceite",
                Diagnostico = "Mantenimiento preventivo",
                Costo = 15000,
                Estado = EstadoReparacion.Pendiente,
                Observaciones = "Sin observaciones"
            };

            // ACT: Registrar la reparación

            bool resultado = servicio.AgregarReparacion(
                reparacion,
                idVehiculo: 1,
                idPersonal: 1
            );

            // ASSERT: Comprobar los resultados. Tenemos más aserciones porque queremos verificar distintos aspectos del registro.

            Assert.True(resultado);
            Assert.Equal(1, reparacion.IdReparacion);

            Assert.Single(mockData.Reparaciones);
            Assert.Single(vehiculo.Reparaciones);
            Assert.Single(mecanico.Reparaciones);

            Assert.Same(vehiculo, reparacion.Vehiculo);
            Assert.Same(mecanico, reparacion.Personal);

            Assert.Same(reparacion, vehiculo.Reparaciones[0]);
            Assert.Same(reparacion, mecanico.Reparaciones[0]);
        }

        [Fact]
        public void AgregarReparacion_FechaFinalizacionAnterior_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Vehiculos.Clear();
            mockData.Personal.Clear();
            mockData.Reparaciones.Clear();

            // Crear las dependencias
            var clienteService = new ClienteService(mockData);

            var vehiculoService = new VehiculoService(
                mockData,
                clienteService
            );

            var personalService = new PersonalService(mockData);

            var servicio = new ReparacionService(
                mockData,
                vehiculoService,
                personalService
            );

            // Crear una reparación con fechas incorrectas
            var reparacion = new Reparacion
            {
                FechaIngreso = new DateTime(2026, 10, 15),
                FechaFinalizacion = new DateTime(2026, 10, 10),
                Descripcion = "Cambio de aceite",
                Diagnostico = "Mantenimiento preventivo",
                Costo = 15000,
                Estado = EstadoReparacion.Finalizada,
                Observaciones = "Sin observaciones"
            };

            // ACT: Intentar registrar la reparación

            bool resultado = servicio.AgregarReparacion(
                reparacion,
                idVehiculo: 1,
                idPersonal: 1
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Reparaciones);
        }

        [Fact]
        public void AgregarReparacion_FechaIngresoSinInicializar_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Vehiculos.Clear();
            mockData.Personal.Clear();
            mockData.Reparaciones.Clear();

            // Crear las dependencias
            var clienteService = new ClienteService(mockData);

            var vehiculoService = new VehiculoService(
                mockData,
                clienteService
            );

            var personalService = new PersonalService(mockData);

            var servicio = new ReparacionService(
                mockData,
                vehiculoService,
                personalService
            );

            // Crear una reparación sin fecha de ingreso
            var reparacion = new Reparacion
            {
                Descripcion = "Cambio de aceite",
                Diagnostico = "Mantenimiento preventivo",
                Costo = 15000,
                Estado = EstadoReparacion.Pendiente,
                Observaciones = "Sin observaciones"
            };

            // ACT: Intentar registrar la reparación

            bool resultado = servicio.AgregarReparacion(
                reparacion,
                idVehiculo: 1,
                idPersonal: 1
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Reparaciones);
        }
    }
}
