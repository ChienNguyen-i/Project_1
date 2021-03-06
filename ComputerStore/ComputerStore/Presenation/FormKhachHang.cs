﻿using System;
using System.Text;
using System.Collections.Generic;
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
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                IKhachHangBLL khachhang = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                        NHẬP THÔNG TIN KHÁCH HÀNG", x, y, 10, 110);
                IO.Writexy("Họ tên:", x + 4, y + 3);
                IO.Writexy("Địa chỉ:", x + 4, y + 5);
                IO.Writexy("Số điện thoại:", x + 48, y + 5);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);
                Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);
                KhachHang kh = new KhachHang();

                do
                {
                    Console.SetCursorPosition(x + 12, y + 3);
                    kh.tenKH = Console.ReadLine();
                    if (kh.tenKH == null || CongCu.CheckName(kh.tenKH) == false)
                    {
                        IO.Writexy("Nhập lại tên khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 11, y + 3, 97, ConsoleColor.Black);
                    }
                    else if (kh.tenKH == "!")
                        return;
                } while (kh.tenKH == null ||CongCu.CheckName(kh.tenKH) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 13, y + 5);
                    kh.diaChi = Console.ReadLine();
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
                    break;
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
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
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
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);
                Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);

                string makh;
                string tenkh;
                string diachi;
                string sdt;

                do
                {
                    Console.SetCursorPosition(x + 11, y + 3);
                    makh = Console.ReadLine();
                    if (makh == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (makh == "!")
                        return;
                    else
                    {
                        if (khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(makh)) == false)
                        {
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 10, y + 3, 38, ConsoleColor.Black);
                        }
                        else
                            makh = CongCu.ChuanHoaMa(makh);
                    }
                } while (makh == "" || khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(makh)) == false);
                KhachHang kh = khachhang.LayKhachHang(makh);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 57, y + 3);
                    tenkh = Console.ReadLine();
                    if (tenkh == "" || CongCu.CheckName(tenkh) == false)
                    {
                        IO.Writexy("Nhập lại tên khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 56, y + 3, 52, ConsoleColor.Black);
                    }
                    else if (tenkh != kh.tenKH && tenkh != "")
                        kh.tenKH = CongCu.ChuanHoaXau(tenkh);
                } while (tenkh == "" || CongCu.CheckName(tenkh) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 13, y + 5);
                    diachi = Console.ReadLine();
                    if (diachi == "")
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (diachi != kh.diaChi && diachi != "")
                        kh.diaChi = CongCu.ChuanHoaXau(diachi);
                } while (diachi == "");
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
                        kh.soDT = CongCu.ChuanHoaMa(sdt);
                } while (sdt == null || sdt.Length < 10 || sdt.Length > 10);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 38, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
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
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string makh = "";
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              XÓA KHÁCH HÀNG", x, y, 8, 110);
                IO.Writexy("Nhập mã khách hàng cần xóa:", x + 4, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 16, y + 8, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 32, y + 3);
                    makh = Console.ReadLine();
                    if (makh == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (makh == "!")
                        return;
                    else
                    {
                        if (khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(makh)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            makh = CongCu.ChuanHoaMa(makh);
                            khachhang.XoaKhachHang(makh);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Khách hàng đã được xóa...", x + 4, y + 5);
                            Hien(x + 16, y + 8, khachhang.LayDSKhachHang(), 5, 1);
                        }
                    }
                } while (makh == "" || khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(makh)) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            IKhachHangBLL khachhang = new KhachHangBLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x + 17, y + 1, khachhang.LayDSKhachHang(), 5, 1);
        }
        public void TimTen(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string hoten = "";
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                           TÌM KIẾM KHÁCH HÀNG", x, y, 8, 110);
                IO.Writexy("Nhập họ tên khách hàng cần tìm:", x + 2, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 16, y + 8, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 34, y + 3);
                    hoten = Console.ReadLine();
                    if (hoten == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên khách hàng...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (hoten == "!")
                        return;
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
                            Hien(x + 16, y + 8, list, 5, 1);
                        }
                    }
                } while (hoten == "" || khBLL.KT_TenKhachHang(CongCu.ChuanHoaXau(hoten)) == false);
            } while (true);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string makh = "";
                IKhachHangBLL khachhang = new KhachHangBLL();
                KhachHangBLL khBLL = new KhachHangBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                           TÌM KIẾM KHÁCH HÀNG", x, y, 8, 110);
                IO.Writexy("Nhập mã khách hàng cần tìm:", x + 2, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 16, y + 8, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 30, y + 3);
                    makh = Console.ReadLine();
                    if (makh == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (makh == "!")
                        return;
                    else
                    {
                        if (khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(makh)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 29, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Khách hàng tìm được...", x + 4, y + 5);
                            makh = CongCu.ChuanHoaMa(makh);
                            List<KhachHang> list = khachhang.TimKhachHang(new KhachHang(makh, null, null, null));
                            Hien(x + 16, y + 8, list, 5, 1);
                        }
                    }
                } while (makh == "" || khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(makh)) == false);
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
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "  Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để quay lại...", x, y + d);
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
    }
}
