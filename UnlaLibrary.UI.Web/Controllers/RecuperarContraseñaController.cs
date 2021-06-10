using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.UI.Web.Controllers
{
    public class RecuperarContraseñaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly ICuentaRepository _Cuenta;
        public RecuperarContraseñaController(ICuentaRepository Cuenta)
        {
            _Cuenta = Cuenta;
        }
        public JsonResult Recuperar(string email)
        {
            _Cuenta.RecuperarClave(email);
            return Json(new { status = true });
        }
    }
}
