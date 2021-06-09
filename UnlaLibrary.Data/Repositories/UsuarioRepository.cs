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

        public List<Usuario> GetUsuariosAgregados(int idUniversidad, int idCarrera)
        {
            return _Library.UsuarioCarreraUniversidad
                            .Include(x => x.IdUsuarioNavigation)
                            .Where(x => x.IdUniversidad == idUniversidad && x.IdCarrera == idCarrera)
                            .Select(x => x.IdUsuarioNavigation)
                            .ToList();
        }

        public List<Usuario> GetUsuariosNoAgregados(int idUniversidad, int idCarrera)
        {
            var usuariosAgregados = GetUsuariosAgregados(idUniversidad, idCarrera);
            var usuarios = _Library.Usuario
                .Where(x => x.IdTipoUsuario != 3 && !usuariosAgregados.Contains(x))
                .ToList();
            return usuarios;
        }
        public bool modificarUsuarioCarreraUniversidad(int idUniversidad, int idCarrera, int idUsuario)
        {
            try
            {
                var ucu = _Library.UsuarioCarreraUniversidad
                    .Where(x => x.IdCarrera == idCarrera && x.IdUniversidad == idUniversidad && x.IdUsuario == idUsuario)
                    .FirstOrDefault();
                if (ucu == null)
                {
                    var nuevo = new UsuarioCarreraUniversidad
                    {
                        IdCarrera = idCarrera,
                        IdUniversidad = idUniversidad,
                        IdUsuario = idUsuario
                    };
                    _Library.UsuarioCarreraUniversidad.Add(nuevo);
                }
                else
                {
                    _Library.UsuarioCarreraUniversidad.Remove(ucu);
                }
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
