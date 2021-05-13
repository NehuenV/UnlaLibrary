using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class CarreraMaterium
    {
        public int IdCarrera { get; set; }
        public int IdMateria { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Materium IdMateriaNavigation { get; set; }
    }
}
