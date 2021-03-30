using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class GroupImages
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Level { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }

		public GroupImages()
		{

		}
		public List<GroupImages> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<GroupImages>("sp_GroupImages_GetByAll");
		}
		public GroupImages SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<GroupImages>("sp_GroupImages_GetById", new SqlParameter("@Id", Id));
		}
		public static List<GroupImages> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<GroupImages>("sp_GroupImages_GetByTop", pars);
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE GroupImages SET Active=@Active WHERE Id=@Id ";
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
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@Name", Name);
            pars[1] = new SqlParameter("@Level", Level);
            pars[2] = new SqlParameter("@Ord", Ord);
            pars[3] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_GroupImages_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Level", Level);
            pars[3] = new SqlParameter("@Ord", Ord);
            pars[4] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_GroupImages_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_GroupImages_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
