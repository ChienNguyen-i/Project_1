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
                " F1.Nhap danh sach hoc sinh ",
                " F2.Tim hoc sinh ",
                " F3.Xoa thong tin hoc sinh ",
                " F4.Sua thong tin hoc sinh ",
                " F5.Hien thi cac hoc sinh ",
                " F6.Ket thuc "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ComputerStore.Presenation.MenuNV mnnv = new ComputerStore.Presenation.MenuNV(mn);
            mnnv.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
