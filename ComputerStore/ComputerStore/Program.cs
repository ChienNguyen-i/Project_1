using ComputerStore.Utility;
using System;
using System.Text;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            DangNhap dn = new DangNhap();
            bool ok = dn.Hien(10, 5, "1", "1");
            if (ok)
            {
                Hien();
            }
            else
                Environment.Exit(0);
        }
        public static void Hien()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhap danh sach ",
                " F2.Sua thong tin ",
                " F3.Xoa thong tin ",
                " F4.Hien thi ",
                " F5.Tim kiem ",
                " F6.Ket thuc "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ComputerStore.Presenation.FormMayTinh.MenuMT mnmt = new ComputerStore.Presenation.FormMayTinh.MenuMT(mn);
            mnmt.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
