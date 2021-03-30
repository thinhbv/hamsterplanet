using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Contact
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Company { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Website { get; set; }
		public string Title { get; set; }
		public string Detail { get; set; }
		public DateTime Date { get; set; }

		public Contact()
		{

		}
		public List<Contact> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<Contact>("sp_Contact_GetByAll");
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@Company", Company);
			pars[2] = new SqlParameter("@Email", Email);
			pars[3] = new SqlParameter("@Phone", Phone);
			pars[4] = new SqlParameter("@Website", Website);
			pars[5] = new SqlParameter("@Title", Title);
			pars[6] = new SqlParameter("@Detail", Detail);
			pars[7] = new SqlParameter("@Date", Date);


            db.ExecuteNonQuerySP("sp_Contact_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Company", Company);
            pars[3] = new SqlParameter("@Email", Email);
            pars[4] = new SqlParameter("@Phone", Phone);
            pars[5] = new SqlParameter("@Website", Website);
            pars[6] = new SqlParameter("@Title", Title);
            pars[7] = new SqlParameter("@Detail", Detail);
            pars[8] = new SqlParameter("@Date", Date);

            db.ExecuteNonQuerySP("sp_Contact_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_Contact_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
