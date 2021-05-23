using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.Data.Interfaces;
using UnlaLibrary.Data.Models;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly IProfesoresRepository _ProfesoresRepository;
        public ProfesoresController(ILogger<HomeController> logger, Library Library, IProfesoresRepository ProfesoresRepository)
        {
            _logger = logger;
            _Library = Library;
            _ProfesoresRepository = ProfesoresRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        //return Json( new { status = aut, name = n, email = login.email, message ="Bienvenido " });

        public bool ValidarTipoUsuario()
        {
            var userType = HttpContext.Session.GetInt32("TipoDeUsuarioId");
            if (userType != null) return (int)userType == 2;
            return false;
        }

        public IActionResult AlumnoMateria()
        {
           if(!ValidarTipoUsuario()) return View("Error");
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
            List<Universidad> lista = _ProfesoresRepository.GetUniverdadesByUsuario(iduser);
            ViewBag.Universidad = lista;
            return View();
        }
        public IActionResult AgregarAlumnoMateria(string dni)
        {
            return View();
        }
        /*
        public IActionResult MateriasDisponibles()
        {
            return View();
        }
        */
        public IActionResult UniversidadesDisponibles()
        {
            if (!ValidarTipoUsuario()) return View("Error");
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
            List<Universidad> lista =_ProfesoresRepository.GetUniverdadesByUsuario(iduser);
            return Json(new { universidades = lista });
        }

        public IActionResult CarrerasDisponibles(int iduniversidad)
        {
            if (!ValidarTipoUsuario()) return View("Error");
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
            List<Carrera> lista = _ProfesoresRepository.GetCarrerasByUniversidadAndUser(iduser, iduniversidad);
            return Json(new { carreras = lista });
        }

        public IActionResult MateriasDisponibles(int idcarrera, int iduniversidad)
        {
            if (!ValidarTipoUsuario()) return View("Error");
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
            List<Materia> lista = _ProfesoresRepository.GetMateriasByUserAndCarreraAndUniversidad(iduser, idcarrera, iduniversidad);
            return Json(new { materias = lista });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
