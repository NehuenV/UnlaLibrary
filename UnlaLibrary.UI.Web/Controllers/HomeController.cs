using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interfaces;
using UnlaLibrary.Data.Models;
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
            return View();
        }
        public async Task<IActionResult>Login(Login login)
        {
            
            var aut = _login.Authentication(login);

            if (aut)
            {
                string name = _login.GetName(login);
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _login.GetId(login).ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                identity.AddClaim(new Claim("TipoDeUsuarioId", _login.GetIdTipoDeUsuario(login).ToString()));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent =true});
                return Json( new { status = aut, name = name, email = login.email, message ="Bienvenido " });
            }
            else
            {
                return Json(new { status = aut, name = "", email = "", message = "Clave o usuario incorrecto " });
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
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
