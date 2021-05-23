using System;
using System.Collections.Generic;
using System.Text;

namespace UnlaLibrary.Data.Models
{
    public class Alumno
    {
        public int IdUsuario { get; set; }
        public int IdCarrera { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }

    }
}
