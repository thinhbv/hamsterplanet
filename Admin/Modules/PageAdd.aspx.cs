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
	public partial class PageAdd : System.Web.UI.Page
	{
		private string id = string.Empty;
		private string level = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			id = BizUtils.GetQueryString("Id", Request);
			level = BizUtils.GetQueryString("Level", Request);
			if (!IsPostBack)
			{
				LoadDropDownListPageLink();
				if (id != string.Empty)
				{
					btnUpdate_T.Visible = true;
					btnUpdate_B.Visible = true;
					btnAdd_B.Visible = false;
					btnAdd_T.Visible = false;

					PageInfo objAd = new PageInfo();
					objAd.Id = int.Parse(id);
					objAd = objAd.SelectById();
					txtName.Value = objAd.Name;
					level = objAd.Level;
					ddlType.Value = objAd.Type.ToString();
					txtImage.Value = objAd.Image;
					imgImage.ImageUrl = objAd.Image;
					fckDetail.Value = objAd.Detail;
					try
					{
						ddlLink.Value = objAd.Link;
						ddlLinkType.Value = "1";
					}
					catch (Exception)
					{
						ddlLinkType.Value = "0";
						txtLink.Value = objAd.Link;
					}
					
					ddlTarget.Value = objAd.Target;
					foreach (ListItem item in ddlPosition.Items)
					{
						if (objAd.Position.Contains(item.Value))
						{
							item.Selected = true;
						}
					}
					txtOrd.Value = objAd.Ord.ToString();
					chkActive.Checked = objAd.Active == 1;
					fckKeywords.Value = objAd.Keyword;
					txtDescription.Value = objAd.Description;
					lblTitle.Text = "Cập nhật menu";
				}
				else
				{
					txtOrd.Value = Config.GetMaxOrd("Page", level, true);
				}
			}
		}
		private void LoadDropDownListPageLink()
        {
            ddlLink.Items.Clear();
			ddlLink.Items.Add(new ListItem("■Trang chủ", "/"));
            GroupProduct obj = new GroupProduct();
            List<GroupProduct> lstGr = obj.SelectByTop("","Active=1", "Level,Ord");
			//ddlLink.Items.Add(new ListItem("■Dịch vụ", "#"));
            for (int i = 0; i < lstGr.Count; i++)
            {
                ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel("■" + lstGr[i].Name, lstGr[i].Level), "/" + Consts.SAN_PHAM + "/" + lstGr[i].Id + "/" + StringClass.NameToTag(lstGr[i].Name)));
                //List<Product> pro = Product.SelectByTop("", "Active=1 AND GroupId=" + lstGr[i].Id, "Ord");
                //for (int j = 0; j < pro.Count; j++)
                //{
                //    ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(pro[j].Name, lstGr[i].Level + "00000"), StringClass.GeneralDetailUrl(Consts.SAN_PHAM, pro[j].GroupName, pro[j].Id.ToString(), pro[j].Name)));
                //}
            }
            List<GroupNews> listN = GroupNews.SelectByTop("", "Active=1", "Level, Ord");
			//ddlLink.Items.Add(new ListItem("■Tin tức", "#"));
   //         if (listN.Count > 0)
   //         {
   //             for (int i = 0; i < listN.Count; i++)
   //             {
			//		ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(listN[i].Name, listN[i].Level + "00000"), "/" + Consts.TIN_TUC + "/" + listN[i].Id + "/" + StringClass.NameToTag(listN[i].Name)));
   //             }
   //         }
			ddlLink.Items.Add(new ListItem("■Liên hệ", "/lien-he"));
			ddlLink.DataBind();
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (Page.IsValid)
				{
					PageInfo objPage = new PageInfo();
					objPage.Name = txtName.Value.Trim();
					objPage.Image = txtImage.Value.Trim();
					objPage.Detail = fckDetail.Value;
					objPage.Level = level + "00000";
					objPage.Type = int.Parse(ddlType.Value);
					if (objPage.Type == 0)
					{
						if (ddlLinkType.Value == "0")
						{
							objPage.Link = txtLink.Value.Trim();
						}
						else
						{
							objPage.Link = ddlLink.Value;
						}
					}
					else
					{
						if (id != string.Empty)
						{
							objPage.Link = "/" + id + "/" + StringClass.NameToTag(objPage.Name);
						}
						else
						{
							objPage.Link = "/" + PageInfo.GetMaxId().ToString() + "/" + StringClass.NameToTag(objPage.Name);
						}
					}
					
					objPage.Target = ddlTarget.Value;
					objPage.Keyword = fckKeywords.Value.Trim();
					objPage.Description = txtDescription.Value.Trim();
					string lstItem = "";
					foreach (ListItem item in ddlPosition.Items)
					{
						if (item.Selected)
						{
							lstItem = lstItem + item.Value + ",";
						}
					}
					if (lstItem.Length > 0)
					{
						lstItem = lstItem.Substring(0, lstItem.Length - 1);
					}
					objPage.Position = lstItem;
					objPage.Ord = txtOrd.Value.Trim() != "" ? int.Parse(txtOrd.Value.Trim()) : 1;
					objPage.Active = chkActive.Checked ? 1 : 0;

					if (id != string.Empty)
					{
						objPage.Id = int.Parse(id);
						objPage.Update();
					}
					else
					{
						objPage.Insert();
					}
					Response.Redirect("PageList.aspx", false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}