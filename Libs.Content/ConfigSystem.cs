using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class ConfigInfo
	{
		public int Id { get; set; }
		public string Mail_Smtp { get; set; }
		public int Mail_Port { get; set; }
		public string Mail_Info { get; set; }
		public string Mail_Noreply { get; set; }
		public string Mail_Password { get; set; }
		public string Contact { get; set; }
		public string Copyright { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Keyword { get; set; }

		public ConfigInfo()
		{

		}
		public List<ConfigInfo> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<ConfigInfo>("sp_Config_GetByAll");
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[10];
            pars[0] = new SqlParameter("@Mail_Smtp", Mail_Smtp);
            pars[1] = new SqlParameter("@Mail_Port", Mail_Port);
            pars[2] = new SqlParameter("@Mail_Info", Mail_Info);
            pars[3] = new SqlParameter("@Mail_Noreply", Mail_Noreply);
            pars[4] = new SqlParameter("@Mail_Password", Mail_Password);
            pars[5] = new SqlParameter("@Contact", Contact);
            pars[6] = new SqlParameter("@Copyright", Copyright);
            pars[7] = new SqlParameter("@Title", Title);
            pars[8] = new SqlParameter("@Description", Description);
            pars[9] = new SqlParameter("@Keyword", Keyword);


            db.ExecuteNonQuerySP("sp_Config_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[11];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Mail_Smtp", Mail_Smtp);
            pars[2] = new SqlParameter("@Mail_Port", Mail_Port);
            pars[3] = new SqlParameter("@Mail_Info", Mail_Info);
            pars[4] = new SqlParameter("@Mail_Noreply", Mail_Noreply);
            pars[5] = new SqlParameter("@Mail_Password", Mail_Password);
            pars[6] = new SqlParameter("@Contact", Contact);
            pars[7] = new SqlParameter("@Copyright", Copyright);
            pars[8] = new SqlParameter("@Title", Title);
            pars[9] = new SqlParameter("@Description", Description);
            pars[10] = new SqlParameter("@Keyword", Keyword);

            db.ExecuteNonQuerySP("sp_Config_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_Config_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
