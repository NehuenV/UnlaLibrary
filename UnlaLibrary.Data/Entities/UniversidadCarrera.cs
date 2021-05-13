using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class UniversidadCarrera
    {
        public int IdUniversidad { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Universidad IdUniversidadNavigation { get; set; }
    }
}
