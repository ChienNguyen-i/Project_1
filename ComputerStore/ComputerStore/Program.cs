using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Presenation;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            /*DangNhap dn = new DangNhap();
            bool ok = dn.Hien(10, 5, "1", "1");
            if (ok)
            {
                FormMenuChinh.Hien();
            }
            else
                Environment.Exit(0);*/
            FormMenuChinh.Hien();
        }
    }
}
