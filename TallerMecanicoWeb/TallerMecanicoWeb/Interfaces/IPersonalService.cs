using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Interfaces
{
    //Nuestra interfaz define las operaciones básicas que deberá ofrecer el servicio de personal.
    public interface IPersonalService
    {
        List<Personal> ObtenerTodos();    //Consultar todos los empleados

        Personal? ObtenerPorId(int id);   //Buscar un empleado por identificador

        bool ExisteDni(string dni);       //Comprobar si un DNI ya está registrado

        bool AgregarPersonal(Personal personal);  //Agregar un nuevo empleado
    }
}

