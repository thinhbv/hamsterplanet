using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Support
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Nick { get; set; }
		public string Skype { get; set; }
		public int Active { get; set; }

		public Support()
		{

		}
		public List<Support> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<Support>("sp_Support_GetByAll");
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE Support SET Active=@Active WHERE Id=@Id ";
			SqlCommand sqlCmd;
			SqlConnection mCon = null;
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				mCon = db.OpenConnection();
				sqlCmd = new SqlCommand(sSQL, mCon);
				sqlCmd.Parameters.Add(new SqlParameter("@Active", Active));
				sqlCmd.Parameters.Add(new SqlParameter("@Id", Id));
				sqlCmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
		}
		public Support SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<Support>("sp_Support_GetById", new SqlParameter("@Id", Id));
		}

		public static List<Support> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<Support>("sp_Support_GetByTop", pars);
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@Email", Email);
			pars[2] = new SqlParameter("@Phone", Phone);
			pars[3] = new SqlParameter("@Nick", Nick);
			pars[4] = new SqlParameter("@Skype", Skype);
			pars[5] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_Support_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Email", Email);
            pars[3] = new SqlParameter("@Phone", Phone);
            pars[4] = new SqlParameter("@Nick", Nick);
            pars[5] = new SqlParameter("@Skype", Skype);
            pars[6] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_Support_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_Support_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
