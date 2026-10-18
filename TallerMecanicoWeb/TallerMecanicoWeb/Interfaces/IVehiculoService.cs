using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Interfaces
{
    public interface IVehiculoService
    {
        List<Vehiculo> ObtenerTodos();

        Vehiculo? ObtenerPorId(int id);

        bool ExistePatente(string patente);

        bool AgregarVehiculo(Vehiculo vehiculo, int idCliente);
    }
}

