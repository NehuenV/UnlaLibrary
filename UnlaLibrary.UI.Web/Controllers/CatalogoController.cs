using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly ICatalogoRepository _Catalogo;

        public CatalogoController(ILogger<HomeController> logger, Library Library, ICatalogoRepository Catalogo)
        {
            _logger = logger;
            _Library = Library;
            _Catalogo = Catalogo;
        }
        public bool ValidarTipoUsuario()
        {
            var userType = HttpContext.Session.GetInt32("TipoDeUsuarioId");
            if (userType != null)
                return true;
            return false;
        }

        public IActionResult Catalogo()
        {
            if (!ValidarTipoUsuario()) return View("Error");
            return View();
        }
        public IActionResult ListaCatalogo(string texto)
        {
            if (!ValidarTipoUsuario()) return View("Error");
            var cat = texto == null ? _Catalogo.GetCatalogo() : _Catalogo.GetCatalogo(texto);
            ViewBag.Catalogo = cat;
            return View(cat);
        }
        public IActionResult Detalle(int id)
        {
            if (!ValidarTipoUsuario()) return View("Error");
            var detalle = _Catalogo.GetMaterial(id);
            ViewBag.Detalle = detalle;
            return View(detalle);
        }
        public FileResult DownloadFile(int id)
        {

            var detalle = _Catalogo.GetMaterial(id);
            string contentType = "application/pdf";
            return File(detalle.Archivo, contentType, string.Format("{0}.pdf", detalle.Titulo));
        }
        public FileResult ViewFile(int id)
        {
            var detalle = _Catalogo.GetMaterial(id);
            string contentType = "application/pdf";
            return File(detalle.Archivo, contentType);
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
