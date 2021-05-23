using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnlaLibrary.Data.Models
{
    public class Material
    {
        public int Materia { get; set; }
        public int Universidad { get; set; }
        public IFormFile Archivo { get; set; }
        public IFormFile Miniatura { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string Prologo { get; set; }
        public int Idioma { get; set; }
    }
}
