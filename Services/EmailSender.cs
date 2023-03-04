using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace BookWorm.Services
{
    public class EmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly bool _enableSsl;
        private readonly string _username;
        private readonly string _password;

        public EmailSender(string smtpServer, int smtpPort, bool enableSsl, string username, string password)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _enableSsl = enableSsl;
            _username = username;
            _password = password;
        }

        public async Task SendAsync(string from, string to, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.EnableSsl = _enableSsl;
                client.Credentials = new NetworkCredential("nakonirina1996@gmail.com", "wtmdcuhrkmytkzkk");

                using (var message = new MailMessage(from, to, subject, body))
                {
                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
