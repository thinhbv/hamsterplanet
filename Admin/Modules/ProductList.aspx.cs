using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;
using System.Web.UI.HtmlControls;
using Libs.Utils;

namespace Admin.Modules
{
	public partial class ProductList : System.Web.UI.Page
	{
		private static string where = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
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
					BinData();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void BinData()
		{
			List<Product> lstData = new List<Product>();
			if (string.IsNullOrEmpty(where))
			{
				lstData = Product.SelectByTop("","IsNew = 1","");
			}
			else
			{
				lstData = Product.SelectByTop("", where, "Ord");
			}
			lblCount.Text = lstData.Count.ToString();
			rptData.DataSource = lstData;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				Product objData = new Product();
				string id = e.CommandArgument.ToString();
				objData.Id = int.Parse(id);
				switch (e.CommandName)
				{
					case "Edit":
						Response.Redirect("ProductAdd.aspx?Id=" + id, false);
						break;
					case "Active":
						string strA = "";
						string active = e.CommandArgument.ToString();
						id = ((HiddenField)e.Item.FindControl("hdId")).Value;
						strA = active == "1" ? "0" : "1";
						objData.Id = int.Parse(id);
						objData.Active = int.Parse(strA);
						objData.UpdateActive();
						BinData();
						break;
					case "Delete":
						objData.Delete(id);
						BinData();
						break;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				Product objData = new Product();
				foreach (RepeaterItem item in rptData.Items)
				{
					if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
					{
						if (((HtmlInputCheckBox)item.FindControl("chkItem")).Checked)
						{
							string strId = ((HiddenField)item.FindControl("hdId")).Value;
							objData.Delete(strId);
						}
					}
				}
				BinData();
			}
			catch (Exception)
			{
				throw;
			}
		}

		protected void lbtApply_Click(object sender, EventArgs e)
		{
			try
			{
				if (ddlGroup.Value != "")
				{
					where = "GroupId=" + ddlGroup.Value;
				}
				else
				{
					where = "";
				}
				BinData();
			}
			catch (Exception)
			{
				
				throw;
			}
		}
	}
}