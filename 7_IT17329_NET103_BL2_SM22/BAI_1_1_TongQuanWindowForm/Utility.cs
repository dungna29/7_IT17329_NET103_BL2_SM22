using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    internal class Utility
    {
        // Nguyễn Anh Dũng => dungna
        public static string GetMaTuSinh(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            string temp = value.Trim().ToLower();//Cắt khoảng trắng 2 đầu và đưa về chữ thường. => nguyễn anh dũng
            string[] arrNames = temp.Split(' ');//Cắt chuỗi về mảng
            string final = GetVietHoaChuCaiDau(arrNames[arrNames.Length - 1]).Trim();//Dung
            for (int i = 0; i < arrNames.Length - 1; i++)
            {
                final += GetChuCaiDau(arrNames[i]);
            }

            return ConvertToUnsign(final);//Dungna
        }

        public static string VietHoaChuCaiDau(string value)//nguyễn ANH DŨNG
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            string temp = value.Trim().ToLower();//Cắt khoảng trắng 2 đầu và đưa về chữ thường. => nguyễn anh dũng
            string[] arrNames = temp.Split(' ');//Cắt chuỗi về mảng
            string final = "";//Dung
            for (int i = 0; i < arrNames.Length; i++)
            {
                final += GetVietHoaChuCaiDau(arrNames[i]);
            }

            return final;//Dungna
        }

        public static string GetChuCaiDau(string value)//nguyễn
        {
            return Convert.ToString(value[0]);//= n
        }

        public static string GetVietHoaChuCaiDau(string value)//nguyễn
        {
            return Convert.ToString(value[0]).ToUpper() + value.Substring(1) + " ";//= Nguyễn
        }

        //Loại bỏ tiếng việt
        private static Regex ConvertToUnsign_rg = null;

        public static string ConvertToUnsign(string str)
        {
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc =
                    System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }
}