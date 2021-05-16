using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Interfaces;

namespace UnlaLibrary.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly Library _Library;
        public AuthenticationRepository(Library Library)
        {
            _Library = Library;
        }
        public void Authentication()
        {
            string esto = "prueba ";
        }

    }
}
