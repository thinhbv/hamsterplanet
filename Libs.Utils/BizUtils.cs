using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Libs.Utils
{
	public class BizUtils
	{
		public static string GetConfig(string keyname)
		{
			return ConfigurationManager.AppSettings[keyname].ToString();
		}
		public static string GetQueryString(string keyname, HttpRequest request)
		{
			if (request.QueryString[keyname] == null)
			{
				return string.Empty;
			}
			return request.QueryString[keyname].ToString();
		}
		public static string[] ConvertToArray(string strConv)
		{
			string[] myArr;
			if (strConv.IndexOf(",") < 0)
			{
				myArr = new string[] { "0," + strConv };
			}
			else
			{
				myArr = strConv.Split(',');
				for (int i = 0; i < myArr.Length; i++)
				{
					myArr[i] = i.ToString() + "," + myArr[i];
				}
			}
			return myArr;
		}
		public static string ShowStatusCart(string status, string myString)
		{
			string[] myArr = ConvertToArray(myString);
			string strString = "";
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(status))
				{
					strString = arr[1];
					break;
				}
			}
			switch (status)
			{
				case "0":
					return string.Format("<span class=\"label label-danger\">{0}</span>", strString);
				case "1":
					return string.Format("<span class=\"label label-warning\">{0}</span>", strString);
				case "3":
					return string.Format("<span class=\"label label-primary\">{0}</span>", strString);
				default:
					return string.Format("<span class=\"label label-success\">{0}</span>", strString);
			}
		}
		public static string ShowStatus(string status)
		{
			string[] myArr = new string[] { "0,Ẩn", "1,Hiển thị" };
			string strString = "";
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(status))
				{
					strString = arr[1];
					break;
				}
			}
			switch (status)
			{
				case "0":
					return string.Format("<span class=\"label label-primary\">{0}</span>", strString);
				default:
					return string.Format("<span class=\"label label-success\">{0}</span>", strString);
			}
		}
		public static string ShowPageType(string type)
		{
			string[] myArr = new string[] { "0,Trang liên kết", "1,Trang nội dung" };
			string strString = "";
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(type))
				{
					strString = arr[1];
					break;
				}
			}
			switch (type)
			{
				case "0":
					return string.Format("<span class=\"label label-primary\">{0}</span>", strString);
				default:
					return string.Format("<span class=\"label label-success\">{0}</span>", strString);
			}
		}

		public static string ShowPositionAdvertise(string type)
		{
			string[] myArr = new string[] { "0,Banner", "1,Logo", "2,Quảng cáo" };
			string strString = "";
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(type))
				{
					strString = arr[1];
					break;
				}
			}
			switch (type)
			{
				case "0":
					return string.Format("<span class=\"label label-primary\">{0}</span>", strString);
				default:
					return string.Format("<span class=\"label label-success\">{0}</span>", strString);
			}
		}

		public static string ShowPagePosition(string position)
		{
			string[] myArr = new string[] { "0,Menu trên", "1,Menu giữa", "2,Menu dưới", "3,Giới thiệu", "4,Giữa trang" };
			string strReturn = string.Empty;
			string strString = "";
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (position.Contains(arr[0]))
				{
					strString = arr[1];
					strReturn += string.Format("<span class=\"label label-success\">{0}</span>", strString);
				}
			}
			return strReturn;
		}

		public static void LoadDropDownList(DropDownList ddl, string StringArray)
		{
			string[] myArr = ConvertToArray(StringArray);
			List<ListItem> items = StringArray2ListItem(myArr);
			for (int i = 0; i < items.Count; i++)
			{
				ddl.Items.Add(items[i]);
			}
			ddl.DataBind();
		}

		public static void LoadDropDownList(HtmlSelect ddl, string StringArray)
		{
			string[] myArr = ConvertToArray(StringArray);
			List<ListItem> items = StringArray2ListItem(myArr);
			for (int i = 0; i < items.Count; i++)
			{
				ddl.Items.Add(items[i]);
			}
			ddl.DataBind();
		}

		public static List<ListItem> StringArray2ListItem(string[] StringArray)
		{
			char[] splitter = { ',', ';' };
			List<ListItem> list = new List<ListItem>();
			for (int i = 0; i < StringArray.Length; i++)
			{
				string[] arr = StringArray[i].Split(splitter);
				if (arr.Length > 1)
				{
					list.Add(new ListItem(arr[1], arr[0]));
				}
				else
				{
					list.Add(new ListItem(arr[0], arr[0]));
				}
			}
			return list;
		}

		public static string ConvertPrice(string price)
		{
			if (price.Length > 0)
			{
				if (price.Length > 3)
				{
					int Length = price.Length;
					while (Length > 3)
					{
						price = price.Insert(Length - 3, ".");
						Length = Length - 3;
					}
					return price + " ₫";
				}
				else
				{
					return price + " ₫";
				}
			}
			else
			{
				return "0 ₫";
			}
		}
		#region[FormatContentNews]
		public static string SubStringByLength(string value, int count)
		{
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
			string _value = value;
			if (_value.Length >= count)
			{
				string ValueCut = _value.Substring(0, count - 3);
				string[] valuearray = ValueCut.Split(' ');
				string valuereturn = "";
				for (int i = 0; i < valuearray.Length - 1; i++)
				{
					valuereturn = valuereturn + " " + valuearray[i];
				}
				return valuereturn + "...";
			}
			else
			{
				return _value;
			}
		}
		#endregion
		public static string ShowCheckBoxStatus(string val)
		{
			if (val == "1")
			{
				return "<i class='fa fa-check-circle fa-lg text-success'></i>";
			}
			else
			{
				return "<i class='fa fa-times-circle fa-lg text-danger'></i>";
			}
		}
	}
}
