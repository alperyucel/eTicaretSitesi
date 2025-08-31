using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Core.Utility
{
    public class EmailService
    {
        IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool SendEmail(string message, string subject, bool IsBodyHtml = true, params string[] emailAddresses)
        {

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Port = int.Parse(configuration["Email:port"].ToString());
            smtpClient.Host = configuration.GetSection("Email:host").Value;
            smtpClient.EnableSsl = bool.Parse(configuration.GetSection("Email:enableSsl").Value);

            string fromEmail = configuration.GetSection("Email:emailAddress").Value;
            string password = configuration.GetSection("Email:password").Value;

            smtpClient.Credentials = new NetworkCredential(fromEmail, password);

            try
            {
                for (int i = 0; i < emailAddresses.Length; i++)
                {
                    MailMessage mailMessage = new MailMessage(fromEmail, emailAddresses[i], subject, message);

                    mailMessage.IsBodyHtml = IsBodyHtml;
                    mailMessage.SubjectEncoding = Encoding.UTF8;

                    smtpClient.Send(mailMessage);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SendEmail(string message, string subject, byte[] file, bool IsBodyHtml = true, params string[] emailAddresses)
        {

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Port = int.Parse(configuration["Email:port"].ToString());
            smtpClient.Host = configuration.GetSection("Email:host").Value;
            smtpClient.EnableSsl = bool.Parse(configuration.GetSection("Email:enableSsl").Value);


            string fromEmail = configuration.GetSection("Email:emailAddress").Value;
            string password = configuration.GetSection("Email:password").Value;


            smtpClient.Credentials = new NetworkCredential(fromEmail, password);

            MemoryStream ms = new MemoryStream(file);

            try
            {
                for (int i = 0; i < emailAddresses.Length; i++)
                {
                    MailMessage mailMessage = new MailMessage(fromEmail, emailAddresses[i], subject, message);

                    mailMessage.IsBodyHtml = IsBodyHtml;
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.Attachments.Add(new Attachment(ms, "invoice.pdf", "application/octet-stream"));

                    smtpClient.Send(mailMessage);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
