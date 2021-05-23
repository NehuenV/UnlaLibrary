using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Models;

namespace UnlaLibrary.Data.Interface
{
    public interface IProfesoresRepository
    {

        List<Universidad> GetUniverdades();
        List<UsuarioCarreraUniversidad> GetUsuariosByCarreraUniversidad(int iduser, int iduni);

        List<Materia> GetMateriasByCarrera(int idcarr);

        List<Alumno> GetAlumnosByCarrera(int idMat, int idcarr);
        List<Alumno> GetAlumnosAgregadosMateria(int idMat);
        List<Alumno> GetAlumnosNoagregadosByCarrera(int idMat);
    }
}
