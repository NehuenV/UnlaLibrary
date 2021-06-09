using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface IUsuarioRepository
    {
        Usuario Get(int idUniversidad);
        List<Usuario> Get();
        bool Create(Usuario universidad);
        bool Edit(Usuario u);
        bool Delete(int id);
        List<TipoUsuario> GetTipoUsuario();
        List<Usuario> GetUsuariosAgregados(int idUniversidad, int idCarrera);
        List<Usuario> GetUsuariosNoAgregados(int idUniversidad, int idCarrera);
        bool modificarUsuarioCarreraUniversidad(int idUniversidad, int idCarrera, int idUsuario);
    }
}
