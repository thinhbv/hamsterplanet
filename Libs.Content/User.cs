using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime Date { get; set; }
		public int Admin { get; set; }
		public int Active { get; set; }

		public User()
		{

		}
		public List<User> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<User>("sp_User_GetByAll");
		}
		public static User Login(string user, string password)
		{
			string sSQL = "SELECT * FROM [User] WHERE UserName=@UserName AND Password=@Password AND Active=1";
			SqlCommand sqlCmd;
			SqlConnection mCon = null;
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				mCon = db.OpenConnection();
				sqlCmd = new SqlCommand(sSQL, mCon);
				sqlCmd.Parameters.Add(new SqlParameter("@UserName", user));
				sqlCmd.Parameters.Add(new SqlParameter("@Password", password));
				return db.GetInstance<User>(sqlCmd);
			}
			catch (Exception)
			{
				throw;
			}
		}
		public void UpdateActive()
		{
			string sSQL = "UPDATE [User] SET Active=@Active WHERE Id=@Id ";
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
		public User SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<User>("sp_User_GetById", new SqlParameter("@Id", Id));
		}
		public static List<User> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<User>("sp_User_GetByTop", pars);
		}
		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@UserName", UserName);
			pars[2] = new SqlParameter("@Password", Password);
			pars[3] = new SqlParameter("@Email", Email);
			pars[4] = new SqlParameter("@Phone", Phone);
			pars[5] = new SqlParameter("@Date", Date);
			pars[6] = new SqlParameter("@Admin", Admin);
			pars[7] = new SqlParameter("@Active", Active);


            db.ExecuteNonQuerySP("sp_User_Insert", pars);
            
            
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@Id", Id);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@UserName", UserName);
            pars[3] = new SqlParameter("@Password", Password);
            pars[4] = new SqlParameter("@Email", Email);
            pars[5] = new SqlParameter("@Phone", Phone);
            pars[6] = new SqlParameter("@Date", Date);
            pars[7] = new SqlParameter("@Admin", Admin);
            pars[8] = new SqlParameter("@Active", Active);

            db.ExecuteNonQuerySP("sp_User_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

            db.ExecuteNonQuerySP("sp_User_Delete", new SqlParameter("@Id", lstId));
		}
	}
}
