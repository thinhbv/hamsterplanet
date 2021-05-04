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
	public partial class ProductAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				id = BizUtils.GetQueryString("Id", Request);
				if (!IsPostBack)
				{
					GroupProduct objGr = new GroupProduct();
					List<GroupProduct> lstGr = objGr.SelectByTop("", "Active = 1 AND Position = 0", "Level, Ord");
					ddlGroup.Items.Clear();
					ddlGroup.Items.Add(new ListItem("--Chọn nhóm sản phẩm--", ""));
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

						Product objPr = new Product();
						objPr.Id = int.Parse(id);
						objPr = objPr.SelectById();
						txtName.Value = objPr.Name;
                        if (!string.IsNullOrEmpty(objPr.Image1))
                        {
                            txtImage1.Value = objPr.Image1;
                            if (objPr.Image1.StartsWith("/"))
                            {
                                imgImage1.ImageUrl = objPr.Image1;
                            }
                            else
                            {
                                imgImage1.ImageUrl = "/" + objPr.Image1;
                            }
                        }
                        if (!string.IsNullOrEmpty(objPr.Image2))
                        {
                            txtImage2.Value = objPr.Image2;
                            if (objPr.Image2.StartsWith("/"))
                            {
                                imgImage2.ImageUrl = objPr.Image2;
                            }
                            else
                            {
                                imgImage2.ImageUrl = "/" + objPr.Image2;
                            }
                        }
                        if (!string.IsNullOrEmpty(objPr.Image3))
                        {
                            txtImage3.Value = objPr.Image3;
                            if (objPr.Image3.StartsWith("/"))
                            {
                                imgImage3.ImageUrl = objPr.Image3;
                            }
                            else
                            {
                                imgImage3.ImageUrl = "/" + objPr.Image3;
                            }
                        }

                        if (!string.IsNullOrEmpty(objPr.Image4))
                        {
                            txtImage4.Value = objPr.Image4;
                            if (objPr.Image4.StartsWith("/"))
                            {
                                imgImage4.ImageUrl = objPr.Image4;
                            }
                            else
                            {
                                imgImage4.ImageUrl = "/" + objPr.Image4;
                            }
                        }
                        txtPrice.Value = objPr.Price;
                        txtPrice1.Value = objPr.Price1;
						txtContent.Value = objPr.Content;
						ddlGroup.Value = objPr.GroupId.ToString();
						fckDetail.Value = objPr.Detail;
						txtKeywords.Value = objPr.Keywords;
						txtDescription.Value = objPr.Description;
						chkPopular.Checked = objPr.IsPopular == 1;
						txtOrd.Value = objPr.Ord.ToString();
						chkActive.Checked = objPr.Active == 1;
						lblTitle.Text = "Cập nhật sản phẩm";
					}
					else
					{
						txtOrd.Value = Config.GetMaxOrd("Product", "");
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
					Product objPr = new Product();
					objPr.Name = txtName.Value.Trim();
					objPr.Image1 = txtImage1.Value.Trim();
					objPr.Image2 = txtImage2.Value.Trim();
					objPr.Image3 = txtImage3.Value.Trim();
					objPr.Image4 = txtImage4.Value.Trim();
					objPr.Image5 = "";
					objPr.Price = txtPrice.Value.Trim();
                    objPr.Price1 = txtPrice1.Value.Trim();
                    objPr.Content = txtContent.Value.Trim();
					objPr.Detail = fckDetail.Value;
					objPr.GroupId = int.Parse(ddlGroup.Value);
					objPr.GroupName = ddlGroup.Items[ddlGroup.SelectedIndex].Text.Replace(".","");
					objPr.IsPopular = chkPopular.Checked ? 1 : 0;
					objPr.Keywords = txtKeywords.Value.Trim();
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
					Response.Redirect("ProductList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}