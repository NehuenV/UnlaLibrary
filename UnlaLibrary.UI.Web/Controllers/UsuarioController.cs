using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _Usuario;
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository Usuario)
        {
            _logger = logger;
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
    }
}
