using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICuentaRepository
    {
        //bool Agregar(string nombre);
        Usuario Get(int idUsuario);
        bool Edit(string email, string clave, int iduser);
    }
}
