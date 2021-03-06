﻿using System;
using System.Text;
using System.Collections.Generic;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormNCC
    {
        public void Nhap(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                INCC_BLL nhacc = new NCC_BLL();
                
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                   NHẬP THÔNG TIN NHÀ CUNG CẤP", x, y, 10, 101);
                IO.Writexy("Tên nhà cung cấp:", x + 4, y + 3);
                IO.Writexy("Địa chỉ:", x + 4, y + 5);
                IO.Writexy("Số điện thoại:", x + 39, y + 5);
                IO.Writexy("---------------------------------------------------------------------------------------------------", x + 1, y + 6);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);
                Hien(x + 11, y + 10, nhacc.LayDSNCC(), 5, 0);
                NCC ncc = new NCC();

                do
                {
                    Console.SetCursorPosition(x + 22, y + 3);
                    ncc.tenNCC = Console.ReadLine();
                    if (ncc.tenNCC == null)
                        IO.Writexy("Nhập lại tên nhà cung cấp...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (ncc.tenNCC == "!")
                        return;
                } while (ncc.tenNCC == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 13, y + 5);
                    ncc.diaChi = Console.ReadLine();
                    if (ncc.diaChi == null)
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                } while (ncc.diaChi == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    ncc.soDT = IO.ReadNumber(x + 54, y + 5);
                    if (ncc.soDT == null || ncc.soDT.Length < 10 || ncc.soDT.Length > 10)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 53, y + 5, 46, ConsoleColor.Black);
                    }
                } while (ncc.soDT == null || ncc.soDT.Length < 10 || ncc.soDT.Length > 10);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 34, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Nhà cung cấp đã được thêm...", x + 4, y + 7);
                    nhacc.ThemNCC(ncc);
                    Hien(x + 11, y + 10, nhacc.LayDSNCC(), 5, 1);
                }
            } while (true);
        }
        public void Sua(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                 CẬP NHẬT THÔNG TIN NHÀ CUNG CẤP", x, y, 10, 101);
                IO.Writexy("Mã NCC:", x + 4, y + 3);
                IO.Writexy("Tên nhà cung cấp:", x + 39, y + 3);
                IO.Writexy("Địa chỉ:", x + 4, y + 5);
                IO.Writexy("Số điện thoại:", x + 39, y + 5);
                IO.Writexy("---------------------------------------------------------------------------------------------------", x + 1, y + 6);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);
                Hien(x + 11, y + 10, nhacc.LayDSNCC(), 5, 0);

                string mancc;
                string tenncc;
                string diachi;
                string sdt;

                do
                {
                    Console.SetCursorPosition(x + 12, y + 3);
                    mancc = Console.ReadLine();
                    if (mancc == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mancc == "!")
                        return;
                    else
                    {
                        if (nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 11, y + 3, 27, ConsoleColor.Black);
                        }
                        else
                            mancc = CongCu.ChuanHoaMa(mancc);
                    }
                } while (mancc == "" || nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false);
                NCC ncc = nhacc.LayNCC(mancc);
                
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 57, y + 3);
                    tenncc = Console.ReadLine();
                    if (tenncc == "")
                        IO.Writexy("Nhập lại tên nhà cung cấp...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (tenncc != ncc.tenNCC && tenncc != "")
                        ncc.tenNCC = CongCu.ChuanHoaXau(tenncc);
                } while (tenncc == "");
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 13, y + 5);
                    diachi = Console.ReadLine();
                    if (diachi == "")
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (diachi != ncc.diaChi && diachi != "")
                        ncc.diaChi = CongCu.ChuanHoaXau(diachi);
                } while (diachi == "");
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    sdt = IO.ReadNumber(x + 54, y + 5);
                    if (sdt == null || sdt.Length < 10 || sdt.Length > 10)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 53, y + 5, 46, ConsoleColor.Black);
                    }
                    else if (sdt != ncc.soDT && sdt != null)
                        ncc.soDT = CongCu.ChuanHoaMa(sdt);
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
                    IO.Writexy("Nhà cung cấp đã được cập nhật...", x + 4, y + 7);
                    nhacc.SuaNCC(ncc);
                    Hien(x + 11, y + 10, nhacc.LayDSNCC(), 5, 1);
                }
            } while (true);
        }
        public void Xoa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mancc = "";
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                        XÓA NHÀ CUNG CẤP", x, y, 8, 101);
                IO.Writexy("Nhập mã nhà cung cấp cần xóa:", x + 4, y + 3);
                IO.Writexy("---------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 11, y + 8, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 34, y + 3);
                    mancc = Console.ReadLine();
                    if (mancc == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mancc == "!")
                        return;
                    else
                    {
                        if (nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mancc = CongCu.ChuanHoaMa(mancc);
                            nhacc.XoaNCC(mancc);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Nhà cung cấp đã được xóa...", x + 4, y + 5);
                            Hien(x + 11, y + 8, nhacc.LayDSNCC(), 5, 1);
                        }
                    }
                } while (mancc == "" || nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false);

                IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                Console.SetCursorPosition(x + 33, y + 5);
                IO.Writexy("E", x + 4, y + 5);
                IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                ConsoleKeyInfo ktr = Console.ReadKey();
                if (ktr.Key == ConsoleKey.Escape)
                    break;
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            INCC_BLL nhacc = new NCC_BLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x + 17, y + 1, nhacc.LayDSNCC(), 5, 1);
        }
        public void TimTen(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string tenncc = "";
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                      TÌM KIẾM NHÀ CUNG CẤP", x, y, 8, 101);
                IO.Writexy("Nhập tên nhà cung cấp cần tìm:", x + 2, y + 3);
                IO.Writexy("---------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 11, y + 8, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 33, y + 3);
                    tenncc = Console.ReadLine();
                    if (tenncc == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên nhà cung cấp...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (tenncc == "!")
                        return;
                    else
                    {
                        if (nccBLL.KT_TenNCC(CongCu.ChuanHoaXau(tenncc)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại tên nhà cung cấp này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 32, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Nhà cung cấp tìm được...", x + 4, y + 5);
                            tenncc = CongCu.ChuanHoaXau(tenncc);
                            List<NCC> list = nhacc.TimNCC(new NCC(null, tenncc, null, null));
                            Hien(x + 11, y + 8, list, 5, 1);
                        }
                    }
                } while (tenncc == "" || nccBLL.KT_TenNCC(tenncc) == false);
            } while (true);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mancc = "";
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                      TÌM KIẾM NHÀ CUNG CẤP", x, y, 8, 101);
                IO.Writexy("Nhập mã nhà cung cấp cần tìm:", x + 2, y + 3);
                IO.Writexy("---------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 11, y + 8, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 32, y + 3);
                    mancc = Console.ReadLine();
                    if (mancc == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mancc == "!")
                        return;
                    else
                    {
                        if (nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Nhà cung cấp tìm được...", x + 4, y + 5);
                            mancc = CongCu.ChuanHoaMa(mancc);
                            List<NCC> list = nhacc.TimNCC(new NCC(mancc, null, null, null));
                            Hien(x + 11, y + 8, list, 5, 1);
                        }
                    }
                } while (mancc == "" || nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false);
            } while (true);
        }
        public void Hien(int xx, int yy, List<NCC> list, int n, int type)
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
                IO.Writexy("                           DANH SÁCH NHÀ CUNG CẤP", x, y);
                IO.Writexy("┌─────────────────┬───────────────────────┬─────────────────┬───────────────┐", x, y + 1);
                IO.Writexy("│ Mã nhà cung cấp │   Tên nhà cung cấp    │     Địa chỉ     │     Số ĐT     │", x, y + 2);
                IO.Writexy("├─────────────────┼───────────────────────┼─────────────────┼───────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 18);
                    IO.Writexy(list[i].maNCC, x + 1, y + d, 18);
                    IO.Writexy("│", x + 18, y + d);
                    IO.Writexy(list[i].tenNCC, x + 19, y + d, 24);
                    IO.Writexy("│", x + 42, y + d);
                    IO.Writexy(list[i].diaChi, x + 43, y + d, 18);
                    IO.Writexy("│", x + 60, y + d);
                    IO.Writexy(list[i].soDT, x + 61, y + d, 16);
                    IO.Writexy("│", x + 76, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────────┼───────────────────────┼─────────────────┼───────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────────┴───────────────────────┴─────────────────┴───────────────┘", x, y + d - 1);
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
