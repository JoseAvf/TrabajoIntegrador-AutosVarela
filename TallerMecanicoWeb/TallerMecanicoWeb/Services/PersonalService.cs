using System.ComponentModel.DataAnnotations;
using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly MockData _mockData;

        public PersonalService(MockData mockData)
        {
            _mockData = mockData;
        }

        public List<Personal> ObtenerTodos()
        {
            return _mockData.Personal;
        }

        public Personal? ObtenerPorId(int id)
        {
            return _mockData.Personal
                .FirstOrDefault(p => p.IdPersonal == id);
        }

        public bool ExisteDni(string dni)
        {
            return _mockData.Personal.Any(p => p.Dni == dni);
        }

        public bool AgregarPersonal(Personal personal)
        {
            // 1. Validar los datos del empleado
            var contexto = new ValidationContext(personal);
            var resultados = new List<ValidationResult>();

            bool esValido = Validator.TryValidateObject(
                personal,
                contexto,
                resultados,
                validateAllProperties: true
            );

            if (!esValido)
            {
                return false;
            }

            // 2. Comprobar que el DNI no esté repetido
            if (ExisteDni(personal.Dni))
            {
                return false;
            }

            // 3. Generar el identificador
            personal.IdPersonal = _mockData.Personal.Count == 0
                ? 1
                : _mockData.Personal.Max(p => p.IdPersonal) + 1;

            // 4. Registrar el empleado
            _mockData.Personal.Add(personal);

            return true;
        }
    }
}

