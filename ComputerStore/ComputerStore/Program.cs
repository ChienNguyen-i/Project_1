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
            Console.SetWindowSize(114, 28);
            FormDangNhap dn = new FormDangNhap();
            dn.HienChinh(26, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
