using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Tags
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string Link { get; set; }
		public int Ord { get; set; }
		public int Active { get; set; }

		public Tags()
		{

		}
		public List<Tags> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<Tags>("sp_Tags_GetByAll");
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Title", Title);
            pars[3] = new SqlParameter("@Link", Link);
            pars[4] = new SqlParameter("@Ord", Ord);
            pars[5] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_Tags_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Title", Title);
            pars[3] = new SqlParameter("@Link", Link);
            pars[4] = new SqlParameter("@Ord", Ord);
            pars[5] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_Tags_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_Tags_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
