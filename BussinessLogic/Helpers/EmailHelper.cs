using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Helpers
{
    public interface IEmailHelper
    {
        Task<bool> SendEmail(string Email, string Content);
    }
    public class EmailHelper: IEmailHelper
    {
        public async Task<bool> SendEmail(string Email,string Content)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("sendingEmail");
                //Recieving email
                message.To.Add(Email);
                message.Subject = "Just wash activation Email";
                string Design = Content;
                message.Body = string.Format(Design);
                message.IsBodyHtml = true;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("sendingEmail", "password");
                client.Send(message);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
