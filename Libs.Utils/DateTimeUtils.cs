using System;
using System.Collections.Generic;
using System.Text;

namespace Libs.Utils
{
    public class DateTimeUtils
    {
        // Trả về dạng: Thứ sáu, ngày 08/01/2010
        public static string ReadDay(DateTime d)
        {
            string s = "";
            switch (Convert.ToInt32(d.DayOfWeek))
            {
                case 0:
                    s = "Chủ nhật";
                    break;
                case 1:
                    s = "Thứ hai";
                    break;
                case 2:
                    s = "Thứ ba";
                    break;
                case 3:
                    s = "Thứ tư";
                    break;
                case 4:
                    s = "Thứ năm";
                    break;
                case 5:
                    s = "Thứ sáu";
                    break;
                case 6:
                    s = "Thứ bảy";
                    break;
            }
            return s + ", ngày " + d.ToString("dd/MM/yyyy");
        }
    }
}
