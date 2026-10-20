using System.ComponentModel.DataAnnotations;

namespace TallerMecanicoWeb.Models
{
    public class Personal
    {
        public int IdPersonal { get; set; }

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

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100, ErrorMessage = "La especialidad no puede superar los 100 caracteres")]
        public string Especialidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "El teléfono debe contener 10 números")]
        public string Telefono { get; set; } = string.Empty;


        // Relación con Reparacion
        public List<Reparacion> Reparaciones { get; set; } = new List<Reparacion>();
    }
}
