using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class GroupProduct
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string Level { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }
		public int Priority { get; set; }
		public int Position { get; set; }
		public int Items { get; set; }
		public string Description { get; set; }
		public string Keywords { get; set; }

		public GroupProduct()
		{

		}
		public List<GroupProduct> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<GroupProduct>("sp_GroupProduct_GetByAll");
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE GroupProduct SET Active=@Active WHERE Id=@Id ";
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
		public GroupProduct SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<GroupProduct>("sp_GroupProduct_GetById", new SqlParameter("@Id", Id));
		}

		public List<GroupProduct> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<GroupProduct>("sp_GroupProduct_GetByTop", pars);
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[10];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@Image", Image);
			pars[2] = new SqlParameter("@Level", Level);
			pars[3] = new SqlParameter("@Ord", Ord);
			pars[4] = new SqlParameter("@Active", Active);
			pars[5] = new SqlParameter("@Priority", Priority);
			pars[6] = new SqlParameter("@Position", Position);
			pars[7] = new SqlParameter("@Items", Items);
			pars[8] = new SqlParameter("@Description", Description);
			pars[9] = new SqlParameter("@Keywords", Keywords);

            db.ExecuteNonQuerySP("sp_GroupProduct_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[11];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Image", Image);
            pars[3] = new SqlParameter("@Level", Level);
            pars[4] = new SqlParameter("@Ord", Ord);
			pars[5] = new SqlParameter("@Active", Active);
			pars[6] = new SqlParameter("@Priority", Priority);
            pars[7] = new SqlParameter("@Position", Position);
            pars[8] = new SqlParameter("@Items", Items);
            pars[9] = new SqlParameter("@Description", Description);
            pars[10] = new SqlParameter("@Keywords", Keywords);

            db.ExecuteNonQuerySP("sp_GroupProduct_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_GroupProduct_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
