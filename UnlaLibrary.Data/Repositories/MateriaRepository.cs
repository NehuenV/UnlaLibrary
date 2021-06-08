using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.Data.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly Library _Library;
        public MateriaRepository(Library Library)
        {
            _Library = Library;
        }

        public List<Materia> Get()
        {
            return _Library.Materia.Select(x => x).ToList();
        }

        public Materia Get(int idMateria)
        {
            return _Library.Materia.Where(x => x.IdMateria == idMateria).FirstOrDefault();
        }

        public bool Create(Materia m)
        {
            try
            {
                var materia = new Materia
                {
                    Materia1 = m.Materia1
                };
                _Library.Materia.Add(materia);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(Materia m)
        {
            try
            {
                var mat = _Library.Materia.Where(x => x.IdMateria == m.IdMateria).FirstOrDefault();
                mat.Materia1 = m.Materia1;
                _Library.Materia.Update(mat);
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
                var mat = _Library.Materia.Where(x => x.IdMateria == id).FirstOrDefault();
                _Library.Materia.Remove(mat);
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
