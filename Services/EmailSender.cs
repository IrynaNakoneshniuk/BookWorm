using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using UserSecrets;

namespace BookWorm.Services
{
    public class EmailSender
    {
        private readonly string? _smtpServer;
        private readonly int _smtpPort;
        private readonly bool _enableSsl;

        public EmailSender()
        {
            _smtpServer = "smtp.gmail.com";
            _smtpPort = 587;
            _enableSsl = true;
        }

        public async Task SendAsync(string ?to, string ?subject, string? body)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.EnableSsl = _enableSsl;
                client.Credentials = new NetworkCredential(Secrets.GmailLogin, Secrets.GmailAppPass);

                using (var message = new MailMessage(Secrets.GmailLogin, to, subject, body))
                {
                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
