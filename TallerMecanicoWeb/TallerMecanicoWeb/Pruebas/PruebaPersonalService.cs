using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Pruebas
{
    public class PruebaPersonalService
    {
        public static void ProbarRegistro(IPersonalService servicio)
        {
            // 1. Empleado con DNI duplicado
            var personalDuplicado = new Personal
            {
                Nombre = "Pedro",
                Apellido = "López",
                Dni = "28567890",
                Especialidad = "Mecánica general",
                Telefono = "2641234567"
            };

            bool resultado1 = servicio.AgregarPersonal(personalDuplicado);

            Console.WriteLine(
                $"¿Se registró el empleado duplicado?: {resultado1}");

            // 2. Empleado con datos inválidos
            var personalInvalido = new Personal
            {
                Nombre = "",
                Apellido = "García",
                Dni = "40123456",
                Especialidad = "Electricidad",
                Telefono = "2641234567"
            };

            bool resultado2 = servicio.AgregarPersonal(personalInvalido);

            Console.WriteLine(
                $"¿Se registró el empleado inválido?: {resultado2}");

            // 3. Empleado válido con DNI nuevo
            var personalNuevo = new Personal
            {
                Nombre = "Martín",
                Apellido = "Fernández",
                Dni = "38123456",
                Especialidad = "Chapa y pintura",
                Telefono = "2647654321"
            };

            bool resultado3 = servicio.AgregarPersonal(personalNuevo);

            Console.WriteLine(
                $"¿Se registró el empleado nuevo?: {resultado3}");

            Console.WriteLine(
                $"Total de empleados: {servicio.ObtenerTodos().Count}");
        }
    }
}

