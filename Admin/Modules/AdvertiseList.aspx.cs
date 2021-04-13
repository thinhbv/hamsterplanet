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
	public partial class AdvertiseList : System.Web.UI.Page
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
			Advertise objData = new Advertise();
			List<Advertise> lstData = new List<Advertise>();
			lstData = objData.SelectAll();
			rptData.DataSource = lstData;
			rptData.DataBind();
		}
		protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			try
			{
				Advertise objData = new Advertise();
				string id = e.CommandArgument.ToString();
				objData.Id = int.Parse(id);
				switch (e.CommandName)
				{
					case "Edit":
						Response.Redirect("AdvertiseAdd.aspx?Id=" + id, false);
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
				string listId = "";
				foreach (RepeaterItem item in rptData.Items)
				{
					if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
					{
						if (((HtmlInputCheckBox)item.FindControl("chkItem")).Checked)
						{
							string strId = ((HiddenField)item.FindControl("hdId")).Value;
                            Advertise objData = new Advertise();
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