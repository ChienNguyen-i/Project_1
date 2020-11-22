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
        public static bool CheckDate(string x)
        {
            string a, b, c;
            int day, month, year;
            string s = CatXau(x);

            if (CheckCount(s) == 2)
            {
                a = s.Substring(0, s.IndexOf("/"));
                b = s.Substring(s.IndexOf("/") + 1, s.LastIndexOf("/") - a.Length - 1);
                c = s.Substring(s.LastIndexOf("/") + 1);

                if (a == "" || b == "" || c == "")
                {
                    return false;
                }
                else if (a != "" && b != "" && c != "")
                {
                    day = Convert.ToInt16(a);
                    month = Convert.ToInt16(b);
                    year = Convert.ToInt16(c);

                    int daymax = 0;
                    if (year < 0 || month <= 0 || month > 12 || day <= 0 || day > 31)
                        return false;
                    else
                    {
                        switch (month)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                                daymax = 31;
                                break;
                            case 2:
                                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                                    daymax = 29;
                                else
                                    daymax = 28;
                                break;
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                daymax = 30;
                                break;
                        }
                        if (day <= daymax)
                            return true;
                        else
                            return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static int CheckCount(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '/')
                    count++;
            }
            return count;
        }
    }
}
