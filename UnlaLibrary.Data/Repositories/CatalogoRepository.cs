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
        public List<MaterialEstudio> GetCatalogo(int idusuario, string texto, int idmateria)
        {
            var catalogo = _Library.MaterialEstudio
                .Include(p => p.IdIdiomaNavigation)
                .Include(p => p.IdMateriaNavigation)
                .Where(x =>
                  _Library.UsuarioMateria.Where(y => y.IdUsuario == idusuario).Select(z => z.IdMateria).Contains(x.IdMateria)
                    &&
                  _Library.UsuarioCarreraUniversidad.Where(a => a.IdUsuario == idusuario).Select(z => z.IdUniversidad).Contains(x.IdUniversidad)
                  &&
                  (idmateria == 0 || x.IdMateria == idmateria)
                  &&
                  (texto == null || (x.Titulo.Contains(texto) || x.Descripcion.Contains(texto) || x.Autor.Contains(texto)))
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

        public List<Materia> GetMaterias(int idusuario)
        {
            var materias = (

                           from MA in _Library.Materia
                           join UM in _Library.UsuarioMateria on MA.IdMateria equals UM.IdMateria
                           where UM.IdUsuario == idusuario
                           select
                           new Materia
                           {
                               IdMateria = MA.IdMateria,
                               Materia1 = MA.Materia1
                           }).ToList();
            return materias;
        }

    }
}
