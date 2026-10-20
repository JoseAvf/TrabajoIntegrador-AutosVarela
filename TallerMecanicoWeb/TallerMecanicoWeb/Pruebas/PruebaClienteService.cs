
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Pruebas
{
    public class PruebaClienteService
    {
        public static void ProbarRegistro(IClienteService servicio)
        {
            // Cliente con DNI duplicado
            var clienteDuplicado = new Cliente
            {
                Nombre = "Pedro",
                Apellido = "López",
                Dni = "30123456",
                Telefono = "2641234567",
                Email = "pedro@example.com",
                Direccion = "San Martín 100"
            };

            bool resultado1 = servicio.AgregarCliente(clienteDuplicado);

            Console.WriteLine(
                $"¿Se registró el cliente duplicado?: {resultado1}");

            // Cliente con DNI nuevo
            var clienteNuevo = new Cliente
            {
                Nombre = "Ana",
                Apellido = "Martínez",
                Dni = "35123456",
                Telefono = "2647654321",
                Email = "ana@example.com",
                Direccion = "Mitre 200"
            };

            bool resultado2 = servicio.AgregarCliente(clienteNuevo);

            Console.WriteLine(
                $"¿Se registró el cliente nuevo?: {resultado2}");

            Console.WriteLine(
                $"Total de clientes: {servicio.ObtenerTodos().Count}");


            // Cliente con nombre vacío y DNI nuevo
            var clienteInvalido = new Cliente
            {
                Nombre = "",
                Apellido = "García",
                Dni = "40123456",
                Telefono = "2641234567",
                Email = "garcia@example.com",
                Direccion = "Belgrano 150"
            };

            bool resultado3 = servicio.AgregarCliente(clienteInvalido);

            Console.WriteLine(
                $"¿Se registró el cliente inválido?: {resultado3}");

            Console.WriteLine(
                $"Total de clientes después de la prueba: {servicio.ObtenerTodos().Count}");

        }
    }
}

