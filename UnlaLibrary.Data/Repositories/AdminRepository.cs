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

            var aAgregados = ( from U in _Library.Usuario 
                               join UM in _Library.UsuarioMateria on U.IdUsuario equals UM.IdUsuario
                               join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                               join UCU in _Library.UsuarioCarreraUniversidad on  
                               new 
                               { 
                                   Key1 = U.IdUsuario, 
                                   Key2 = idCarrera 
                               }equals 
                               new 
                               { 
                                   Key1 = UCU.IdUsuario, 
                                   Key2 = UCU.IdCarrera 
                               }
                              select new
                              {
                                  IdUsuario = U.IdUsuario,
                                  Nombre = U.Nombre,
                                  Apellido = U.Apellido,
                                  Dni = U.Dni,
                                  Tipo = T.NombreTipoUsuario,
                                  IdMateria = UM.IdMateria
                              })//.ToList();
                              .Where(x => x.IdMateria == idMat && x.Tipo == "Profesor").ToList();

            List<Alumno> usuariosAgregado = new List<Alumno>();

            foreach (var L in aAgregados) usuariosAgregado.Add(new Alumno
            {
               // IdCarrera = L.IdCarrera,
                IdUsuario = L.IdUsuario,
                Nombre = L.Nombre,
                Apellido = L.Apellido,
                Dni = L.Dni,
                Tipo = L.Tipo,
                Estado = true
            });
            return usuariosAgregado;
        }

        public List<Alumno> GetProfesoresNoAgregadosMateria(int idMat, int idCarrera, int idUniversidad)
        {
            var lista = GetProfesoresAgregadosMateria(idMat, idCarrera);

            var result = (from U in _Library.Usuario
                          join UC in _Library.UsuarioCarreraUniversidad on
                          new {
                              Key1 = U.IdUsuario,
                              Key2 = idUniversidad,
                              Key3 = idCarrera
                          }
                          equals new
                          {
                              Key1 = UC.IdUsuario,
                              Key2 = UC.IdUniversidad,
                              Key3 = UC.IdCarrera
                          }
                          join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                          select new
                          {
                              IdUniversidad = UC.IdUniversidad,
                              IdUsuario = U.IdUsuario,
                              Nombre = U.Nombre,
                              Apellido = U.Apellido,
                              Dni = U.Dni,
                              Tipo = T.NombreTipoUsuario
                          }
                          ).Where(x=> x.Tipo =="Profesor").Distinct().ToList();
            List<Alumno> profesoresAsignaados = new List<Alumno>();
            foreach (var L in result)
                profesoresAsignaados.Add(new Alumno
                {
                    IdCarrera = 0,
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

        public bool AgregarProfesorMateria(int idAlumno, int idMat)
        {
            _Library.UsuarioMateria.Add(new UsuarioMateria { IdMateria = idMat, IdUsuario = idAlumno });
            _Library.SaveChanges();
            return true;
        }
        public bool EliminarProfesorMateria(int idAlumno, int idMat)
        {
            var usuario = _Library.UsuarioMateria.Find(idAlumno, idMat);
            _Library.UsuarioMateria.Remove(usuario);
            _Library.SaveChanges();
            return true;
        }



    }
}
