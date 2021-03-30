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
	public partial class UserList : System.Web.UI.Page
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
			User objData = new User();
			List<User> lstData = new List<User>();
			lstData = objData.SelectAll();
			lblCount.Text = lstData.Count.ToString();
			rptData.DataSource = lstData;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				User objData = new User();
				string id = e.CommandArgument.ToString();
				objData.Id = int.Parse(id);
				switch (e.CommandName)
				{
					case "Edit":
						Response.Redirect("UserAdd.aspx?Id=" + id, false);
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
				foreach (RepeaterItem item in rptData.Items)
				{
					if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
					{
						if (((HtmlInputCheckBox)item.FindControl("chkItem")).Checked)
						{
							string strId = ((HiddenField)item.FindControl("hdId")).Value;
							User objData = new User();
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