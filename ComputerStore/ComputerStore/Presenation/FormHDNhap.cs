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
        public void Nhap()
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

                Console.Clear();
                IO.BoxTitle("                                 NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 100);
                IO.Writexy("Mã nhân viên:", 3, 4);
                IO.Writexy("Mã nhà cung cấp:", 25, 4);
                IO.Writexy("Mã máy tính:", 51, 4);
                IO.Writexy("Ngày nhập:", 75, 4);
                IO.Writexy("Số lượng:", 3, 6);
                IO.Writexy("Đơn giá:", 33, 6);
                IO.Writexy("Tổng tiền:", 68, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                HDNhap hdn = new HDNhap();

                fnv.Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    hdn.maNV = IO.ReadString(17, 4);
                    if (hdn.maNV == null)
                        IO.Writexy("Nhập lại mã nhân viên...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdn.maNV == null);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                fncc.Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    hdn.maNCC = IO.ReadString(42, 4);
                    if (hdn.maNCC == null)
                        IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdn.maNCC == null);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                fmt.Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    hdn.maMT = IO.ReadString(64, 4);
                    if (hdn.maMT == null)
                        IO.Writexy("Nhập lại mã máy tính...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdn.maMT == null);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    hdn.ngayNhap = IO.ReadString(86, 4);
                    if (hdn.ngayNhap == null)
                        IO.Writexy("Nhập lại ngày nhập...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdn.ngayNhap == null);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                do
                {
                    hdn.soLuong = int.Parse(IO.ReadNumber(13, 6));
                    if (hdn.soLuong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(12, 6, 16, ConsoleColor.Black);
                    }
                } while (hdn.soLuong <= 0);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                do
                {
                    hdn.donGia = double.Parse(IO.ReadNumber(42, 6));
                    if (hdn.donGia <= 0)
                    {
                        IO.Writexy("Nhập lại đơn giá...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(41, 6, 16, ConsoleColor.Black);
                    }
                } while (hdn.donGia <= 0);
                IO.Clear(4, 8, 30, ConsoleColor.Black);
                IO.Writexy(hdn.tongTien.ToString(), 79, 6);

                IO.Clear(4, 8, 30, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(35, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    hdnhap.ThemHDNhap(hdn);
                    Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 1);
                }
            } while (true);
        }
        public void Sua()
        {
            IHDNhapBLL hdnhap = new HDNhapBLL();
            INhanVienBLL nhanvien = new NhanVienBLL();
            INCC_BLL nhacc = new NCC_BLL();
            IMayTinhBLL maytinh = new MayTinhBLL();
            FormNhanVien fnv = new FormNhanVien();
            FormNCC fncc = new FormNCC();
            FormMayTinh fmt = new FormMayTinh();

            Console.Clear();
            IO.BoxTitle("                               CẬP NHẬT THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 100);
            IO.Writexy("Mã HD nhập:", 3, 4);
            IO.Writexy("Mã nhân viên:", 23, 4);
            IO.Writexy("Mã nhà cung cấp:", 50, 4);
            IO.Writexy("Mã máy tính:", 76, 4);
            IO.Writexy("Ngày nhập:", 3, 6);
            IO.Writexy("Số lượng:", 28, 6);
            IO.Writexy("Đơn giá:", 50, 6);
            IO.Writexy("Tổng tiền:", 74, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 0);

            string mahdn;
            string manv;
            string mancc;
            string mamt;
            string ngaynhap;
            int soluong;
            double dongia;

            do
            {
                mahdn = IO.ReadString(15, 4);
                if (mahdn == null)
                    IO.Writexy("Nhập lại mã hóa đơn nhập...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else
                    mahdn = CongCu.CatXau(mahdn.ToUpper());
            } while (mahdn == null);
            HDNhap hdn = hdnhap.LayHDNhap(mahdn);
            IO.Writexy(hdn.maNV.ToString(), 37, 4);
            IO.Writexy(hdn.maNCC.ToString(), 67, 4);
            IO.Writexy(hdn.maMT.ToString(), 89, 4);
            IO.Writexy(hdn.ngayNhap, 14, 6);
            IO.Writexy(hdn.soLuong.ToString(), 38, 6);
            IO.Writexy(hdn.donGia.ToString(), 59, 6);
            IO.Writexy(hdn.tongTien.ToString(), 85, 6);

            IO.Clear(4, 8, 30, ConsoleColor.Black);
            fnv.Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
            do
            {
                manv = IO.ReadString(37, 4);
                if (manv == null)
                    IO.Writexy("Nhập lại mã nhân viên...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (manv != hdn.maNV && manv != null)
                    hdn.maNV = CongCu.CatXau(manv.ToUpper());
            } while (manv == null);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            fncc.Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
            do
            {
                mancc = IO.ReadString(67, 4);
                if (mancc == null)
                    IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (mancc != hdn.maNCC && mancc != null)
                    hdn.maNCC = CongCu.CatXau(mancc.ToUpper());
            } while (mancc == null);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            fmt.Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
            do
            {
                mamt = IO.ReadString(89, 4);
                if (mamt == null)
                    IO.Writexy("Nhập lại mã máy tính...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (mamt != hdn.maMT && mamt != null)
                    hdn.maMT = CongCu.CatXau(mamt.ToUpper());
            } while (mamt == null);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 0);
            do
            {
                ngaynhap = IO.ReadString(14, 6);
                if (ngaynhap == null)
                    IO.Writexy("Nhập lại ngày nhập...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                else if (ngaynhap != hdn.ngayNhap && ngaynhap != null)
                    hdn.ngayNhap = CongCu.CatXau(ngaynhap);
            } while (ngaynhap == null);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            do
            {
                soluong = int.Parse(IO.ReadNumber(38, 6));
                if (soluong <= 0)
                {
                    IO.Writexy("Nhập lại số lượng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(37, 6, 12, ConsoleColor.Black);
                }
                else if (soluong != hdn.soLuong && soluong > 0)
                    hdn.soLuong = soluong;
            } while (soluong <= 0);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            do
            {
                dongia = double.Parse(IO.ReadNumber(59, 6));
                if (dongia <= 0)
                {
                    IO.Writexy("Nhập lại đơn giá...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(58, 6, 14, ConsoleColor.Black);
                }
                else if (dongia != hdn.donGia && dongia > 0)
                    hdn.donGia = dongia;
            } while (dongia <= 0);
            IO.Clear(4, 8, 30, ConsoleColor.Black);
            IO.Writexy(hdn.tongTien.ToString(), 85, 6);

            IO.Clear(4, 8, 30, ConsoleColor.Black);
            IO.Writexy("Enter để cập nhật, Esc để thoát...", 5, 8);
            Console.SetCursorPosition(39, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdnhap.SuaHDNhap(hdn);
                Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            string mahdn = "";
            do
            {
                Console.Clear();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                      XÓA HÓA ĐƠN NHẬP", 1, 1, 7, 100);
                IO.Writexy("Nhập mã hóa đơn nhập cần xóa:", 5, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                Hien(1, 8, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    mahdn = IO.ReadString(35, 4);
                    if (mahdn == null)
                    {
                        IO.Clear(5, 6, 30, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(5, 8, 30, ConsoleColor.Black);
                        IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                        mahdn = CongCu.CatXau(mahdn.ToUpper());
                        hdnhap.XoaHDNhap(mahdn);
                    }
                } while (mahdn == null);
                Hien(1, 8, hdnhap.LayDSHDNhap(), 5, 1);
            } while (true);
        }
        public void Xem()
        {
            IHDNhapBLL hdnhap = new HDNhapBLL();
            Console.Clear();
            Hien(1, 1, hdnhap.LayDSHDNhap(), 5, 1);
            HienChucNang();
        }
        public void Tim()
        {
            string mahdn = "";
            do
            {
                Console.Clear();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                    TÌM KIẾM HÓA ĐƠN NHẬP", 1, 1, 7, 100);
                IO.Writexy("Nhập mã hóa đơn nhập cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, hdnhap.LayDSHDNhap(), 5, 0);
                do
                {
                    mahdn = IO.ReadString(33, 4);
                    if (mahdn == null)
                    {
                        IO.Clear(5, 6, 30, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn nhập...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        mahdn = CongCu.CatXau(mahdn.ToUpper());
                        List<HDNhap> list = hdnhap.TimHDNhap(new HDNhap(mahdn, null, null, null, null, 0, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (mahdn == null);
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
                IO.Clear(xx, yy, 1500, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                                         DANH SÁCH HÓA ĐƠN NHẬP", x, y);
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
        public void HienChucNang()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhập danh sách hóa đơn nhập ",
                " F2.Sửa thông tin hóa đơn nhập ",
                " F3.Xóa hóa đơn nhập ",
                " F4.Hiển thị danh sách hóa đơn nhập ",
                " F5.Tìm kiếm hóa đơn nhập ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuHDN mnhdn = new MenuHDN(mn);
            mnhdn.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuHDN : Menu
        {
            public MenuHDN(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormHDNhap hdnhap = new FormHDNhap();
                FormMenuChinh fhd = new FormMenuChinh();
                switch (location)
                {
                    case 0:
                        hdnhap.Nhap();
                        break;
                    case 1:
                        hdnhap.Sua();
                        break;
                    case 2:
                        hdnhap.Xoa();
                        break;
                    case 3:
                        hdnhap.Xem();
                        break;
                    case 4:
                        hdnhap.Tim();
                        break;
                    case 5:
                        fhd.HienHoaDon();
                        break;
                }
            }
        }
    }
}
