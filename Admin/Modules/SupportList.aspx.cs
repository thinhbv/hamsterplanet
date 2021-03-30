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
	public partial class SupportList : System.Web.UI.Page
	{
		Support objSp = new Support();
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
			List<Support> lstGr = objSp.SelectAll();
			rptData.DataSource = lstGr;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				string id = e.CommandArgument.ToString();
				objSp.Id = int.Parse(id);
				switch (e.CommandName)
				{
					case "Edit":
						Response.Redirect("SupportAdd.aspx?Id=" + id, false);
						break;
					case "Active":
						string strA = "";
						string active = e.CommandArgument.ToString();
						id = ((HiddenField)e.Item.FindControl("hdId")).Value;
						strA = active == "1" ? "0" : "1";
						objSp.Id = int.Parse(id);
						objSp.Active = int.Parse(strA);
						objSp.UpdateActive();
						BinData();
						break;
					case "Delete":
						objSp.Delete(id);
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
							objSp.Delete(strId);
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