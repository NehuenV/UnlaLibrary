using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;
using UnlaLibrary.Data.Models;

namespace UnlaLibrary.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Library _Library;
        public AdminRepository(Library Library)
        {
            _Library = Library;
        }
        public List<Universidad> GetAllUniversidades()
        {
            return _Library.Universidad.ToList();
        }

        public List<Carrera> GetCarreras(int idUniversidad)
        {
            return _Library.UniversidadCarrera.Where(x => x.IdUniversidad == idUniversidad).Select(x => x.IdCarreraNavigation).ToList();
        }

        public List<Materia> GetMaterias(int idCarrera)
        {
            return _Library.CarreraMateria.Where(x => x.IdCarrera == idCarrera).Select(x => x.IdMateriaNavigation).ToList();
        }

        public List<Alumno> GetProfesoresAgregadosMateria(int idMat, int idCarrera)
        {
            var result = (from CM in _Library.CarreraMateria
                          join M in _Library.Materia on CM.IdMateria equals M.IdMateria
                          join UM in _Library.UsuarioMateria on M.IdMateria equals UM.IdMateria
                          join U in _Library.Usuario on UM.IdUsuario equals U.IdUsuario
                          join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                          select new
                          {
                              IdCarrera = CM.IdCarrera,
                              IdUsuario = U.IdUsuario,
                              Nombre = U.Nombre,
                              Apellido = U.Apellido,
                              Dni = U.Dni,
                              Tipo = T.NombreTipoUsuario,
                              Estado = true,
                              IdMateria = UM.IdMateria
                          }).Where(x => x.IdMateria == idMat && x.IdCarrera == idCarrera && x.Tipo == "Profesor").ToList();
            List<Alumno> profesoresAsignaados = new List<Alumno>();
            foreach (var L in result)
                profesoresAsignaados.Add(new Alumno
            {
                IdCarrera = L.IdCarrera,
                IdUsuario = L.IdUsuario,
                Nombre = L.Nombre,
                Apellido = L.Apellido,
                Dni = L.Dni,
                Tipo = L.Tipo,
                Estado = L.Estado
            });
            return profesoresAsignaados;
        }

        public List<Alumno> GetProfesoresNoAgregadosMateria(int idMat, int idCarrera)
        {
            var lista = GetProfesoresAgregadosMateria(idMat, idCarrera);

            var result = (from UCU in _Library.UsuarioCarreraUniversidad
                          join U in _Library.Usuario on UCU.IdUsuario equals U.IdUsuario
                          join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                          select new
                          {
                              IdCarrera = UCU.IdCarrera,
                              IdUsuario = U.IdUsuario,
                              Nombre = U.Nombre,
                              Apellido = U.Apellido,
                              Dni = U.Dni,
                              Tipo = T.NombreTipoUsuario,

                          }).Where(x => x.IdCarrera == idCarrera && x.Tipo == "Profesor").ToList();
            List<Alumno> profesoresAsignaados = new List<Alumno>();
            foreach (var L in result)
                profesoresAsignaados.Add(new Alumno
                {
                    IdCarrera = L.IdCarrera,
                    IdUsuario = L.IdUsuario,
                    Nombre = L.Nombre,
                    Apellido = L.Apellido,
                    Dni = L.Dni,
                    Tipo = L.Tipo,
                    Estado = false
                });

            foreach (var item in lista)
            {
                var u = profesoresAsignaados.Where(x => x.Dni == item.Dni).FirstOrDefault();
                if (u != null)
                {
                    profesoresAsignaados.Remove(u);
                }
            }

            return profesoresAsignaados;
        }





    }
}
