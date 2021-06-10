using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using UnlaLibrary.Data.Context;
using UnlaLibrary.Data.Entities;
using UnlaLibrary.Data.Interface;

namespace UnlaLibrary.Data.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly Library _Library;

        public CuentaRepository(Library Library)
        {
            _Library = Library;
        }

        public Usuario Get(int idUsuario)
        {
            return _Library.Usuario.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
        }

        public bool Edit(string email, string clave, int idUser)
        {
            try
            {
                var usuario = _Library.Usuario.Where(x => x.IdUsuario == idUser).FirstOrDefault();
                usuario.Email = email;
                usuario.Clave = clave;
                _Library.Usuario.Update(usuario);
                _Library.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void RecuperarClave (string email)
        {
            var user = _Library.Usuario.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                enviarCorreo(email, user.Clave);
            }
        }
    
        public String enviarCorreo( string email,string clave)
        {
            MailMessage myMessage = new MailMessage("",//from
                "", //to
                "Contraseña UnlaLibrary", 
                "su contraseña actual es: " + clave
                );
            try
            {
                SmtpClient client = new SmtpClient 
                { 
                    Host = "smtp.gmail.com", 
                    
                    //Port = 587, 
                    EnableSsl =true, 
                    UseDefaultCredentials = false, 
                    Credentials = new System.Net.NetworkCredential("", "") //usuario contraseña
                //    DeliveryMethod = SmtpDeliveryMethod.Network 
                };

                client.Send(myMessage);
            }
            catch (System.Exception ex)
            {
                //_retorno = "Error al enviar mail aviso: " + ex.Message;
            }

            return "XD";

        }

    }
}
