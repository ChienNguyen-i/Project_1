using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Presenation;

namespace ComputerStore.Utility
{
    public class DangNhap
    {
        private string User;
        private string Password;
        public DangNhap()
        { }
        public string user
        {
            get
            {
                return User;
            }
            set
            {
                if (value != "")
                    User = value;
            }
        }
        public string pass
        {
            get
            {
                return Password;
            }
            set
            {
                if (value != "")
                    Password = value;
            }
        }
        public bool Hien(int x, int y, string user, string pass)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            IO.BoxTitle("                       ĐĂNG NHẬP", x, y, 15, 60);
            IO.Writexy("Tài khoản:", x + 3, y + 5);
            IO.Writexy("Mật khẩu:", x + 3, y + 8);
            IO.Writexy("Đăng nhập", x + 40, y + 10);
            IO.Writexy("----------------------------------------------------------", x + 1, y + 11);
            do
            {
                IO.Clear(x + 14, y + 5, 42, ConsoleColor.Black);
                IO.Clear(x + 13, y + 8, 42, ConsoleColor.Black);
                do
                {
                    this.user = IO.ReadString(x + 15, y + 5);
                    if (this.user == null)
                    {
                        IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tài khoản...", x + 3, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 14, y + 5, 42, ConsoleColor.Black);
                    }
                } while (this.user == null);
                IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                do
                {
                    this.pass = IO.ReadPassword(x + 14, y + 8);
                    if (this.pass == null)
                    {
                        IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mật khẩu...", x + 3, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 13, y + 8, 42, ConsoleColor.Black);
                    }
                } while (this.pass == null);
                IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                IO.Writexy("Nhấn Enter để đăng nhập hoặc nhấn ESC để thoát...", x + 3, y + 12);
                IO.Writexy("Đăng nhập", x + 40, y + 10, ConsoleColor.Blue, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (this.user == user && this.pass == pass)
                        return true;
                    else
                    {
                        IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                        IO.Writexy("Tài khoản hoặc Mật khẩu không đúng, mời nhập lại...", x + 3, y + 12, ConsoleColor.Black, ConsoleColor.White);
                    }
                }
                else
                    return false;
            } while (true);
        }
        public void Dang_Nhap()
        {
            DangNhap dn = new DangNhap();
            bool ok = dn.Hien(26, 6, "1", "1");
            if (ok)
            {
                FormMenuChinh.HienMNC(29, 5, ConsoleColor.Black, ConsoleColor.White);
            }
            else
                Environment.Exit(0);
        }
    }
}
