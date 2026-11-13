using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Controllers
{
    public class ReparacionesController : Controller
    {
        private readonly IReparacionService _reparacionService;
        private readonly IVehiculoService _vehiculoService;
        private readonly IPersonalService _personalService;

        public ReparacionesController(
            IReparacionService reparacionService,
            IVehiculoService vehiculoService,
            IPersonalService personalService)
        {
            _reparacionService = reparacionService;
            _vehiculoService = vehiculoService;
            _personalService = personalService;
        }

        // --- CAMBIO 1 (PB11): Calcula contadores por estado antes de filtrar ---
        public IActionResult Index(EstadoReparacion? estado)
        {
            var todas = _reparacionService.ObtenerTodas();

            ViewBag.Total = todas.Count;
            ViewBag.Pendientes = todas.Count(r => r.Estado == EstadoReparacion.Pendiente);
            ViewBag.EnReparacion = todas.Count(r => r.Estado == EstadoReparacion.EnReparacion);
            ViewBag.Finalizadas = todas.Count(r => r.Estado == EstadoReparacion.Finalizada);
            ViewBag.Canceladas = todas.Count(r => r.Estado == EstadoReparacion.Cancelada);

            var reparaciones = estado.HasValue
                ? todas.Where(r => r.Estado == estado.Value).ToList()
                : todas;

            ViewBag.EstadoSeleccionado = estado;
            return View(reparaciones);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CargarListas();

            var nuevaReparacion = new Reparacion
            {
                FechaIngreso = DateTime.Today,
                Estado = EstadoReparacion.Pendiente
            };

            return View(nuevaReparacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reparacion reparacion, int? idVehiculo, int? idPersonal)
        {
            if (!ModelState.IsValid)
            {
                CargarListas();
                return View(reparacion);
            }

            if (!idVehiculo.HasValue)
            {
                ModelState.AddModelError("idVehiculo", "Debe seleccionar un vehículo.");
                CargarListas();
                return View(reparacion);
            }

            if (!idPersonal.HasValue)
            {
                ModelState.AddModelError("idPersonal", "Debe seleccionar un mecánico responsable.");
                CargarListas();
                return View(reparacion);
            }

            bool registrado = _reparacionService.AgregarReparacion(
                reparacion,
                idVehiculo.Value,
                idPersonal.Value
            );

            if (!registrado)
            {
                ModelState.AddModelError(
                    "",
                    "No se pudo registrar la reparación. Verifique los datos ingresados, las fechas y que el vehículo y mecánico sean válidos."
                );

                CargarListas();
                return View(reparacion);
            }

            return RedirectToAction(nameof(Index));
        }

        // --- CAMBIO 2 (PB11): Actualiza FechaFinalizacion y envía alerta visual ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CambiarEstado(int idReparacion, EstadoReparacion nuevoEstado)
        {
            var reparacion = _reparacionService.ObtenerPorId(idReparacion);
            if (reparacion != null)
            {
                reparacion.Estado = nuevoEstado;
                if (nuevoEstado == EstadoReparacion.Finalizada && !reparacion.FechaFinalizacion.HasValue)
                {
                    reparacion.FechaFinalizacion = DateTime.Today;
                }
                else if (nuevoEstado != EstadoReparacion.Finalizada)
                {
                    reparacion.FechaFinalizacion = null;
                }

                TempData["MensajeExito"] = $"El estado de la orden #{idReparacion} ({reparacion.Vehiculo?.Patente}) se actualizó a {nuevoEstado}.";
            }

            return RedirectToAction(nameof(Index));
        }

        private void CargarListas()
        {
            var vehiculos = _vehiculoService.ObtenerTodos();
            ViewBag.Vehiculos = vehiculos.Select(v => new SelectListItem
            {
                Value = v.IdVehiculo.ToString(),
                Text = $"{v.Patente} - {v.Marca} {v.Modelo} ({(v.Cliente != null ? v.Cliente.Nombre + " " + v.Cliente.Apellido : "Sin propietario")})"
            }).ToList();

            var personal = _personalService.ObtenerTodos();
            ViewBag.Personal = personal.Select(p => new SelectListItem
            {
                Value = p.IdPersonal.ToString(),
                Text = $"{p.Nombre} {p.Apellido} - {p.Especialidad}"
            }).ToList();
        }
    }
}