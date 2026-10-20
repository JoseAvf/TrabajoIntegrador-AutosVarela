using System.ComponentModel.DataAnnotations;

namespace TallerMecanicoWeb.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        //El código usa atributos de validación de System.ComponentModel.DataAnnotations

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [RegularExpression(@"^\d{7,8}$",
            ErrorMessage = "El DNI debe contener 7 u 8 números")]
        public string Dni { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "El teléfono debe contener 10 números")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    }
}
