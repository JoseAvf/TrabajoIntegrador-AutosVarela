using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Pruebas
{
    public class PruebaVehiculoService
    {
        public static void ProbarRegistro(IVehiculoService servicio)
        {
            // 1. Vehículo con patente duplicada. En MockData ya tenemos un Toyota Corolla con patente AB123CD, asociado al cliente Juan Pérez.
            var vehiculoDuplicado = new Vehiculo
            {
                Patente = "AB123CD",
                Marca = "Toyota",
                Modelo = "Etios",
                Anio = 2021,
                Color = "Rojo",
                Kilometraje = 30000
            };

            bool resultado1 = servicio.AgregarVehiculo(
                vehiculoDuplicado, 1);

            Console.WriteLine(
                $"¿Se registró el vehículo duplicado?: {resultado1}");

            // 2. Vehículo con propietario inexistente
            var vehiculoSinCliente = new Vehiculo
            {
                Patente = "AD789EF",
                Marca = "Fiat",
                Modelo = "Cronos",
                Anio = 2022,
                Color = "Blanco",
                Kilometraje = 15000
            };

            bool resultado2 = servicio.AgregarVehiculo(
                vehiculoSinCliente, 999);

            Console.WriteLine(
                $"¿Se registró el vehículo sin propietario?: {resultado2}");

            // 3. Vehículo válido con propietario existente
            var vehiculoNuevo = new Vehiculo
            {
                Patente = "AE456GH",
                Marca = "Volkswagen",
                Modelo = "Gol",
                Anio = 2019,
                Color = "Gris",
                Kilometraje = 60000
            };

            bool resultado3 = servicio.AgregarVehiculo(
                vehiculoNuevo, 1);

            Console.WriteLine(
                $"¿Se registró el vehículo nuevo?: {resultado3}");

            Console.WriteLine(
                $"Total de vehículos: {servicio.ObtenerTodos().Count}");

            Console.WriteLine(
                $"Propietario del vehículo nuevo: " +
                $"{vehiculoNuevo.Cliente?.Nombre} " +
                $"{vehiculoNuevo.Cliente?.Apellido}");


            bool apareceEnCliente = vehiculoNuevo.Cliente != null
                && vehiculoNuevo.Cliente.Vehiculos.Any(
                    v => v.IdVehiculo == vehiculoNuevo.IdVehiculo);

            Console.WriteLine(
                $"¿El vehículo aparece en la lista del cliente?: {apareceEnCliente}");

        }
    }
}

