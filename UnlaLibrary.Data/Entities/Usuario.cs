using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            MaterialEstudio = new HashSet<MaterialEstudio>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int TipoUsuario { get; set; }

        public virtual TipoUsuario TipoUsuarioNavigation { get; set; }
        public virtual ICollection<MaterialEstudio> MaterialEstudio { get; set; }
    }
}
