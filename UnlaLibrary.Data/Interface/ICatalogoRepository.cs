using System;
using System.Collections.Generic;
using System.Text;
using UnlaLibrary.Data.Entities;

namespace UnlaLibrary.Data.Interface
{
    public interface ICatalogoRepository
    {
        List<MaterialEstudio> GetCatalogo(int idusuario, string texto, int idmateria, int[] idiomas, string[] tipos);
        MaterialEstudio GetMaterial(int id);
        List<Materia> GetMaterias(int idusuario);
        bool CambiarReseña(Reseña reseña);
        List<Reseña> GetAllReseñas(int IdMaterial, int iduser);
        Reseña GetReseña(int IdMaterial, int IdUsuario);

    }
}
