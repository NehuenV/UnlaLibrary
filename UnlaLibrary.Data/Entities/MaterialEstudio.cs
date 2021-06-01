using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class MaterialEstudio
    {
        public MaterialEstudio()
        {
            Favoritos = new HashSet<Favoritos>();
            Reseña = new HashSet<Reseña>();
        }

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

        public virtual Idioma IdIdiomaNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Universidad IdUniversidadNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Favoritos> Favoritos { get; set; }
        public virtual ICollection<Reseña> Reseña { get; set; }
    }
}
