using System.ComponentModel.DataAnnotations;
using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Services
{
    public class ClienteService : IClienteService
    {
        private readonly MockData _mockData;

        public ClienteService(MockData mockData)
        {
            _mockData = mockData;
        }

        public List<Cliente> ObtenerTodos()
        {
            return _mockData.Clientes;
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _mockData.Clientes
                .FirstOrDefault(c => c.IdCliente == id);
        }

        public bool ExisteDni(string dni)
        {
            return _mockData.Clientes
                .Any(c => c.Dni == dni);
        }


        public bool AgregarCliente(Cliente cliente)
        {
            // Validar los atributos del modelo
            var contexto = new ValidationContext(cliente);
            var resultados = new List<ValidationResult>();

            bool esValido = Validator.TryValidateObject(
                cliente,
                contexto,
                resultados,
                validateAllProperties: true
            );

            if (!esValido)
            {
                return false;
            }

            // Comprobar que el DNI no esté repetido
            if (ExisteDni(cliente.Dni))
            {
                return false;
            }

            // Generar identificador
            cliente.IdCliente = _mockData.Clientes.Count == 0
                ? 1
                : _mockData.Clientes.Max(c => c.IdCliente) + 1;

            // Registrar cliente
            _mockData.Clientes.Add(cliente);

            return true;
        }


        public List<Cliente> BuscarClientes(string texto)   // Método para buscar clientes por nombre, apellido o DNI
        {
            if (string.IsNullOrWhiteSpace(texto))  
            {
                return _mockData.Clientes;
            }

            texto = texto.Trim();                   

            return _mockData.Clientes
                .Where(c =>
                    c.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    c.Apellido.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    c.Dni.Contains(texto))
                .ToList();
        }
    }
}

