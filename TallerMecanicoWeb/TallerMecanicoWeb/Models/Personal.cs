namespace TallerMecanicoWeb.Models
{
    public class Personal
    {
        public int IdPersonal { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Relación con Reparacion
        public List<Reparacion> Reparaciones { get; set; } = new List<Reparacion>();
    }
}
