using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace GiftGestion.Objetos
{
    public class Gmail
    {
        public void EnviarMails(List<Usuario> administradores, string asunto, string mensaje)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("");

            foreach (var user in administradores)
            {
                msg.To.Add(user.mail);
            }

            msg.Subject = asunto;
            msg.Body = mensaje;

            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential();
            networkCredential.UserName = "";
            networkCredential.Password = "";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkCredential;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}
