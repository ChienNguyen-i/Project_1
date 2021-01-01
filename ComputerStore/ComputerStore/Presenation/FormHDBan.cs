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
    public class FormHDBan
    {
        public void Nhap(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                IHDBanBLL hdban = new HDBanBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                IKhachHangBLL khachhang = new KhachHangBLL();
                IMayTinhBLL maytinh = new MayTinhBLL();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormKhachHang fkh = new FormKhachHang();
                FormMayTinh fmt = new FormMayTinh();
                NhanVienBLL nvBLL = new NhanVienBLL();
                KhachHangBLL khBLL = new KhachHangBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();
                FormHDNhap fhdn = new FormHDNhap();
                ICTHDBanBLL cthdban = new CTHDBanBLL();
                HDBanBLL hdbBLL = new HDBanBLL();
                HDBan hdb = new HDBan();
                CTHDBan cthdb = new CTHDBan();
                HDBan hd;


                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                         NHẬP THÔNG TIN HÓA ĐƠN BÁN", x, y, 10, 112);
                IO.Writexy("Mã nhân viên:", x + 2, y + 3);
                IO.Writexy("Mã khách hàng:", x + 28, y + 3);
                IO.Writexy("Ngày bán:", x + 55, y + 3);
                IO.Writexy("Tổng tiền:", x + 83, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Mã máy tính:", x + 2, y + 5);
                IO.Writexy("Số lượng:", x + 28, y + 5);
                IO.Writexy("Đơn giá:", x + 55, y + 5);
                IO.Writexy("Thành tiền:", x + 83, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);

                fnv.Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 16, y + 3);
                    hdb.maNV = Console.ReadLine();
                    if (hdb.maNV == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (hdb.maNV == "!")
                        return;
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(CongCu.ChuanHoaMa(hdb.maNV)) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 15, y + 3, 12, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdb.maNV == null || nvBLL.KT_MaNhanVien(CongCu.ChuanHoaMa(hdb.maNV)) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                fkh.Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 43, y + 3);
                    hdb.maKH = Console.ReadLine();
                    if (hdb.maKH == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(hdb.maKH)) == false)
                        {
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 42, y + 3, 12, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdb.maKH == null || khBLL.KT_MaKhachHang(CongCu.ChuanHoaMa(hdb.maKH)) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fhdn.Hien(x + 13, y + 10, hdnhap.LayDSHDNhap(), 5, 0);
                IO.Writexy("Nhập ngày bán định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 65, y + 3);
                    hdb.ngayBan = Console.ReadLine();
                    if (hdb.ngayBan == null || CongCu.CheckDate(hdb.ngayBan) == false)
                    {
                        IO.Writexy("Nhập lại ngày bán...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 64, y + 3, 18, ConsoleColor.Black);
                    }
                } while (hdb.ngayBan == null || CongCu.CheckDate(hdb.ngayBan) == false);

                hdban.ThemHDBan(hdb);

                while (true)
                {
                    hd = hdbBLL.LayMaHDB(hdb.maNV, hdb.maKH, hdb.ngayBan);
                    cthdb.maHDB = hd.maHDB;

                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    fmt.Hien(x + 11, y + 10, maytinh.LayDSMayTinh(), 5, 0);
                    do
                    {
                        IO.Clear(x + 14, y + 5, 13, ConsoleColor.Black);
                        Console.SetCursorPosition(x + 15, y + 5);
                        cthdb.maMT = Console.ReadLine();
                        if (cthdb.maMT == null)
                        {
                            IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                            IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        }
                        else
                        {
                            if (mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(cthdb.maMT)) == false)
                            {
                                IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                                IO.Clear(x + 14, y + 5, 13, ConsoleColor.Black);
                            }
                            else
                                break;
                        }
                    } while (cthdb.maMT == null || mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(cthdb.maMT)) == false);
                    IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    MayTinh mt = mtBLL.LayMayTinh(CongCu.ChuanHoaMa(cthdb.maMT));
                    do
                    {
                        IO.Clear(x + 37, y + 5, 14, ConsoleColor.Black);
                        cthdb.soLuong = int.Parse(IO.ReadNumber(x + 38, y + 5));
                        if (cthdb.soLuong <= 0 || mt.sLCon <= 0 || cthdb.soLuong > mt.sLCon)
                        {
                            IO.Writexy("Nhập lại số lượng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 37, y + 5, 14, ConsoleColor.Black);
                        }
                    } while (cthdb.soLuong <= 0 || mt.sLCon <= 0 || cthdb.soLuong > mt.sLCon);

                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Clear(x + 63, y + 5, 16, ConsoleColor.Black);
                    cthdb.donGia = mt.giaBan;
                    IO.Writexy(cthdb.donGia.ToString(), x + 64, y + 5);
                    

                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Clear(x + 94, y + 5, 16, ConsoleColor.Black);
                    IO.Writexy(cthdb.thanhTien.ToString(), x + 95, y + 5);

                    cthdban.ThemCTHDBan(cthdb);

                    if (mtBLL.KT_MaMayTinh(cthdb.maMT) == true)
                        mtBLL.TruSoLuong(mt, cthdb.soLuong);

                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    Console.SetCursorPosition(x + 34, y + 7);
                    IO.Writexy("Nhập tiếp? (C/K)...", x + 4, y + 7);
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar != 'c')
                        break;
                }

                IO.Clear(x + 93, y + 5, 16, ConsoleColor.Black);
                IO.Writexy(hdbBLL.TTien(cthdb.maHDB).ToString(), x + 94, y + 3);
                hdb.tongTien = hdbBLL.TTien(cthdb.maHDB);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 34, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn bán đã được thêm...", x + 4, y + 7);
                    hdban.XoaHDBan(cthdb.maHDB);
                    hdban.ThemHDBan(hdb);
                    Hien(x + 13, y + 10, hdban.LayDSHDBan(), 5, 1);
                }
            } while (true);
        }
        public void Xoa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mahdb = "";
                ICTHDBanBLL cthdban = new CTHDBanBLL();
                IHDBanBLL hdban = new HDBanBLL();
                HDBanBLL hdbBLL = new HDBanBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                             XÓA HÓA ĐƠN BÁN", x, y, 8, 110);
                IO.Writexy("Nhập mã hóa đơn bán cần xóa:", x + 4, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 13, y + 8, hdban.LayDSHDBan(), 5, 0);

                do
                {
                    Console.SetCursorPosition(x + 33, y + 3);
                    mahdb = Console.ReadLine();
                    if (mahdb == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mahdb == "!")
                        return;
                    else
                    {
                        if (hdbBLL.KT_MaHDB(CongCu.ChuanHoaMa(mahdb)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn bán này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 32, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mahdb = CongCu.ChuanHoaMa(mahdb);
                            hdban.XoaHDBan(mahdb);
                            cthdban.XoaCTHDBan(mahdb);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 32, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn nhập đã được xóa...", x + 4, y + 5);
                            Hien(x + 13, y + 8, hdban.LayDSHDBan(), 5, 1);
                        }
                    }
                } while (mahdb == "" || hdbBLL.KT_MaHDB(CongCu.ChuanHoaMa(mahdb)) == false);
            } while (true);
        }
        public void XemCTHDB(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mahdb = "";
                ICTHDBanBLL cthdban = new CTHDBanBLL();
                IHDBanBLL hdban = new HDBanBLL();
                HDBanBLL hdbBLL = new HDBanBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                    XEM DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP", x, y, 8, 112);
                IO.Writexy("Nhập mã hóa đơn bán cần xem chi tiết:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 13, y + 8, hdban.LayDSHDBan(), 5, 0);

                do
                {
                    Console.SetCursorPosition(x + 40, y + 3);
                    mahdb = Console.ReadLine();
                    if (mahdb == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mahdb == "!")
                        return;
                    else
                    {
                        if (hdbBLL.KT_MaHDB(CongCu.ChuanHoaMa(mahdb)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn bán này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 39, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn bán tìm được...", x + 4, y + 5);
                            mahdb = CongCu.ChuanHoaMa(mahdb);
                            List<CTHDBan> list = cthdban.LayCTHDBan(new CTHDBan(mahdb, null, 0, 0, 0));
                            HienCT_B(x + 13, y + 8, list, 5, 1);
                        }
                    }
                } while (mahdb == "" || hdbBLL.KT_MaHDB(CongCu.ChuanHoaMa(mahdb)) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            IHDBanBLL hdban = new HDBanBLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x + 13, y + 1, hdban.LayDSHDBan(), 5, 1);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mahdb = "";
                IHDBanBLL hdban = new HDBanBLL();
                HDBanBLL hdbBLL = new HDBanBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                            TÌM KIẾM HÓA ĐƠN BÁN", x, y, 8, 112);
                IO.Writexy("Nhập mã hóa đơn bán cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 13, y + 8, hdban.LayDSHDBan(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 31, y + 3);
                    mahdb = Console.ReadLine();
                    if (mahdb == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mahdb == "!")
                        return;
                    else
                    {
                        if (hdbBLL.KT_MaHDB(mahdb.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn bán này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 30, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn bán tìm được...", x + 4, y + 5);
                            mahdb = CongCu.CatXau(mahdb.ToUpper());
                            List<HDBan> list = hdban.TimHDBan(new HDBan(mahdb, null, null, null, 0));
                            Hien(x + 13, y + 8, list, 5, 1);
                        }
                    }
                } while (mahdb == "" || hdbBLL.KT_MaHDB(mahdb.ToUpper()) == false);
            } while (true);
        }
        public void Hien(int xx, int yy, List<HDBan> list, int n, int type)
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
                IO.Writexy("                               DANH SÁCH HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌──────────────┬────────────────┬───────────────┬───────────────┬───────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HD bán   │  Mã nhân viên  │ Mã khách hàng │   Ngày bán    │     Tổng tiền     │", x, y + 2);
                IO.Writexy("├──────────────┼────────────────┼───────────────┼───────────────┼───────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 15);
                    IO.Writexy(list[i].maHDB, x + 1, y + d, 15);
                    IO.Writexy("│", x + 15, y + d);
                    IO.Writexy(list[i].maNV, x + 16, y + d, 17);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].maKH, x + 33, y + d, 16);
                    IO.Writexy("│", x + 48, y + d);
                    IO.Writexy(list[i].ngayBan, x + 49, y + d, 16);
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
        public void HienCT_B(int xx, int yy, List<CTHDBan> list, int n, int type)
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
                IO.Writexy("                           DANH SÁCH CHI TIẾT HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌──────────────┬────────────────┬───────────────┬───────────────┬───────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HD bán   │  Mã máy tính   │   Số lượng    │    Đơn giá    │    Thành tiền     │", x, y + 2);
                IO.Writexy("├──────────────┼────────────────┼───────────────┼───────────────┼───────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 15);
                    IO.Writexy(list[i].maHDB, x + 1, y + d, 15);
                    IO.Writexy("│", x + 15, y + d);
                    IO.Writexy(list[i].maMT, x + 16, y + d, 17);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].soLuong.ToString(), x + 33, y + d, 16);
                    IO.Writexy("│", x + 48, y + d);
                    IO.Writexy(list[i].donGia.ToString(), x + 49, y + d, 16);
                    IO.Writexy("│", x + 64, y + d);
                    IO.Writexy(list[i].thanhTien.ToString(), x + 65, y + d, 20);
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
    }
}
