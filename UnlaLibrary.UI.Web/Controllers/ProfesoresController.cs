using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        #region Actions
        public IActionResult SubirMaterial()
        {
            var uni = _ProfesoresRepository.GetUniverdades();
            ViewBag.Universidades = uni;
            var idioma = _ProfesoresRepository.GetIdiomas();
            ViewBag.Idioma = idioma;
            return View();
        }


        #endregion


        #region RequestJson
        public JsonResult up(Material m)
        {
            bool estado = _ProfesoresRepository.AgregarMaterial(m);
            if (estado)
            {
                return Json(new { status = estado, message = string.Format("El material {0} fue agregado con exito", m.Titulo) });
            }
            else
            {
                return Json(new { status = estado, message = string.Format("El material {0} no pudo ser agregado", m.Titulo) });
            }
        }
        public JsonResult GetMaterias(int idUniversidad, int idUsuario = 1)
        {
            var lista= _ProfesoresRepository.GetMateriaByCarreraUsuario(idUniversidad, idUsuario);
            return Json(new SelectList(lista, "IdMateria", "Materia1"));
        }

        #endregion
        public IActionResult AlumnoMateria()
        {

            return View();
        }
        public IActionResult AgregarAlumnoMateria(string dni)
        {
            
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
