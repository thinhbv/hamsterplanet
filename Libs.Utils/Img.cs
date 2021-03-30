using System;
using System.Collections.Generic;
using System.Text;

namespace Libs.Utils
{
    public class Img
    {
        public static string SetTagImg(string sImageUrl, int nWidth)
        {
            string s;
            if (sImageUrl.Length > 0)
            {
                s = "<img src=\"" + sImageUrl + "\" alt=\"\" border=\"0\" width=\"" + nWidth.ToString() + "\" >";
            }
            else
            {
                s = "";
            }
            return s;
        }

        public static string GetImgUrl(string sTag)
        {
            string s;
            sTag = sTag.ToLower();
            int n, i, k;
            s = "";
            n = sTag.Length;
            k = sTag.IndexOf("src=\"");
            if (k >= 0)
            {
                k = k + 5;
                for (i = k; i < n; i++)
                {
                    if (sTag[i] == '"')
                    {
                        s = sTag.Substring(k, i - k);
                        break;
                    }
                }
            }
            n = s.Length;
            return s;
        }

        public static string GetTagImg(string sContent)
        {
            string s;
            sContent = sContent.ToLower();
            int n, i, k;
            s = "";
            n = sContent.Length;
            k = sContent.IndexOf("<img");
            if (k >= 0)
            {
                for (i = k; i < n; i++)
                {
                    if (sContent[i] == '>')
                    {
                        s = sContent.Substring(k, i - k + 1);
                        break;
                    }
                }
            }
            return s;
        }
    }
}
