using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface IMateriaRepository
    {
        Materia Get(int idUniversidad);
        List<Materia> Get();
        bool Create(Materia universidad);
        bool Edit(Materia u);
        bool Delete(int id);
    }
}
