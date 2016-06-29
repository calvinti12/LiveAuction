using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace UtilityLayer
{
    public class Mail
    {

        public static int ShootMail(string Tomail, string from, string sub, string MsgBody)
        {
            try
            {

                string sMailTo = Tomail;
                string sMailFrom = from;
                string ssubject = sub;

                string sBody = MsgBody;
                MailMessage mailObj = new System.Net.Mail.MailMessage();

                mailObj.From = new MailAddress(sMailFrom,"ABP Admin");
                mailObj.To.Add(new MailAddress(sMailTo));
                mailObj.Subject = ssubject;
                mailObj.Body = sBody;
                mailObj.IsBodyHtml = true;

                mailObj.Priority = MailPriority.High;
                SmtpClient SMTPClient = new SmtpClient(System.Configuration.ConfigurationSettings.AppSettings["SMTPHost"].ToString(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SMTPPort"]));
                SMTPClient.EnableSsl = true;
                SMTPClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["AdminEmailID"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["AdminEmailIDPassword"].ToString());
                SMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                SMTPClient.Send(mailObj);
                return 1;

            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public static int ShootMailWithCC(string Tomail, string from, string sub, string MsgBody, string CC)
        {
            try
            {

                string sMailTo = Tomail;
                string sMailFrom = from;
                string ssubject = sub;

                string sBody = MsgBody;
                MailMessage mailObj = new System.Net.Mail.MailMessage();

                mailObj.From = new MailAddress(sMailFrom);
                mailObj.To.Add(new MailAddress(sMailTo));
                mailObj.Subject = ssubject;
                mailObj.Body = sBody;
                mailObj.IsBodyHtml = true;

                mailObj.Priority = MailPriority.High;
                SmtpClient SMTPClient = new SmtpClient(System.Configuration.ConfigurationSettings.AppSettings["SMTPHost"].ToString(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SMTPPort"]));
                SMTPClient.EnableSsl = true;
                SMTPClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["AdminEmailID"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["AdminEmailIDPassword"].ToString());
                mailObj.CC.Add(new MailAddress(CC)); 
                SMTPClient.Send(mailObj);
                return 1;

            }
            catch (Exception ex)
            {
                return -1;
            }

        }

    }
}
