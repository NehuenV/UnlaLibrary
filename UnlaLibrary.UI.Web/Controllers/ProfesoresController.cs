using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.Data.Interfaces;
using UnlaLibrary.Data.Models;
using UnlaLibrary.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using UnlaLibrary.Data.Utils;

namespace UnlaLibrary.UI.Web.Controllers
{
    [Authorize]
    public class ProfesoresController : Controller
    {
        #region constructor
        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly IProfesoresRepository _ProfesoresRepository;
        public ProfesoresController(ILogger<HomeController> logger, Library Library, IProfesoresRepository ProfesoresRepository)
        {
            _logger = logger;
            _Library = Library;
            _ProfesoresRepository = ProfesoresRepository;
        }
        #endregion
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

        public JsonResult CambiarAlumnoMateria(int idUsuario, bool estado, int idMat)
        {
            if (estado)
            {
                _ProfesoresRepository.EliminarAlumnoMateria(idUsuario, idMat);
            }
            else
            {
                _ProfesoresRepository.AgregarAlumnoMateria(idUsuario, idMat);
            }
            return Json(new { status = "Ok" });
        }

        public JsonResult up(Material mat)
        {
            bool estado = _ProfesoresRepository.AgregarMaterial(mat);
            if (estado)
            {
                return Json(new { status = estado, message = string.Format("El material {0} fue agregado con exito", mat.Titulo) });
            }
            else
            {
                return Json(new { status = estado, message = string.Format("El material {0} no pudo ser agregado", mat.Titulo) });
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

            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User)); 
            List<Universidad> lista = _ProfesoresRepository.GetUniverdadesByUsuario(iduser);
            ViewBag.Universidad = lista;
            return View();
        }
        public IActionResult ListaAlumnoMateria(int idMat, int idCarrera)
        {
            var lista2 = _ProfesoresRepository.GetAlumnosAgregadosMateria(idMat, idCarrera);
            var lista1 = _ProfesoresRepository.GetAlumnosNoagregadosByCarrera(idMat, idCarrera);
            lista2.AddRange(lista1);
            return View(lista2);
        }

        public IActionResult UniversidadesDisponibles()
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            List<Universidad> lista =_ProfesoresRepository.GetUniverdadesByUsuario(iduser);
            return Json(new { universidades = lista });
        }

        public JsonResult CarrerasDisponibles(int iduniversidad)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            List<Carrera> lista = _ProfesoresRepository.GetCarrerasByUniversidadAndUser(iduser, iduniversidad);
            return Json(new SelectList(lista, "IdCarrera", "Carrera1"));
        }

        public JsonResult MateriasDisponibles(int idcarrera, int iduniversidad)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            List<Materia> lista = _ProfesoresRepository.GetMateriasByUserAndCarreraAndUniversidad(iduser, idcarrera, iduniversidad);
            return Json(new SelectList(lista, "IdMateria", "Materia1"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
