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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Library _Library;
        public UsuarioRepository(Library Library)
        {
            _Library = Library;
        }


        public List<Usuario> Get()
        {
            return _Library.Usuario.Select(x => x).Include(p => p.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Get(int idUsuario)
        {
            return _Library.Usuario.Where(x => x.IdUsuario == idUsuario).Include(p => p.IdTipoUsuarioNavigation).FirstOrDefault();
        }
        public List<TipoUsuario> GetTipoUsuario()
        {
            return _Library.TipoUsuario.ToList();
        }
        public bool Create(Usuario u)
        {
            try
            {
                _Library.Usuario.Add(u);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(Usuario u)
        {
            try
            {
                var user = _Library.Usuario.Where(x => x.IdUsuario == u.IdUsuario).FirstOrDefault();
                user.Apellido = u.Apellido;
                user.Clave = u.Clave;
                user.Dni = u.Dni;
                user.Email = u.Email;
                user.IdTipoUsuario = u.IdTipoUsuario;
                user.Nombre = u.Nombre;
                _Library.Usuario.Update(user);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = _Library.Usuario.Where(x => x.IdUsuario == id).FirstOrDefault();
                _Library.Usuario.Remove(user);
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
