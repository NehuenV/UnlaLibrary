using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface IBibliotecaRepository
    {
        bool ModificarFavoritos(int idMaterial, int idUsuario);
        Favoritos GetFavorito(int idMaterial, int idUsuario);
        List<MaterialEstudio> GetBiblioteca(int idusuario);
    }
}
