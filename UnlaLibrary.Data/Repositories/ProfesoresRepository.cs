﻿using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Interface;
using System.Linq;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Models;
using System.IO;

namespace UnlaLibrary.Data.Repositories
{
    public class ProfesoresRepository : IProfesoresRepository
    {
        private readonly Library _Library;
        public ProfesoresRepository(Library Library)
        {
            _Library = Library;
        }


        public List<Universidad> GetUniverdades()
        {

            var uni = _Library.Universidad.ToList();
            return uni;

        }

        public List<UsuarioCarreraUniversidad> GetUsuariosByCarreraUniversidad(int iduser, int iduni )
        {
            var carrera = _Library.UsuarioCarreraUniversidad.Where(x => x.IdUsuario == iduser && x.IdUniversidad == iduni).ToList();
            return carrera;
        }
        public List<Materia> GetMateriasByCarrera(int idcarr)
        {
            var materias = (from CM in _Library.CarreraMateria
                            join M in _Library.Materia on CM.IdMateria equals M.IdMateria
                            select new
                            {
                                carr = CM.IdCarrera,
                                IdMateria = CM.IdMateria,
                                Materia1 = M.Materia1
                            }).Where(x => x.carr == idcarr).ToList();

            List<Materia> listaMaterias = new List<Materia>();

            foreach (var item in materias) listaMaterias.Add(new Materia {
                IdMateria = item.IdMateria,
                Materia1 = item.Materia1
            });
            return listaMaterias;
        }

        //todos los alumnos de la carrera
        public List<Alumno> GetAlumnosByCarrera(int idMat, int idcarr)
        {
            var alumnosCarrera = (from A in _Library.UsuarioCarreraUniversidad
                                  join U in _Library.Usuario on A.IdUsuario equals U.IdUsuario
                                  join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                                  select new Alumno
                                  {
                                      IdCarrera = A.IdCarrera,
                                      IdUsuario = U.IdUsuario,
                                      Nombre = U.Nombre,
                                      Apellido = U.Apellido,
                                      Dni = U.Dni,
                                      Tipo = T.NombreTipoUsuario,
                                      Estado = false
                                  })
                           .Where(x => x.IdCarrera == idcarr && x.Tipo == "Estudiante")
                           .ToList();
            return alumnosCarrera;
        }

        public List<Alumno> GetAlumnosAgregadosMateria(int idMat) 
        {
            var alumnosCarrera = GetAlumnosByCarrera(1, 1);
            var aAgregados = (from UM in _Library.UsuarioMateria
                            join U in _Library.Usuario on UM.IdUsuario equals U.IdUsuario
                            join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                            join A in _Library.UsuarioCarreraUniversidad on UM.IdUsuario equals A.IdUsuario
                            select new 
                            {
                                IdCarrera = A.IdCarrera,
                                IdUsuario = U.IdUsuario,
                                Nombre = U.Nombre,
                                Apellido = U.Apellido,
                                Dni = U.Dni,
                                Tipo = T.NombreTipoUsuario,
                                Estado = true,
                                IdMateria = UM.IdMateria
                            }).Where(x=> x.IdMateria == idMat).ToList();

            List<Alumno> usuariosAgregado = new List<Alumno>();

            foreach (var L in aAgregados) usuariosAgregado.Add(new Alumno
            {
                IdCarrera = L.IdCarrera,
                IdUsuario = L.IdUsuario,
                Nombre = L.Nombre,
                Apellido = L.Apellido,
                Dni = L.Dni,
                Tipo = L.Tipo,
                Estado = L.Estado
            });
            return usuariosAgregado;
        }
        public List<Alumno> GetAlumnosNoagregadosByCarrera(int idMat)
        {
                var alumnosCarrera = GetAlumnosByCarrera(1, 1);


                var aAgregados = (from UM in _Library.UsuarioMateria
                                  join U in _Library.Usuario on UM.IdUsuario equals U.IdUsuario
                                  join T in _Library.TipoUsuario on U.IdTipoUsuario equals T.IdTipoUsuario
                                  join A in _Library.UsuarioCarreraUniversidad on UM.IdUsuario equals A.IdUsuario
                                  select new
                                  {
                                      IdCarrera = A.IdCarrera,
                                      IdUsuario = U.IdUsuario,
                                      Nombre = U.Nombre,
                                      Apellido = U.Apellido,
                                      Dni = U.Dni,
                                      Tipo = T.NombreTipoUsuario,
                                      Estado = true,
                                      IdMateria = UM.IdMateria
                                  }).Where(x => x.IdMateria == idMat).ToList();

                List<Alumno> usuariosAgregado = new List<Alumno>();

                foreach (var L in aAgregados) usuariosAgregado.Add(new Alumno
                {
                    IdCarrera = L.IdCarrera,
                    IdUsuario = L.IdUsuario,
                    Nombre = L.Nombre,
                    Apellido = L.Apellido,
                    Dni = L.Dni,
                    Tipo = L.Tipo,
                    Estado = L.Estado
                });
                foreach (var item in usuariosAgregado) alumnosCarrera.Remove(item);

            return usuariosAgregado;
        }


        public bool AgregarMaterial(Material m)
        {
            try
            {


                var materialEstudio = new MaterialEstudio
                {
                    Autor = m.Autor,
                    Descripcion = m.Descripcion,
                    Titulo = m.Titulo,
                    Prologo = m.Prologo,
                    IdIdioma = m.Idioma,
                    IdMateria = m.Materia,
                    IdUsuario = 1,
                    IdUniversidad = m.Universidad

                };

                using (var archivo = new MemoryStream())
                {
                    m.Archivo.CopyTo(archivo);
                    var fileBytes = archivo.ToArray();
                    materialEstudio.Archivo = fileBytes;
                }
                using (var miniatura = new MemoryStream())
                {
                    m.Miniatura.CopyTo(miniatura);
                    var fileBytes = miniatura.ToArray();
                    materialEstudio.Miniatura = fileBytes;
                }
                _Library.MaterialEstudio.Add(materialEstudio);
                _Library.SaveChanges();
                return true;
            }catch (Exception e)
            {
                return false;
            }
        }

        public List<Idioma> GetIdiomas()
        {
            var idioma = _Library.Idioma.ToList();
            return idioma;
        }

        public List<Materia> GetMateriaByCarreraUsuario(int idUniversidad, int idUsuario )
        {
            int idCarrera = _Library.UsuarioCarreraUniversidad.Where(x => x.IdUniversidad == idUniversidad && x.IdUsuario == idUsuario).Select(x=>x.IdCarrera).FirstOrDefault();

            return GetMateriasByCarrera(idCarrera);
            
        }

    }
}
