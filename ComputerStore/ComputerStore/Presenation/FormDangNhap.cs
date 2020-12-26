using System;
using ComputerStore.DataAccessLayer;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Presenation
{
    public class FormDangNhap
    {
        private string User;
        private string Password;
        public FormDangNhap()
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
        public void HienChinh(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);

            IO.BoxTitle("                       ĐĂNG NHẬP", x, y, 15, 60);
            IO.Writexy("Tài khoản:", x + 3, y + 5);
            IO.Writexy("Mật khẩu:", x + 3, y + 8);
            IO.Writexy("Đăng nhập", x + 40, y + 10);
            IO.Writexy("----------------------------------------------------------", x + 1, y + 11);
            do
            {
                IO.Clear(x + 14, y + 5, 44, ConsoleColor.Black);
                IO.Clear(x + 13, y + 8, 45, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 15, y + 5);
                    User = Console.ReadLine();
                    if (User == "")
                    {
                        IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tài khoản...", x + 3, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 14, y + 5, 44, ConsoleColor.Black);
                    }
                    else
                        user = User;
                } while (User == "");
                IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                do
                {
                    pass = IO.ReadPassword(x + 14, y + 8);
                    if (pass == null)
                    {
                        IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mật khẩu...", x + 3, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 13, y + 8, 45, ConsoleColor.Black);
                    }
                } while (pass == null);
                IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                IO.Writexy("Nhấn Enter để đăng nhập hoặc nhấn ESC để thoát...", x + 3, y + 12);
                IO.Writexy("Đăng nhập", x + 40, y + 10, ConsoleColor.Blue, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (user == "admin" && pass == "admin")
                        Form_MN_QuanLy.HienMNC_QL(29, 4, ConsoleColor.Black, ConsoleColor.White);
                    else if (KT_DangNhap(user, pass) == true)
                        Form_MN_NhanVien.HienMNC_NV(29, 5, ConsoleColor.Black, ConsoleColor.White);
                    else
                    {
                        IO.Clear(x + 2, y + 12, 51, ConsoleColor.Black);
                        IO.Writexy("Tài khoản hoặc Mật khẩu không đúng, mời nhập lại...", x + 3, y + 12, ConsoleColor.Black, ConsoleColor.White);
                    }
                }
            } while (true);
        }
        public bool KT_DangNhap(string user, string pass)
        {
            NhanVienDAL nvDAL = new NhanVienDAL();
            bool kt = false;
            foreach (NhanVien nhanvien in nvDAL.GetData())
            {
                if (nhanvien.maNV == user && nhanvien.pass == CongCu.GetMD5(pass))
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
    }
}
