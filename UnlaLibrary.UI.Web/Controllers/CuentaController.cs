using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.UI.Web.Helper;
using UnlaLibrary.UI.Web.Models;

namespace UnlaLibrary.UI.Web.Controllers
{
    [Authorize]

    public class CuentaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly Library _Library;
        private readonly ICuentaRepository _Cuenta;
        public CuentaController(ILogger<CuentaController> logger, Library Library, ICuentaRepository Cuenta)
        {
            _logger = logger;
            _Library = Library;
            _Cuenta = Cuenta;
        }

        public ActionResult Index()
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            var usuario = _Cuenta.Get(iduser);
            return View(usuario);
        }

        [HttpPost]
        public JsonResult Edit(string email, string clave)
        {
            int iduser = Convert.ToInt32(SessionHelper.GetNameIdentifier(HttpContext.User));
            bool resultado = _Cuenta.Edit(email, clave, iduser);
            return Json(new { status =  resultado });
        }
        public JsonResult Recuperar(string email)
        {
            _Cuenta.RecuperarClave(email);
            return Json(new { status = true });
        }
    }
}
