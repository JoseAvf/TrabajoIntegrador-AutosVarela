using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Models;
using TallerMecanicoWeb.Services;

namespace TallerMecanicoWeb.Tests
{
    public class PersonalServiceTests
    {
        [Fact]
        public void AgregarPersonal_DniDuplicado_DebeRechazar()   // Test para verificar que no se pueda registrar un empleado con un DNI duplicado
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();
            mockData.Personal.Clear();

            var servicio = new PersonalService(mockData);

            var empleadoExistente = new Personal
            {
                IdPersonal = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Dni = "30123456",
                Especialidad = "Mecánica general",
                Telefono = "2641234567"
            };

            mockData.Personal.Add(empleadoExistente);

            var empleadoDuplicado = new Personal
            {
                Nombre = "Pedro",
                Apellido = "López",
                Dni = "30123456",
                Especialidad = "Electricidad",
                Telefono = "2647654321"
            };

            // ACT: Intentar registrar al empleado

            bool resultado = servicio.AgregarPersonal(empleadoDuplicado);

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Single(mockData.Personal);
        }

        [Fact]
        public void AgregarPersonal_DatosValidos_DebeRegistrar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();
            mockData.Personal.Clear();

            var servicio = new PersonalService(mockData);

            var empleadoNuevo = new Personal
            {
                Nombre = "Carlos",
                Apellido = "Gómez",
                Dni = "35123456",
                Especialidad = "Mecánica general",
                Telefono = "2641234567"
            };

            // ACT: Ejecutar la operación

            bool resultado = servicio.AgregarPersonal(empleadoNuevo);

            // ASSERT: Comprobar los resultados

            Assert.True(resultado);
            Assert.Single(mockData.Personal);
            Assert.Equal(1, empleadoNuevo.IdPersonal);
        }

        [Fact]
        public void AgregarPersonal_NombreVacio_DebeRechazar()
        {
            // ARRANGE: Preparar los datos

            var mockData = new MockData();
            mockData.Personal.Clear();

            var servicio = new PersonalService(mockData);

            var empleadoInvalido = new Personal
            {
                Nombre = "",
                Apellido = "García",
                Dni = "40123456",
                Especialidad = "Electricidad",
                Telefono = "2641234567"
            };

            // ACT: Intentar registrar al empleado

            bool resultado = servicio.AgregarPersonal(empleadoInvalido);

            // ASSERT: Comprobar los resultados

            Assert.False(resultado);
            Assert.Empty(mockData.Personal);
        }
    }
}
