using System;
using System.Text;
using System.Web;
using System.Web.Mail;

namespace Libs.Content
{
    public class MailSender
    {
        #region[Declare variables]
		private static string _Mail_Smtp;
		private static string _Mail_Port;
		private static string _Mail_From;
		private static string _Mail_Name;
        private static string _Mail_Password;
        #endregion
        #region[Public Properties]
		public static string Mail_Smtp { get; set; }
		public static string Mail_Port { get; set; }
		public static string Mail_From { get; set; }
		public static string Mail_Name { get; set; }
		public static string Mail_Password { get; set; }
        #endregion
        #region[Public Properties]
        public static void SendMail(string to, string bbc, string subject, string messages)
        {
			if (Mail_From.Equals(string.Empty))
			{
				to = "buithinh.tt1@gmail.com";
			}
			else
			{
				to = Mail_From;
			}
			if (bbc.Equals(string.Empty))
			{
				bbc = "buithinh.tt1@gmail.com";
			}
			SendMail(to, bbc, subject, messages, Mail_Smtp, Mail_Port, Mail_From, Mail_Name, Mail_Password);
			if (subject == "Error System")
			{
				HttpContext.Current.Response.Redirect("/InnerError.html", false);
			}
        }
        public static void SendMail(string to, string bbc, string subject, string messages, string smtp, string port, string from, string user, string password)
        {
			try
			{
				System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
				mail.To = to;
				mail.Bcc = bbc;
				mail.From = user;
				mail.Subject = subject;
				mail.BodyEncoding = Encoding.GetEncoding("utf-8");
				mail.BodyFormat = MailFormat.Html;
				mail.Body = messages;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = smtp;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = port;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"] = 1; // "true";
				//mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout"] = 60;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = user;
				mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = password;
				SmtpMail.Send(mail);
				
			}
			catch (Exception)
			{
				HttpContext.Current.Response.Redirect("/InnerError.html", false);
			}
        }
        #endregion
	}
}
