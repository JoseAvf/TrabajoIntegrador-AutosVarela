using Microsoft.AspNetCore.Mvc;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Models;

namespace TallerMecanicoWeb.Controllers
{
    public class PersonalController : Controller
    {
        private readonly IPersonalService _personalService;

        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        // GET: Personal
        public IActionResult Index()
        {
            var personal = _personalService.ObtenerTodos();

            return View(personal);
        }

        // GET: Personal/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return View(personal);
            }

            if (_personalService.ExisteDni(personal.Dni))
            {
                ModelState.AddModelError(
                    nameof(Personal.Dni),
                    "Ya existe un mecánico registrado con ese DNI."
                );

                return View(personal);
            }

            bool registrado = _personalService.AgregarPersonal(personal);

            if (!registrado)
            {
                ModelState.AddModelError(
                    "",
                    "No se pudo registrar el mecánico."
                );

                return View(personal);
            }

            TempData["Mensaje"] = "Mecánico registrado correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}
