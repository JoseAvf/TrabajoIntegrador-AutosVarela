namespace TallerMecanicoWeb.Models
{
    public class Reparacion
    {
        public int IdReparacion { get; set; }

        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public string Descripcion { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;

        public decimal Costo { get; set; }

        public EstadoReparacion Estado { get; set; }

        public string Observaciones { get; set; } = string.Empty;

        // Relaciones
        public Vehiculo? Vehiculo { get; set; }
        public Personal? Personal { get; set; }
    }
}
