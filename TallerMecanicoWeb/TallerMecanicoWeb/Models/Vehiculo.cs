namespace TallerMecanicoWeb.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }

        public string Patente { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Color { get; set; } = string.Empty;
        public int Kilometraje { get; set; }

        // Relación con Cliente
        public Cliente? Cliente { get; set; }

        public List<Reparacion> Reparaciones { get; set; } = new List<Reparacion>();
    }
}
