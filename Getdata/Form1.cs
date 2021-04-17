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
using System.Drawing.Drawing2D;
using Spire.Xls;

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
        public void UpdateImage(string image, string name)
        {
            string connectionString = "data source=THINHBV;initial catalog=hamster;user id=sa;password=1qaz2wsx;MultipleActiveResultSets=True";

            string queryString = @"Update [dbo].[Product]
                         SET Image1 = @Image1 WHERE Name = @Name";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                try
                {
                    //This example assumes all the columns are varchar(500) in your database table design, you may
                    //likewise modify these to SqlDbType.Float, SqlDbType.DateTime etc. based on your design

                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 500).Value = name;
                    sqlCommand.Parameters.Add("@Image1", SqlDbType.VarChar, 500).Value = image;

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
        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text.Trim();
            var imgs = Directory.GetFiles(path);
            foreach (var item in imgs)
            {
                Image img = Image.FromFile(item);
                Bitmap bitmap = ResizeImage(img, 250, 250);
                bitmap.Save(path + @"/_thumbs/" + Path.GetFileName(item));
            }
        }
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int newWidth, int newHeight)
        {
            Image imgPhoto = image;

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();

            return bmPhoto;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\WorkSpace\SURDIAL_M32C\Admin\";
            string pathThumb = @"C:\WorkSpace\SURDIAL_M32C\Admin\";
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(textBox1.Text.Trim());
            for (int j = 1; j < workbook.Worksheets.Count; j++)
            {
                Worksheet sheet = workbook.Worksheets[j];
                int i = 5;
                foreach (var item in sheet.Pictures)
                {
                    ExcelPicture picture = (ExcelPicture)item;
                    CellRange cell = sheet.Range["B" + i];
                    string name = StringClass.NameToTag(cell.Value).Replace("\r\n", "");
                    string groupname = StringClass.NameToTag(sheet.Name);
                    if (!Directory.Exists(string.Format(path + @"{0}", groupname)))
                    {
                        Directory.CreateDirectory(string.Format(path + @"uploads\images\{0}", groupname));
                    }
                    picture.Picture.Save(string.Format(path + @"uploads\images\{0}\{1}.jpg", groupname, name), ImageFormat.Jpeg);
                    Bitmap bitmap = ResizeImage(picture.Picture, 250, 250);
                    if (!Directory.Exists(string.Format(pathThumb + @"{0}", groupname)))
                    {
                        Directory.CreateDirectory(string.Format(pathThumb + @"uploads\_thumbs\images\{0}", groupname));
                    }
                    bitmap.Save(string.Format(pathThumb + @"uploads\_thumbs\images\{0}\{1}.jpg", groupname, name));
                    UpdateImage(string.Format(@"uploads\images\{0}\{1}.jpg", groupname, name), cell.Value.Replace("\r\n", ""));
                    i++;
                }
            }
            
            MessageBox.Show("Done");
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
