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
	public partial class AdvertiseAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			id = BizUtils.GetQueryString("Id", Request);
			if (!IsPostBack)
			{
				BizUtils.LoadDropDownList(ddlPosition, "Banner, Logo, Quảng cáo");
				if (id != string.Empty)
				{
					btnUpdate_T.Visible = true;
					btnUpdate_B.Visible = true;
					btnAdd_B.Visible = false;
					btnAdd_T.Visible = false;

					Advertise objAd = new Advertise();
					objAd.Id = int.Parse(id);
					objAd = objAd.SelectById();
					txtName.Value = objAd.Name;
					txtImage.Value = objAd.Image;
					imgImage.ImageUrl = objAd.Image;
					txtLink.Value = objAd.Link;
					ddlTarget.Value = objAd.Target;
					ddlPosition.Value = objAd.Position.ToString();
					txtOrd.Value = objAd.Ord.ToString();
					chkActive.Checked = objAd.Active == 1;
					lblTitle.Text = "Cập nhật thông tin quảng cáo";
				}
				else
				{
					txtOrd.Value = Config.GetMaxOrd("Advertise", "");
				}
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					Advertise objAdv = new Advertise();
					objAdv.Name = txtName.Value.Trim();
					objAdv.Image = txtImage.Value.Trim();
					objAdv.Width = 0;
					objAdv.Height = 0;
					objAdv.Link = txtLink.Value.Trim();
					objAdv.Target = ddlTarget.Value;
					objAdv.Content = "";
					objAdv.Position = int.Parse(ddlPosition.Value);
					objAdv.PageId = 0;
					objAdv.Click = 0;
					objAdv.Ord = txtOrd.Value.Trim() != "" ? int.Parse(txtOrd.Value.Trim()) : 1;
					objAdv.Active = chkActive.Checked ? 1 : 0;
					
					if (id != string.Empty)
					{
						objAdv.Id = int.Parse(id);
						objAdv.Update();
					}
					else
					{
						objAdv.Insert();
					}
					Response.Redirect("AdvertiseList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}