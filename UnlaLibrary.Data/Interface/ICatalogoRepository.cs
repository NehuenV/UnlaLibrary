using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICatalogoRepository
    {
        //List<MaterialEstudio> GetCatalogo();
        List<MaterialEstudio> GetCatalogo(int idusuario);
        //List<MaterialEstudio> GetCatalogo(string texto);
        List<MaterialEstudio> GetCatalogo(string texto, int idusuario);
        MaterialEstudio GetMaterial(int id);
    }
}
