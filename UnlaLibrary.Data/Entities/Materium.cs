using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Materium
    {
        public Materium()
        {
            MaterialEstudios = new HashSet<MaterialEstudio>();
        }

        public int IdMateria { get; set; }
        public string Materia { get; set; }

        public virtual ICollection<MaterialEstudio> MaterialEstudios { get; set; }
    }
}
