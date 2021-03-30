using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

namespace Admin.Modules
{
	public partial class ConfigSystem : System.Web.UI.Page
	{
		private static ConfigInfo config = new ConfigInfo();
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					List<ConfigInfo> lstCon = config.SelectAll();
					if (lstCon.Count > 0)
					{
						config = config.SelectAll()[0];
						txtEmailPassword.Value = config.Mail_Password;
						txtMailReceipt.Value = config.Mail_Noreply;
						txtMailSend.Value = config.Mail_Info;
						txtPort.Value = config.Mail_Port.ToString();
						txtSmtpServer.Value = config.Mail_Smtp;
						fckCopyright.Value = config.Copyright;
						fckDetail.Value = config.Contact;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					config.Contact = fckDetail.Value;
					config.Copyright = fckCopyright.Value;
					config.Description = "";
					config.Keyword = "";
					config.Mail_Info = txtMailSend.Value.Trim();
					config.Mail_Noreply = txtMailReceipt.Value.Trim();
					config.Mail_Password = txtEmailPassword.Value.Trim();
					config.Mail_Port = int.Parse(txtPort.Value.Trim());
					config.Mail_Smtp = txtSmtpServer.Value.Trim();
					config.Title = "";

					if (config.Id > 0)
					{
						config.Update();
					}
					else
					{
						config.Insert();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}