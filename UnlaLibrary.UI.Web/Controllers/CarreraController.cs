using Microsoft.AspNetCore.Http;
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
    public class CarreraController : Controller
    {
        private readonly ILogger<CarreraController> _logger;
        private readonly ICarreraRepository _Carrera;
        public CarreraController(ILogger<CarreraController> logger, ICarreraRepository Carrera)
        {
            _logger = logger;
            _Carrera = Carrera;
        }
        // GET: CarrerasController
        public ActionResult Index()
        {
            var carrera = _Carrera.Get();
            return View(carrera);
        }

        // GET: CarrerasController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Carrera carrera)
        {
            bool result = _Carrera.Create(carrera);
            if (!result) return View("Error");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var carrera = _Carrera.Get(id);
            return View(carrera);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carrera carrera)
        {
            bool resultado = _Carrera.Edit(carrera);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool resultado = _Carrera.Delete(id);
            if (!resultado) return View("Error");
            return RedirectToAction("Index");
        }
    }
}
