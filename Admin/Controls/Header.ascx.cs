using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Controls
{
	public partial class Header : System.Web.UI.UserControl
	{
		protected string project = "";
		protected string UserName = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Application["ProjectName"] != null)
			{
				project = Application["ProjectName"].ToString();
			}
			if (Session["UserName"] != null)
			{
				UserName = Session["UserName"] as string;
			}
			else
			{
				if (Request.UrlReferrer != null)
				{
					Response.Redirect("/login?url=" + Server.UrlEncode(Request.UrlReferrer.PathAndQuery), false);
				}
				else
				{
					Response.Redirect("/login", false);
				}
			}
		}
	}
}