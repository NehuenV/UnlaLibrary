using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.UI.Web.Controllers
{
    [Authorize(Policy = "AdminType")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly Library _Library;
        private readonly IUsuarioRepository _Usuario;
        public UsuarioController(ILogger<UsuarioController> logger, Library Library, IUsuarioRepository Usuario)
        {
            _logger = logger;
            _Library = Library;
            _Usuario = Usuario;
        }
        // GET: UsuariosController
        public ActionResult Index()
        {
            var user = _Usuario.Get();
            return View(user);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            var typeuser = _Usuario.GetTipoUsuario();
            ViewData["Tipos"] = typeuser;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            bool result = _Usuario.Create(usuario);
            if (!result) return View("Error");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = _Usuario.Get(id);
            var typeuser = _Usuario.GetTipoUsuario();
            ViewData["Tipos"] = typeuser;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            bool resultado = _Usuario.Edit(usuario);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool resultado = _Usuario.Delete(id);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }

        public ActionResult Academica()
        {
            List<Universidad> universidades = _Library.Universidad.Select(x => x).ToList();
            return View(universidades);
        }
        public JsonResult CarrerasDisponibles(int idUniversidad)
        {
            List<Carrera> carreras = _Library.UniversidadCarrera
                .Include(x => x.IdCarreraNavigation)
                .Where(x => x.IdUniversidad == idUniversidad)
                .Select(x => x.IdCarreraNavigation)
                .ToList();
            return Json(new SelectList(carreras, "IdCarrera", "Carrera1"));
        }
        [HttpPost]
        public ActionResult ListaUsuarioCarreraUniversidad(int idUniversidad, int idCarrera)
        {
            var usuariosAgregados = _Usuario.GetUsuariosAgregados(idUniversidad, idCarrera);
            var usuariosNoAgregados = _Usuario.GetUsuariosNoAgregados(idUniversidad, idCarrera);
            ViewBag.usuariosAgregados = usuariosAgregados;
            ViewBag.usuariosNoAgregados = usuariosNoAgregados;
            return View();
        }
        public JsonResult ModificarUsuarioCarreraUniversidad(int idUniversidad, int idCarrera, int idUsuario)
        {
            bool status = _Usuario.modificarUsuarioCarreraUniversidad(idUniversidad, idCarrera, idUsuario);
            return Json(new { status = status });
        }
    }
}
