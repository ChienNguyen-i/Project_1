using System;
using System.Text;
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

                fnv.Hien(x + 1, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    hdn.maNV = IO.ReadString(x + 16, y + 3);
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
                    hdn.maNCC = IO.ReadString(x + 46, y + 3);
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
                    hdn.maMT = IO.ReadString(x + 73, y + 3);
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
                    hdn.ngayNhap = IO.ReadString(x + 98, y + 3);
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
                    hdn.soLuong = int.Parse(IO.ReadNumber(x + 12, y + 5));
                    if (hdn.soLuong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 11, y + 5, 16, ConsoleColor.Black);
                    }
                } while (hdn.soLuong <= 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    hdn.donGia = double.Parse(IO.ReadNumber(x + 46, y + 5));
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
                    HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn nhập đã được thêm...", x + 4, y + 7);
                    hdnhap.ThemHDNhap(hdn);
                    Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 1);
                }
            } while (true);
        }
        public void Sua(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
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
                Hien(x, y+10, hdnhap.LayDSHDNhap(), 5, 0);

                string mahdn;
                string manv;
                string mancc;
                string mamt;
                string ngaynhap;
                int soluong;
                double dongia;

                do
                {
                    mahdn = IO.ReadString(x + 14, y + 3);
                    if (mahdn == null)
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
                } while (mahdn == null || hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false);
                HDNhap hdn = hdnhap.LayHDNhap(mahdn);
                IO.Writexy(hdn.maNV.ToString(), x + 42, y + 3);
                IO.Writexy(hdn.maNCC.ToString(), x + 75, y + 3);
                IO.Writexy(hdn.maMT.ToString(), x + 102, y + 3);
                IO.Writexy(hdn.ngayNhap, x + 13, y + 5);
                IO.Writexy(hdn.soLuong.ToString(), x + 42, y + 5);
                IO.Writexy(hdn.donGia.ToString(), x + 66, y + 5);
                IO.Writexy(hdn.tongTien.ToString(), x + 95, y + 5);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fnv.Hien(x + 1, y + 10, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    manv = IO.ReadString(x + 42, y + 3);
                    if (manv == null)
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
                        else if (manv != hdn.maNV && manv != null)
                            hdn.maNV = CongCu.CatXau(manv.ToUpper());
                    }
                } while (manv == null || nvBLL.KT_MaNhanVien(manv.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fncc.Hien(x + 16, y + 10, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    mancc = IO.ReadString(x + 75, y + 3);
                    if (mancc == null)
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
                        else if (mancc != hdn.maNCC && mancc != null)
                            hdn.maNCC = CongCu.CatXau(mancc.ToUpper());
                    }
                } while (mancc == null || nccBLL.KT_MaNCC(mancc.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fmt.Hien(x + 11, y + 10, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    mamt = IO.ReadString(x + 102, y + 3);
                    if (mamt == null)
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
                        else if (mamt != hdn.maMT && mamt != null)
                            hdn.maMT = CongCu.CatXau(mamt.ToUpper());
                    }
                } while (mamt == null || mtBLL.KT_MaMayTinh(mamt.ToUpper()) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 0);
                IO.Writexy("Nhập ngày nhập định dạng 'dd/MM/yyyy'...", x + 4, y + 8, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    ngaynhap = IO.ReadString(x + 13, y + 5);
                    if (ngaynhap == null || CongCu.CheckDate(ngaynhap) == false)
                    {
                        IO.Writexy("Nhập lại ngày nhập...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 12, y + 5, 19, ConsoleColor.Black);
                    }
                    else if (ngaynhap != hdn.ngayNhap && ngaynhap != null)
                        hdn.ngayNhap = CongCu.CatXau(ngaynhap);
                } while (ngaynhap == null || CongCu.CheckDate(ngaynhap) == false);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    soluong = int.Parse(IO.ReadNumber(x + 42, y + 5));
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
                    dongia = double.Parse(IO.ReadNumber(x + 66, y + 5));
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
                    HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn nhập đã được cập nhật...", x + 4, y + 7);
                    hdnhap.SuaHDNhap(hdn);
                    Hien(x, y + 10, hdnhap.LayDSHDNhap(), 5, 1);
                }
            } while (true);
        }
        public void Xoa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                string mahdn = "";
                IHDNhapBLL hdnhap = new HDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                              XÓA HÓA ĐƠN NHẬP", x, y, 7, 112);
                IO.Writexy("Nhập mã hóa đơn nhập cần xóa:", x + 4, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để xóa, Esc để thoát...", x + 4, y + 5);
                Hien(x, y + 7, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    mahdn = IO.ReadString(x + 34, y + 3);
                    if (mahdn == null)
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
                        }
                    }
                } while (mahdn == null || hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            IHDNhapBLL hdnhap = new HDNhapBLL();
            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x, y, hdnhap.LayDSHDNhap(), 5, 1);
            HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                string mahdn = "";
                IHDNhapBLL hdnhap = new HDNhapBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                           TÌM KIẾM HÓA ĐƠN NHẬP", x, y, 7, 112);
                IO.Writexy("Nhập mã hóa đơn nhập cần tìm:", x + 2, y + 3);
                IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Enter để tìm, Esc để thoát...", x + 4, y + 5);
                Hien(x, y + 7, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    mahdn = IO.ReadString(x + 32, y + 3);
                    if (mahdn == null)
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
                        }
                    }
                } while (mahdn == null || hdnBLL.KT_MaHDN(mahdn.ToUpper()) == false);
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
        public void HienChucNang(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách hóa đơn nhập", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin hóa đơn nhập", x + 12, y + 5);
                IO.Writexy("F3. Xóa hóa đơn nhập", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách hóa đơn nhập", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm hóa đơn nhập", x + 12, y + 11);
                IO.Writexy("F6. Quay lại", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormHDNhap hdnhap = new FormHDNhap();
                FormMenuChinh fhd = new FormMenuChinh();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        hdnhap.Nhap(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        hdnhap.Sua(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        hdnhap.Xoa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        hdnhap.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        hdnhap.TimMa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        fhd.HienHoaDon(30, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
    }
}
