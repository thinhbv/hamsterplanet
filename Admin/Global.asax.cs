using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Libs.Utils;

namespace Admin
{
    public class Global : System.Web.HttpApplication
    {
		private void RegisterRoutes()
		{
			RouteTable.Routes.MapPageRoute("Default", "", "~/Account/Login.aspx");
            RouteTable.Routes.MapPageRoute("Login", "login", "~/Account/Login.aspx");
        }
        protected void Application_Start(object sender, EventArgs e)
        {
			RegisterRoutes();
			Application["ProjectName"] = BizUtils.GetConfig(Consts.KeyName.ProjectName.ToString());
			
        }
    }
}