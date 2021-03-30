using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// Summary description for DbHelper
/// 2009-08-08 11:24:05
/// </summary>
namespace Libs.Db
{
    public class DbHelper
    {
        private string ConnectionString { get; set; }
        public SqlConnection ConnectionToDB { get; set; }

        public DbHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #region Open, close connection string
        /// <summary>
        /// Chuẩn hoá connection string
        /// </summary>
        public string FixConnectionString(string connectionString, bool pooling)
        {
            string[] list = connectionString.Split(';');
            var s = "";

            for (var i = 0; i < list.Length; i++)
            {
                if (
                    !list[i].StartsWith("Pooling=") &&
                    !list[i].StartsWith("Min Pool Size=") &&
                    !list[i].StartsWith("Max Pool Size=") &&
                    !list[i].StartsWith("Connect Timeout=") &&                     
                    !list[i].Equals("")
                    ) s += list[i] + ";";
                    
            }

            if (pooling)
            {
                s += "Pooling=true;Min Pool Size=1;Max Pool Size=15;Connect Timeout=2;";
            }
            else
            {
                s += "Pooling=false;Connect Timeout=45;";
            }
            return s;
        }

        public void Open()
        {
            ConnectionToDB = OpenConnection();
        }

        public void Close()
        {
            CloseConnection(ConnectionToDB);
        }

        public SqlConnection OpenConnection()
        {
            if (ConnectionString == "")
            {
                throw new Exception("Connection String can not null");
            }

            try
            {
                SqlConnection sqlConnection;
                sqlConnection = new SqlConnection(FixConnectionString(ConnectionString, true));
                sqlConnection.Open();
                return sqlConnection;
            }
            catch
            {
                SqlConnection sqlConnection;
                sqlConnection = new SqlConnection(FixConnectionString(ConnectionString, false));
                sqlConnection.Open();
                return sqlConnection;
            }
        }

        public SqlConnection OpenConnection(string connectionString)
        {
            ConnectionString = connectionString;
            return OpenConnection();
        }

        public void CloseConnection(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        #endregion

        # region GetDataTable
        public DataTable GetDataTable(SqlCommand sqlCommand)
        {
            try
            {
                if (ConnectionToDB == null)
                {
                    sqlCommand.Connection = OpenConnection();
                }
                else
                {
                    sqlCommand.Connection = ConnectionToDB;
                }
                var myDataAdapter = new SqlDataAdapter(sqlCommand);
                var dt = new DataTable();
                myDataAdapter.Fill(dt);
                myDataAdapter.Dispose();
                return dt;
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public DataTable GetDataTable(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            sqlCommand.Parameters.AddRange(Parameters);
            return GetDataTable(sqlCommand);
        }

        public DataTable GetDataTable(string strSQL)
        {
            var sqlCommand = new SqlCommand(strSQL);
            return GetDataTable(sqlCommand);
        }

        public DataTable GetDataTable(string strSQL, params SqlParameter[] Parameters)
        {
            var sqlCommand = new SqlCommand(strSQL);
            return GetDataTable(sqlCommand, Parameters);
        }
        #endregion

        #region GetDataTableSP
        public DataTable GetDataTableSP(string spName)
        {
            var sqlCommand = new SqlCommand(spName) { CommandType = CommandType.StoredProcedure };
            return GetDataTable(sqlCommand);
        }

        public DataTable GetDataTableSP(string spName, params SqlParameter[] pars)
        {
            var sqlCommand = new SqlCommand(spName) { CommandType = CommandType.StoredProcedure };
            return GetDataTable(sqlCommand, pars);
        }
        #endregion

        //#region ExecuteScalarSP
        //public object ExecuteScalarSP(string spName)
        //{
        //    var sqlCommand = new SqlCommand(spName) { CommandType = CommandType.StoredProcedure };
        //    return ExecuteScalar(sqlCommand);
        //}

        //public object ExecuteScalarSP(string spName, params SqlParameter[] pars)
        //{
        //    var sqlCommand = new SqlCommand(spName) { CommandType = CommandType.StoredProcedure };
        //    return ExecuteScalar(sqlCommand, pars);
        //}
        //#endregion

        # region ExecuteNonQuery
        public int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            try
            {
                if (ConnectionToDB == null)
                {
                    sqlCommand.Connection = OpenConnection();
                }
                else
                {
                    sqlCommand.Connection = ConnectionToDB;
                }
                return sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public int ExecuteNonQuery(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            sqlCommand.Parameters.AddRange(Parameters);
            return ExecuteNonQuery(sqlCommand);
        }

        public int ExecuteNonQuery(string strSQL)
        {
            var sqlCommand = new SqlCommand(strSQL);
            return ExecuteNonQuery(sqlCommand);
        }

        public int ExecuteNonQuery(string strSQL, params SqlParameter[] Parameters)
        {
            var sqlCommand = new SqlCommand(strSQL);
            return ExecuteNonQuery(sqlCommand, Parameters);
        }
        #endregion

        #region ExecuteNonQuerySP
        public int ExecuteNonQuerySP(string spName)
        {
            var sqlCommand = new SqlCommand(spName) { CommandType = CommandType.StoredProcedure };
            return ExecuteNonQuery(sqlCommand);
        }

        public int ExecuteNonQuerySP(string spName, params SqlParameter[] pars)
        {
            var sqlCommand = new SqlCommand(spName) { CommandType = CommandType.StoredProcedure };
            return ExecuteNonQuery(sqlCommand, pars);
        }
        #endregion

        #region[ListGenerate]
        public List<T> GetList<T>(SqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection = ConnectionToDB ?? OpenConnection();
                var dr = sqlCommand.ExecuteReader();
                if (dr == null || dr.FieldCount == 0) return null;
                var fCount = dr.FieldCount;
                var m_Type = typeof(T);
                var l_Property = m_Type.GetProperties();
                object obj;
                var m_List = new List<T>();
                string pName;
                while (dr.Read())
                {
                    obj = Activator.CreateInstance(m_Type);
                    for (var i = 0; i < fCount; i++)
                    {
                        pName = dr.GetName(i);
                        if (l_Property.Where(a => a.Name == pName).Select(a => a.Name).Count() <= 0) continue;
                        if (dr[i] != DBNull.Value)
                        {
                            m_Type.GetProperty(pName).SetValue(obj,dr[i],null);
                        }
                        else
                        {
                            m_Type.GetProperty(pName).SetValue(obj, null, null);
                        }
                    }
                    m_List.Add((T)obj);
                }
                dr.Close();
                return m_List;
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {

                CloseConnection(sqlCommand.Connection);

            }
        }

        public List<T> GetList<T>(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            sqlCommand.Parameters.AddRange(Parameters);
            return GetList<T>(sqlCommand);
        }

        public List<T> GetList<T>(string strSQL)
        {
            var sqlCommand = new SqlCommand(strSQL);
            return GetList<T>(sqlCommand);
        }

        public List<T> GetList<T>(string strSQL, params SqlParameter[] Parameters)
        {
            var sqlCommand = new SqlCommand(strSQL);
            sqlCommand.Parameters.AddRange(Parameters);
            return GetList<T>(sqlCommand);
        }
        #endregion

        #region[ListGenerateSP]
        public List<T> GetListSP<T>(string SPName)
        {
            var sqlCommand = new SqlCommand(SPName) { CommandType = CommandType.StoredProcedure };
            return GetList<T>(sqlCommand);
        }

        public List<T> GetListSP<T>(string SPName, params SqlParameter[] Parameters)
        {
            var sqlCommand = new SqlCommand(SPName) { CommandType = CommandType.StoredProcedure };
            return GetList<T>(sqlCommand, Parameters);
        }
        #endregion

        #region[GetInstance]
        public T GetInstance<T>(SqlCommand sqlCommand)
        {
            try
            {
                T temp = default(T);

                sqlCommand.Connection = ConnectionToDB ?? OpenConnection();
                var dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    var fCount = dr.FieldCount;
                    var m_Type = typeof(T);
                    var l_Property = m_Type.GetProperties();
                    object obj;
                    var m_List = new List<T>();
                    string pName;

                    obj = Activator.CreateInstance(m_Type);
                    for (var i = 0; i < fCount; i++)
                    {
                        pName = dr.GetName(i);
                        if (l_Property.Where(a => a.Name == pName).Select(a => a.Name).Count() <= 0) continue;
                        if (dr[i] != DBNull.Value)
                        {
                            m_Type.GetProperty(pName).SetValue(obj, dr[i], null);
                        }
                        else
                        {
                            m_Type.GetProperty(pName).SetValue(obj, null, null);
                        }
                    }
                    dr.Close();
                    return (T)obj;
                }
                else
                {
                    return temp;
                }
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public T GetInstance<T>(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            sqlCommand.Parameters.AddRange(Parameters);
            return GetInstance<T>(sqlCommand);
        }

        public T GetInstance<T>(string strSQL)
        {
            var sqlCommand = new SqlCommand(strSQL);
            return GetInstance<T>(sqlCommand);
        }

        public T GetInstance<T>(string strSQL, params SqlParameter[] Parameters)
        {
            var sqlCommand = new SqlCommand(strSQL);
            sqlCommand.Parameters.AddRange(Parameters);
            return GetInstance<T>(sqlCommand);
        }
        #endregion

        #region[GetInstanceSP]
        public T GetInstanceSP<T>(string SPName)
        {
            var sqlCommand = new SqlCommand(SPName) { CommandType = CommandType.StoredProcedure };
            return GetInstance<T>(sqlCommand);
        }

        public T GetInstanceSP<T>(string SPName, params SqlParameter[] Parameters)
        {
            var sqlCommand = new SqlCommand(SPName) { CommandType = CommandType.StoredProcedure };
            return GetInstance<T>(sqlCommand, Parameters);
        }
        #endregion
		#region[SqlInjection]
		public string SqlInjection(string param)
		{
			return param.Replace("'", "''");
		}
		#endregion
		public object ExecuteScalar(string sql)
		{
			return ExecuteScalar(GetCommand(sql));
		}
		public object ExecuteScalar(SqlCommand cmd)
		{
			try
			{
				if (cmd.Connection == null) { cmd.Connection = OpenConnection(); }
				return cmd.ExecuteScalar();
			}
			finally
			{
				if (cmd.Connection != null)
				{
					cmd.Connection.Close();
				}
			}
		}

		private SqlCommand GetCommand(string sql)
		{
			SqlCommand cmd = new SqlCommand(sql, OpenConnection());
			return cmd;
		}
    }
}
