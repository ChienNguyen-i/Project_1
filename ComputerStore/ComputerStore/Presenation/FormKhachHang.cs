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
                IO.Writexy("Giới tính:", 49, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 49, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, khachhang.LayDSKhachHang(), 5, 0);
                KhachHang kh = new KhachHang();
                kh.tenKH = IO.ReadString(13, 4);
                kh.gioiTinh = IO.ReadString(60, 4);
                kh.diaChi = IO.ReadString(14, 6);
                kh.soDT = IO.ReadNumber(64, 6);
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, khachhang.LayDSKhachHang(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    khachhang.ThemKhachHang(kh);
            } while (true);
        }
        public void Sua()
        {
            IKhachHangBLL khachhang = new KhachHangBLL();
            Console.Clear();
            IO.BoxTitle("                                  CẬP NHẬT THÔNG TIN KHÁCH HÀNG", 1, 1, 10, 100);
            IO.Writexy("Mã KH:", 5, 4);
            IO.Writexy("Họ tên:", 32, 4);
            IO.Writexy("Giới tính:", 5, 6);
            IO.Writexy("Địa chỉ:", 32, 6);
            IO.Writexy("Số điện thoại:", 65, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, khachhang.LayDSKhachHang(), 5, 0);
            int makh;
            string tenkh;
            string gioitinh;
            string diachi;
            string sdt;

            makh = int.Parse(IO.ReadNumber(12, 4));
            KhachHang kh = khachhang.LayKhachHang(makh);
            IO.Writexy(kh.tenKH, 40, 4);
            IO.Writexy(kh.gioiTinh, 16, 6);
            IO.Writexy(kh.diaChi, 41, 6);
            IO.Writexy(kh.soDT, 80, 6);

            tenkh = IO.ReadString(40, 4);
            if (tenkh != kh.tenKH && tenkh != null)
                kh.tenKH = tenkh;
            gioitinh = IO.ReadString(16, 6);
            if (gioitinh != kh.gioiTinh && gioitinh != null)
                kh.gioiTinh = gioitinh;
            diachi = IO.ReadString(41, 6);
            if (diachi != kh.diaChi && diachi != null)
                kh.diaChi = diachi;
            sdt = IO.ReadNumber(80, 6);
            if (sdt != kh.soDT && sdt != null)
                kh.soDT = sdt;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, khachhang.LayDSKhachHang(), 5, 1);
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
                IO.BoxTitle("                                        XÓA KHÁCH HÀNG", 1, 1, 5, 100);
                IO.Writexy("Nhập mã khách hàng cần xóa:", 5, 4);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 0);
                makh = int.Parse(IO.ReadNumber(33, 4));
                if (makh == 0)
                    break;
                else
                    khachhang.XoaKhachHang(makh);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 1);
            } while (true);
            HienChucNang();
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
                IO.BoxTitle("                                     TÌM KIẾM KHÁCH HÀNG", 1, 1, 5, 100);
                IO.Writexy("Nhập họ tên khách hàng cần tìm:", 3, 4);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 0);
                hoten = ComputerStore.Utility.CongCu.ChuanHoaXau(IO.ReadString(35, 4));
                List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(0, hoten, null, null, null));
                Hien(1, 8, list, 5, 1);
                if (hoten == "")
                    break;
            } while (true);
            HienChucNang();
        }
        public void TimMa()
        {
            int makh = 0;
            do
            {
                Console.Clear();
                IKhachHangBLL khachhang = new KhachHangBLL();
                Console.Clear();
                IO.BoxTitle("                                     TÌM KIẾM KHÁCH HÀNG", 1, 1, 5, 100);
                IO.Writexy("Nhập mã khách hàng cần tìm:", 3, 4);
                Hien(1, 8, khachhang.LayDSKhachHang(), 5, 0);
                makh = int.Parse(IO.ReadNumber(31, 4));
                List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(makh, null, null, null, null));
                Hien(1, 8, list, 5, 1);
                if (makh == 0)
                    break;
            } while (true);
            HienChucNang();
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
                IO.Writexy("                          DANH SÁCH KHÁCH HÀNG", x, y);
                IO.Writexy("┌───────┬───────────────────────┬───────────┬───────────────┬─────────────┐", x, y + 1);
                IO.Writexy("│ Mã KH │         Họ tên        │ Giới tính │    Địa chỉ    │    Số ĐT    │", x, y + 2);
                IO.Writexy("├───────┼───────────────────────┼───────────┼───────────────┼─────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].maKH.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].tenKH, x + 9, y + d, 24);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].gioiTinh, x + 33, y + d, 12);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].diaChi, x + 45, y + d, 16);
                    IO.Writexy("│", x + 60, y + d);
                    IO.Writexy(list[i].soDT, x + 61, y + d, 14);
                    IO.Writexy("│", x + 74, y + d);
                    if (i < final - 1)
                        IO.Writexy("├───────┼───────────────────────┼───────────┼───────────────┼─────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└───────┴───────────────────────┴───────────┴───────────────┴─────────────┘", x, y + d - 1);
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
            ComputerStore.Presenation.FormKhachHang.MenuKH mnkh = new ComputerStore.Presenation.FormKhachHang.MenuKH(mn);
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
                        ComputerStore.Presenation.FormMenuChinh.Hien();
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
            ComputerStore.Presenation.FormKhachHang.MenuTimKiem mntk = new ComputerStore.Presenation.FormKhachHang.MenuTimKiem(mn);
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
