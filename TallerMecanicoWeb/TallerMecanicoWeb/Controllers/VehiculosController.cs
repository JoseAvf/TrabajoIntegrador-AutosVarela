using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallerMecanicoWeb.Interfaces;

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

        [HttpGet]                                               //Esta acción se ejecutará cuando el usuario haga clic en Nuevo Vehículo.
        public IActionResult Create()
        {
            var clientes = _clienteService.ObtenerTodos();

            ViewBag.Clientes = new SelectList(
                clientes,
                "IdCliente",
                "Dni"
            );

            return View();
        }
    }
}

