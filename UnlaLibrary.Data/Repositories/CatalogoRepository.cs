using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using System.Linq;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.Data.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly Library _Library;
        public CatalogoRepository(Library Library)
        {
            _Library = Library;
        }
        //from I in _Library.Idiomas 
        //join ME in _Library.MaterialEstudios on I.IdIdioma equals ME.Idioma
        //join M in _Library.Materia on ME.Materia equals M.Materia
        public List<MaterialEstudio> GetCatalogo()
        {
            var catalogo =(

                           from ME in _Library.MaterialEstudios
                              join I in _Library.Idiomas on ME.Idioma equals I.IdIdioma
                              join M in _Library.Materia on ME.Materia equals M.IdMateria
                              select
                              new MaterialEstudio
                              {
                                  Descripcion = ME.Descripcion,
                                  IdMateriaEstudio = ME.IdMateriaEstudio,
                                  IdiomaNavigation = ME.IdiomaNavigation,
                                  MateriaNavigation = ME.MateriaNavigation,
                                  Materia = ME.Materia,
                                  Idioma = ME.Idioma,
                                  Titulo = ME.Titulo
                              }).ToList();
            return catalogo;
        }

    }
}
