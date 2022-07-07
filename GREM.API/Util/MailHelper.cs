using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mime;

namespace GREM.API.Util
{
    public static class MailHelper
    {
        public static void Send(string title, string body, string to)
        {
            MailMessage mail = new MailMessage();

            
            mail.To.Add(to);
            mail.IsBodyHtml = true;
            mail.Subject = title;
            mail.Body = body;

            ContentType mime = new System.Net.Mime.ContentType("text/html");
            AlternateView vw = AlternateView.CreateAlternateViewFromString(mail.Body, mime);
            mail.AlternateViews.Add(vw);

            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"], int.Parse(ConfigurationManager.AppSettings["smtpPort"]));

            if(ConfigurationManager.AppSettings["ambiente"] == "DEV")
            {

                mail.From = new MailAddress("fabiene.amoreira@ternium.com.br");
                smtp.Credentials = new System.Net.NetworkCredential("fabiene.amoreira@ternium.com.br", "tHor1306..");
            }
            else
            {
                mail.From = new MailAddress(ConfigurationManager.AppSettings["mail"]);
            }
           // smtp.Credentials = new System.Net.NetworkCredential("fabiene.amoreira@ternium.com.br", "tHor1306..");
            smtp.Send(mail);
            
            //SmtpServer.EnableSsl = true;
            //SmtpServer.Send(mail);
        }
    }
}