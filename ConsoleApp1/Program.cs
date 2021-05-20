using ConsoleApp1.Context;
using System;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
         static void Main(string[] args)
        {
           using(var c = new Library())
            {
                string path1 = Directory.GetCurrentDirectory();
                var n = path1.IndexOf("\\ConsoleApp1\\bin\\Debug\\netcoreapp3.1");
                string dir = path1.Substring(0, n);

                Byte[] bytes = File.ReadAllBytes(string.Format("{0}\\kernighan-and-ritchie.pdf",dir));
                String file = Convert.ToBase64String(bytes);
                Byte[] bytesP = File.ReadAllBytes(string.Format("{0}\\portada.png",dir));
                //c.MaterialEstudio.Add(new Entities.MaterialEstudio {Titulo = "Fundamentos de programación",  Descripcion = "descripcion 1",Prologo ="prologo1", Autor="autor 1", IdIdioma=1,IdUsuario=3, IdMateria=1,IdUniversidad=1,Archivo =bytes, Miniatura=bytesP });
                c.MaterialEstudio.Add(new Entities.MaterialEstudio { Titulo = "Fundamentos de programación 2", Descripcion = "descripcion 2", Prologo = "prologo1", Autor = "autor 1", IdIdioma = 1, IdUsuario = 3, IdMateria = 1, IdUniversidad = 1, Archivo = bytes, Miniatura = bytesP });
                c.MaterialEstudio.Add(new Entities.MaterialEstudio { Titulo = "Database Programming", Descripcion = "description in english", Prologo = "prologo1", Autor = "autor 1", IdIdioma = 1, IdUsuario = 3, IdMateria = 1, IdUniversidad = 1, Archivo = bytes, Miniatura = bytesP });
                c.MaterialEstudio.Add(new Entities.MaterialEstudio { Titulo = "Matematica basica", Descripcion = "descripcion matematica basica", Prologo = "prologo1", Autor = "autor 1", IdIdioma = 2, IdUsuario = 4, IdMateria = 1, IdUniversidad = 2, Archivo = bytes, Miniatura = bytesP });
                c.MaterialEstudio.Add(new Entities.MaterialEstudio { Titulo = "Matematica basica 2", Descripcion = "descripcion matematica basica 2", Prologo = "prologo1", Autor = "autor 1", IdIdioma = 2, IdUsuario = 4, IdMateria = 1, IdUniversidad = 2, Archivo = bytes, Miniatura = bytesP });
                c.MaterialEstudio.Add(new Entities.MaterialEstudio { Titulo = "Fisica básica", Descripcion = "descripcion fisica basica", Prologo = "prologo1", Autor = "autor 1", IdIdioma = 2, IdUsuario = 4, IdMateria = 1, IdUniversidad = 2, Archivo = bytes, Miniatura = bytesP });

                c.SaveChanges();
                
            }

        }
    }
}
