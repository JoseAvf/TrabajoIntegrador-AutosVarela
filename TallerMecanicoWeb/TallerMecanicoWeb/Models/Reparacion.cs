using System.ComponentModel.DataAnnotations;

namespace TallerMecanicoWeb.Models
{
    public class Reparacion
    {
        public int IdReparacion { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaFinalizacion { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "El diagnóstico no puede superar los 300 caracteres")]
        public string Diagnostico { get; set; } = string.Empty;

        [Range(typeof(decimal), "0", "999999999",
            ErrorMessage = "El costo no puede ser negativo")]
        public decimal Costo { get; set; }

        public EstadoReparacion Estado { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres")]
        public string Observaciones { get; set; } = string.Empty;


        // Relaciones
        public Vehiculo? Vehiculo { get; set; }
        public Personal? Personal { get; set; }
    }
}
