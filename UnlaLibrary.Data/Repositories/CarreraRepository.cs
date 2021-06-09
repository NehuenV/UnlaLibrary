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
    public class CarreraRepository : ICarreraRepository
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
                var carrera = _Library.Carrera.Where(x => x.IdCarrera == c.IdCarrera).FirstOrDefault();
                carrera.Carrera1 = c.Carrera1;
                _Library.Carrera.Update(carrera);
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
                var carrera = _Library.Carrera.Where(x => x.IdCarrera == id).FirstOrDefault();
                _Library.Carrera.Remove(carrera);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Materia> GetMateriasActuales(int idCarrera)
        {
			return _Library.CarreraMateria
				.Include(x => x.IdMateriaNavigation)
				.Where(x => x.IdCarrera == idCarrera)
				.Select(x => x.IdMateriaNavigation)
				.OrderBy(x => x.Materia1)
				.ToList();
		}

        public List<Materia> GetMateriasRestantes(int idCarrera)
        {
            var materiasActualesIndex = GetMateriasActuales(idCarrera).Select(x => x.IdMateria).ToList();
            var materias = _Library.Materia.Select(x => x).OrderBy(x => x.Materia1);
            var materiasRestantes = materias.Where(x => !materiasActualesIndex.Contains(x.IdMateria)).ToList();
            return materiasRestantes;
        }
        public bool modificarMateriaCarrera(int idCarrera, int idMateria)
        {
            try
            {
                var materiaCarrera = _Library.CarreraMateria
                    .Where(x => x.IdCarrera == idCarrera && x.IdMateria == idMateria)
                    .FirstOrDefault();
                if (materiaCarrera == null)
                {
                    var nuevo = new CarreraMateria
                    {
                        IdCarrera = idCarrera,
                        IdMateria = idMateria
                    };
                    _Library.CarreraMateria.Add(nuevo);
                }
                else
                {
                    _Library.CarreraMateria.Remove(materiaCarrera);
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
