﻿using Microsoft.AspNetCore.Authorization;
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

        public CatalogoController(ILogger<HomeController> logger, Library Library, ICatalogoRepository Catalogo)
        {
            _logger = logger;
            _Library = Library;
            _Catalogo = Catalogo;
        }
        public IActionResult Catalogo()
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            ViewBag.Materias = _Catalogo.GetMaterias(iduser);
            return View();
        }
        public IActionResult ListaCatalogo(string texto, int idmateria)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var cat =  _Catalogo.GetCatalogo(iduser, texto, idmateria);
            ViewBag.Catalogo = cat;
            return View(cat);
        }

        public IActionResult CatalogoCargado(string texto, int idmateria)
        {
            ViewData["texto"] = texto;
            ViewData["idmateria"] = idmateria;
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            ViewBag.Materias = _Catalogo.GetMaterias(iduser);
            return View("Catalogo");
        }

        public IActionResult Detalle(int id)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var detalle = _Catalogo.GetMaterial(id);
            ViewBag.Materias = _Catalogo.GetMaterias(iduser);
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
