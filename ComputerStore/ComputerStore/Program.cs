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
            Console.ReadKey();
        }
        public static void Hien()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                "menu",
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            
        }
    }
}
