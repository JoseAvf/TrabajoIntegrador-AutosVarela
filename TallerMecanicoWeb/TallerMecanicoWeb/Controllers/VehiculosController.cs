using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly IVehiculoService _vehiculoService;
        private readonly IClienteService _clienteService;       //Nos permite obtener los clientes registrados sin acceder directamente a MockData.

        public VehiculosController(
            IVehiculoService vehiculoService,
            IClienteService clienteService)
        {
            _vehiculoService = vehiculoService;
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var vehiculos = _vehiculoService.ObtenerTodos();

            return View(vehiculos);
        }

        [HttpGet]                                                           //Cuando el usuario haga click en Nuevo Vehículo, se ejecutará este método para mostrar el formulario de creación.
        public IActionResult Create()
        {
            var clientes = _clienteService.ObtenerTodos();

            ViewBag.Clientes = clientes.Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = $"{c.Nombre} {c.Apellido} - DNI: {c.Dni}"
            }).ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehiculo vehiculo, int? idCliente)
        {
            // 1. Validar los datos del vehículo
            if (!ModelState.IsValid)
            {
                CargarClientes();
                return View(vehiculo);
            }

            // 2. Comprobar que se seleccionó un propietario
            if (!idCliente.HasValue)
            {
                ModelState.AddModelError(
                    "idCliente",
                    "Debe seleccionar un propietario."
                );

                CargarClientes();
                return View(vehiculo);
            }

            // 3. Registrar el vehículo mediante el servicio
            bool registrado = _vehiculoService.AgregarVehiculo(
                vehiculo,
                idCliente.Value
            );

            // 4. Controlar si el registro falló
            if (!registrado)
            {
                ModelState.AddModelError(
                    "",
                    "No se pudo registrar el vehículo. Verifique que la patente no esté registrada y que el propietario sea válido."
                );

                CargarClientes();
                return View(vehiculo);
            }

            // 5. Volver al listado
            return RedirectToAction(nameof(Index));
        }

        private void CargarClientes()
        {
            var clientes = _clienteService.ObtenerTodos();

            ViewBag.Clientes = clientes.Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = $"{c.Nombre} {c.Apellido} - DNI: {c.Dni}"
            }).ToList();
        }
    }
}

