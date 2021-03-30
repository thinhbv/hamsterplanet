using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libs.Db;
using System.Data.SqlClient;
using System.Data;

namespace Libs.Content
{
    public sealed class Config
    {
        private static readonly Config instance = new Config();

		private string _ConnectionStrings;

        public static string ConnectionStrings
        {
            get
            {
                return instance._ConnectionStrings;
            }
        }
        public Config()
        {
			_ConnectionStrings = GetConnectionString("ConnectionStrings");
        }

        public string GetConnectionString(string Name)
        {
            if (ConfigurationManager.ConnectionStrings[Name] == null) return "";
            //RijndaelEnhanced rijndaelKey = new RijndaelEnhanced("20b2", "@1B2c3D4e5F6g7H8");
            //return rijndaelKey.Decrypt(ConfigurationManager.ConnectionStrings[Name].ConnectionString);
			return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }
		public static string GetMaxOrd(string Table, string level, bool isLevel = false)
		{
			string strReturn = "";
			DbHelper db = new DbHelper(Config.ConnectionStrings);
			if (string.IsNullOrEmpty(level))
			{
				if (isLevel)
				{
					strReturn = db.ExecuteScalar("SELECT max(Ord) as Ord FROM [" + Table + "] WHERE LEN(Level)=" + (level.Length + 5)).ToString();
				}
				else
				{
					strReturn = db.ExecuteScalar("SELECT max(Ord) as Ord FROM [" + Table + "]").ToString();
				}
			}
			else
			{
				strReturn = db.ExecuteScalar("SELECT max(Ord) as Ord FROM [" + Table + "] WHERE LEN(Level)=" + (level.Length + 5) + " AND LEFT(Level," + level.Length + ")='" + level + "'").ToString();
			}
			if (string.IsNullOrEmpty(strReturn))
			{
				strReturn = "0";
			}
			return (int.Parse(strReturn) + 1).ToString();
		}
        public static Config Instance
        {
            get { return instance; }
        }
    }
}
