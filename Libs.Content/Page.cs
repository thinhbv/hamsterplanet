using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class PageInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string Detail { get; set; }
		public string Level { get; set; }
		public string Description { get; set; }
		public string Keyword { get; set; }
		public int Type { get; set; }
		public string Link { get; set; }
		public string Target { get; set; }
		public string Position { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }

		public PageInfo()
		{

		}
		public List<PageInfo> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<PageInfo>("sp_Page_GetByAll");
		}
		public PageInfo SelectById()
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				return db.GetInstanceSP<PageInfo>("sp_Page_GetById", new SqlParameter("@Id", Id));
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateActive()
		{
			string sSQL = "UPDATE Page SET Active=@Active WHERE Id=@Id ";
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
		public List<PageInfo> SelectByPosition(string pos)
		{
			string sSQL = "SELECT * FROM Page WHERE Position LIKE '%"+pos+"%' AND Active = 1 ORDER BY Level, Ord";
			SqlCommand sqlCmd;
			SqlConnection mCon = null;
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				mCon = db.OpenConnection();
				sqlCmd = new SqlCommand(sSQL, mCon);
				//sqlCmd.Parameters.Add(new SqlParameter("@Position", pos));
				return db.GetList<PageInfo>(sqlCmd);
			}
			catch (Exception)
			{
				throw;
			}
		}
		public static int GetMaxId()
		{
			string sSQL = "SELECT MAX(Id) FROM Page";
			SqlCommand sqlCmd;
			SqlConnection mCon = null;
			SqlDataReader dr = null;
			int maxId = 0;
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				mCon = db.OpenConnection();
				sqlCmd = new SqlCommand(sSQL, mCon);
				dr = sqlCmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						maxId = dr.GetInt32(0);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (dr != null)
				{
					dr.Close();
				}
			}
			return maxId + 1;
		}
		public static List<PageInfo> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<PageInfo>("sp_Page_GetByTop", pars);
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[12];
            pars[0] = new SqlParameter("@Name", Name);
            pars[1] = new SqlParameter("@Image", Image);
            pars[2] = new SqlParameter("@Detail", Detail);
            pars[3] = new SqlParameter("@Level", Level);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@Keyword", Keyword);
            pars[6] = new SqlParameter("@Type", Type);
            pars[7] = new SqlParameter("@Link", Link);
            pars[8] = new SqlParameter("@Target", Target);
            pars[9] = new SqlParameter("@Position", Position);
            pars[10] = new SqlParameter("@Ord", Ord);
            pars[11] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_Page_Insert", pars);
            
            //
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[13];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Image", Image);
            pars[3] = new SqlParameter("@Detail", Detail);
            pars[4] = new SqlParameter("@Level", Level);
            pars[5] = new SqlParameter("@Description", Description);
            pars[6] = new SqlParameter("@Keyword", Keyword);
            pars[7] = new SqlParameter("@Type", Type);
            pars[8] = new SqlParameter("@Link", Link);
            pars[9] = new SqlParameter("@Target", Target);
            pars[10] = new SqlParameter("@Position", Position);
            pars[11] = new SqlParameter("@Ord", Ord);
            pars[12] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_Page_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_Page_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
