using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Reseña
    {
        public int IdReseña { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }
        public int IdMaterial { get; set; }
        public int IdUsuario { get; set; }

        public virtual MaterialEstudio IdMaterialNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
