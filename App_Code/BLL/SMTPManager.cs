using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// SMTPManager 服务器用于控制邮件发送
/// </summary>


public class SMTPManager  
{
    public SMTPManager()
    {
    }
    public  void SendEmail(string FROM, string FromDisplayName, string TO, string BODY, string SUBJECT, bool bIsHtml)
    {
        MailMessage m = new MailMessage();
        m.From = new MailAddress(FROM, FromDisplayName);
        m.To.Add(TO);
        m.Subject = SUBJECT;
        m.Body = BODY;
        m.BodyEncoding = System.Text.Encoding.UTF8;
        m.IsBodyHtml = bIsHtml;
        m.ReplyTo = new MailAddress(FROM);
        SmtpClient smtp = new SmtpClient("smtp.163.com", 25);
        smtp.Credentials = new NetworkCredential("a414018479game", "741424975");
        smtp.EnableSsl = true;

        smtp.Send(m);

    }
}