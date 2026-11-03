using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Models;
using TallerMecanicoWeb.Services;

namespace TallerMecanicoWeb.Tests
{
    public class VehiculoServiceTests
    {
        [Fact]
        public void AgregarVehiculo_PatenteDuplicada_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Vehiculos.Clear();

            var clienteService = new ClienteService(mockData);
            var servicio = new VehiculoService(
                mockData,
                clienteService
            );

            // Registrar un vehículo existente
            var vehiculoExistente = new Vehiculo
            {
                IdVehiculo = 1,
                Patente = "AB123CD",
                Marca = "Ford",
                Modelo = "Fiesta",
                Anio = 2018,
                Color = "Blanco",
                Kilometraje = 85000
            };

            mockData.Vehiculos.Add(vehiculoExistente);

            // Intentar registrar otro vehículo con la misma patente
            var vehiculoDuplicado = new Vehiculo
            {
                Patente = "ab123cd",
                Marca = "Toyota",
                Modelo = "Corolla",
                Anio = 2020,
                Color = "Negro",
                Kilometraje = 50000
            };

            // ACT: Intentar registrar el vehículo

            bool resultado = servicio.AgregarVehiculo(
                vehiculoDuplicado,
                idCliente: 1
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Single(mockData.Vehiculos);
        }

        [Fact]
        public void AgregarVehiculo_ClienteInexistente_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Clientes.Clear();
            mockData.Vehiculos.Clear();

            var clienteService = new ClienteService(mockData);

            var servicio = new VehiculoService(
                mockData,
                clienteService
            );

            // Crear un vehículo con datos válidos
            var vehiculo = new Vehiculo
            {
                Patente = "AC456EF",
                Marca = "Chevrolet",
                Modelo = "Onix",
                Anio = 2021,
                Color = "Rojo",
                Kilometraje = 45000
            };

            // ACT: Intentar registrar el vehículo
            // El cliente con ID 999 no existe

            bool resultado = servicio.AgregarVehiculo(
                vehiculo,
                idCliente: 999
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Vehiculos);
            Assert.Null(vehiculo.Cliente);
        }

        [Fact]
        public void AgregarVehiculo_DatosValidos_DebeRegistrar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Clientes.Clear();
            mockData.Vehiculos.Clear();

            var clienteService = new ClienteService(mockData);

            var servicio = new VehiculoService(
                mockData,
                clienteService
            );

            // Crear un cliente existente
            var cliente = new Cliente
            {
                IdCliente = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Dni = "30123456",
                Telefono = "2641234567",
                Email = "juan@example.com",
                Direccion = "San Martín 100"
            };

            mockData.Clientes.Add(cliente);

            // Crear un vehículo válido
            var vehiculo = new Vehiculo
            {
                Patente = "AC456EF",
                Marca = "Toyota",
                Modelo = "Corolla",
                Anio = 2020,
                Color = "Blanco",
                Kilometraje = 50000
            };

            // ACT: Registrar el vehículo

            bool resultado = servicio.AgregarVehiculo(
                vehiculo,
                idCliente: 1
            );

            // ASSERT: Comprobar los resultados

            Assert.True(resultado);
            Assert.Equal(1, vehiculo.IdVehiculo);

            Assert.Single(mockData.Vehiculos);
            Assert.Single(cliente.Vehiculos);

            Assert.Same(cliente, vehiculo.Cliente);
            Assert.Same(vehiculo, cliente.Vehiculos[0]);
            Assert.Same(vehiculo, mockData.Vehiculos[0]);
        }

        [Fact]
        public void AgregarVehiculo_PatenteInvalida_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Clientes.Clear();
            mockData.Vehiculos.Clear();

            var clienteService = new ClienteService(mockData);

            var servicio = new VehiculoService(
                mockData,
                clienteService
            );

            // Crear un vehículo con patente inválida
            var vehiculoInvalido = new Vehiculo
            {
                Patente = "123ABC",
                Marca = "Ford",
                Modelo = "Focus",
                Anio = 2019,
                Color = "Azul",
                Kilometraje = 65000
            };

            // ACT: Intentar registrar el vehículo

            bool resultado = servicio.AgregarVehiculo(
                vehiculoInvalido,
                idCliente: 1
            );

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Vehiculos);
            Assert.Null(vehiculoInvalido.Cliente);
        }
    }
}