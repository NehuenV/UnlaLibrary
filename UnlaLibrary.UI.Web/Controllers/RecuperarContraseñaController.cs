using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class RecuperarContraseñaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly ICuentaRepository _Cuenta;
        private readonly Library _Library;

        public RecuperarContraseñaController(ICuentaRepository Cuenta, Library Library)
        {
            _Cuenta = Cuenta;
            _Library = Library;

        }
        public JsonResult Recuperar(string email)
        {
            var usuario = _Library.Usuario.Where(x => x.Email == email).FirstOrDefault();
            if(usuario == null)
            {
                return Json(new { status = false });
            }
            return Json(new { status = true, password = usuario.Clave });
        }
    }
}
