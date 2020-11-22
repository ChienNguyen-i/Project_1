using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;
using System.Linq;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormKhachHang
    {
        public void Nhap(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                IKhachHangBLL khachhang = new KhachHangBLL();
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                        NHẬP THÔNG TIN KHÁCH HÀNG", x, y, 10, 110);
                IO.Writexy("Họ tên:", x + 4, y + 3);
                IO.Writexy("Địa chỉ:", x + 4, y + 5);
                IO.Writexy("Số điện thoại:", x + 48, y + 5);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);
                KhachHang kh = new KhachHang();

                do
                {
                    kh.tenKH = IO.ReadString(x + 12, y + 3);
                    if (kh.tenKH == null)
                        IO.Writexy("Nhập lại tên khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                } while (kh.tenKH == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    kh.diaChi = IO.ReadString(x + 13, y + 5);
                    if (kh.diaChi == null)
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                } while (kh.diaChi == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    kh.soDT = IO.ReadNumber(x + 63, y + 5);
                    if (kh.soDT == null || kh.soDT.Length < 10 || kh.soDT.Length > 10)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 62, y + 5, 46, ConsoleColor.Black);
                    }
                } while (kh.soDT == null || kh.soDT.Length < 10 || kh.soDT.Length > 10);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 34, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Khách hàng đã được thêm...", x + 4, y + 7);
                    khachhang.ThemKhachHang(kh);
                    Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 1);
                }
            } while (true);
        }
        public void Sua(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                      CẬP NHẬT THÔNG TIN KHÁCH HÀNG", x, y, 10, 110);
                IO.Writexy("Mã KH:", x + 4, y + 3);
                IO.Writexy("Họ tên:", x + 49, y + 3);
                IO.Writexy("Địa chỉ:", x + 4, y + 5);
                IO.Writexy("Số điện thoại:", x + 49, y + 5);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);

                string makh;
                string tenkh;
                string diachi;
                string sdt;

                do
                {
                    makh = IO.ReadString(x + 11, y + 3);
                    if (makh == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_MaKhachHang(makh.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 10, y + 3, 38, ConsoleColor.Black);
                        }
                        else
                            makh = CongCu.CatXau(makh.ToUpper());
                    }
                } while (makh == null || khBLL.KT_MaKhachHang(makh.ToUpper()) == false);
                KhachHang kh = khachhang.LayKhachHang(makh);
                IO.Writexy(kh.tenKH, x + 57, y + 3);
                IO.Writexy(kh.diaChi, x + 13, y + 5);
                IO.Writexy(kh.soDT, x + 64, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    tenkh = IO.ReadString(x + 57, y + 3);
                    if (tenkh == null)
                        IO.Writexy("Nhập lại tên khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (tenkh != kh.tenKH && tenkh != null)
                        kh.tenKH = CongCu.ChuanHoaXau(tenkh);
                } while (tenkh == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    diachi = IO.ReadString(x + 13, y + 5);
                    if (diachi == null)
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (diachi != kh.diaChi && diachi != null)
                        kh.diaChi = CongCu.ChuanHoaXau(diachi);
                } while (diachi == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    sdt = IO.ReadNumber(x + 64, y + 5);
                    if (sdt == null || sdt.Length < 10 || sdt.Length > 10)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 63, y + 5, 45, ConsoleColor.Black);
                    }
                    else if (sdt != kh.soDT && sdt != null)
                        kh.soDT = CongCu.CatXau(sdt);
                } while (sdt == null || sdt.Length < 10 || sdt.Length > 10);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 38, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Khách hàng đã được cập nhật...", x + 4, y + 7);
                    khachhang.SuaKhachHang(kh);
                    Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 1);
                }
            } while (true);
        }
        public void Xoa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                string makh = "";
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              XÓA KHÁCH HÀNG", x, y, 7, 110);
                IO.Writexy("Nhập mã khách hàng cần xóa:", x + 4, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                Hien(x + 16, y + 7, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    makh = IO.ReadString(x + 32, y + 3);
                    if (makh == null)
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_MaKhachHang(makh.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            makh = CongCu.CatXau(makh.ToUpper());
                            khachhang.XoaKhachHang(makh);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Khách hàng đã được xóa...", x + 4, y + 5);
                            Hien(x + 16, y + 7, khachhang.LayDSKhachHang(), 5, 1);
                        }
                    }
                } while (makh == null || khBLL.KT_MaKhachHang(makh.ToUpper()) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            IKhachHangBLL khachhang = new KhachHangBLL();
            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x + 17, y, khachhang.LayDSKhachHang(), 5, 1);
            HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
        }
        public void TimTen(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                string hoten = "";
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                           TÌM KIẾM KHÁCH HÀNG", x, y, 7, 110);
                IO.Writexy("Nhập họ tên khách hàng cần tìm:", x + 2, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                Hien(x + 16, y + 7, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    hoten = IO.ReadString(x + 34, y + 3);
                    if (hoten == null)
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên khách hàng...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_TenKhachHang(CongCu.ChuanHoaXau(hoten)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại tên khách hàng này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Khách hàng tìm được...", x + 4, y + 5);
                            hoten = CongCu.ChuanHoaXau(hoten);
                            List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(null, hoten, null, null));
                            Hien(x + 16, y + 7, list, 5, 1);
                        }
                    }
                } while (hoten == null || khBLL.KT_TenKhachHang(CongCu.ChuanHoaXau(hoten)) == false);
            } while (true);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                string makh = "";
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                           TÌM KIẾM KHÁCH HÀNG", x, y, 7, 110);
                IO.Writexy("Nhập mã khách hàng cần tìm:", x + 2, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                Hien(x + 16, y + 7, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    makh = IO.ReadString(x + 30, y + 3);
                    if (makh == null)
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_MaKhachHang(makh.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 29, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Khách hàng tìm được...", x + 4, y + 5);
                            makh = CongCu.CatXau(makh.ToUpper());
                            List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(makh, null, null, null));
                            Hien(x + 16, y + 7, list, 5, 1);
                        }
                    }
                } while (makh == null || khBLL.KT_MaKhachHang(makh.ToUpper()) == false);
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
                IO.Clear(xx, yy, 1900, ConsoleColor.Black);
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                            DANH SÁCH KHÁCH HÀNG", x, y);
                IO.Writexy("┌───────────────┬───────────────────────┬─────────────────┬─────────────────┐", x, y + 1);
                IO.Writexy("│ Mã khách hàng │         Họ tên        │     Địa chỉ     │      Số ĐT      │", x, y + 2);
                IO.Writexy("├───────────────┼───────────────────────┼─────────────────┼─────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].maKH, x + 1, y + d, 16);
                    IO.Writexy("│", x + 16, y + d);
                    IO.Writexy(list[i].tenKH, x + 17, y + d, 24);
                    IO.Writexy("│", x + 40, y + d);
                    IO.Writexy(list[i].diaChi, x + 41, y + d, 18);
                    IO.Writexy("│", x + 58, y + d);
                    IO.Writexy(list[i].soDT, x + 59, y + d, 18);
                    IO.Writexy("│", x + 76, y + d);
                    if (i < final - 1)
                        IO.Writexy("├───────────────┼───────────────────────┼─────────────────┼─────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└───────────────┴───────────────────────┴─────────────────┴─────────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "  Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để thoát...", x, y + d);
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
        public void HienChucNang(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách khách hàng", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin khách hàng", x + 12, y + 5);
                IO.Writexy("F3. Xóa khách hàng", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách khách hàng", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm khách hàng", x + 12, y + 11);
                IO.Writexy("F6. Quay lại ", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormKhachHang khachang = new FormKhachHang();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        khachang.Nhap(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        khachang.Sua(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        khachang.Xoa(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        khachang.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        khachang.HienTimKiem(27, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        FormMenuChinh.HienMNC(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        public void HienTimKiem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 11, 56);
                IO.Writexy("F1. Tìm kiếm khách hàng theo mã", x + 12, y + 3);
                IO.Writexy("F2. Tìm kiếm khách hàng theo tên", x + 12, y + 5);
                IO.Writexy("F3. Quay lại", x + 12, y + 7);
                IO.Writexy("Chọn chức năng...", x + 12, y + 9);

                FormKhachHang khachang = new FormKhachHang();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        khachang.TimMa(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        khachang.TimTen(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        khachang.HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
    }
}
