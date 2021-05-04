using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image1 { get; set; }
		public string Image2 { get; set; }
		public string Image3 { get; set; }
		public string Image4 { get; set; }
		public string Image5 { get; set; }
		public string Content { get; set; }
		public string Detail { get; set; }
		public string Price { get; set; }
        public string Price1 { get; set; }
        public int GroupId { get; set; }
		public string GroupName { get; set; }
        public int IsHot { get; set; }
        public int IsPopular { get; set; }
		public int Ord { get; set; }
		public string Description { get; set; }
		public string Keywords { get; set; }
		public int Active { get; set; }

		public Product()
		{

		}
		public List<Product> SelectAll()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<Product>("sp_Product_GetByAll");
		}

		public List<Product> SelectByPaging(int currPage, int perpage, string level)
		{
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				return db.GetListSP<Product>("spProduct_PhanTrang", new SqlParameter("@currPage", currPage),
																	new SqlParameter("@recodperpage", perpage),
																	new SqlParameter("@Level", level));
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Product SelectById()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetInstanceSP<Product>("sp_Product_GetById", new SqlParameter("@Id", Id));
		}
		//public int GetTotalCount(string level)
		//{
		//	DbHelper db = new DbHelper(Config.ConnectionStrings);
		//	return db.GetInstance<int>("sp_Product_GetCount", new SqlParameter("@Level", level));
		//}
		#region[Product_GetCount]
		public int GetTotalCount(string level)
		{
			int total = 0;
			SqlDataReader dr = null;
			try
			{
				DbHelper db = new DbHelper(Config.ConnectionStrings);
				using (SqlCommand dbCmd = new SqlCommand("sp_Product_GetCount", db.OpenConnection()))
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
			}
			return total;
		}
		#endregion
		public void UpdateActive()
		{
			string sSQL = "UPDATE Product SET Active=@Active WHERE Id=@Id ";
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
		public static List<Product> SelectByTop(string top, string where, string ord)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[3];
			pars[0] = new SqlParameter("@Top", top);
			pars[1] = new SqlParameter("@Where", where);
			pars[2] = new SqlParameter("@Order", ord);
			return db.GetListSP<Product>("sp_Product_GetByTop", pars);
		}

		public void Insert()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[18];
			pars[0] = new SqlParameter("@Name", Name);
			pars[1] = new SqlParameter("@Image1", Image1);
			pars[2] = new SqlParameter("@Image2", Image2);
			pars[3] = new SqlParameter("@Image3", Image3);
			pars[4] = new SqlParameter("@Image4", Image4);
			pars[5] = new SqlParameter("@Image5", Image5);
			pars[6] = new SqlParameter("@Content", Content);
			pars[7] = new SqlParameter("@Detail", Detail);
			pars[8] = new SqlParameter("@Price", Price);
            pars[9] = new SqlParameter("@Price1", Price1);
            pars[10] = new SqlParameter("@GroupId", GroupId);
			pars[11] = new SqlParameter("@GroupName", GroupName);
			pars[12] = new SqlParameter("@IsHot", IsHot);
			pars[13] = new SqlParameter("@IsPopular", IsPopular);
			pars[14] = new SqlParameter("@Ord", Ord);
			pars[15] = new SqlParameter("@Description", Description);
			pars[16] = new SqlParameter("@Keywords", Keywords);
			pars[17] = new SqlParameter("@Active", Active);
			db.ExecuteNonQuerySP("sp_Product_Insert", pars);

			//
		}
		public void Update()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			SqlParameter[] pars = new SqlParameter[19];
			pars[0] = new SqlParameter("@Id", Id);
			pars[1] = new SqlParameter("@Name", Name);
			pars[2] = new SqlParameter("@Image1", Image1);
			pars[3] = new SqlParameter("@Image2", Image2);
			pars[4] = new SqlParameter("@Image3", Image3);
			pars[5] = new SqlParameter("@Image4", Image4);
			pars[6] = new SqlParameter("@Image5", Image5);
			pars[7] = new SqlParameter("@Content", Content);
			pars[8] = new SqlParameter("@Detail", Detail);
			pars[9] = new SqlParameter("@Price", Price);
            pars[10] = new SqlParameter("@Price1", Price1);
            pars[11] = new SqlParameter("@GroupId", GroupId);
			pars[12] = new SqlParameter("@GroupName", GroupName);
			pars[13] = new SqlParameter("@IsHot", IsHot);
			pars[14] = new SqlParameter("@IsPopular", IsPopular);
			pars[15] = new SqlParameter("@Ord", Ord);
			pars[16] = new SqlParameter("@Description", Description);
			pars[17] = new SqlParameter("@Keywords", Keywords);
			pars[18] = new SqlParameter("@Active", Active);

			db.ExecuteNonQuerySP("sp_Product_Update", pars);
		}
		public void Delete(string lstId)
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);

			db.ExecuteNonQuerySP("sp_Product_Delete", new SqlParameter("@Id", lstId));
		}
	}
	public class CountTotal
	{
		public int GroupId { get; set; }
		public int Count { get; set; }
		public CountTotal()
		{

		}

		public List<CountTotal> SelectCount()
		{
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			return db.GetListSP<CountTotal>("sp_Product_GetCountByGroupId");
		}
	}
}
