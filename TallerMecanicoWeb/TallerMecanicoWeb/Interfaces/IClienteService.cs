using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> ObtenerTodos();

        Cliente? ObtenerPorId(int id);

        bool ExisteDni(string dni);

        bool AgregarCliente(Cliente cliente);
    }
}

