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
        public List<MaterialEstudio> GetCatalogo(int idusuario, string texto, int idmateria, int[] idiomas, string[] tipos = null)
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
                  &&
                  (idiomas[0] == 0 || idiomas.Contains(x.IdIdioma))
                  &&
                  (tipos[0] == "TODOS" || tipos.Contains(x.TipoArchivo))
                  )
                .Select(x => new MaterialEstudio {IdUniversidad= x.IdUniversidad,IdMateriaNavigation=x.IdMateriaNavigation,IdMateria=x.IdMateria,IdIdioma=x.IdIdioma,IdIdiomaNavigation=x.IdIdiomaNavigation,TipoArchivo=x.TipoArchivo,Titulo=x.Titulo, Autor=x.Autor,Descripcion=x.Descripcion ,Miniatura = x.Miniatura, IdMaterial = x.IdMaterial })
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

        public bool CambiarReseña(Reseña reseña)
        {
            bool flag = false;
            var r = GetReseña(reseña.IdMaterial,reseña.IdUsuario);
            if (r == null)
            {
                _Library.Reseña.Add(reseña);
                flag = true;
            }
            else
            {
                r.Comentario = reseña.Comentario;
                r.Puntuacion = reseña.Puntuacion;
                _Library.Reseña.Update(r);
                flag = true;
            }
            _Library.SaveChanges();
            return flag;
        }

        public List<Reseña> GetAllReseñas(int IdMaterial, int iduser)
        {
            return _Library.Reseña
                .Include(p => p.IdUsuarioNavigation)
                .Where(x=>x.IdMaterial==IdMaterial && x.IdUsuario != iduser).ToList();
        }
        public Reseña GetReseña( int IdMaterial, int IdUsuario)
        {
            Reseña r = null;
            var exist = _Library.Reseña.Include(x => x.IdUsuarioNavigation).Where(x => x.IdMaterial == IdMaterial && x.IdUsuario == IdUsuario).FirstOrDefault();
            if(exist!=null)
                r = _Library.Reseña.Find(exist.IdReseña);
            return r;
        }

    }
}
