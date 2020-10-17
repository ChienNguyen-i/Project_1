using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Utility
{
    class CongCu
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
    }
}
