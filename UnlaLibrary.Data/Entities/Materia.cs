using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Materia
    {
        public Materia()
        {
            MaterialEstudio = new HashSet<MaterialEstudio>();
        }

        public int IdMateria { get; set; }
        public string Materia1 { get; set; }

        public virtual ICollection<MaterialEstudio> MaterialEstudio { get; set; }
    }
}
