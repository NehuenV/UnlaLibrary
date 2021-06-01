using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICatalogoRepository
    {
        List<MaterialEstudio> GetCatalogo(int idusuario, string texto, int idmateria);
        MaterialEstudio GetMaterial(int id);
        List<Materia> GetMaterias(int idusuario);

    }
}
