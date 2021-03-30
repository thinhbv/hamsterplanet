using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class News
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string File { get; set; }
		public string Content { get; set; }
		public string Detail { get; set; }
		public DateTime Date { get; set; }
		public int Priority { get; set; }
		public int Index { get; set; }
		public int Views { get; set; }
		public int GroupNewsId { get; set; }
		public string GroupName { get; set; }
		public string LinkDemo { get; set; }
		public string Description { get; set; }
		public string Keyword { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }

		public News()
		{

		}
		public List<News> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<News>("sp_News_GetByAll");
		}
		public News SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<News>("sp_News_GetById", new SqlParameter("@Id", Id));
		}
		public List<News> SelectByPaging(int currPage, int perpage, string level)
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				return db.GetListSP<News>("spNews_PhanTrang", new SqlParameter("@currPage", currPage),
															  new SqlParameter("@recodperpage", perpage),
															  new SqlParameter("@Level", level));
			}
			catch (Exception)
			{
				throw;
			}
		}
		#region[News_GetCount]
		public int GetTotalCount(string level)
		{
			int total = 0;
			News obj = new News();
			SqlDataReader dr = null;
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				using (SqlCommand dbCmd = new SqlCommand("sp_News_GetCount", db.OpenConnection()))
				{
					dbCmd.CommandType = CommandType.StoredProcedure;
					dbCmd.Parameters.Add(new SqlParameter("@Level", level));
					dr = dbCmd.ExecuteReader();
					if (dr.HasRows)
					{
						while (dr.Read())
						{
							total = dr.GetInt32(0);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null)
				{
					dr.Close();
				}
				obj = null;
			}
			return total;
		}
		#endregion
		public List<News> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<News>("sp_News_GetByTop", pars);
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE News SET Active=@Active WHERE Id=@Id ";
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
            SqlParameter[] pars = new SqlParameter[16];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@Image", Image);
			pars[2] = new SqlParameter("@File", File);
			pars[3] = new SqlParameter("@Content", Content);
			pars[4] = new SqlParameter("@Detail", Detail);
			pars[5] = new SqlParameter("@Date", Date);
			pars[6] = new SqlParameter("@Priority", Priority);
			pars[7] = new SqlParameter("@Index", Index);
			pars[8] = new SqlParameter("@Views", Views);
			pars[9] = new SqlParameter("@GroupNewsId", GroupNewsId);
			pars[10] = new SqlParameter("@GroupName", GroupName);
			pars[11] = new SqlParameter("@LinkDemo", LinkDemo);
			pars[12] = new SqlParameter("@Description", Description);
			pars[13] = new SqlParameter("@Keyword", Keyword);
			pars[14] = new SqlParameter("@Ord", Ord);
			pars[15] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_News_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[17];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Image", Image);
            pars[3] = new SqlParameter("@File", File);
            pars[4] = new SqlParameter("@Content", Content);
            pars[5] = new SqlParameter("@Detail", Detail);
            pars[6] = new SqlParameter("@Date", Date);
            pars[7] = new SqlParameter("@Priority", Priority);
            pars[8] = new SqlParameter("@Index", Index);
            pars[9] = new SqlParameter("@Views", Views);
			pars[10] = new SqlParameter("@GroupNewsId", GroupNewsId);
            pars[11] = new SqlParameter("@GroupName", GroupName);
            pars[12] = new SqlParameter("@LinkDemo", LinkDemo);
            pars[13] = new SqlParameter("@Description", Description);
            pars[14] = new SqlParameter("@Keyword", Keyword);
            pars[15] = new SqlParameter("@Ord", Ord);
            pars[16] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_News_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_News_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
