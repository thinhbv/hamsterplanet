using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Libs.Db
{
    public class MySQLHelper
    {
        public string ConnectionString { get; set; }
        public MySqlConnection ConnectionToDB { get; set; }

        # region Open, close connection string
        /// <summary>
        /// Chuẩn hoá pooling cho connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="pooling">Có chuẩn hoá hay không</param>
        /// <returns></returns>
        public string FixConnectionString(string connectionString, bool pooling)
        {
            connectionString = connectionString.ToLower();
            string[] list = connectionString.Split(';');
            string s = "";

            for (int i = 0; i < list.Length; i++)
            {
                if (
                    !list[i].ToLower().StartsWith("pooling=")
                    && !list[i].ToLower().StartsWith("min pool size=")
                    && !list[i].ToLower().StartsWith("max pool size=")
                    && !list[i].ToLower().StartsWith("connect timeout=")
                    && !list[i].Equals("")
                    )
                {
                    s += list[i] + ";";
                }
            }

            if (pooling)
            {
                s += "Pooling=true;Min Pool Size=1;Max Pool Size=15;Connect Timeout=2;Connection Reset = True;Connection Lifetime = 600;";
            }
            else
            {
                s += "Pooling=false;Connect Timeout=45;";
            }
            return s;
        }

        /// <summary>
        /// Mở kết nối
        /// </summary>
        public MySqlConnection OpenConnection()
        {
            if (ConnectionString == "")
            {
                throw new Exception("Connection String can not null");
            }

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(FixConnectionString(ConnectionString, true));
                mySqlConnection.Open();
                return mySqlConnection;
            }
            catch (Exception)
            {
                MySqlConnection mySqlConnection = new MySqlConnection(FixConnectionString(ConnectionString, false));
                mySqlConnection.Open();
                return mySqlConnection;
            }
        }

        /// <summary>
        /// Mở kết nối
        /// </summary>
        public MySqlConnection OpenConnection(string connectionString)
        {
            ConnectionString = connectionString;
            return OpenConnection();
        }

        /// <summary>
        /// Đóng kết nối
        /// </summary>
        public void CloseConnection(MySqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null && mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        #endregion

        # region GetDataTable
        public DataTable GetDataTable(MySqlCommand sqlCommand)
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

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(sqlCommand);
                var dt = new DataTable();
                myDataAdapter.Fill(dt);
                myDataAdapter.Dispose();
                return dt;
            }
            catch (MySqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public DataTable GetDataTable(MySqlCommand sqlCommand, params MySqlParameter[] pars)
        {
            foreach (MySqlParameter par in pars)
            {
                sqlCommand.Parameters.Add(par);
            }
            return GetDataTable(sqlCommand);
        }

        public DataTable GetDataTable(string cmdText)
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            return GetDataTable(sqlCommand);
        }

        public DataTable GetDataTable(string cmdText, params MySqlParameter[] pars)
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            return GetDataTable(sqlCommand, pars);
        }
        #endregion

        # region ExecuteScalar
        public object ExecuteScalar(MySqlCommand sqlCommand)
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
                return sqlCommand.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public object ExecuteScalar(MySqlCommand sqlCommand, params MySqlParameter[] pars)
        {
            foreach (MySqlParameter par in pars)
            {
                sqlCommand.Parameters.Add(par);
            }
            return ExecuteScalar(sqlCommand);
        }

        public object ExecuteScalar(string cmdText)
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            return ExecuteScalar(sqlCommand);
        }

        public object ExecuteScalar(string cmdText, params MySqlParameter[] pars)
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            return ExecuteScalar(sqlCommand, pars);
        }
        #endregion

        # region ExecuteNonQuery
        public int ExecuteNonQuery(MySqlCommand sqlCommand)
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
            catch (MySqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public int ExecuteNonQuery(MySqlCommand sqlCommand, params MySqlParameter[] pars)
        {
            foreach (MySqlParameter par in pars)
            {
                sqlCommand.Parameters.Add(par);
            }
            return ExecuteNonQuery(sqlCommand);
        }

        public int ExecuteNonQuery(string cmdText)
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            return ExecuteNonQuery(sqlCommand);
        }

        public int ExecuteNonQuery(string cmdText, params MySqlParameter[] pars)
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            return ExecuteNonQuery(sqlCommand, pars);
        }
        #endregion

        #region[ListGenerate]
        public List<T> GetList<T>(MySqlCommand sqlCommand)
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
                            m_Type.GetProperty(pName).SetValue(obj, dr[i], null);
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
            catch (MySqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public List<T> GetList<T>(MySqlCommand sqlCommand, params MySqlParameter[] pars)
        {
            sqlCommand.Parameters.Add(pars);
            return GetList<T>(sqlCommand);
        }

        public List<T> GetList<T>(string cmdText)
        {
            var sqlCommand = new MySqlCommand(cmdText);
            return GetList<T>(sqlCommand);
        }

        public List<T> GetList<T>(string cmdText, params MySqlParameter[] pars)
        {
            var sqlCommand = new MySqlCommand(cmdText);
            sqlCommand.Parameters.Add(pars);
            return GetList<T>(sqlCommand);
        }
        #endregion

        #region[GetInstance]
        public T GetInstance<T>(MySqlCommand sqlCommand)
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
            catch (MySqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                CloseConnection(sqlCommand.Connection);
            }
        }

        public T GetInstance<T>(MySqlCommand sqlCommand, params MySqlParameter[] pars)
        {
            sqlCommand.Parameters.Add(pars);
            return GetInstance<T>(sqlCommand);
        }

        public T GetInstance<T>(string cmdText)
        {
            var sqlCommand = new MySqlCommand(cmdText);
            return GetInstance<T>(sqlCommand);
        }

        public T GetInstance<T>(string cmdText, params MySqlParameter[] pars)
        {
            var sqlCommand = new MySqlCommand(cmdText);
            sqlCommand.Parameters.Add(pars);
            return GetInstance<T>(sqlCommand);
        }
        #endregion
    }
}
