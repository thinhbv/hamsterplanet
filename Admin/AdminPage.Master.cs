using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
	public partial class AdminPage : System.Web.UI.MasterPage
	{
		protected string project = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Application["ProjectName"] != null)
			{
				project = Application["ProjectName"].ToString();
			}	
		}
	}
}