using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            return View();
        }
        public IActionResult ListaCatalogo()
        {
            var cat = _Catalogo.GetCatalogo();
            ViewBag.Catalogo = cat;
            return View(cat);
        }
        public IActionResult Detalle(int algo)
        {
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
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
