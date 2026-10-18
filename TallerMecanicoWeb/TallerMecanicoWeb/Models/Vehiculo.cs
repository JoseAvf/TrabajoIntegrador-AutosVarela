using System.ComponentModel.DataAnnotations;

namespace TallerMecanicoWeb.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }


        [Required(ErrorMessage = "La patente es obligatoria")]
        [RegularExpression(@"^([A-Za-z]{2}\d{3}[A-Za-z]{2}|[A-Za-z]{3}\d{3})$",
            ErrorMessage = "La patente debe tener un formato argentino válido")]
        public string Patente { get; set; } = string.Empty;

        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(50, ErrorMessage = "La marca no puede superar los 50 caracteres")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [StringLength(50, ErrorMessage = "El modelo no puede superar los 50 caracteres")]
        public string Modelo { get; set; } = string.Empty;

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El color es obligatorio")]
        [StringLength(30, ErrorMessage = "El color no puede superar los 30 caracteres")]
        public string Color { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El kilometraje no puede ser negativo")]
        public int Kilometraje { get; set; }


        // Relación con Cliente
        public Cliente? Cliente { get; set; }

        public List<Reparacion> Reparaciones { get; set; } = new List<Reparacion>();
    }
}
