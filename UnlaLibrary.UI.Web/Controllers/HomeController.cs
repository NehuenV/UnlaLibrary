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
using UnlaLibrary.Data.Interfaces;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Library _Library;
        private readonly IAuthenticationRepository _login;
        public HomeController(ILogger<HomeController> logger, Library Library, IAuthenticationRepository login)
        {
            _logger = logger;
            _Library = Library;
            _login = login;
        }
        public IActionResult Index()
        {
            //var algo = _Library.Carreras.Where(x=> x.Carrera1 == "algo").Select(x=>x.IdCarrera).ToList();
            //_Library.CarreraMateria.Add(new CarreraMaterium { IdMateria = 1 });
            
            //List<Materium> lista = new List<Materium>();
            //lista.Select(x => x.Materia).ToList();
            //var a = _Library.Carreras.Select(x => x.Carrera1);//Add(new Carrera { Carrera1 = "Licenciatura en sistemas" });
                //_Library.SaveChanges();
            
            return View();
        }
        public IActionResult Login(Login login)
        {
            _login.Authentication();
            //var algo = _Library.Carreras.Where(x=> x.Carrera1 == "algo").Select(x=>x.IdCarrera).ToList();
            //_Library.CarreraMateria.Add(new CarreraMaterium { IdMateria = 1 });

            //List<Materium> lista = new List<Materium>();
            //lista.Select(x => x.Materia).ToList();
            //var a = _Library.Carreras.Select(x => x.Carrera1);//Add(new Carrera { Carrera1 = "Licenciatura en sistemas" });
            //_Library.SaveChanges();

            return View("Index");
        }
        public IActionResult Privacy()
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
