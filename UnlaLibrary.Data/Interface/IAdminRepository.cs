using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Models;

namespace UnlaLibrary.Data.Interface
{
    public interface IAdminRepository
    {
        List<Universidad> GetAllUniversidades();
        List<Carrera> GetCarreras(int idUniversidad);
        List<Materia> GetMaterias(int idCarrera);
        List<Alumno> GetProfesoresAgregadosMateria(int idMat, int idCarrera);
        List<Alumno> GetProfesoresNoAgregadosMateria(int idMat, int idCarrera);
    }
}
