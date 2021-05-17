using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class UsuarioMateria
    {
        public int IdUsuario { get; set; }
        public int IdMateria { get; set; }

        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
