﻿using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Idioma
    {
        public Idioma()
        {
            MaterialEstudio = new HashSet<MaterialEstudio>();
        }

        public int IdIdioma { get; set; }
        public string Idioma1 { get; set; }

        public virtual ICollection<MaterialEstudio> MaterialEstudio { get; set; }
    }
}
