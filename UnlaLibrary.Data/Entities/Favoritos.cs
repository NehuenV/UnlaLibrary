using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Favoritos
    {
        public int IdUsuario { get; set; }
        public int IdMaterial { get; set; }

        public virtual MaterialEstudio IdMaterialNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
