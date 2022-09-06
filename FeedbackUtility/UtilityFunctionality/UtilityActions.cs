using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeedbackUtility.UtilityFunctionality
{
    public class UtilityActions
    {
        public static void SendEmail(string to, string from, string msgBody, string subject)
        {
            try
            {
                MailMessage message = new MailMessage(from, to);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = msgBody; 

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;

                NetworkCredential NetworkCred = new NetworkCredential("Type_Here_From_GMAIL_ID", "Type_Here_Password");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
               
                smtp.Send(message);
            }
            catch(Exception ex)
            {

            }
        }

    }
}
