using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface IUniversidadRepository
    {
        //bool Agregar(string nombre);
        Universidad Get(int idUniversidad);
        List<Universidad> Get();
        bool Create(Universidad universidad);
        bool Edit(Universidad u);
        bool Delete(int id);


    }
}
