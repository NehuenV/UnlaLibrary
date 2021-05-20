using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Carrera
    {
        public Carrera()
        {
            CarreraMateria = new HashSet<CarreraMateria>();
            UniversidadCarrera = new HashSet<UniversidadCarrera>();
            UsuarioCarreraUniversidad = new HashSet<UsuarioCarreraUniversidad>();
        }

        public int IdCarrera { get; set; }
        public string Carrera1 { get; set; }

        public virtual ICollection<CarreraMateria> CarreraMateria { get; set; }
        public virtual ICollection<UniversidadCarrera> UniversidadCarrera { get; set; }
        public virtual ICollection<UsuarioCarreraUniversidad> UsuarioCarreraUniversidad { get; set; }
    }
}
