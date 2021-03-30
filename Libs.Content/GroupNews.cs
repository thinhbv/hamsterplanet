using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class GroupNews
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string Level { get; set; }
		public string Description { get; set; }
		public string Keyword { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }
		public int Index { get; set; }

		public GroupNews()
		{

		}
		public List<GroupNews> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<GroupNews>("sp_GroupNews_GetByAll");
		}
		public GroupNews SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<GroupNews>("sp_GroupNews_GetById", new SqlParameter("@Id", Id));
		}
		public static List<GroupNews> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<GroupNews>("sp_GroupNews_GetByTop", pars);
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE GroupNews SET Active=@Active WHERE Id=@Id ";
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
            SqlParameter[] pars = new SqlParameter[8];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@Image", Image);
			pars[2] = new SqlParameter("@Level", Level);
			pars[3] = new SqlParameter("@Description", Description);
			pars[4] = new SqlParameter("@Keyword", Keyword);
			pars[5] = new SqlParameter("@Ord", Ord);
			pars[6] = new SqlParameter("@Active", Active);
			pars[7] = new SqlParameter("@Index", Index);

            db.ExecuteNonQuerySP("sp_GroupNews_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Image", Image);
            pars[3] = new SqlParameter("@Level", Level);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@Keyword", Keyword);
            pars[6] = new SqlParameter("@Ord", Ord);
            pars[7] = new SqlParameter("@Active", Active);
            pars[8] = new SqlParameter("@Index", Index);

            db.ExecuteNonQuerySP("sp_GroupNews_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_GroupNews_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
