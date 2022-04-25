using System;
using System.Net.Mail;
using System.Text;

namespace Pastelaria.Domain.Infra
{
    public class DisparoEmailService
    {

      
        public static void SendEmail(string destinatario, string mensagem, string titulo)
        {
            MailMessage mailMessage = new MailMessage("projeto.pastelaria@gmail.com", destinatario);
            mailMessage.Subject = titulo;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<h3>"+mensagem+"</h3>";
            mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");


            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("projeto.pastelaria@gmail.com", "projpast1100");

                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
