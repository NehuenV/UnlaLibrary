using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.Data.Interfaces;
using UnlaLibrary.Data.Models;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly IProfesoresRepository _ProfesoresRepository;
        public ProfesoresController(ILogger<HomeController> logger, Library Library, IProfesoresRepository ProfesoresRepository)
        {
            _logger = logger;
            _Library = Library;
            _ProfesoresRepository = ProfesoresRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AlumnoMateria()
        {

            return View();
        }
        public IActionResult AgregarAlumnoMateria(string dni)
        {
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
