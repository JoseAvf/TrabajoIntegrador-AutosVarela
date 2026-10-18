using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Interfaces
{
    public interface IReparacionService
    {
        //Cuando registremos una reparación, hay que comprobar que los datos de la reparación sean válidos, el vehículo exista, el mecánico exista y la reparación quede asociada correctamente con ambos.
        List<Reparacion> ObtenerTodas();    //Consultar todas las reparaciones

        Reparacion? ObtenerPorId(int id);   //Buscar una reparación por identificador

        bool AgregarReparacion(             //Registrar una reparación y asociarla a un vehículo y un mecánico. 
            Reparacion reparacion,
            int idVehiculo,
            int idPersonal);
    }
}

