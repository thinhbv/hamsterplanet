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
	public partial class GroupNewsAdd : System.Web.UI.Page
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

					GroupNews objGr = new GroupNews();
					objGr.Id = int.Parse(id);
					objGr = objGr.SelectById();
					txtName.Value = objGr.Name;
					txtKeywords.Value = objGr.Keyword;
					txtDescription.Value = objGr.Description;
					txtOrd.Value = objGr.Ord.ToString();
					chkActive.Checked = objGr.Active == 1;
					lblTitle.Text = "Cập nhật nhóm tin tức";
				}
				else
				{
					txtOrd.Value = Config.GetMaxOrd("GroupNews", level, true);
				}
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					GroupNews objGr = new GroupNews();
					objGr.Name = txtName.Value.Trim();
					objGr.Image = "";
					objGr.Level = level + "00000";
					objGr.Index = 1;
					objGr.Keyword = txtKeywords.Value.Trim();
					objGr.Description = txtDescription.Value.Trim();
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
					Response.Redirect("GroupNewsList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}