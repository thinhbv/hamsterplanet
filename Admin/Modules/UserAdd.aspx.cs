using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;
using Libs.Utils;

namespace Admin.Modules
{
	public partial class UserAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			id = BizUtils.GetQueryString("Id", Request);
			if (!IsPostBack)
			{
				if (id != string.Empty)
				{
					btnUpdate_T.Visible = true;
					btnUpdate_B.Visible = true;
					btnAdd_B.Visible = false;
					btnAdd_T.Visible = false;

					User objUser = new User();
					objUser.Id = int.Parse(id);
					objUser = objUser.SelectById();
					txtName.Value = objUser.Name;
					txtUserName.Value = objUser.UserName;
					txtPassword.Value = objUser.Password;
					txtEmail.Value = objUser.Email;
					txtPhone.Value = objUser.Phone;
					chkAdmin.Checked = objUser.Admin == 1;
					chkActive.Checked = objUser.Active == 1;
					lblTitle.Text = "Cập nhật thông tin người dùng";
				}
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					User objUser = new User();
					objUser.Name = txtName.Value.Trim();
					objUser.UserName = txtUserName.Value.Trim();
					objUser.Password = txtPassword.Value.Trim();
					objUser.Email = txtEmail.Value.Trim();
					objUser.Phone = txtPhone.Value.Trim();
					objUser.Admin = chkAdmin.Checked ? 1 : 0;
					objUser.Date = DateTime.Now;
					objUser.Active = chkActive.Checked ? 1 : 0;

					if (id != string.Empty)
					{
						objUser.Id = int.Parse(id);
						objUser.Update();
					}
					else
					{
						objUser.Insert();
					}
					Response.Redirect("UserList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}