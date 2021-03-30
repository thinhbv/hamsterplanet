using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Images
	{
		public int Id { get; set; }
		public string Thumbnail { get; set; }
		public string Image { get; set; }
		public int GroupId { get; set; }
		public int Priority { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }

		public Images()
		{

		}
		public List<Images> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<Images>("sp_Images_GetByAll");
		}
		public Images SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<Images>("sp_Images_GetById", new SqlParameter("@Id", Id));
		}
		public static List<Images> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<Images>("sp_Images_GetByTop", pars);
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE Images SET Active=@Active WHERE Id=@Id ";
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
            SqlParameter[] pars = new SqlParameter[6];
			pars[0] = new SqlParameter("@Thumbnail", Thumbnail);
			pars[1] = new SqlParameter("@Image", Image);
			pars[2] = new SqlParameter("@GroupId", GroupId);
			pars[3] = new SqlParameter("@Priority", Priority);
			pars[4] = new SqlParameter("@Ord", Ord);
			pars[5] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_Images_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Thumbnail", Thumbnail);
            pars[2] = new SqlParameter("@Image", Image);
            pars[3] = new SqlParameter("@GroupId", GroupId);
            pars[4] = new SqlParameter("@Priority", Priority);
            pars[5] = new SqlParameter("@Ord", Ord);
            pars[6] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_Images_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_Images_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
