using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICatalogoRepository
    {
        List<MaterialEstudio> GetCatalogo();
        List<MaterialEstudio> GetCatalogo(string texto);
        MaterialEstudio GetMaterial(int id);
    }
}
