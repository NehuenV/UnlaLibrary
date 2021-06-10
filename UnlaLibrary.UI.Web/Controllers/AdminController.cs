using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.UI.Web.Helper;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminRepository _AdminRepository;
        private readonly IProfesoresRepository _ProfesoresRepository;
        public AdminController(ILogger<AdminController> logger, IAdminRepository AdminRepository)
        {
            _logger = logger;
            _AdminRepository = AdminRepository;
        }
        public IActionResult Index()
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            List<Universidad> lista = _AdminRepository.GetAllUniversidades();
            ViewBag.Universidad = lista;
            return View();
        }

        public JsonResult CarrerasDisponibles(int iduniversidad)
        {
            List<Carrera> lista = _AdminRepository.GetCarreras(iduniversidad);
            return Json(new SelectList(lista, "IdCarrera", "Carrera1"));
        }

        public JsonResult MateriasDisponibles(int idcarrera)
        {
            List<Materia> lista = _AdminRepository.GetMaterias(idcarrera);
            return Json(new SelectList(lista, "IdMateria", "Materia1"));
        }

        public IActionResult ListaProfesorMateria(int idMat, int idCarrera)
        {

            var lista1 = _AdminRepository.GetProfesoresAgregadosMateria(idMat, idCarrera);
            var lista2 = _AdminRepository.GetProfesoresNoAgregadosMateria(idMat, idCarrera);
            lista1.AddRange(lista2);
            return View(lista1);
        }
    }
}
