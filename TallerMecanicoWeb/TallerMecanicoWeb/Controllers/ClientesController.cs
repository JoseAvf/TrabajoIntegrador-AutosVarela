using Microsoft.AspNetCore.Mvc;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;  

        public ClientesController(IClienteService clienteService)  
        {
            _clienteService = clienteService;
        }

        public IActionResult Index(string? buscar)    
        {
            var clientes = _clienteService.BuscarClientes(buscar ?? ""); //El controlador no busca directamente los clientes en MockData. Delega esa responsabilidad al servicio.

            ViewBag.Buscar = buscar;   

            return View(clientes);   //Retorna la vista con la lista de clientes filtrada según el parámetro de búsqueda
        }


        // Muestra el formulario para registrar un cliente
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //recibe los datos, los valida y registra al cliente.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            bool registrado = _clienteService.AgregarCliente(cliente);   //El controlador no agrega directamente el cliente a MockData. Delega esa responsabilidad al servicio

            if (!registrado)
            {
                ModelState.AddModelError(
                    "Dni",
                    "Ya existe un cliente registrado con ese DNI."  
                );

                return View(cliente);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}


