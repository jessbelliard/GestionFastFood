using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GestionFastFood.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task EnviarCorreoAsync(string destinatario, string asunto, string mensaje)
        {
            var emailSettings = _configuration.GetSection("EmailSetting");
            var smtpClient = new SmtpClient(emailSettings["SmtPort"])
            {
                Port = int.Parse(emailSettings["SmtPort"]),
                Credentials = new NetworkCredential(emailSettings["SenderEmail"], emailSettings["SenderPassword"]),
                EnableSsl = true,

            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["SenderEmail"], emailSettings["SenderName"]),
                Subject = asunto,
                Body = mensaje,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(destinatario);

            await smtpClient.SendMailAsync(mailMessage);
           
        }
    }
}
