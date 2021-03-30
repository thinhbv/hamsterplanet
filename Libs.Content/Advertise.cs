using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Advertise
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string Link { get; set; }
		public string Target { get; set; }
		public string Content { get; set; }
		public int Position { get; set; }
		public int PageId { get; set; }
		public int Click { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }

		public Advertise()
		{

		}
		public List<Advertise> SelectAll()
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				return db.GetListSP<Advertise>("sp_Advertise_GetByAll");
			}
			catch (Exception)
			{
				
				throw;
			}
		}

		public Advertise SelectById()
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				return db.GetInstanceSP<Advertise>("sp_Advertise_GetById", new SqlParameter("@Id", Id));
			}
			catch (Exception)
			{
				
				throw;
			}
		}
		public static List<Advertise> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<Advertise>("sp_Advertise_GetByTop", pars);
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE Advertise SET Active=@Active WHERE Id=@Id ";
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
			try
			{

				DbHelper db = new DbHelper(Config.ConnectionStrings);
				SqlParameter[] pars = new SqlParameter[12];
				pars[0] = new SqlParameter("@Name", Name);
				pars[1] = new SqlParameter("@Image", Image);
				pars[2] = new SqlParameter("@Width", Width);
				pars[3] = new SqlParameter("@Height", Height);
				pars[4] = new SqlParameter("@Link", Link);
				pars[5] = new SqlParameter("@Target", Target);
				pars[6] = new SqlParameter("@Content", Content);
				pars[7] = new SqlParameter("@Position", Position);
				pars[8] = new SqlParameter("@PageId", PageId);
				pars[9] = new SqlParameter("@Click", Click);
				pars[10] = new SqlParameter("@Ord", Ord);
				pars[11] = new SqlParameter("@Active", Active);

				db.ExecuteNonQuerySP("sp_Advertise_Insert", pars);

				
			}
			catch (Exception)
			{

				throw;
			}
		}
		public void Update()
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				SqlParameter[] pars = new SqlParameter[13];
				pars[0] = new SqlParameter("@Id", Id);
				pars[1] = new SqlParameter("@Name", Name);
				pars[2] = new SqlParameter("@Image", Image);
				pars[3] = new SqlParameter("@Width", Width);
				pars[4] = new SqlParameter("@Height", Height);
				pars[5] = new SqlParameter("@Link", Link);
				pars[6] = new SqlParameter("@Target", Target);
				pars[7] = new SqlParameter("@Content", Content);
				pars[8] = new SqlParameter("@Position", Position);
				pars[9] = new SqlParameter("@PageId", PageId);
				pars[10] = new SqlParameter("@Click", Click);
				pars[11] = new SqlParameter("@Ord", Ord);
				pars[12] = new SqlParameter("@Active", Active);

				db.ExecuteNonQuerySP("sp_Advertise_Update", pars);
			}
			catch (Exception)
			{
				throw;
			}	
		}
		public void Delete(string lstId)
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);

				db.ExecuteNonQuerySP("sp_Advertise_Delete", new SqlParameter("@Id", lstId));
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
