using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Interfaces
{
    public interface IVehiculoService
    {
        List<Vehiculo> ObtenerTodos();

        Vehiculo? ObtenerPorId(int id);

        List<Vehiculo> BuscarVehiculos(string patente);

        bool ExistePatente(string patente);

        bool AgregarVehiculo(Vehiculo vehiculo, int idCliente);
    }
}

