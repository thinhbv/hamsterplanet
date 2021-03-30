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
	public partial class GroupImageAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		private string level = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			id = BizUtils.GetQueryString("Id", Request);
			level = BizUtils.GetQueryString("Level", Request);
			if (!IsPostBack)
			{
				if (id != string.Empty)
				{
					btnUpdate_T.Visible = true;
					btnUpdate_B.Visible = true;
					btnAdd_B.Visible = false;
					btnAdd_T.Visible = false;

					GroupImages objGr = new GroupImages();
					objGr.Id = int.Parse(id);
					objGr = objGr.SelectById();
					txtName.Value = objGr.Name;
					txtOrd.Value = objGr.Ord.ToString();
					chkActive.Checked = objGr.Active == 1;
					lblTitle.Text = "Cập nhật nhóm hình ảnh";
				}
				else
				{
					txtOrd.Value = Config.GetMaxOrd("GroupImages", level, true);
				}
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					GroupImages objGr = new GroupImages();
					objGr.Name = txtName.Value.Trim();
					objGr.Level = level + "00000";
					objGr.Ord = txtOrd.Value.Trim() != "" ? int.Parse(txtOrd.Value.Trim()) : 1;
					objGr.Active = chkActive.Checked ? 1 : 0;

					if (id != string.Empty)
					{
						objGr.Id = int.Parse(id);
						objGr.Update();
					}
					else
					{
						objGr.Insert();
					}
					Response.Redirect("GroupImageList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}