using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;
using System.Web.UI.HtmlControls;

namespace Admin.Modules
{
	public partial class PageList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
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
			PageInfo objData = new PageInfo();
			List<PageInfo> lstData = new List<PageInfo>();
			lstData = objData.SelectAll();
			rptData.DataSource = lstData;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				PageInfo objData = new PageInfo();
				string strCA = e.CommandArgument.ToString();
				string strId = ((HiddenField)e.Item.FindControl("hdId")).Value;
				objData.Id = int.Parse(strId);
				switch (e.CommandName)
				{
					case "AddSub":
						Response.Redirect("PageAdd.aspx?Level=" + strCA, false);
						break;
					case "Edit":
						if (strCA.Length > 5)
						{
							strCA = strCA.Substring(0, strCA.Length - 5);
						}
						else
						{
							strCA = "";
						}
						Response.Redirect("PageAdd.aspx?Id=" + strId + "&Level=" + strCA, false);
						break;
					case "Active":
						string strA = "";
						string active = e.CommandArgument.ToString();
						strA = active == "1" ? "0" : "1";
						objData.Id = int.Parse(strId);
						objData.Active = int.Parse(strA);
						objData.UpdateActive();
						BinData();
						break;
					case "Delete":
						objData.Delete(strId);
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
				foreach (RepeaterItem item in rptData.Items)
				{
					if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
					{
						if (((HtmlInputCheckBox)item.FindControl("chkItem")).Checked)
						{
							string strId = ((HiddenField)item.FindControl("hdId")).Value;
                            PageInfo objData = new PageInfo();
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
	}
}