using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.Data.Repositories
{
    public class CarreraRepository :ICarreraRepository
    {
        private readonly Library _Library;
        public CarreraRepository(Library Library)
        {
            _Library = Library;
        }

        public List<Carrera> Get()
        {
            return _Library.Carrera.Select(x => x).ToList();
        }

        public Carrera Get(int idCarrera)
        {
            return _Library.Carrera.Where(x => x.IdCarrera == idCarrera).FirstOrDefault();
        }

        public bool Create(Carrera c)
        {
            try
            {
                var carrera = new Carrera
                {
                    Carrera1 = c.Carrera1
                };
                _Library.Carrera.Add(carrera);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(Carrera c)
        {
            try
            {
                var uni = _Library.Carrera.Where(x => x.IdCarrera == c.IdCarrera).FirstOrDefault();
                uni.Carrera1 = c.Carrera1;
                _Library.Carrera.Update(uni);
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
                var uni = _Library.Carrera.Where(x => x.IdCarrera == id).FirstOrDefault();
                _Library.Carrera.Remove(uni);
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
