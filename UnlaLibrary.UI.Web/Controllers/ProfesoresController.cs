using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
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
        public IActionResult CambiarAlumnoMateria(int idUsuario, bool estado, int idMat)
        {
            if (estado)
            {
                _ProfesoresRepository.EliminarAlumnoMateria(idUsuario, idMat);
            }
            else
            {
                _ProfesoresRepository.AgregarAlumnoMateria(idUsuario,idMat);
            }
            return View();
        }

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

        public bool ValidarTipoUsuario()
        {
            var userType = HttpContext.Session.GetInt32("TipoDeUsuarioId");
            if (userType != null) 
                return (int)userType == 2;
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
        public IActionResult ListaAlumnoMateria(int idMat, int idCarrera)
        {
            var lista2 = _ProfesoresRepository.GetAlumnosAgregadosMateria(idMat, idCarrera);
            var lista1 = _ProfesoresRepository.GetAlumnosNoagregadosByCarrera(idMat, idCarrera);
            List<Alumno> listaUsuarios = new List<Alumno>();
            listaUsuarios.AddRange(lista2);
            listaUsuarios.AddRange(lista1);
            return View(listaUsuarios);
        }

        public IActionResult UniversidadesDisponibles()
        {
            if (!ValidarTipoUsuario()) return View("Error");
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
            List<Universidad> lista =_ProfesoresRepository.GetUniverdadesByUsuario(iduser);
            return Json(new { universidades = lista });
        }

        public JsonResult CarrerasDisponibles(int iduniversidad)
        {
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
            List<Carrera> lista = _ProfesoresRepository.GetCarrerasByUniversidadAndUser(iduser, iduniversidad);
            return Json(new SelectList(lista, "IdCarrera", "Carrera1"));
        }

        public JsonResult MateriasDisponibles(int idcarrera, int iduniversidad)
        {
            int iduser = (int)HttpContext.Session.GetInt32("UserId");
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
