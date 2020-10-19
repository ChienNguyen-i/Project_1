using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Entities;
using ComputerStore.Utility;

namespace ComputerStore.Presenation
{
    class FormDangNhap
    {
        public bool Hien(int x, int y, string user, string pass)
        {
            IO.BoxTitle("ĐĂNG NHẬP", x, y, 15, 60);
            IO.Writexy("TÀI KHOẢN:", x + 3, y + 5);
            IO.Writexy("MẬT KHẨU:", x + 3, y + 8);
            DangNhap dn = new DangNhap();
            do
            {
                dn.user = IO.ReadString(x + 15, y + 5);
                dn.pass = IO.ReadPassword(x + 15, y + 8);
                IO.Writexy("Nhấn Enter để đăng nhập hoặc nhấn ESC để thoát", x + 2, y + 12);
                IO.Writexy("Đăng nhập", x + 40, y + 10, ConsoleColor.Blue, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (dn.user == user && dn.pass == pass)
                        return true;
                    else
                    {
                        IO.Clear(x + 2, y + 12, 55, ConsoleColor.Black);
                        IO.Writexy("Tài khoản hoặc Mật khẩu không đúng, mời nhập lại", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 15, y + 5, 30, ConsoleColor.Black);
                        IO.Clear(x + 15, y + 8, 30, ConsoleColor.Black);
                    }
                }
                else
                    return false;
            } while (true);
        }
    }
}
