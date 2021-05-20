using System;
using System.Collections.Generic;

#nullable disable

namespace UnlaLibrary.Data.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            MaterialEstudio = new HashSet<MaterialEstudio>();
            Reseña = new HashSet<Reseña>();
            UsuarioCarreraUniversidad = new HashSet<UsuarioCarreraUniversidad>();
            UsuarioMateria = new HashSet<UsuarioMateria>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<MaterialEstudio> MaterialEstudio { get; set; }
        public virtual ICollection<Reseña> Reseña { get; set; }
        public virtual ICollection<UsuarioCarreraUniversidad> UsuarioCarreraUniversidad { get; set; }
        public virtual ICollection<UsuarioMateria> UsuarioMateria { get; set; }
    }
}
