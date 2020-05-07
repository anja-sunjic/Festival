using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Festival.Web.Helper
{
    public class Email
    {
        void SendEmail()
        {
            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress("account2@gmail.com", "Account2");
                emailMessage.To.Add(new MailAddress("account1@gmail.com", "Account1"));
                emailMessage.Subject = "SUBJECT";
                emailMessage.Body = "BODY";
                emailMessage.Priority = MailPriority.Normal;
                using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587))//or 465 if 587 is not working
                {
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential("account2@gmail.com", "password");
                    MailClient.Send(emailMessage);
                }
                //https://stackoverflow.com/questions/5336239/attach-a-file-from-memorystream-to-a-mailmessage-in-c-sharp
            }
        }
    }
}
