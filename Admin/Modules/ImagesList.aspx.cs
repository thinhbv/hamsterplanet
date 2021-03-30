using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;
using Libs.Utils;
using System.Web.UI.HtmlControls;

namespace Admin.Modules
{
	public partial class ImagesList : System.Web.UI.Page
	{
		Images objGr = new Images();
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
			List<Images> lstGr = objGr.SelectAll();
			rptData.DataSource = lstGr;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				string id = e.CommandArgument.ToString();
				objGr.Id = int.Parse(id);
				switch (e.CommandName)
				{
					case "Edit":
						Response.Redirect("ImagesAdd.aspx?Id=" + id, false);
						break;
					case "Active":
						string strA = "";
						string active = e.CommandArgument.ToString();
						id = ((HiddenField)e.Item.FindControl("hdId")).Value;
						strA = active == "1" ? "0" : "1";
						objGr.Id = int.Parse(id);
						objGr.Active = int.Parse(strA);
						objGr.UpdateActive();
						BinData();
						break;
					case "Delete":
						objGr.Delete(id);
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