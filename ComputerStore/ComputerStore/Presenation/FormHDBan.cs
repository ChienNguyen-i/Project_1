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
                FormNhanVien fnv = new FormNhanVien();
                FormKhachHang fkh = new FormKhachHang();
                FormMayTinh fmt = new FormMayTinh();
                NhanVienBLL nvBLL = new NhanVienBLL();
                KhachHangBLL khBLL = new KhachHangBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                         NHẬP THÔNG TIN HÓA ĐƠN BÁN", x, y, 10, 112);
                IO.Writexy("Mã nhân viên:", x + 2, y + 3);
                IO.Writexy("Mã khách hàng:", x + 29, y + 3);
                IO.Writexy("Mã máy tính:", x + 60, y + 3);
                IO.Writexy("Ngày bán:", x + 87, y + 3);
                IO.Writexy("Số lượng:", x + 2, y + 5);
                IO.Writexy("Đơn giá:", x + 37, y + 5);
                IO.Writexy("Tổng tiền:", x + 72, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                HDBan hdb = new HDBan();

                fnv.Hien(x + 1, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 16, y + 3);
                    hdb.maNV = Console.ReadLine();
                    if (hdb.maNV == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(hdb.maNV.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 15, y + 3, 13, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdb.maNV == null || nvBLL.KT_MaNhanVien(hdb.maNV.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fkh.Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 44, y + 3);
                    hdb.maKH = Console.ReadLine();
                    if (hdb.maKH == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_MaKhachHang(hdb.maKH.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 43, y + 3, 16, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdb.maKH == null || khBLL.KT_MaKhachHang(hdb.maKH.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fmt.Hien(x + 11, y + 10, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 73, y + 3);
                    hdb.maMT = Console.ReadLine();
                    if (hdb.maMT == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (mtBLL.KT_MaMayTinh(hdb.maMT.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 72, y + 3, 14, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdb.maMT == null || mtBLL.KT_MaMayTinh(hdb.maMT.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                Hien(x, y + 10, hdban.LayDSHDBan(), 5, 0);
                IO.Writexy("Nhập ngày bán định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 97, y + 3);
                    hdb.ngayBan = Console.ReadLine();
                    if (hdb.ngayBan == null || CongCu.CheckDate(hdb.ngayBan) == false)
                    {
                        IO.Writexy("Nhập lại ngày bán...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 96, y + 3, 14, ConsoleColor.Black);
                    }
                } while (hdb.ngayBan == null || CongCu.CheckDate(hdb.ngayBan) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 12, y + 5);
                    hdb.soLuong = int.Parse(Console.ReadLine());
                    if (hdb.soLuong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 11, y + 5, 14, ConsoleColor.Black);
                    }
                } while (hdb.soLuong <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 46, y + 5);
                    hdb.donGia = double.Parse(Console.ReadLine());
                    if (hdb.donGia <= 0)
                    {
                        IO.Writexy("Nhập lại đơn giá...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 45, y + 5, 14, ConsoleColor.Black);
                    }
                } while (hdb.donGia <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy(hdb.tongTien.ToString(), x + 83, y + 5);

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
                    hdban.ThemHDBan(hdb);
                    Hien(x, y + 10, hdban.LayDSHDBan(), 5, 1);

                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    Console.SetCursorPosition(x + 34, y + 7);
                    IO.Writexy("E", x + 4, y + 7);
                    IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                    ConsoleKeyInfo ktr = Console.ReadKey();
                    if (ktr.Key == ConsoleKey.Escape)
                        break;
                }
            } while (true);
        }
        public void Sua(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                IHDBanBLL hdban = new HDBanBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                IKhachHangBLL khachhang = new KhachHangBLL();
                IMayTinhBLL maytinh = new MayTinhBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormKhachHang fkh = new FormKhachHang();
                FormMayTinh fmt = new FormMayTinh();
                NhanVienBLL nvBLL = new NhanVienBLL();
                KhachHangBLL khBLL = new KhachHangBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();
                HDBanBLL hdbBLL = new HDBanBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                       CẬP NHẬT THÔNG TIN HÓA ĐƠN BÁN", x, y, 10, 112);
                IO.Writexy("Mã HD bán:", x + 2, y + 3);
                IO.Writexy("Mã nhân viên:", x + 28, y + 3);
                IO.Writexy("Mã khách hàng:", x + 58, y + 3);
                IO.Writexy("Mã máy tính:", x + 89, y + 3);
                IO.Writexy("Ngày bán:", x + 2, y + 5);
                IO.Writexy("Số lượng:", x + 32, y + 5);
                IO.Writexy("Đơn giá:", x + 57, y + 5);
                IO.Writexy("Tổng tiền:", x + 84, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                Hien(x, y + 10, hdban.LayDSHDBan(), 5, 0);

                string mahdb;
                string manv;
                string makh;
                string mamt;
                string ngayban;
                int soluong;
                double dongia;

                do
                {
                    Console.SetCursorPosition(x + 13, y + 3);
                    mahdb = Console.ReadLine();
                    if (mahdb == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (hdbBLL.KT_MaHDB(mahdb.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã hóa đơn bán này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 12, y + 3, 15, ConsoleColor.Black);
                        }
                        else
                            mahdb = CongCu.CatXau(mahdb.ToUpper());
                    }
                } while (mahdb == "" || hdbBLL.KT_MaHDB(mahdb.ToUpper()) == false);
                HDBan hdb = hdban.LayHDBan(mahdb);
                IO.Writexy(hdb.maNV.ToString(), x + 42, y + 3);
                IO.Writexy(hdb.maKH.ToString(), x + 73, y + 3);
                IO.Writexy(hdb.maMT.ToString(), x + 102, y + 3);
                IO.Writexy(hdb.ngayBan, x + 12, y + 5);
                IO.Writexy(hdb.soLuong.ToString(), x + 42, y + 5);
                IO.Writexy(hdb.donGia.ToString(), x + 66, y + 5);
                IO.Writexy(hdb.tongTien.ToString(), x + 95, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fnv.Hien(x + 1, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 42, y + 3);
                    manv = Console.ReadLine();
                    if (manv == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(manv.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 41, y + 3, 16, ConsoleColor.Black);
                        }
                        else if (manv != hdb.maNV && manv != "")
                            hdb.maNV = CongCu.CatXau(manv.ToUpper());
                    }
                } while (manv == "" || nvBLL.KT_MaNhanVien(manv.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fkh.Hien(x + 16, y + 10, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 73, y + 3);
                    makh = Console.ReadLine();
                    if (makh == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã khách hàng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (khBLL.KT_MaKhachHang(makh.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã khách hàng này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 72, y + 3, 16, ConsoleColor.Black);
                        }
                        else if (makh != hdb.maKH && makh != "")
                            hdb.maKH = CongCu.CatXau(makh.ToUpper());
                    }
                } while (makh == "" || khBLL.KT_MaKhachHang(makh.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fmt.Hien(x + 11, y + 10, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 102, y + 3);
                    mamt = Console.ReadLine();
                    if (mamt == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (mtBLL.KT_MaMayTinh(mamt.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 101, y + 3, 9, ConsoleColor.Black);
                        }
                        else if (mamt != hdb.maMT && mamt != "")
                            hdb.maMT = CongCu.CatXau(mamt.ToUpper());
                    }
                } while (mamt == "" || mtBLL.KT_MaMayTinh(mamt.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                Hien(x, y + 10, hdban.LayDSHDBan(), 5, 0);
                IO.Writexy("Nhập ngày bán định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 12, y + 5);
                    ngayban = Console.ReadLine();
                    if (ngayban == "" || CongCu.CheckDate(ngayban) == false)
                    {
                        IO.Writexy("Nhập lại ngày bán...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 11, y + 5, 20, ConsoleColor.Black);
                    }
                    else if (ngayban != hdb.ngayBan && ngayban != "")
                        hdb.ngayBan = CongCu.CatXau(ngayban);
                } while (ngayban == "" || CongCu.CheckDate(ngayban) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 42, y + 5);
                    soluong = int.Parse(Console.ReadLine());
                    if (soluong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 41, y + 5, 12, ConsoleColor.Black);
                    }
                    else if (soluong != hdb.soLuong && soluong > 0)
                        hdb.soLuong = soluong;
                } while (soluong <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 66, y + 5);
                    dongia = double.Parse(Console.ReadLine());
                    if (dongia <= 0)
                    {
                        IO.Writexy("Nhập lại đơn giá...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 65, y + 5, 14, ConsoleColor.Black);
                    }
                    else if (dongia != hdb.donGia && dongia > 0)
                        hdb.donGia = dongia;
                } while (dongia <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy(hdb.tongTien.ToString(), x + 95, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 38, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn bán đã được cập nhật...", x + 4, y + 7);
                    hdban.SuaHDBan(hdb);
                    Hien(x, y + 10, hdban.LayDSHDBan(), 5, 1);

                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    Console.SetCursorPosition(x + 38, y + 7);
                    IO.Writexy("E", x + 4, y + 7);
                    IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                    ConsoleKeyInfo ktr = Console.ReadKey();
                    if (ktr.Key == ConsoleKey.Escape)
                        break;
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
                IHDBanBLL hdban = new HDBanBLL();
                HDBanBLL hdbBLL = new HDBanBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              XÓA HÓA ĐƠN BÁN", x, y, 7, 112);
                IO.Writexy("Nhập mã hóa đơn bán cần xóa:", x + 4, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                Hien(x, y + 7, hdban.LayDSHDBan(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 33, y + 3);
                    mahdb = Console.ReadLine();
                    if (mahdb == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (hdbBLL.KT_MaHDB(mahdb.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn bán này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 32, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mahdb = CongCu.CatXau(mahdb.ToUpper());
                            hdban.XoaHDBan(mahdb);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 32, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn bán đã được xóa...", x + 4, y + 5);
                            Hien(x, y + 7, hdban.LayDSHDBan(), 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        }
                    }
                } while (mahdb == "" || hdbBLL.KT_MaHDB(mahdb.ToUpper()) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            IHDBanBLL hdban = new HDBanBLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x, y, hdban.LayDSHDBan(), 5, 1);
            HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
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
                IO.BoxTitle("                                            TÌM KIẾM HÓA ĐƠN BÁN", x, y, 7, 112);
                IO.Writexy("Nhập mã hóa đơn bán cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                Hien(x, y + 7, hdban.LayDSHDBan(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 31, y + 3);
                    mahdb = Console.ReadLine();
                    if (mahdb == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
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
                            List<HDBan> list = hdban.TimHDBan(new HDBan(mahdb, null, null, null, null, 0, 0, 0));
                            Hien(x, y + 7, list, 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
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
                IO.Writexy("                                             DANH SÁCH HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌──────────┬──────────┬──────────┬──────────┬─────────────────┬────────────┬─────────────────┬─────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HDB  │  Mã NV   │  Mã KH   │  Mã MT   │    Ngày bán     │  Số lượng  │     Đơn giá     │    Tổng tiền    │", x, y + 2);
                IO.Writexy("├──────────┼──────────┼──────────┼──────────┼─────────────────┼────────────┼─────────────────┼─────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 11);
                    IO.Writexy(list[i].maHDB, x + 1, y + d, 11);
                    IO.Writexy("│", x + 11, y + d);
                    IO.Writexy(list[i].maNV, x + 12, y + d, 11);
                    IO.Writexy("│", x + 22, y + d);
                    IO.Writexy(list[i].maKH, x + 23, y + d, 11);
                    IO.Writexy("│", x + 33, y + d);
                    IO.Writexy(list[i].maMT, x + 34, y + d, 11);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].ngayBan, x + 45, y + d, 18);
                    IO.Writexy("│", x + 62, y + d);
                    IO.Writexy(list[i].soLuong.ToString(), x + 63, y + d, 13);
                    IO.Writexy("│", x + 75, y + d);
                    IO.Writexy(list[i].donGia.ToString(), x + 76, y + d, 18);
                    IO.Writexy("│", x + 93, y + d);
                    IO.Writexy(list[i].tongTien.ToString(), x + 94, y + d, 18);
                    IO.Writexy("│", x + 111, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────┼──────────┼──────────┼──────────┼─────────────────┼────────────┼─────────────────┼─────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────┴──────────┴──────────┴──────────┴─────────────────┴────────────┴─────────────────┴─────────────────┘", x, y + d - 1);
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
        public void HienChucNang(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách hóa đơn bán", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin hóa đơn bán", x + 12, y + 5);
                IO.Writexy("F3. Xóa hóa đơn bán", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách hóa đơn bán", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm hóa đơn bán", x + 12, y + 11);
                IO.Writexy("F6. Quay lại ", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormHDBan hdban = new FormHDBan();
                FormMenuChinh fhd = new FormMenuChinh();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        hdban.Nhap(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        hdban.Sua(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        hdban.Xoa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        hdban.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        hdban.TimMa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        fhd.HienHoaDon(30, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
    }
}
