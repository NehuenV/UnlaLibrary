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
    public class CatalogoController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly ICatalogoRepository _Catalogo;
        private readonly IBibliotecaRepository _Biblioteca;

        public CatalogoController(ILogger<HomeController> logger, Library Library, ICatalogoRepository Catalogo, IBibliotecaRepository Biblioteca)
        {
            _logger = logger;
            _Library = Library;
            _Catalogo = Catalogo;
            _Biblioteca = Biblioteca;
        }
        public IActionResult Catalogo()
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            ViewBag.Materias = _Catalogo.GetMaterias(iduser);
            ViewBag.Idiomas = _Library.Idioma.Select(x => x);
            return View();
        }
        public IActionResult ListaCatalogo(string texto, int idmateria, int[] idiomas = null, string[]tipos = null)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var cat =  _Catalogo.GetCatalogo(iduser, texto, idmateria, idiomas, tipos);
            ViewBag.Catalogo = cat;
            return View(cat);
        }

        public IActionResult CatalogoCargado(string texto, int idmateria)
        {
            ViewData["texto"] = texto;
            ViewData["idmateria"] = idmateria;
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            ViewBag.Materias = _Catalogo.GetMaterias(iduser);
            ViewBag.Idiomas = _Library.Idioma.Select(x => x);
            return View("Catalogo");
        }

        public IActionResult Detalle(int id)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var detalle = _Catalogo.GetMaterial(id);
            ViewBag.Materias = _Catalogo.GetMaterias(iduser);
            ViewData["Fav"] = _Biblioteca.GetFavorito(iduser, id)!=null ? true : false ;
            ViewData["Res"] = _Catalogo.GetAllReseñas(id, iduser);
            ViewBag.MiReseña = _Catalogo.GetReseña(id, iduser);
            return View(detalle);
        }
        public FileResult DownloadFile(int id)
        {
            string contentType;
            var detalle = _Catalogo.GetMaterial(id);
            if (detalle.TipoArchivo.Equals("MP3"))
            {
                contentType = string.Format("application/{0}","MPEG");
            }
            else
            {
                contentType = string.Format("application/{0}", detalle.TipoArchivo);
            }
            return File(detalle.Archivo, contentType, string.Format("{0}.{1}", detalle.Titulo, detalle.TipoArchivo));
        }
        public FileResult ViewFile(int id)
        {
            var detalle = _Catalogo.GetMaterial(id);
            string contentType;
            if (detalle.TipoArchivo.Equals("MP3"))
            {
                contentType = string.Format("application/{0}", "MPEG");
            }
            else
            {
                contentType = string.Format("application/{0}", detalle.TipoArchivo);
            }
            return File(detalle.Archivo, contentType);
        }
        /*
        public IActionResult Reseña(string texto, int idMaterial)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            _Catalogo.CambiarReseña(new Reseña {Comentario= texto, IdUsuario=iduser,IdMaterial = idMaterial});
            return Json(new { status = "Ok", message = "hecho" });
        }*/
        public IActionResult Reseña(string texto, int puntuacion, int idMaterial)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            _Catalogo.CambiarReseña(new Reseña { Comentario = texto, Puntuacion = puntuacion, IdUsuario = iduser, IdMaterial = idMaterial });
            return Json(new { status = "Ok", message = "hecho" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
