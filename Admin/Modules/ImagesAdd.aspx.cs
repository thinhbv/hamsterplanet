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
	public partial class ImagesAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				id = BizUtils.GetQueryString("Id", Request);
				if (!IsPostBack)
				{
					GroupImages objGr = new GroupImages();
					List<GroupImages> lstGr = GroupImages.SelectByTop("", "Active = 1", "Level, Ord");
					ddlGroup.Items.Clear();
					ddlGroup.Items.Add(new ListItem("--Chọn nhóm hình ảnh--", ""));
					for (int i = 0; i < lstGr.Count; i++)
					{
						objGr = lstGr[i];
						ddlGroup.Items.Add(new ListItem(StringClass.ShowNameLevel(objGr.Name, objGr.Level), objGr.Id.ToString()));
					}
					ddlGroup.DataBind();

					if (id != string.Empty)
					{
						btnUpdate_T.Visible = true;
						btnUpdate_B.Visible = true;
						btnAdd_B.Visible = false;
						btnAdd_T.Visible = false;

						Images objPr = new Images();
						objPr.Id = int.Parse(id);
						objPr = objPr.SelectById();
						txtName.Value = objPr.Thumbnail;
						txtImage.Value = objPr.Image;
						imgImage.ImageUrl = objPr.Image;
						ddlGroup.Value = objPr.GroupId.ToString();
						chkPriority.Checked = objPr.Priority == 1;
						txtOrd.Value = objPr.Ord.ToString();
						chkActive.Checked = objPr.Active == 1;
						lblTitle.Text = "Cập nhật hình ảnh";
					}
					else
					{
						txtOrd.Value = Config.GetMaxOrd("Images", "");
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
					Images objPr = new Images();
					objPr.Thumbnail = txtName.Value.Trim();
					objPr.Image = txtImage.Value.Trim();
					objPr.Priority = chkPriority.Checked ? 1 : 0;
					objPr.GroupId = int.Parse(ddlGroup.Value);
					objPr.Ord = txtOrd.Value.Trim() != "" ? int.Parse(txtOrd.Value.Trim()) : 1;
					objPr.Active = chkActive.Checked ? 1 : 0;

					if (id != string.Empty)
					{
						objPr.Id = int.Parse(id);
						objPr.Update();
					}
					else
					{
						objPr.Insert();
					}
					Response.Redirect("ImagesList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}