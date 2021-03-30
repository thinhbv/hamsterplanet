using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Libs.Content;
using Libs.Utils;

namespace Admin.Modules
{
	public partial class GroupNewsList : System.Web.UI.Page
	{
		GroupNews objGr = new GroupNews();
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
			List<GroupNews> lstGr = objGr.SelectAll();
			rptData.DataSource = lstGr;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				string strCA = e.CommandArgument.ToString();
				string strId = ((HiddenField)e.Item.FindControl("hdId")).Value;
				objGr.Id = int.Parse(strId);
				switch (e.CommandName)
				{
					case "AddSub":
						Response.Redirect("GroupNewsAdd.aspx?Level=" + strCA, false);
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
						Response.Redirect("GroupNewsAdd.aspx?Id=" + strId + "&Level=" + strCA, false);
						break;
					case "Active":
						string strA = "";
						string active = e.CommandArgument.ToString();
						strA = active == "1" ? "0" : "1";
						objGr.Id = int.Parse(strId);
						objGr.Active = int.Parse(strA);
						objGr.UpdateActive();
						BinData();
						break;
					case "Delete":
						objGr.Delete(strId);
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
							objGr.Delete(strId);
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