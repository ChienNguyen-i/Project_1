using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;
namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormKhachHang
    {
        public void Nhap()
        {
            do
            {
                IKhachHangBLL khachhang = new KhachHangBLL();
                Console.Clear();
                IO.BoxTitle("                                   NHẬP THÔNG TIN KHÁCH HÀNG", 1, 1, 10, 100);
                IO.Writexy("Họ tên:", 5, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 49, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                Hien(1, 13, khachhang.LayDSKhachHang(), 5, 0);
                KhachHang kh = new KhachHang();

                do
                {
                    kh.tenKH = IO.ReadString(13, 4);
                    if (kh.tenKH == null)
                        IO.Writexy("Nhập lại tên khách hàng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (kh.tenKH == null);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                do
                {
                    kh.diaChi = IO.ReadString(14, 6);
                    if (kh.diaChi == null)
                        IO.Writexy("Nhập lại địa chỉ...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (kh.diaChi == null);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                do
                {
                    kh.soDT = IO.ReadNumber(64, 6);
                    if (kh.soDT == null || kh.soDT.Length < 10 || kh.soDT.Length > 10)
                        IO.Writexy("Nhập lại số điện thoại...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (kh.soDT == null || kh.soDT.Length < 10 || kh.soDT.Length > 10);
                
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(35, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    khachhang.ThemKhachHang(kh);
                    Hien(1, 13, khachhang.LayDSKhachHang(), 5, 1);
                }
            } while (true);
        }
        public void Sua()
        {
            IKhachHangBLL khachhang = new KhachHangBLL();
            Console.Clear();
            IO.BoxTitle("                                  CẬP NHẬT THÔNG TIN KHÁCH HÀNG", 1, 1, 10, 100);
            IO.Writexy("Mã KH:", 5, 4);
            IO.Writexy("Họ tên:", 32, 4);
            IO.Writexy("Địa chỉ:", 5, 6);
            IO.Writexy("Số điện thoại:", 50, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            Hien(1, 13, khachhang.LayDSKhachHang(), 5, 0);

            int makh;
            string tenkh;
            string diachi;
            string sdt;

            do
            {
                makh = int.Parse(IO.ReadNumber(12, 4));
                if (makh <= 0)
                    IO.Writexy("Nhập lại mã khách hàng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
            } while (makh <= 0);
            KhachHang kh = khachhang.LayKhachHang(makh);
            IO.Writexy(kh.tenKH, 40, 4);
            IO.Writexy(kh.diaChi, 14, 6);
            IO.Writexy(kh.soDT, 65, 6);

            IO.Clear(4, 8, 30, ConsoleColor.Black);
            do
            {
                tenkh = IO.ReadString(40, 4);
                if (tenkh == null)
                    IO.Writexy("Nhập lại tên khách hàng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (tenkh != kh.tenKH && tenkh != null)
                    kh.tenKH = CongCu.ChuanHoaXau(tenkh);
            } while (tenkh == null);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            do
            {
                diachi = IO.ReadString(14, 6);
                if (diachi == null)
                    IO.Writexy("Nhập lại địa chỉ...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (diachi != kh.diaChi && diachi != null)
                    kh.diaChi = CongCu.ChuanHoaXau(diachi);
            } while (diachi == null);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            do
            {
                sdt = IO.ReadNumber(65, 6);
                if (sdt == null)
                    IO.Writexy("Nhập lại số điện thoại...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (sdt != kh.soDT && sdt != null)
                    kh.soDT = CongCu.CatXau(sdt);
            } while (sdt == null);

            IO.Clear(4, 8, 30, ConsoleColor.Black);
            IO.Writexy("Enter để cập nhật, Esc để thoát...", 5, 8);
            Console.SetCursorPosition(39, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.Enter)
            {
                khachhang.SuaKhachHang(kh);
                Hien(1, 13, khachhang.LayDSKhachHang(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int makh = 0;
            do
            {
                Console.Clear();
                IKhachHangBLL khachhang = new KhachHangBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA KHÁCH HÀNG", 1, 1, 7, 100);
                IO.Writexy("Nhập mã khách hàng cần xóa:", 5, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    makh = int.Parse(IO.ReadNumber(33, 4));
                    if (makh <= 0)
                    {
                        IO.Clear(5, 6, 30, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(5, 8, 30, ConsoleColor.Black);
                        IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                        khachhang.XoaKhachHang(makh);
                    }
                } while (makh <= 0);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 1);
            } while (true);
        }
        public void Xem()
        {
            IKhachHangBLL khachhang = new KhachHangBLL();
            Console.Clear();
            Hien(1, 1, khachhang.LayDSKhachHang(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                IKhachHangBLL khachhang = new KhachHangBLL();
                Console.Clear();
                IO.BoxTitle("                                     TÌM KIẾM KHÁCH HÀNG", 1, 1, 7, 100);
                IO.Writexy("Nhập họ tên khách hàng cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    hoten = IO.ReadString(35, 4);
                    if (hoten == null)
                    {
                        IO.Clear(5, 6, 30, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên khách hàng...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    {
                        List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(0, CongCu.ChuanHoaXau(hoten), null, null));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (hoten == null);
            } while (true);
        }
        public void TimMa()
        {
            int makh = 0;
            do
            {
                Console.Clear();
                IKhachHangBLL khachhang = new KhachHangBLL();
                Console.Clear();
                IO.BoxTitle("                                     TÌM KIẾM KHÁCH HÀNG", 1, 1, 7, 100);
                IO.Writexy("Nhập mã khách hàng cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    makh = int.Parse(IO.ReadNumber(31, 4));
                    if (makh <= 0)
                    {
                        IO.Clear(5, 6, 30, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(makh, null, null, null));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (makh <= 0);
            } while (true);
        }
        public void Hien(int xx, int yy, List<KhachHang> list, int n, int type)
        {
            int head = 0;
            int curpage = 1;
            int totalpage = list.Count % n == 0 ? list.Count / n : list.Count / n + 1;
            int final = list.Count <= n ? list.Count : n;
            int x, y, d;
            do
            {
                IO.Clear(xx, yy, 1500, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                   DANH SÁCH KHÁCH HÀNG", x, y);
                IO.Writexy("┌───────┬───────────────────────┬───────────────┬───────────────┐", x, y + 1);
                IO.Writexy("│ Mã KH │         Họ tên        │    Địa chỉ    │     Số ĐT     │", x, y + 2);
                IO.Writexy("├───────┼───────────────────────┼───────────────┼───────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].maKH.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].tenKH, x + 9, y + d, 24);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].diaChi, x + 33, y + d, 16);
                    IO.Writexy("│", x + 48, y + d);
                    IO.Writexy(list[i].soDT, x + 49, y + d, 16);
                    IO.Writexy("│", x + 64, y + d);
                    if (i < final - 1)
                        IO.Writexy("├───────┼───────────────────────┼───────────────┼───────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└───────┴───────────────────────┴───────────────┴───────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để thoát...", x, y + d);
                if (type == 0)
                    break;
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.PageDown)
                {
                    if (curpage < totalpage)
                        curpage += 1;
                    else
                        curpage = 1;
                }
                else if (kt.Key == ConsoleKey.PageUp)
                {
                    if (curpage > 1)
                        curpage -= 1;
                    else
                        curpage = totalpage;
                }
                else if (kt.Key == ConsoleKey.Escape)
                    break;
            } while (true);
        }
        public void HienChucNang()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhập danh sách khách hàng ",
                " F2.Sửa thông tin khách hàng ",
                " F3.Xóa khách hàng ",
                " F4.Hiển thị danh sách khách hàng ",
                " F5.Tìm kiếm khách hàng ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuKH mnkh = new MenuKH(mn);
            mnkh.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuKH : Menu
        {
            public MenuKH(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormKhachHang khachang = new FormKhachHang();
                switch (location)
                {
                    case 0:
                        khachang.Nhap();
                        break;
                    case 1:
                        khachang.Sua();
                        break;
                    case 2:
                        khachang.Xoa();
                        break;
                    case 3:
                        khachang.Xem();
                        break;
                    case 4:
                        khachang.HienTimKiem();
                        break;
                    case 5:
                        FormMenuChinh.Hien();
                        break;
                }
            }
        }
        public void HienTimKiem()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Tìm kiếm khách hàng theo mã ",
                " F2.Tìm kiếm khách hàng theo tên ",
                " F3.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuTimKiem mntk = new MenuTimKiem(mn);
            mntk.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuTimKiem : Menu
        {
            public MenuTimKiem(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormKhachHang khachhang = new FormKhachHang();
                switch (location)
                {
                    case 0:
                        khachhang.TimMa();
                        break;
                    case 1:
                        khachhang.TimTen();
                        break;
                    case 2:
                        khachhang.HienChucNang();
                        break;
                }
            }
        }
    }
}
