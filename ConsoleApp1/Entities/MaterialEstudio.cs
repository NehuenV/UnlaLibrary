using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Entities
{
    public partial class MaterialEstudio
    {
        public int IdMaterial { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Prologo { get; set; }
        public string Autor { get; set; }
        public byte[] Archivo { get; set; }
        public byte[] Miniatura { get; set; }
        public int IdIdioma { get; set; }
        public int IdUsuario { get; set; }
        public int IdMateria { get; set; }
        public int IdUniversidad { get; set; }
        public string TipoArchivo { get; set; }
    }
}
