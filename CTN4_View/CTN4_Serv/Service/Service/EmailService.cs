using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;

using MimeKit;


namespace CTN4_Serv.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task<string> SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();


                if (mailRequest.attachmentPaths != null)
                {
                    foreach (var attachmentFilePath in mailRequest.attachmentPaths)
                    {
                        var attachment = new MimePart()
                        {
                            Content = new MimeContent(System.IO.File.OpenRead(attachmentFilePath)),
                            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = System.IO.Path.GetFileName(attachmentFilePath)
                        };
                        builder.Attachments.Add(attachment);
                    }
                }
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                return email.ToString();

            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
