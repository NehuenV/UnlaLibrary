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
        //var algo = _Library.Carreras.Where(x=> x.Carrera1 == "algo").Select(x=>x.IdCarrera).ToList();
        //_Library.CarreraMateria.Add(new CarreraMaterium { IdMateria = 1 });

        //List<Materium> lista = new List<Materium>();
        //lista.Select(x => x.Materia).ToList();
        //var a = _Library.Carreras.Select(x => x.Carrera1);//Add(new Carrera { Carrera1 = "Licenciatura en sistemas" });
        //_Library.SaveChanges();
        public IActionResult Catalogo()
        {
            //var algo = HttpContext.Session.GetString("Email");
            //if(string.IsNullOrEmpty(algo))
            //{
            //    return View("Error");
            //}
            return View();
        }
        public IActionResult ListaCatalogo(string texto)
        {
            var cat = texto == null ? _Catalogo.GetCatalogo() : _Catalogo.GetCatalogo(texto);
            ViewBag.Catalogo = cat;
            return View(cat);
        }
        public IActionResult Detalle(int id)
        {
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
        // Ejemplo de traer materialEstudio mediante query
        /* 
        var lista = (from ME in _Library.MaterialEstudios
                     join I in _Library.Idiomas on ME.Idioma equals I.IdIdioma
                     select
                     new MaterialEstudio
                     {
                         Descripcion = ME.Descripcion,
                         IdMateriaEstudio = ME.IdMateriaEstudio,
                         IdiomaNavigation = ME.IdiomaNavigation,
                         Materia = ME.Materia,
                         Idioma = ME.Idioma,
                         Titulo = ME.Titulo
                     }).ToList();

        //Ejemplo de traer materialEstudios con sql 
        var aa = _Library.MaterialEstudios.FromSqlRaw("select * from MaterialEstudio").ToList();


        // Ejemplo con lamda
        MaterialEstudio[] matariales = _Library.MaterialEstudios.Select(s => s).ToArray<MaterialEstudio>();
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
