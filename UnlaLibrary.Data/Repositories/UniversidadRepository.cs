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
    public class UniversidadRepository : IUniversidadRepository
    {
        private readonly Library _Library;

        public UniversidadRepository(Library Library)
        {
            _Library = Library;
        }

        public List<Universidad> Get()
        {
            return _Library.Universidad.Select(x => x).ToList();
        }

        public Universidad Get(int idUniversidad)
        {
            return _Library.Universidad.Where(x => x.IdUniversidad == idUniversidad).FirstOrDefault();
        }

        public bool Create(Universidad u)
        {
            try
            {
                var universidad = new Universidad
                {
                    NombreUniversidad = u.NombreUniversidad
                };
                _Library.Universidad.Add(universidad);
                _Library.SaveChanges();
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(Universidad u)
        {
            try
            {
                var uni = _Library.Universidad.Where(x => x.IdUniversidad == u.IdUniversidad).FirstOrDefault();
                uni.NombreUniversidad = u.NombreUniversidad;
                _Library.Universidad.Update(uni);
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
                var uni = _Library.Universidad.Where(x => x.IdUniversidad == id).FirstOrDefault();
                _Library.Universidad.Remove(uni);
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
