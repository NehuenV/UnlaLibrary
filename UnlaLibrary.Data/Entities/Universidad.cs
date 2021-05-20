using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Universidad
    {
        public Universidad()
        {
            MaterialEstudio = new HashSet<MaterialEstudio>();
            UniversidadCarrera = new HashSet<UniversidadCarrera>();
            UsuarioCarreraUniversidad = new HashSet<UsuarioCarreraUniversidad>();
        }

        public int IdUniversidad { get; set; }
        public string NombreUniversidad { get; set; }

        public virtual ICollection<MaterialEstudio> MaterialEstudio { get; set; }
        public virtual ICollection<UniversidadCarrera> UniversidadCarrera { get; set; }
        public virtual ICollection<UsuarioCarreraUniversidad> UsuarioCarreraUniversidad { get; set; }
    }
}
