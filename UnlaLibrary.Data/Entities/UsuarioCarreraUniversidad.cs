using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class UsuarioCarreraUniversidad
    {
        public int IdUsuario { get; set; }
        public int IdCarrera { get; set; }
        public int IdUniversidad { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Universidad IdUniversidadNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
