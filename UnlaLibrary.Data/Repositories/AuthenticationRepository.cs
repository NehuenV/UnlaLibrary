using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Interfaces;
using UnlaLibrary.Data.Models;
using System.Linq;
using System.IO;

namespace UnlaLibrary.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly Library _Library;
        public AuthenticationRepository(Library Library)
        {
            _Library = Library;
        }
        public bool Authentication(Login login)
        {
            var user = _Library.Usuario.Where(x => x.Email == login.email && x.Clave == login.password).ToList();
            if(user.Any())
            {
                if (user.Where(x=>x.Email==login.email && x.Clave == login.password).Any())
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }
        public string GetName(Login login)
        {
        //   
            var user = _Library.Usuario.Where(x => x.Email == login.email && x.Clave == login.password).Select(x => x.Nombre).FirstOrDefault();
            return user;
        }

    }
}
