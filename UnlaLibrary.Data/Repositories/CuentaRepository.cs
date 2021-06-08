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
    public class CuentaRepository : ICuentaRepository
    {
        private readonly Library _Library;

        public CuentaRepository(Library Library)
        {
            _Library = Library;
        }

        public Usuario Get(int idUsuario)
        {
            return _Library.Usuario.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
        }

        public bool Edit(string email, string clave, int idUser)
        {
            try
            {
                var usuario = _Library.Usuario.Where(x => x.IdUsuario == idUser).FirstOrDefault();
                usuario.Email = email;
                usuario.Clave = clave;
                _Library.Usuario.Update(usuario);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
