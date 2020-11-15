using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ComputerStore.Utility
{
    public static class CongCu
    {
        public static string ChuanHoaXau(string xau)
        {
            string s = xau.Trim();
            while (s.IndexOf("  ") >= 0)
                s = s.Remove(s.IndexOf("  "), 1);
            string[] a = s.Split(' ');
            s = "";
            for (int i = 0; i < a.Length; ++i)
                s = s + " " + char.ToUpper(a[i][0]) + a[i].Substring(1).ToLower();
            return s.Trim();
        }
        public static string CatXau(string xau)
        {
            string s = xau.Trim();
            while (s.IndexOf("  ") >= 0)
                s = s.Remove(s.IndexOf("  "), 1);
            return s;
        }
        public static string ChuanHoaXau(string xau, int max)
        {
            string s = CatXau(xau);
            while (s.Length < max)
                s += " ";
            return s;
        }
        public static string HoaDau(string xau)
        {
            string s = xau.Trim();
            while (s.IndexOf("  ") > 0)
                s = s.Remove(s.IndexOf("  "), 1);
            s += " ";
            s = s.Substring(0, 1).ToUpper() + s.Substring(1);
            return s.Trim();
        }
        public static int TachSo(string input)
        {
            int i = 0;
            string[] numbers = Regex.Split(input, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    i = int.Parse(value);
                }
            }
            return i;
        }
    }
}
