using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "AdminType")]
    public class MateriaController : Controller
    {
        private readonly ILogger<MateriaController> _logger;
        private readonly IMateriaRepository _Materia;
        public MateriaController(ILogger<MateriaController> logger, IMateriaRepository Materia)
        {
            _logger = logger;
            _Materia = Materia;
        }
        // GET: MateriasController
        public ActionResult Index()
        {
            var materia = _Materia.Get();
            return View(materia);
        }

        // GET: MateriasController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Materia materia)
        {
            bool result = _Materia.Create(materia);
            if (!result) return View("Error");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var materia = _Materia.Get(id);
            return View(materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Materia materia)
        {
            bool resultado = _Materia.Edit(materia);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool resultado = _Materia.Delete(id);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }
    }
}
