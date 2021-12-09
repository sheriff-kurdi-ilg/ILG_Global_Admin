using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Services
{
    public class MailService
    {
        private IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Send(string sendTo, string subject, string body)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(configuration["Email:EmailAddress"]);
            message.To.Add(sendTo);
            message.Subject = subject;
            message.Body = body;


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(configuration["Email:EmailAddress"], configuration["Email:EmailPassword"]);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }
        }

        public void Send(string sendTo, string subject, string body, Attachment oAttachment)
        { 
            MailMessage message = new MailMessage();

            message.From = new MailAddress(configuration["Email:EmailAddress"]);
            message.To.Add(sendTo);
            message.Subject = subject;
            message.Body = body;
            message.Attachments.Add(oAttachment);

            using (SmtpClient client = new SmtpClient())
            {
                
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(configuration["Email:EmailAddress"], configuration["Email:EmailPassword"]);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }
        }
    }
}
