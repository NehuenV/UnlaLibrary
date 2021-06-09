using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.UI.Web.Helper;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class UniversidadController : Controller
    {
        private readonly ILogger<UniversidadController> _logger;
        private readonly Library _Library;
        private readonly IUniversidadRepository _Universidad;
        public UniversidadController(ILogger<UniversidadController> logger, Library Library, IUniversidadRepository Universidad)
        {
            _logger = logger;
            _Library = Library;
            _Universidad = Universidad;
        }

        public ActionResult Index()
        {
            var universidades = _Universidad.Get();
            return View(universidades);
        }

        // GET: UniversidadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversidadController/Create
        [HttpPost]
        public ActionResult Create(Universidad universidad)
        {
            bool result = _Universidad.Create(universidad);
            if (!result) return View("Error");
            return RedirectToAction("Index");
        }

        // GET: UniversidadController/Edit/5
        public ActionResult Edit(int id)
        {
            var universidad = _Universidad.Get(id);
            return View(universidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Universidad universidad)
        {
            bool resultado = _Universidad.Edit(universidad);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool resultado = _Universidad.Delete(id);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }
        public ActionResult Carreras(int id)
        {
            var universidad = _Universidad.Get(id);
            ViewBag.carrerasActuales = _Universidad.GetCarrerasActuales(id);
            ViewBag.carrerasRestantes = _Universidad.GetCarrerasRestantes(id);
            return View(universidad);
        }
        public JsonResult ModificarCarreras(int idUniversidad, int idCarrera)
        {
            bool status = _Universidad.modificarUniversidadCarrera(idUniversidad, idCarrera);
            return Json(new { status = status });
        }
    }
}
