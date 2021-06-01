using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.Data.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly Library _Library;

        public BibliotecaRepository(Library Library)
        {
            _Library = Library;
        }

        public bool ModificarFavoritos( int idUsuario, int idMaterial)
        {
            bool r = false;
            if (idMaterial != 0)
            {
                var exist = GetFavorito(idUsuario, idMaterial);
                if (exist == null)
                {
                    _Library.Favoritos.Add(new Favoritos { IdMaterial = idMaterial, IdUsuario = idUsuario });
                    r = true;
                }
                else
                {
                    _Library.Favoritos.Remove(exist);
                }
                _Library.SaveChanges();
            }
            return r;
        }

        public Favoritos GetFavorito(int idUsuario, int idMaterial)
        {
            Favoritos f = null;
            f = _Library.Favoritos.Find(idUsuario, idMaterial);
            return f;

        }

        public List<MaterialEstudio> GetBiblioteca(int idusuario)
        {

            var lista = (from F in _Library.Favoritos
                         join ME in _Library.MaterialEstudio on
                         new
                         {
                             Key1 =F.IdMaterial,
                             Key2 = F.IdUsuario
                         } equals 
                         new
                         {
                             Key1 = ME.IdMaterial,
                             Key2 = idusuario
                         }
                         join I in _Library.Idioma on ME.IdIdioma equals I.IdIdioma
                         join M in _Library.Materia on ME.IdMateria equals M.IdMateria
                         select 
                         new MaterialEstudio
                         {
                          IdMaterial = ME.IdMaterial,
                          Titulo = ME.Titulo,
                          Descripcion = ME.Descripcion,
                          Autor = ME.Autor,
                          Prologo = ME.Prologo,
                          Archivo = ME.Archivo,
                          Miniatura = ME.Miniatura,
                          IdIdioma = ME.IdIdioma,
                          IdIdiomaNavigation = ME.IdIdiomaNavigation,
                          IdMateria = ME.IdMateria,
                          IdMateriaNavigation = ME.IdMateriaNavigation,
                          IdUniversidad = ME.IdUniversidad,
                          IdUniversidadNavigation = ME.IdUniversidadNavigation,
                          TipoArchivo = ME.TipoArchivo,

                        //   FUser = F.IdUsuario,
                             
                         }
                        )//.Where(x=>x.FUser == idusuario)
                        .ToList();

            return lista;
        }

    }
}
