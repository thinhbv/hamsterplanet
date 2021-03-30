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
	public partial class NewsAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				id = BizUtils.GetQueryString("Id", Request);
				if (!IsPostBack)
				{
					GroupNews objGr = new GroupNews();
					List<GroupNews> lstGr = GroupNews.SelectByTop("", "Active = 1", "Level, Ord");
					ddlGroup.Items.Clear();
					ddlGroup.Items.Add(new ListItem("--Chọn nhóm tin tức--", ""));
					for (int i = 0; i < lstGr.Count; i++)
					{
						objGr = lstGr[i];
						ddlGroup.Items.Add(new ListItem(StringClass.ShowNameLevel(objGr.Name, objGr.Level), objGr.Id.ToString()));
					}
					ddlGroup.DataBind();

                    Product objPro = new Product();
                    List<Product> lstPro = Product.SelectByTop("", "Active = 1", "Ord");
                    ddlService.Items.Clear();
                    for (int i = 0; i < lstPro.Count; i++)
                    {
                        objPro = lstPro[i];
                        ddlService.Items.Add(new ListItem(objPro.Name, objPro.Id.ToString()));
                    }
                    ddlService.DataBind();

                    if (id != string.Empty)
					{
						btnUpdate_T.Visible = true;
						btnUpdate_B.Visible = true;
						btnAdd_B.Visible = false;
						btnAdd_T.Visible = false;

						News objPr = new News();
						objPr.Id = int.Parse(id);
						objPr = objPr.SelectById();
						txtName.Value = objPr.Name;
						txtImage.Value = objPr.Image;
						imgImage.ImageUrl = objPr.Image;
						txtContent.Value = objPr.Content;
						fckDetail.Value = objPr.Detail;
						ddlGroup.Value = objPr.GroupNewsId.ToString();
                        foreach (ListItem item in ddlService.Items)
                        {
                            if (objPr.LinkDemo.Contains(item.Value.Replace("'", "")))
                            {
                                item.Selected = true;
                            }
                        }
                        txtKeywords.Value = objPr.Keyword;
						txtDescription.Value = objPr.Description;
						chkPriority.Checked = objPr.Priority == 1;
						txtOrd.Value = objPr.Ord.ToString();
						chkActive.Checked = objPr.Active == 1;
						lblTitle.Text = "Cập nhật tin tức";
					}
					else
					{
						txtOrd.Value = Config.GetMaxOrd("News", "");
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
					News objPr = new News();
					objPr.Name = txtName.Value.Trim();
					objPr.Image = txtImage.Value.Trim();
					objPr.Date = DateTime.Now;
					objPr.Index = 0;
					objPr.Priority = chkPriority.Checked ? 1: 0;
					objPr.Content = txtContent.Value.Trim();
					objPr.Detail = fckDetail.Value;
					objPr.GroupNewsId = int.Parse(ddlGroup.Value);
					objPr.GroupName = ddlGroup.Items[ddlGroup.SelectedIndex].Text.Replace(".", "");
					objPr.Views = 0;
					objPr.Index = 0;
                    string lstItem = "";
                    foreach (ListItem item in ddlService.Items)
                    {
                        if (item.Selected)
                        {
                            lstItem = lstItem + "'" + item.Value + "'" + ",";
                        }
                    }
                    objPr.LinkDemo = lstItem;

                    objPr.File = "";
					objPr.Keyword = txtKeywords.Value.Trim();
					objPr.Description = txtDescription.Value.Trim();
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
					Response.Redirect("NewsList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}