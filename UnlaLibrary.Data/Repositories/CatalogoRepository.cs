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

                           from ME in _Library.MaterialEstudio
                              join I in _Library.Idioma on ME.IdIdioma equals I.IdIdioma
                              join M in _Library.Materia on ME.IdMateria equals M.IdMateria
                              select
                              new MaterialEstudio
                              {
                                  Descripcion = ME.Descripcion,
                                  Archivo = ME.Archivo,
                                  Autor = ME.Autor,
                                  Prologo= ME.Prologo,
                                  Reseña = ME.Reseña,
                                  Miniatura = ME.Miniatura,
                                  IdIdioma = I.IdIdioma,
                                  IdMateria= M.IdMateria,
                                  IdMaterial = ME.IdMaterial,
                                  IdIdiomaNavigation = ME.IdIdiomaNavigation,
                                  IdMateriaNavigation = ME.IdMateriaNavigation,
                                  Titulo = ME.Titulo
                              }).ToList();
            return catalogo;
        }
        public List<MaterialEstudio> GetCatalogo(string texto)
        {
            var catalogo = (

                           from ME in _Library.MaterialEstudio
                           join I in _Library.Idioma on ME.IdIdioma equals I.IdIdioma
                           join M in _Library.Materia on ME.IdMateria equals M.IdMateria
                           where ME.Titulo.Contains(texto) || ME.Descripcion.Contains(texto) || ME.Autor.Contains(texto)
                           select
                           new MaterialEstudio
                           {
                               Descripcion = ME.Descripcion,
                               Archivo = ME.Archivo,
                               Autor = ME.Autor,
                               Prologo = ME.Prologo,
                               Reseña = ME.Reseña,
                               Miniatura = ME.Miniatura,
                               IdIdioma = I.IdIdioma,
                               IdMateria = M.IdMateria,
                               IdMaterial = ME.IdMaterial,
                               IdIdiomaNavigation = ME.IdIdiomaNavigation,
                               IdMateriaNavigation = ME.IdMateriaNavigation,
                               Titulo = ME.Titulo
                           }).ToList();
            return catalogo;
        }
        public MaterialEstudio GetMaterial(int id)
        {
            return _Library.MaterialEstudio.Where(x => x.IdMaterial==id).FirstOrDefault();
        }

    }
}
