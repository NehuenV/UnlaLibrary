using System;
using System.Collections.Generic;
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

        public bool ModificarFavoritos(int idMaterial, int idUsuario)
        {
            bool r = false;
            var exist = _Library.Favoritos.Find(idMaterial, idUsuario); ;/// GetFavorito(idMaterial,idUsuario);
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
            return r;
        }

        public Favoritos GetFavorito(int idMaterial, int idUsuario)
        {
            Favoritos f = null;
            f = _Library.Favoritos.Find(idMaterial, idUsuario);
            return f;

        }

    }
}
