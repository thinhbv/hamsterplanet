using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Utils
{
	public class Consts
	{
		public enum KeyName
		{
			ProjectName,
			AdminServer
		}

        public enum Active
        {
            Hide,
            Show
        }

        public enum MenuPosition
        {
            Top,
            Middle,
            Bottom
        }

        public enum BannerPosition
        {
            Slider,
            Logo,
            Clients
        }

        public enum Categories
        {
            Nha_May,
            Benh_Vien,
            Toa_Nha,
            Thuong_Mai,
            Phong_Thuy
        }

        public enum PagePosition
        {
            Menu_Top,
            Menu_Main,
            Menu_Bottom,
            About,
            MiddlePage
        }
        public const int PERPAGE = 24;
		public const string PAGE_TITLE = " | Công ty cổ phần Dehun Việt Nam";
        public const string DICH_VU = "dich-vu";
        public const string TIN_TUC = "tin-tuc";
        public const string SAN_PHAM = "san-pham";
    }
}
