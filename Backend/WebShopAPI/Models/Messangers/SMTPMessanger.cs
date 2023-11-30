using System.Net;
using System.Net.Mail;

namespace WebShopAPI.Models.Messangers
{
    public sealed class SMTPMessanger : IMessanger
    {
        private readonly SMTPData _data;

        public SMTPMessanger(IConfiguration config)
            : this(SMTPData.FromConfig(config, null, messageData: ("НОВЫЙ ЗАКАЗ", null))) { }

        public SMTPMessanger(SMTPData data) => _data = data;

        public sealed class SMTPData
        {
            public readonly string host;
            public readonly int port;
            public readonly string from;
            public readonly string to;
            public readonly string? displayName;
            public readonly (string subject, string? body) messageData;
            public readonly NetworkCredential credential;

            public SMTPData(string host,
                            int port,
                            string from,
                            string to,
                            NetworkCredential credential,
                            string? displayName,
                            (string subject, string? body) messageData)
            {
                this.host = host;
                this.port = port;
                this.from = from;
                this.to = to;
                this.displayName = displayName;
                this.messageData = messageData;
                this.credential = credential;
            }

            public static SMTPData FromConfig(IConfiguration config, string? displayName, (string subject, string? body) messageData)
            {
                IConfigurationSection smtp = config.GetSection("SMTP");
                IConfigurationSection credential = smtp.GetSection("Credential");

                SMTPData data = new SMTPData(
                    host: smtp.GetValue<string>("host")!,
                    port: smtp.GetValue<int>("port"),
                    from: smtp.GetValue<string>("sender")!,
                    to: smtp.GetValue<string>("target")!,
                    credential: new NetworkCredential(credential.GetValue<string>("name"), credential.GetValue<string>("password")),
                    displayName, messageData);

                return data;
            }
        }

        public event Action<(bool hasErrors, object? errors)>? Callback;

        public async Task SendAsync(string data, CancellationToken token)
        {
            MailAddress from = new MailAddress(_data.from, _data.displayName);
            MailAddress to = new MailAddress(_data.to);

            using (MailMessage message = new MailMessage(from, to))
            {
                message.Subject = _data.messageData.subject;
                message.Body = _data.messageData.body ?? data;

                message.IsBodyHtml = false;

                SmtpClient client = new SmtpClient(_data.host, _data.port)
                {
                    Credentials = _data.credential,
                    EnableSsl = true
                };
                
                client.SendCompleted += (sender, e) =>
                {
                    bool hasErrors = e.Error != null;
                    Callback?.Invoke((hasErrors, e.Error));
                };
                
                try
                {
                    await client.SendMailAsync(message, token);
                }
                finally
                {
                    client.Dispose();
                }
            }
        }
    }
}
