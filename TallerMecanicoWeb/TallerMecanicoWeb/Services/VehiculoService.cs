using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace TallerMecanicoWeb.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly MockData _mockData;
        private readonly IClienteService _clienteService;

        public VehiculoService(
            MockData mockData,
            IClienteService clienteService)
        {
            _mockData = mockData;
            _clienteService = clienteService;
        }

        public List<Vehiculo> ObtenerTodos()
        {
            return _mockData.Vehiculos;
        }

        public Vehiculo? ObtenerPorId(int id)
        {
            return _mockData.Vehiculos
                .FirstOrDefault(v => v.IdVehiculo == id);
        }

        public bool ExistePatente(string patente)
        {
            return _mockData.Vehiculos.Any(
                v => string.Equals(
                    v.Patente,
                    patente,
                    StringComparison.OrdinalIgnoreCase));
        }


        public bool AgregarVehiculo(Vehiculo vehiculo, int idCliente)
        {
            // 1. Validar los datos del vehículo
            var contexto = new ValidationContext(vehiculo);
            var resultados = new List<ValidationResult>();

            bool esValido = Validator.TryValidateObject(
                vehiculo,
                contexto,
                resultados,
                validateAllProperties: true
            );

            if (!esValido)
            {
                return false;
            }

            // 2. Verificar que la patente no esté registrada
            if (ExistePatente(vehiculo.Patente))
            {
                return false;
            }

            // 3. Buscar al cliente propietario
            Cliente? cliente = _clienteService.ObtenerPorId(idCliente);

            if (cliente == null)
            {
                return false;
            }

            // 4. Generar el identificador del vehículo
            vehiculo.IdVehiculo = _mockData.Vehiculos.Count == 0
                ? 1
                : _mockData.Vehiculos.Max(v => v.IdVehiculo) + 1;

            // 5. Asociar el vehículo con su propietario
            vehiculo.Cliente = cliente;

            // 6. Registrar el vehículo
            _mockData.Vehiculos.Add(vehiculo);

            // 7. Actualizar la colección de vehículos del cliente
            cliente.Vehiculos.Add(vehiculo);

            return true;
        }
    }
}

