using System.ComponentModel.DataAnnotations;
using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Services
{
    public class ReparacionService : IReparacionService
    {
        private readonly MockData _mockData;
        private readonly IVehiculoService _vehiculoService;         //Esto permite reutilizar los métodos de búsqueda que ya implementamos
        private readonly IPersonalService _personalService;         //Esto permite reutilizar los métodos de búsqueda que ya implementamos. Así evitamos que ReparacionService tenga que implementar nuevamente esas búsquedas.

        public ReparacionService(
            MockData mockData,
            IVehiculoService vehiculoService,
            IPersonalService personalService)
        {
            _mockData = mockData;
            _vehiculoService = vehiculoService;
            _personalService = personalService;
        }

        public List<Reparacion> ObtenerTodas()
        {
            return _mockData.Reparaciones;
        }

        public Reparacion? ObtenerPorId(int id)
        {
            return _mockData.Reparaciones
                .FirstOrDefault(r => r.IdReparacion == id);
        }

        public bool AgregarReparacion(
            Reparacion reparacion,
            int idVehiculo,
            int idPersonal)
        {
            // 1. Validar los datos de la reparación
            var contexto = new ValidationContext(reparacion);
            var resultados = new List<ValidationResult>();

            bool esValido = Validator.TryValidateObject(
                reparacion,
                contexto,
                resultados,
                validateAllProperties: true
            );

            if (!esValido)
            {
                return false;
            }


            // Validar que la fecha de ingreso sea válida
            if (reparacion.FechaIngreso == default(DateTime))           
            {
                return false;
            }

            // Validar el orden de las fechas
            if (reparacion.FechaFinalizacion.HasValue &&                         //Si tiene fecha de finalización, entonces validar que sea posterior a la fecha de ingreso. 
                reparacion.FechaFinalizacion.Value < reparacion.FechaIngreso)    
            {
                return false;
            }


            // 2. Buscar el vehículo
            Vehiculo? vehiculo =
                _vehiculoService.ObtenerPorId(idVehiculo);

            if (vehiculo == null)
            {
                return false;
            }

            // 3. Buscar el mecánico
            Personal? personal =
                _personalService.ObtenerPorId(idPersonal);

            if (personal == null)
            {
                return false;
            }

            // 4. Generar el identificador
            reparacion.IdReparacion = _mockData.Reparaciones.Count == 0
                ? 1
                : _mockData.Reparaciones.Max(r => r.IdReparacion) + 1;

            // 5. Asociar la reparación
            reparacion.Vehiculo = vehiculo;
            reparacion.Personal = personal;

            // 6. Guardar la reparación
            _mockData.Reparaciones.Add(reparacion);

            // 7. Actualizar las colecciones relacionadas
            vehiculo.Reparaciones.Add(reparacion);
            personal.Reparaciones.Add(reparacion);

            //En los tres casos anteriores guardamos referencias al mismo objeto Reparacion

            return true;
        }
    }
}

