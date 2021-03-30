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
	public partial class SupportAdd : System.Web.UI.Page
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

					Support objSupport = new Support();
					objSupport.Id = int.Parse(id);
					objSupport = objSupport.SelectById();
					txtName.Value = objSupport.Name;
					txtEmail.Value = objSupport.Email;
					txtPhone.Value = objSupport.Phone;
					txtSkype.Value = objSupport.Skype;
					chkActive.Checked = objSupport.Active == 1;
					lblTitle.Text = "Cập nhật thông tin người hỗ trợ";
				}
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					Support objSup = new Support();
					objSup.Name = txtName.Value.Trim();
					objSup.Email = txtEmail.Value.Trim();
					objSup.Phone = txtPhone.Value.Trim();
					objSup.Skype = txtSkype.Value.Trim();
					objSup.Nick = "";
					objSup.Active = chkActive.Checked ? 1 : 0;

					if (id != string.Empty)
					{
						objSup.Id = int.Parse(id);
						objSup.Update();
					}
					else
					{
						objSup.Insert();
					}
					Response.Redirect("SupportList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}