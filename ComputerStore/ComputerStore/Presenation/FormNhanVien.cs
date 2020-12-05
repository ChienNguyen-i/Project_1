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
    public class FormNhanVien
    {
        public void Nhap(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                INhanVienBLL nhanvien = new NhanVienBLL();
                NhanVienBLL nvBLL = new NhanVienBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                          NHẬP THÔNG TIN NHÂN VIÊN", x, y, 10, 112);
                IO.Writexy("Họ tên:", x + 2, y + 3);
                IO.Writexy("Ngày sinh:", x + 37, y + 3);
                IO.Writexy("Địa chỉ:", x + 64, y + 3);
                IO.Writexy("Giới tính:", x + 94, y + 3);
                IO.Writexy("Số điện thoại:", x + 2, y + 5);
                IO.Writexy("Loại nhân viên:", x + 37, y + 5);
                IO.Writexy("Mật khẩu:", x + 77, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();

                do
                {
                    Console.SetCursorPosition(x + 10, y + 3);
                    nv.tenNV = Console.ReadLine();
                    if (nv.tenNV == null || CongCu.CheckName(nv.tenNV) == false)
                    {
                        IO.Writexy("Nhập lại tên nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 9, y + 3, 27, ConsoleColor.Black);
                    }
                } while (nv.tenNV == null || CongCu.CheckName(nv.tenNV) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Nhập ngày sinh định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 48, y + 3);
                    nv.ngaySinh = Console.ReadLine();
                    if (nv.ngaySinh == null || CongCu.CheckDate(nv.ngaySinh) == false)
                    {
                        IO.Writexy("Nhập lại ngày sinh...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 47, y + 3, 16, ConsoleColor.Black);
                    }
                } while (nv.ngaySinh == null || CongCu.CheckDate(nv.ngaySinh) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 73, y + 3);
                    nv.diaChi = Console.ReadLine();
                    if (nv.diaChi == null)
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                } while (nv.diaChi == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 105, y + 3);
                    nv.gioiTinh = Console.ReadLine();
                    if (nv.gioiTinh == null || nvBLL.KTraGT(nv.gioiTinh) == false)
                    {
                        IO.Writexy("Nhập lại giới tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 104, y + 3, 6, ConsoleColor.Black);
                    }
                } while (nv.gioiTinh == null || nvBLL.KTraGT(nv.gioiTinh) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 17, y + 5);
                    nv.soDT = Console.ReadLine();
                    if (nv.soDT == null || nv.soDT.Length < 10 || nv.soDT.Length > 10 || CongCu.CheckNumber(nv.soDT) == false)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 16, y + 5, 20, ConsoleColor.Black);
                    }
                } while (nv.soDT == null || nv.soDT.Length < 10 || nv.soDT.Length > 10 || CongCu.CheckNumber(nv.soDT) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 53, y + 5);
                    nv.loaiNV = Console.ReadLine();
                    if (nv.loaiNV == null)
                        IO.Writexy("Nhập lại loại nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                } while (nv.loaiNV == null);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 87, y + 5);
                    nv.pass = Console.ReadLine();
                    if (nv.pass == null)
                        IO.Writexy("Nhập lại mật khẩu...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                } while (nv.pass == null);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 34, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Nhân viên đã được thêm...", x + 4, y + 7);
                    nhanvien.ThemNhanVien(nv);
                    Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 1);

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
                INhanVienBLL nhanvien = new NhanVienBLL();
                NhanVienBLL nvBLL = new NhanVienBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                        CẬP NHẬT THÔNG TIN NHÂN VIÊN", x, y, 10, 112);
                IO.Writexy("Mã NV:", x + 2, y + 3);
                IO.Writexy("Họ tên:", x + 23, y + 3);
                IO.Writexy("Ngày sinh:", x + 56, y + 3);
                IO.Writexy("Giới tính:", x + 85, y + 3);
                IO.Writexy("Địa chỉ:", x + 2, y + 5);
                IO.Writexy("Số điện thoại:", x + 27, y + 5);
                IO.Writexy("Loại nhân viên:", x + 53, y + 5);
                IO.Writexy("Mật khẩu:", x + 83, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 0);

                string manv;
                string tennv;
                string ngaysinh;
                string gioitinh;
                string diachi;
                string sdt;
                string loainv;
                string pass;

                do
                {
                    Console.SetCursorPosition(x + 9, y + 3);
                    manv = Console.ReadLine();
                    if (manv == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        if (nvBLL.KT_MaNhanVien(manv.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 8, y + 3, 14, ConsoleColor.Black);
                        }
                        else
                            manv = CongCu.CatXau(manv.ToUpper());
                    }
                } while (manv == "" || nvBLL.KT_MaNhanVien(manv.ToUpper()) == false);
                NhanVien nv = nhanvien.LayNhanVien(manv);
                IO.Writexy(nv.tenNV, x + 31, y + 3);
                IO.Writexy(nv.ngaySinh, x + 67, y + 3);
                IO.Writexy(nv.gioiTinh, x + 96, y + 3);
                IO.Writexy(nv.diaChi, x + 11, y + 5);
                IO.Writexy(nv.soDT, x + 42, y + 5);
                IO.Writexy(nv.loaiNV, x + 69, y + 5);
                IO.Writexy(nv.pass, x + 93, y + 5);
                
                IO.Clear(x + 110, y + 5, 14, ConsoleColor.Black);
                IO.Writexy("│  │", x + 111, y + 5);
                IO.Writexy("-----------", x + 1, y + 6);
                IO.Writexy("║║", x + 112, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 31, y + 3);
                    tennv = Console.ReadLine();
                    if (tennv == "" || CongCu.CheckName(tennv) == false)
                    {
                        IO.Writexy("Nhập lại tên nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 30, y + 3, 25, ConsoleColor.Black);
                    }
                    else if (tennv != nv.tenNV && tennv != "")
                        nv.tenNV = CongCu.ChuanHoaXau(tennv);
                } while (tennv == "" || CongCu.CheckName(tennv) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Nhập ngày sinh định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 67, y + 3);
                    ngaysinh = Console.ReadLine();
                    if (ngaysinh == "" || CongCu.CheckDate(ngaysinh) == false)
                    {
                        IO.Writexy("Nhập lại ngày sinh...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 66, y + 3, 18, ConsoleColor.Black);
                    }
                    else if (ngaysinh != nv.ngaySinh && ngaysinh != "")
                        nv.ngaySinh = CongCu.CatXau(ngaysinh);
                } while (ngaysinh == "" || CongCu.CheckDate(ngaysinh) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 96, y + 3);
                    gioitinh = Console.ReadLine();
                    if (gioitinh == "" || nvBLL.KTraGT(gioitinh) == false)
                    {
                        IO.Writexy("Nhập lại giới tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 95, y + 3, 15, ConsoleColor.Black);
                    }
                    else if (gioitinh != nv.gioiTinh && gioitinh != "")
                        nv.gioiTinh = CongCu.ChuanHoaXau(gioitinh);
                } while (gioitinh == "" || nvBLL.KTraGT(gioitinh) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 11, y + 5);
                    diachi = Console.ReadLine();
                    if (diachi == "")
                        IO.Writexy("Nhập lại địa chỉ...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (diachi != nv.diaChi && diachi != "")
                        nv.diaChi = CongCu.ChuanHoaXau(diachi);
                } while (diachi == "");
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 42, y + 5);
                    sdt = Console.ReadLine();
                    if (sdt == "" || sdt.Length < 10 || sdt.Length > 10 || CongCu.CheckNumber(sdt) == false)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 41, y + 5, 11, ConsoleColor.Black);
                    }
                    else if (sdt != nv.soDT && sdt != "")
                        nv.soDT = CongCu.CatXau(sdt);
                } while (sdt == "" || sdt.Length < 10 || sdt.Length > 10 || CongCu.CheckNumber(sdt) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 69, y + 5);
                    loainv = Console.ReadLine();
                    if (loainv == "")
                        IO.Writexy("Nhập lại loại nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (loainv != nv.loaiNV && loainv != "")
                        nv.loaiNV = CongCu.HoaDau(loainv);
                } while (loainv == "");
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 93, y + 5);
                    pass = Console.ReadLine();
                    if (pass == "")
                        IO.Writexy("Nhập lại mật khẩu...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (pass != nv.pass && pass != "")
                        nv.pass = CongCu.GetMD5(loainv);
                } while (pass == "");

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 38, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Nhân viên đã được cập nhật...", x + 4, y + 7);
                    nhanvien.SuaNhanVien(nv);
                    Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 1);

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
                string manv = "";
                INhanVienBLL nhanvien = new NhanVienBLL();
                NhanVienBLL nvBLL = new NhanVienBLL();
                Form_MN_QuanLy fmn = new Form_MN_QuanLy();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                               XÓA NHÂN VIÊN", x, y, 7, 112);
                IO.Writexy("Nhập mã nhân viên cần xóa:", x + 4, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                Hien(x, y + 7, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 31, y + 3);
                    manv = Console.ReadLine();
                    if (manv == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(manv.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 30, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            manv = CongCu.CatXau(manv.ToUpper());
                            nhanvien.XoaNhanVien(manv);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 30, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Nhân viên đã được xóa...", x + 4, y + 5);
                            Hien(x, y + 7, nhanvien.LayDSNhanVien(), 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                break;
                        }
                    }
                } while (manv == "" || nvBLL.KT_MaNhanVien(manv.ToUpper()) == false);

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
            INhanVienBLL nhanvien = new NhanVienBLL();
           
            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x, y, nhanvien.LayDSNhanVien(), 5, 1);
        }
        public void TimTen(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string hoten = "";
                INhanVienBLL nhanvien = new NhanVienBLL();
                NhanVienBLL nvBLL = new NhanVienBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              TÌM KIẾM NHÂN VIÊN", x, y, 7, 112);
                IO.Writexy("Nhập họ tên nhân viên cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                Hien(x, y + 7, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 33, y + 3);
                    hoten = Console.ReadLine();
                    if (hoten == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên nhân viên...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nvBLL.KT_TenNhanVien(CongCu.ChuanHoaXau(hoten)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại tên nhân viên này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 32, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Nhân viên tìm được...", x + 4, y + 5);
                            hoten = CongCu.ChuanHoaXau(hoten);
                            List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(null, hoten, null, null, null, null, null, null));
                            Hien(x, y + 7, list, 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                break;
                        }
                    }
                } while (hoten == "" || nvBLL.KT_TenNhanVien(CongCu.ChuanHoaXau(hoten)) == false);

                IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                Console.SetCursorPosition(x + 33, y + 5);
                IO.Writexy("E", x + 4, y + 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                ConsoleKeyInfo ktr = Console.ReadKey();
                if (ktr.Key == ConsoleKey.Escape)
                    break;
            } while (true);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string manv = "";
                INhanVienBLL nhanvien = new NhanVienBLL();
                NhanVienBLL nvBLL = new NhanVienBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              TÌM KIẾM NHÂN VIÊN", x, y, 7, 112);
                IO.Writexy("Nhập mã nhân viên cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                Hien(x, y + 7, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 29, y + 3);
                    manv = Console.ReadLine();
                    if (manv == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(manv.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 28, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Nhân viên tìm được...", x + 4, y + 5);
                            manv = CongCu.CatXau(manv.ToUpper());
                            List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(manv, null, null, null, null, null, null, null));
                            Hien(x, y + 7, list, 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                break;
                        }
                    }
                } while (manv == "" || nvBLL.KT_MaNhanVien(manv.ToUpper()) == false);

                IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                Console.SetCursorPosition(x + 33, y + 5);
                IO.Writexy("E", x + 4, y + 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                ConsoleKeyInfo ktr = Console.ReadKey();
                if (ktr.Key == ConsoleKey.Escape)
                    break;
            } while (true);
        }
        public void Hien(int xx, int yy, List<NhanVien> list, int n, int type)
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
                IO.Writexy("                                              DANH SÁCH NHÂN VIÊN", x, y);
                IO.Writexy("┌─────┬──────────────────────┬───────────┬─────────┬───────────────┬───────────┬──────────────┬────────────────┐", x, y + 1);
                IO.Writexy("│Mã NV│        Họ tên        │ Ngày sinh │Giới tính│    Địa chỉ    │   Số ĐT   │    Loại NV   │    Mật khẩu    │", x, y + 2);
                IO.Writexy("├─────┼──────────────────────┼───────────┼─────────┼───────────────┼───────────┼──────────────┼────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 6);
                    IO.Writexy(list[i].maNV, x + 1, y + d, 6);
                    IO.Writexy("│", x + 6, y + d);
                    IO.Writexy(list[i].tenNV, x + 7, y + d, 23);
                    IO.Writexy("│", x + 29, y + d);
                    IO.Writexy(list[i].ngaySinh, x + 30, y + d, 12);
                    IO.Writexy("│", x + 41, y + d);
                    IO.Writexy(list[i].gioiTinh, x + 42, y + d, 10);
                    IO.Writexy("│", x + 51, y + d);
                    IO.Writexy(list[i].diaChi, x + 52, y + d, 16);
                    IO.Writexy("│", x + 67, y + d);
                    IO.Writexy(list[i].soDT, x + 68, y + d, 12);
                    IO.Writexy("│", x + 79, y + d);
                    IO.Writexy(list[i].loaiNV, x + 80, y + d, 15);
                    IO.Writexy("│", x + 94, y + d);
                    IO.Writexy(list[i].pass, x + 95, y + d, 17);
                    IO.Writexy("│", x + 111, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────┼──────────────────────┼───────────┼─────────┼───────────────┼───────────┼──────────────┼────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────┴──────────────────────┴───────────┴─────────┴───────────────┴───────────┴──────────────┴────────────────┘", x, y + d - 1);
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
    }
}
