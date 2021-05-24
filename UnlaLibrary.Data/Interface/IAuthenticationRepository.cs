using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Models;

namespace UnlaLibrary.Data.Interfaces
{
    public interface IAuthenticationRepository
    {
        bool Authentication(Login login);
        string GetName(Login login);
        public int GetId(Login login);
        public int GetIdTipoDeUsuario(Login login);
    }
}
