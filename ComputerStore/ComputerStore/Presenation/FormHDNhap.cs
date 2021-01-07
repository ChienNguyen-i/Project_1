using System;
using System.Text;
using System.Collections.Generic;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormHDNhap
    {
        public void Nhap(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                IHDNhapBLL hdnhap = new HDNhapBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                INCC_BLL nhacc = new NCC_BLL();
                IMayTinhBLL maytinh = new MayTinhBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormNCC fncc = new FormNCC();
                FormMayTinh fmt = new FormMayTinh();
                NhanVienBLL nvBLL = new NhanVienBLL();
                NCC_BLL nccBLL = new NCC_BLL();
                ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();
                HDNhap hdn = new HDNhap();
                CTHDNhap cthdn = new CTHDNhap();
                HDNhap hd;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                        NHẬP THÔNG TIN HÓA ĐƠN NHẬP", x, y, 11, 112);
                IO.Writexy("Mã nhân viên:", x + 2, y + 3);
                IO.Writexy("Mã nhà CC:", x + 28, y + 3);
                IO.Writexy("Ngày nhập:", x + 55, y + 3);
                IO.Writexy("Tổng tiền:", x + 83, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Mã máy tính:", x + 2, y + 5);
                IO.Writexy("Tên máy tính:", x + 2, y + 6);
                IO.Writexy("Số lượng:", x + 28, y + 5);
                IO.Writexy("Đơn giá:", x + 55, y + 5);
                IO.Writexy("Thành tiền:", x + 83, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 7);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 9);

                fnv.Hien(x, y + 11, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 16, y + 3);
                    hdn.maNV = Console.ReadLine();
                    if (hdn.maNV == null)
                    {
                        IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (hdn.maNV == "!")
                        return;
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(CongCu.ChuanHoaMa(hdn.maNV)) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 15, y + 3, 12, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdn.maNV == null || nvBLL.KT_MaNhanVien(CongCu.ChuanHoaMa(hdn.maNV)) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 9, 60, ConsoleColor.Black);
                fncc.Hien(x + 16, y + 11, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 39, y + 3);
                    hdn.maNCC = Console.ReadLine();
                    if (hdn.maNCC == null)
                    {
                        IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(hdn.maNCC)) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 38, y + 3, 16, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdn.maNCC == null || nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(hdn.maNCC)) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Writexy("Nhập ngày nhập định dạng 'dd/MM/yyyy'...", x + 4, y + 9, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 66, y + 3);
                    hdn.ngayNhap = Console.ReadLine();
                    if (hdn.ngayNhap == null || CongCu.CheckDate(hdn.ngayNhap) == false)
                    {
                        IO.Writexy("Nhập lại ngày nhập...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 65, y + 3, 17, ConsoleColor.Black);
                    }
                } while (hdn.ngayNhap == null || CongCu.CheckDate(hdn.ngayNhap) == false);

                hdnhap.ThemHDNhap(hdn);

                while (true)
                {
                    hd = hdnBLL.LayMaHDN(hdn.maNV, hdn.maNCC, hdn.ngayNhap);
                    cthdn.maHDN = hd.maHDN;

                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    fmt.Hien(x + 11, y + 11, maytinh.LayDSMayTinh(), 5, 0);
                    do
                    {
                        IO.Clear(x + 14, y + 5, 12, ConsoleColor.Black);
                        Console.SetCursorPosition(x + 15, y + 5);
                        cthdn.maMT = Console.ReadLine();
                        if (cthdn.maMT == null)
                        {
                            IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                            IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                        }
                    } while (cthdn.maMT == null);
                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);

                    if (mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(cthdn.maMT)) == true)
                    {
                        MayTinh Mt = mtBLL.LayMayTinh(CongCu.ChuanHoaMa(cthdn.maMT));
                        IO.Writexy(Mt.tenMT, x + 16, y + 6);
                        cthdn.tenMT = Mt.tenMT;
                    }
                    else
                    {
                        do
                        {
                            IO.Clear(x + 14, y + 6, 90, ConsoleColor.Black);
                            Console.SetCursorPosition(x + 16, y + 6);
                            cthdn.tenMT = Console.ReadLine();
                            if (cthdn.tenMT == null)
                            {
                                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                                IO.Writexy("Nhập lại tên máy tính...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                            }
                        } while (cthdn.tenMT == null);
                    }

                    IO.Clear(x + 3, y + 9, 60, ConsoleColor.Black);
                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    do
                    {
                        IO.Clear(x + 37, y + 5, 16, ConsoleColor.Black);
                        cthdn.soLuong = int.Parse(IO.ReadNumber(x + 38, y + 5));
                        if (cthdn.soLuong <= 0)
                        {
                            IO.Writexy("Nhập lại số lượng...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 37, y + 5, 16, ConsoleColor.Black);
                        }
                    } while (cthdn.soLuong <= 0);
                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    HienCT_N(x, y + 11, cthdnhap.LayDS_CTHDNhap(), 5, 0);
                    do
                    {
                        IO.Clear(x + 63, y + 5, 16, ConsoleColor.Black);
                        cthdn.donGia = double.Parse(IO.ReadNumber(x + 64, y + 5));
                        if (cthdn.donGia <= 0)
                        {
                            IO.Writexy("Nhập lại đơn giá...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 63, y + 5, 16, ConsoleColor.Black);
                        }
                    } while (cthdn.donGia <= 0);

                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    IO.Clear(x + 94, y + 5, 16, ConsoleColor.Black);
                    IO.Writexy(cthdn.thanhTien.ToString(), x + 95, y + 5);

                    cthdnhap.ThemCTHDNhap(cthdn);

                    MayTinh mt = mtBLL.LayMayTinh(CongCu.ChuanHoaMa(cthdn.maMT));
                    if (mtBLL.KT_MaMayTinh(cthdn.maMT) == true)
                        mtBLL.CongSoLuong(mt, cthdn.soLuong);
                    else
                        cthdn.soLuong = cthdn.soLuong;

                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    Console.SetCursorPosition(x + 34, y + 8);
                    IO.Writexy("Nhập tiếp? (C/K)...", x + 4, y + 8);
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar != 'c')
                        break;
                }

                IO.Clear(x + 93, y + 5, 16, ConsoleColor.Black);
                IO.Writexy(hdnBLL.TTien(cthdn.maHDN).ToString(), x + 94, y + 3);
                hdn.tongTien = hdnBLL.TTien(cthdn.maHDN);

                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 8);
                Console.SetCursorPosition(x + 34, y + 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn nhập đã được thêm...", x + 4, y + 8);
                    hdnhap.XoaHDNhap(cthdn.maHDN);
                    hdnhap.ThemHDNhap(hdn);
                    Hien(x + 13, y + 11, hdnhap.LayDSHDNhap(), 5, 1);
                }
            } while (true);
        }
        public void Xoa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mahdn = "";
                ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                             XÓA HÓA ĐƠN NHẬP", x, y, 8, 110);
                IO.Writexy("Nhập mã hóa đơn nhập cần xóa:", x + 4, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 13, y + 8, hdnhap.LayDSHDNhap(), 5, 0);

                do
                {
                    Console.SetCursorPosition(x + 34, y + 3);
                    mahdn = Console.ReadLine();
                    if (mahdn == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mahdn == "!")
                        return;
                    else
                    {
                        if (hdnBLL.KT_MaHDN(CongCu.ChuanHoaMa(mahdn)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn nhập này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mahdn = CongCu.ChuanHoaMa(mahdn);
                            hdnhap.XoaHDNhap(mahdn);
                            cthdnhap.XoaCTHDNhap(mahdn);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn nhập đã được xóa...", x + 4, y + 5);
                            Hien(x + 13, y + 8, hdnhap.LayDSHDNhap(), 5, 1);
                        }
                    }
                } while (mahdn == "" || hdnBLL.KT_MaHDN(CongCu.ChuanHoaMa(mahdn)) == false);
            } while (true);
        }
        public void XemCTHDN(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mahdn = "";
                ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                    XEM DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP", x, y, 8, 112);
                IO.Writexy("Nhập mã hóa đơn nhập cần xem chi tiết:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 13, y + 8, hdnhap.LayDSHDNhap(), 5, 0);

                do
                {
                    Console.SetCursorPosition(x + 41, y + 3);
                    mahdn = Console.ReadLine();
                    if (mahdn == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mahdn == "!")
                        return;
                    else
                    {
                        if (hdnBLL.KT_MaHDN(CongCu.ChuanHoaMa(mahdn)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn nhập này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 40, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn nhập tìm được...", x + 4, y + 5);
                            mahdn = CongCu.ChuanHoaMa(mahdn);
                            List<CTHDNhap> list = cthdnhap.LayCTHDNhap(new CTHDNhap(mahdn, null, null, 0, 0, 0));
                            HienCT_N(x, y + 8, list, 5, 1);
                        }
                    }
                } while (mahdn == "" || hdnBLL.KT_MaHDN(CongCu.ChuanHoaMa(mahdn)) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            IHDNhapBLL hdnhap = new HDNhapBLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x + 13, y + 1, hdnhap.LayDSHDNhap(), 5, 1);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mahdn = "";
                IHDNhapBLL hdnhap = new HDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                           TÌM KIẾM HÓA ĐƠN NHẬP", x, y, 8, 112);
                IO.Writexy("Nhập mã hóa đơn nhập cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 13, y + 8, hdnhap.LayDSHDNhap(), 5, 0);

                do
                {
                    Console.SetCursorPosition(x + 32, y + 3);
                    mahdn = Console.ReadLine();
                    if (mahdn == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mahdn == "!")
                        return;
                    else
                    {
                        if (hdnBLL.KT_MaHDN(CongCu.ChuanHoaMa(mahdn)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn nhập này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn nhập tìm được...", x + 4, y + 5);
                            mahdn = CongCu.ChuanHoaMa(mahdn);
                            List<HDNhap> list = hdnhap.TimHDNhap(new HDNhap(mahdn, null, null, null, 0));
                            Hien(x + 13, y + 8, list, 5, 1);
                        }
                    }
                } while (mahdn == "" || hdnBLL.KT_MaHDN(CongCu.ChuanHoaMa(mahdn)) == false);
            } while (true);
        }
        public void Hien(int xx, int yy, List<HDNhap> list, int n, int type)
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
                IO.Writexy("                              DANH SÁCH HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌──────────────┬────────────────┬───────────────┬───────────────┬───────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HD nhập  │  Mã nhân viên  │   Mã nhà CC   │   Ngày nhập   │     Tổng tiền     │", x, y + 2);
                IO.Writexy("├──────────────┼────────────────┼───────────────┼───────────────┼───────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 15);
                    IO.Writexy(list[i].maHDN, x + 1, y + d, 15);
                    IO.Writexy("│", x + 15, y + d);
                    IO.Writexy(list[i].maNV, x + 16, y + d, 17);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].maNCC, x + 33, y + d, 16);
                    IO.Writexy("│", x + 48, y + d);
                    IO.Writexy(list[i].ngayNhap, x + 49, y + d, 16);
                    IO.Writexy("│", x + 64, y + d);
                    IO.Writexy(list[i].tongTien.ToString(), x + 65, y + d, 20);
                    IO.Writexy("│", x + 84, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────────┼────────────────┼───────────────┼───────────────┼───────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────────┴────────────────┴───────────────┴───────────────┴───────────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "      Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để quay lại...", x, y + d);
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
        public void HienCT_N(int xx, int yy, List<CTHDNhap> list, int n, int type)
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
                IO.Writexy("                                         DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌──────────────┬────────────────┬─────────────────────────┬───────────────┬───────────────┬────────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HD nhập  │  Mã máy tính   │      Tên máy tính       │   Số lượng    │    Đơn giá    │     Thành tiền     │", x, y + 2);
                IO.Writexy("├──────────────┼────────────────┼─────────────────────────┼───────────────┼───────────────┼────────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 15);
                    IO.Writexy(list[i].maHDN, x + 1, y + d, 15);
                    IO.Writexy("│", x + 15, y + d);
                    IO.Writexy(list[i].maMT, x + 16, y + d, 17);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].tenMT, x + 33, y + d, 26);
                    IO.Writexy("│", x + 58, y + d);
                    IO.Writexy(list[i].soLuong.ToString(), x + 59, y + d, 16);
                    IO.Writexy("│", x + 74, y + d);
                    IO.Writexy(list[i].donGia.ToString(), x + 75, y + d, 16);
                    IO.Writexy("│", x + 90, y + d);
                    IO.Writexy(list[i].thanhTien.ToString(), x + 91, y + d, 21);
                    IO.Writexy("│", x + 111, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────────┼────────────────┼─────────────────────────┼───────────────┼───────────────┼────────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────────┴────────────────┴─────────────────────────┴───────────────┴───────────────┴────────────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "      Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để quay lại...", x, y + d);
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
