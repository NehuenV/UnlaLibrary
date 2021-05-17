using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class MaterialEstudio
    {
        public int IdMateriaEstudio { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Idioma { get; set; }
        public int Materia { get; set; }
        public int Usuario { get; set; }
        public string Autor { get; set; }
        public byte[] Miniatura { get; set; }
        public byte[] Archivo { get; set; }

        public virtual Idioma IdiomaNavigation { get; set; }
        public virtual Materia MateriaNavigation { get; set; }
        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
