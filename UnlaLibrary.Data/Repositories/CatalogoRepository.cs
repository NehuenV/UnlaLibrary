using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using System.Linq;
using UnlaLibrary.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace UnlaLibrary.Data.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly Library _Library;
        public CatalogoRepository(Library Library)
        {
            _Library = Library;
        }
        public List<MaterialEstudio> GetCatalogo(int idusuario)
        {
            var catalogo = _Library.MaterialEstudio
                .Include(p => p.IdIdiomaNavigation)
                .Include(p => p.IdMateriaNavigation)
                .Where(x =>
                  _Library.UsuarioMateria.Where(y => y.IdUsuario == idusuario).Select(z => z.IdMateria).Contains(x.IdMateria) 
                    &&
                  _Library.UsuarioCarreraUniversidad.Where(a => a.IdUsuario == idusuario).Select(z => z.IdUniversidad).Contains(x.IdUniversidad)
                  )
                .ToList();
            return catalogo;
        }
        public List<MaterialEstudio> GetCatalogo(string texto, int idusuario)
        {
            var catalogo = _Library.MaterialEstudio
               .Include(p => p.IdIdiomaNavigation)
               .Include(p => p.IdMateriaNavigation)
               .Where(x =>
                 _Library.UsuarioMateria.Where(y => y.IdUsuario == idusuario).Select(z => z.IdMateria).Contains(x.IdMateria)
                   &&
                 _Library.UsuarioCarreraUniversidad.Where(a => a.IdUsuario == idusuario).Select(z => z.IdUniversidad).Contains(x.IdUniversidad)
                 && ( x.Titulo.Contains(texto) || x.Descripcion.Contains(texto) || x.Autor.Contains(texto))
                 )
               .ToList();
            return catalogo;
        }

        public MaterialEstudio GetMaterial(int id)
        {
            return _Library.MaterialEstudio
                .Include(p => p.IdMateriaNavigation)
                .Include(p=> p.IdIdiomaNavigation)
                .Where(x => x.IdMaterial==id).FirstOrDefault();
        }

    }
}
