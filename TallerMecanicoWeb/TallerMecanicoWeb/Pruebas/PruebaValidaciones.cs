using System.ComponentModel.DataAnnotations;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Pruebas
{
    public class PruebaValidaciones
    {

        //Creamos un cliente con tres datos incorrectos intencionalmente. Después, Validator.TryValidateObject() evalúa los atributos de validación del objeto. 

        public static void ProbarCliente()
        {
            var cliente = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Dni = "30123456",
                Telefono = "2641234567",
                Email = "juan.perez@example.com",
                Direccion = "Av. Libertador 123"
            };


            var contexto = new ValidationContext(cliente);
            var resultados = new List<ValidationResult>();

            bool esValido = Validator.TryValidateObject(
                cliente,
                contexto,
                resultados,
                validateAllProperties: true
            );

            Console.WriteLine($"¿Cliente válido?: {esValido}");

            foreach (var resultado in resultados)
            {
                Console.WriteLine(resultado.ErrorMessage);
            }
        }
    }
}

