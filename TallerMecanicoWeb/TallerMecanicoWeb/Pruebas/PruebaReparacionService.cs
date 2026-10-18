using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Pruebas
{
    public class PruebaReparacionService
    {
        public static void ProbarRegistro(IReparacionService servicio)
        {
            //Nuestro MockData ya contiene dos reparaciones. Vamos a intentar registrar tres nuevas, pero solamente una debería ser aceptada.

            // 1. Reparación con vehículo inexistente
            var reparacionSinVehiculo = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Descripcion = "Cambio de aceite",
                Diagnostico = "Mantenimiento preventivo",
                Costo = 45000m,
                Estado = EstadoReparacion.Pendiente
            };

            bool resultado1 = servicio.AgregarReparacion(
                reparacionSinVehiculo, 999, 1);

            Console.WriteLine(
                $"¿Se registró sin vehículo?: {resultado1}");

            // 2. Reparación con mecánico inexistente
            var reparacionSinMecanico = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Descripcion = "Revisión de frenos",
                Diagnostico = "Desgaste de pastillas",
                Costo = 60000m,
                Estado = EstadoReparacion.Pendiente
            };

            bool resultado2 = servicio.AgregarReparacion(
                reparacionSinMecanico, 1, 999);

            Console.WriteLine(
                $"¿Se registró sin mecánico?: {resultado2}");

            // 3. Reparación válida
            var reparacionNueva = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Descripcion = "Cambio de batería",
                Diagnostico = "Batería agotada",
                Costo = 95000m,
                Estado = EstadoReparacion.Pendiente,
                Observaciones = "Pendiente de comenzar"
            };

            bool resultado3 = servicio.AgregarReparacion(
                reparacionNueva, 1, 1);

            Console.WriteLine(
                $"¿Se registró la reparación válida?: {resultado3}");

            Console.WriteLine(
                $"Total de reparaciones: {servicio.ObtenerTodas().Count}");

            // 4. Verificar las relaciones
            bool apareceEnVehiculo = reparacionNueva.Vehiculo != null
                && reparacionNueva.Vehiculo.Reparaciones.Any(
                    r => r.IdReparacion == reparacionNueva.IdReparacion);

            bool apareceEnPersonal = reparacionNueva.Personal != null
                && reparacionNueva.Personal.Reparaciones.Any(
                    r => r.IdReparacion == reparacionNueva.IdReparacion);

            Console.WriteLine(
                $"¿Aparece en el historial del vehículo?: {apareceEnVehiculo}");

            Console.WriteLine(
                $"¿Aparece en los trabajos del mecánico?: {apareceEnPersonal}");


            // 5. Reparación con fecha de finalización anterior al ingreso
            var reparacionFechaInvalida = new Reparacion
            {
                FechaIngreso = new DateTime(2026, 10, 15),
                FechaFinalizacion = new DateTime(2026, 10, 12),
                Descripcion = "Cambio de embrague",
                Diagnostico = "Embrague desgastado",
                Costo = 150000m,
                Estado = EstadoReparacion.Finalizada
            };

            bool resultado4 = servicio.AgregarReparacion(
                reparacionFechaInvalida, 1, 1);

            Console.WriteLine(
                $"¿Se registró con fechas inválidas?: {resultado4}");

            // 6. Reparación sin fecha de ingreso inicializada
            var reparacionSinFecha = new Reparacion
            {
                Descripcion = "Revisión de suspensión",
                Diagnostico = "Ruido en tren delantero",
                Costo = 70000m,
                Estado = EstadoReparacion.Pendiente
            };

            bool resultado5 = servicio.AgregarReparacion(
                reparacionSinFecha, 1, 1);

            Console.WriteLine(
                $"¿Se registró sin fecha de ingreso?: {resultado5}");

            Console.WriteLine(
                $"Total final de reparaciones: {servicio.ObtenerTodas().Count}");

        }
    }
}

