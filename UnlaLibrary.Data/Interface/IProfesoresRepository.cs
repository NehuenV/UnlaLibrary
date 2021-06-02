using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Models;

namespace UnlaLibrary.Data.Interface
{
    public interface IProfesoresRepository
    {
        List<Universidad> GetUniverdadesByUsuario(int iduser);
        List<Carrera> GetCarrerasByUniversidadAndUser(int iduser, int iduniversidad);
        List<Materia> GetMateriasByUserAndCarreraAndUniversidad(int iduser, int idcarrera, int iduniversidad);
        List<Universidad> GetUniverdades();
        List<UsuarioCarreraUniversidad> GetUsuariosByCarreraUniversidad(int iduser, int iduni);
        List<Materia> GetMateriasByCarrera(int idcarr);
        List<Alumno> GetAlumnosByCarrera(int idcarr);
        List<Alumno> GetAlumnosAgregadosMateria(int idMat, int idCarrera);
        List<Alumno> GetAlumnosNoagregadosByCarrera(int idMat, int idCarrera);
        List<Idioma> GetIdiomas();
        bool AgregarMaterial(Material m);

        List<Materia> GetMateriaByCarreraUsuario(int idUniversidad, int idUsuario);
        #region alumnoMateria
        bool AgregarAlumnoMateria(int idMat, int idAlumno);
        bool EliminarAlumnoMateria(int idMat, int idAlumno);
        #endregion
        List<MaterialEstudio> GetMaterialEstudio(int idusuario);
        bool EliminarMaterial(int idMaterial);

    }
}
