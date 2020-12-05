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
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                        NHẬP THÔNG TIN HÓA ĐƠN NHẬP", x, y, 10, 112);
                IO.Writexy("Mã nhân viên:", x + 2, y + 3);
                IO.Writexy("Mã nhà cung cấp:", x + 29, y + 3);
                IO.Writexy("Mã máy tính:", x + 60, y + 3);
                IO.Writexy("Ngày nhập:", x + 87, y + 3);
                IO.Writexy("Số lượng:", x + 2, y + 5);
                IO.Writexy("Đơn giá:", x + 37, y + 5);
                IO.Writexy("Tổng tiền:", x + 72, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                HDNhap hdn = new HDNhap();

                fnv.Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 16, y + 3);
                    hdn.maNV = Console.ReadLine();
                    if (hdn.maNV == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhân viên...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nvBLL.KT_MaNhanVien(hdn.maNV.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhân viên này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 15, y + 3, 13, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdn.maNV == null || nvBLL.KT_MaNhanVien(hdn.maNV.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fncc.Hien(x + 16, y + 10, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 46, y + 3);
                    hdn.maNCC = Console.ReadLine();
                    if (hdn.maNCC == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(hdn.maNCC.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 45, y + 3, 14, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdn.maNCC == null || nccBLL.KT_MaNCC(hdn.maNCC.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fmt.Hien(x + 11, y + 10, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 73, y + 3);
                    hdn.maMT = Console.ReadLine();
                    if (hdn.maMT == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (mtBLL.KT_MaMayTinh(hdn.maMT.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 72, y + 3, 14, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (hdn.maMT == null || mtBLL.KT_MaMayTinh(hdn.maMT.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 0);
                IO.Writexy("Nhập ngày nhập định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 98, y + 3);
                    hdn.ngayNhap = Console.ReadLine();
                    if (hdn.ngayNhap == null || CongCu.CheckDate(hdn.ngayNhap) == false)
                    {
                        IO.Writexy("Nhập lại ngày nhập...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 97, y + 3, 13, ConsoleColor.Black);
                    }
                } while (hdn.ngayNhap == null || CongCu.CheckDate(hdn.ngayNhap) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 12, y + 5);
                    hdn.soLuong = int.Parse(Console.ReadLine());
                    if (hdn.soLuong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 11, y + 5, 16, ConsoleColor.Black);
                    }
                } while (hdn.soLuong <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 46, y + 5);
                    hdn.donGia = double.Parse(Console.ReadLine());
                    if (hdn.donGia <= 0)
                    {
                        IO.Writexy("Nhập lại đơn giá...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(46, 6, 16, ConsoleColor.Black);
                    }
                } while (hdn.donGia <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy(hdn.tongTien.ToString(), x + 83, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 34, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn nhập đã được thêm...", x + 4, y + 7);
                    hdnhap.ThemHDNhap(hdn);
                    Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 1);

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
                IHDNhapBLL hdnhap = new HDNhapBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                INCC_BLL nhacc = new NCC_BLL();
                IMayTinhBLL maytinh = new MayTinhBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormNCC fncc = new FormNCC();
                FormMayTinh fmt = new FormMayTinh();
                HDNhapBLL hdnBLL = new HDNhapBLL();
                NhanVienBLL nvBLL = new NhanVienBLL();
                NCC_BLL nccBLL = new NCC_BLL();
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                      CẬP NHẬT THÔNG TIN HÓA ĐƠN NHẬP", x, y, 10, 112);
                IO.Writexy("Mã HD nhập:", x + 2, y + 3);
                IO.Writexy("Mã nhân viên:", x + 28, y + 3);
                IO.Writexy("Mã nhà cung cấp:", x + 58, y + 3);
                IO.Writexy("Mã máy tính:", x + 89, y + 3);
                IO.Writexy("Ngày nhập:", x + 2, y + 5);
                IO.Writexy("Số lượng:", x + 32, y + 5);
                IO.Writexy("Đơn giá:", x + 57, y + 5);
                IO.Writexy("Tổng tiền:", x + 84, y + 5);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 0);

                string mahdn;
                string manv;
                string mancc;
                string mamt;
                string ngaynhap;
                int soluong;
                double dongia;

                do
                {
                    Console.SetCursorPosition(x + 14, y + 3);
                    mahdn = Console.ReadLine();
                    if (mahdn == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã hóa đơn nhập này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 13, y + 3, 14, ConsoleColor.Black);
                        }
                        else
                            mahdn = CongCu.CatXau(mahdn.ToUpper());
                    }
                } while (mahdn == "" || hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false);
                HDNhap hdn = hdnhap.LayHDNhap(mahdn);
                IO.Writexy(hdn.maNV.ToString(), x + 42, y + 3);
                IO.Writexy(hdn.maNCC.ToString(), x + 75, y + 3);
                IO.Writexy(hdn.maMT.ToString(), x + 102, y + 3);
                IO.Writexy(hdn.ngayNhap, x + 13, y + 5);
                IO.Writexy(hdn.soLuong.ToString(), x + 42, y + 5);
                IO.Writexy(hdn.donGia.ToString(), x + 66, y + 5);
                IO.Writexy(hdn.tongTien.ToString(), x + 95, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fnv.Hien(x, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
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
                        else if (manv != hdn.maNV && manv != "")
                            hdn.maNV = CongCu.CatXau(manv.ToUpper());
                    }
                } while (manv == "" || nvBLL.KT_MaNhanVien(manv.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fncc.Hien(x + 16, y + 10, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 75, y + 3);
                    mancc = Console.ReadLine();
                    if (mancc == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(mancc.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 74, y + 3, 14, ConsoleColor.Black);
                        }
                        else if (mancc != hdn.maNCC && mancc != "")
                            hdn.maNCC = CongCu.CatXau(mancc.ToUpper());
                    }
                } while (mancc == "" || nccBLL.KT_MaNCC(mancc.ToUpper()) == false);
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
                        else if (mamt != hdn.maMT && mamt != "")
                            hdn.maMT = CongCu.CatXau(mamt.ToUpper());
                    }
                } while (mamt == "" || mtBLL.KT_MaMayTinh(mamt.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 0);
                IO.Writexy("Nhập ngày nhập định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    Console.SetCursorPosition(x + 13, y + 5);
                    ngaynhap = Console.ReadLine();
                    if (ngaynhap == "" || CongCu.CheckDate(ngaynhap) == false)
                    {
                        IO.Writexy("Nhập lại ngày nhập...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 12, y + 5, 19, ConsoleColor.Black);
                    }
                    else if (ngaynhap != hdn.ngayNhap && ngaynhap != "")
                        hdn.ngayNhap = CongCu.CatXau(ngaynhap);
                } while (ngaynhap == "" || CongCu.CheckDate(ngaynhap) == false);
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
                    else if (soluong != hdn.soLuong && soluong > 0)
                        hdn.soLuong = soluong;
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
                    else if (dongia != hdn.donGia && dongia > 0)
                        hdn.donGia = dongia;
                } while (dongia <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy(hdn.tongTien.ToString(), x + 95, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 38, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn nhập đã được cập nhật...", x + 4, y + 7);
                    hdnhap.SuaHDNhap(hdn);
                    Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 1);

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
                string mahdn = "";
                IHDNhapBLL hdnhap = new HDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              XÓA HÓA ĐƠN NHẬP", x, y, 7, 112);
                IO.Writexy("Nhập mã hóa đơn nhập cần xóa:", x + 4, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                Hien(x, y + 7, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 34, y + 3);
                    mahdn = Console.ReadLine();
                    if (mahdn == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn nhập này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mahdn = CongCu.CatXau(mahdn.ToUpper());
                            hdnhap.XoaHDNhap(mahdn);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 33, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn nhập đã được xóa...", x + 4, y + 5);
                            Hien(x, y + 7, hdnhap.LayDSHDNhap(), 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                break;
                        }
                    }
                } while (mahdn == "" || hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false);

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
            IHDNhapBLL hdnhap = new HDNhapBLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x, y, hdnhap.LayDSHDNhap(), 5, 1);
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
                IO.BoxTitle("                                           TÌM KIẾM HÓA ĐƠN NHẬP", x, y, 7, 112);
                IO.Writexy("Nhập mã hóa đơn nhập cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                Hien(x, y + 7, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 32, y + 3);
                    mahdn = Console.ReadLine();
                    if (mahdn == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã hóa đơn nhập này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 31, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Hóa đơn nhập tìm được...", x + 4, y + 5);
                            mahdn = CongCu.CatXau(mahdn.ToUpper());
                            List<HDNhap> list = hdnhap.TimHDNhap(new HDNhap(mahdn, null, null, null, null, 0, 0, 0));
                            Hien(x, y+7, list, 5, 1);

                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                            Console.SetCursorPosition(x + 33, y + 5);
                            IO.Writexy("E", x + 4, y + 5);
                            IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                            ConsoleKeyInfo kt = Console.ReadKey();
                            if (kt.Key == ConsoleKey.Escape)
                                break;
                        }
                    }
                } while (mahdn == "" || hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false);

                IO.Clear(x + 3, y + 5, 60, ConsoleColor.White);
                Console.SetCursorPosition(x + 33, y + 5);
                IO.Writexy("E", x + 4, y + 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                ConsoleKeyInfo ktr = Console.ReadKey();
                if (ktr.Key == ConsoleKey.Escape)
                    break;
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
                IO.Writexy("                                            DANH SÁCH HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌──────────┬──────────┬──────────┬──────────┬─────────────────┬────────────┬─────────────────┬─────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HDN  │  Mã NV   │  Mã NCC  │  Mã MT   │    Ngày nhập    │  Số lượng  │     Đơn giá     │    Tổng tiền    │", x, y + 2);
                IO.Writexy("├──────────┼──────────┼──────────┼──────────┼─────────────────┼────────────┼─────────────────┼─────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 11);
                    IO.Writexy(list[i].maHDN, x + 1, y + d, 11);
                    IO.Writexy("│", x + 11, y + d);
                    IO.Writexy(list[i].maNV, x + 12, y + d, 11);
                    IO.Writexy("│", x + 22, y + d);
                    IO.Writexy(list[i].maNCC, x + 23, y + d, 11);
                    IO.Writexy("│", x + 33, y + d);
                    IO.Writexy(list[i].maMT, x + 34, y + d, 11);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].ngayNhap, x + 45, y + d, 18);
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
    }
}
