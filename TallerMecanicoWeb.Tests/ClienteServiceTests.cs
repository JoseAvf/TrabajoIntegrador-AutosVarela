using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Models;
using TallerMecanicoWeb.Services;

namespace TallerMecanicoWeb.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public void AgregarCliente_DniDuplicado_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();

            mockData.Clientes.Clear();

            var servicio = new ClienteService(mockData);

            var clienteExistente = new Cliente
            {
                IdCliente = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Dni = "30123456",
                Telefono = "2641234567",
                Email = "juan@example.com",
                Direccion = "San Martín 100"
            };

            mockData.Clientes.Add(clienteExistente);

            var clienteDuplicado = new Cliente
            {
                Nombre = "Pedro",
                Apellido = "López",
                Dni = "30123456",
                Telefono = "2647654321",
                Email = "pedro@example.com",
                Direccion = "Mitre 200"
            };

            // ACT: Ejecutar la operación

            bool resultado = servicio.AgregarCliente(clienteDuplicado);

            // ASSERT: Comprobar el resultado

            Assert.False(resultado);

            // Comprobar que no se agregó otro cliente
            Assert.Single(mockData.Clientes);
        }

        [Fact]
        public void AgregarCliente_DatosValidos_DebeRegistrar()  
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();
            mockData.Clientes.Clear();

            var servicio = new ClienteService(mockData);

            var clienteNuevo = new Cliente
            {
                Nombre = "Ana",
                Apellido = "Martínez",
                Dni = "35123456",
                Telefono = "2647654321",
                Email = "ana@example.com",
                Direccion = "Mitre 200"
            };

            // ACT: Ejecutar la operación

            bool resultado = servicio.AgregarCliente(clienteNuevo);

            // ASSERT: Comprobar los resultados

            Assert.True(resultado);
            Assert.Single(mockData.Clientes);
            Assert.Equal(1, clienteNuevo.IdCliente);
        }

        [Fact]
        public void AgregarCliente_NombreVacio_DebeRechazar()  
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();
            mockData.Clientes.Clear();

            var servicio = new ClienteService(mockData);

            var clienteInvalido = new Cliente
            {
                Nombre = "",      
                Apellido = "García",
                Dni = "40123456",
                Telefono = "2641234567",
                Email = "garcia@example.com",
                Direccion = "Belgrano 150"
            };

            // ACT: Ejecutar la operación

            bool resultado = servicio.AgregarCliente(clienteInvalido);  

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);   
            Assert.Empty(mockData.Clientes);  
        }

        [Fact]
        public void AgregarCliente_EmailInvalido_DebeRechazar() // Test para verificar que se rechaza un cliente con email inválido
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();
            mockData.Clientes.Clear();

            var servicio = new ClienteService(mockData);

            var clienteInvalido = new Cliente
            {
                Nombre = "Lucía",
                Apellido = "Fernández",
                Dni = "42123456",
                Telefono = "2641234567",
                Email = "correo-invalido",
                Direccion = "Sarmiento 250"
            };

            // ACT: Ejecutar la operación

            bool resultado = servicio.AgregarCliente(clienteInvalido);

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Clientes);
        }
    }
}
