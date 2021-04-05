using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Libs.Utils;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Data.SqlClient;

namespace Getdata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cnt;
            var driver = new ChromeDriver();
            driver.Url = textBox1.Text;
            Thread.Sleep(4000);
            //var ele = driver.FindElementByClassName("shopee-page-controller");
            //Actions ac = new Actions(driver);
            //ac.MoveToElement(ele);
            //ac.Perform();
            //Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            var items = driver.FindElementsByClassName("shop-search-result-view__item");
            cnt = 0;
            int groupid = 4;
            string groupname = "Phụ kiện khác";
            //int groupid = InsertDataGroup(groupname);
            foreach (var item in items)
            {
                Products pro = new Products();
                var data = item.FindElement(By.ClassName("_36CEnF"));
                pro.Name = data.Text;
                //var price = item.FindElement(By.ClassName("_3_-SiN"));
                //if (price != null)
                //{
                //    pro.Price = "₫" + price.Text;
                //}
                var price1 = item.FindElements(By.ClassName("_29R_un"));
                if (price1.Count == 1)
                {
                    pro.Price = "₫" + price1[0].Text;
                }
                if (price1.Count == 2)
                {
                    pro.Price = "₫" + price1[0].Text + " - ₫" + price1[1].Text;
                }

                var img = item.FindElements(By.TagName("img"));
                pro.Image = img[0].GetAttribute("src");
                if (!File.Exists("Images\\" + StringClass.NameToTag(pro.Name) + ".jpg") && pro.Image != null)
                {
                    SaveImage("Images\\" + StringClass.NameToTag(pro.Name) + ".jpg", ImageFormat.Jpeg, pro.Image);
                }
                pro.Image = "\\Images\\" + StringClass.NameToTag(pro.Name) + ".jpg";
                cnt++;
                InsertData(cnt, pro, groupid, groupname);
            }
            Activate();
            MessageBox.Show("Get " + cnt.ToString() + " products");
        }
        
        public void SaveImage(string filename, ImageFormat format, string imageUrl)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
        public int InsertDataGroup( string groupName)
        {
            string connectionString = "data source=THINHBV;initial catalog=hamster;user id=sa;password=1qaz2wsx;MultipleActiveResultSets=True";
            string queryString = @"INSERT INTO [dbo].[GroupProduct]
                                ([Name]
                                ,[Image]
                                ,[Level]
                                ,[Ord]
                                ,[Active]
                                ,[Position]
                                ,[Priority]
                                ,[Items]
                                ,[Description]
                                ,[Keywords])
                            VALUES
                                (@Name
                                ,null
                                ,'00001'
                                ,1
                                ,1
                                ,1
                                ,1
                                ,1
                                ,null
                                ,null)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                try
                {
                    //This example assumes all the columns are varchar(500) in your database table design, you may
                    //likewise modify these to SqlDbType.Float, SqlDbType.DateTime etc. based on your design

                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 500).Value = groupName;

                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    

                }

                catch (Exception ex)
                {
                    return 0;
                }

            }
            queryString = "  Select Max(Id) FROM [hamster].[dbo].[GroupProduct]";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                try
                {
                    //This example assumes all the columns are varchar(500) in your database table design, you may
                    //likewise modify these to SqlDbType.Float, SqlDbType.DateTime etc. based on your design
                  

                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    int i = (int)sqlCommand.ExecuteScalar();
                    sqlConnection.Close();

                    return i;
                }

                catch (Exception ex)
                {
                    return 0;
                }

            }
        }
        public void InsertData(int idx, Products pro, int groupid, string groupName)
        {
            string connectionString = "data source=THINHBV;initial catalog=hamster;user id=sa;password=1qaz2wsx;MultipleActiveResultSets=True";

            string queryString = @"INSERT INTO [dbo].[Product]
                               ([Name]
                               ,[Image1]
                               ,[Image2]
                               ,[Image3]
                               ,[Image4]
                               ,[Image5]
                               ,[Content]
                               ,[Detail]
                               ,[Price]
                               ,[Price1]
                               ,[GroupId]
                               ,[GroupName]
                               ,[IsHot]
                               ,[IsPopular]
                               ,[IsSpecial]
                               ,[IsNew]
                               ,[Ord]
                               ,[Description]
                               ,[Keywords]
                               ,[Active])
                         VALUES
                               (@Name
                               ,@Image1
                               ,null
                               ,null
                               ,null
                               ,null
                               ,null
                               ,null
                               ,@Price
                               ,null
                               ,@GroupId
                               ,@GroupName
                               ,1
                               ,1
                               ,1
                               ,1
                               ,@Ord
                               ,null
                               ,null
                               ,1)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                try
                {
                    //This example assumes all the columns are varchar(500) in your database table design, you may
                    //likewise modify these to SqlDbType.Float, SqlDbType.DateTime etc. based on your design

                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 500).Value = pro.Name;
                    sqlCommand.Parameters.Add("@Image1", SqlDbType.NVarChar, 500).Value = pro.Image;
                    sqlCommand.Parameters.Add("@Price", SqlDbType.NVarChar, 500).Value = pro.Price;
                    sqlCommand.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupid;
                    sqlCommand.Parameters.Add("@GroupName", SqlDbType.NVarChar, 500).Value = groupName;
                    sqlCommand.Parameters.Add("@Ord", SqlDbType.Int).Value = idx;

                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }

    public class Products
    {
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Price1 { get; set; }
    }
}
