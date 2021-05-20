﻿using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICatalogoRepository
    {
        List<MaterialEstudio> GetCatalogo();
        MaterialEstudio GetMaterial(int id);
    }
}
