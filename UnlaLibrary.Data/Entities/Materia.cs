using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Materia
    {
        public Materia()
        {
            CarreraMateria = new HashSet<CarreraMateria>();
            MaterialEstudio = new HashSet<MaterialEstudio>();
            UsuarioMateria = new HashSet<UsuarioMateria>();
        }

        public int IdMateria { get; set; }
        public string Materia1 { get; set; }

        public virtual ICollection<CarreraMateria> CarreraMateria { get; set; }
        public virtual ICollection<MaterialEstudio> MaterialEstudio { get; set; }
        public virtual ICollection<UsuarioMateria> UsuarioMateria { get; set; }
    }
}
