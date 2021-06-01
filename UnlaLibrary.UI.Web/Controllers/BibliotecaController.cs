using Microsoft.AspNetCore.Authorization;
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
using UnlaLibrary.UI.Web.Helper;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly ICatalogoRepository _Catalogo;
        private readonly IBibliotecaRepository _Biblioteca;

        public BibliotecaController(ILogger<HomeController> logger, Library Library, ICatalogoRepository Catalogo, IBibliotecaRepository Biblioteca)
        {
            _logger = logger;
            _Library = Library;
            _Catalogo = Catalogo;
            _Biblioteca = Biblioteca;
        }
        public IActionResult Biblioteca()
        {
            // valores de prueba, quitar luego
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var cat = _Catalogo.GetCatalogo(iduser);
            ViewBag.Catalogo = cat;
            return View(cat);
        }
        
        public JsonResult ModificarFav(int idMaterial)
        {
            int idUser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var r = _Biblioteca.ModificarFavoritos(idMaterial, idUser);
            return Json(new { status = r });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
