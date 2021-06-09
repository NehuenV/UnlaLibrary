using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICarreraRepository
    {

        Carrera Get(int idUniversidad);
        List<Carrera> Get();
        bool Create(Carrera universidad);
        bool Edit(Carrera u);
        bool Delete(int id);
        List<Materia> GetMateriasActuales(int idCarrera);
        List<Materia> GetMateriasRestantes(int idCarrera);
        bool modificarMateriaCarrera(int idCarrera, int idMateria);
    }
}
