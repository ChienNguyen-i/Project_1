using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormHDBan
    {
        public void Nhap()
        {
            do
            {
                IHDBanBLL hdban = new HDBanBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                IKhachHangBLL khachhang = new KhachHangBLL();
                IMayTinhBLL maytinh = new MayTinhBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormKhachHang fkh = new FormKhachHang();
                FormMayTinh fmt = new FormMayTinh();

                Console.Clear();
                IO.BoxTitle("                                 NHẬP THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 10, 100);
                IO.Writexy("Mã nhân viên:", 3, 4);
                IO.Writexy("Mã khách hàng:", 25, 4);
                IO.Writexy("Mã máy tính:", 51, 4);
                IO.Writexy("Ngày bán:", 75, 4);
                IO.Writexy("Số lượng:", 3, 6);
                IO.Writexy("Đơn giá:", 33, 6);
                IO.Writexy("Tổng tiền:", 68, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                HDBan hdb = new HDBan();

                fnv.Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    hdb.maNV = IO.ReadString(17, 4);
                    if (hdb.maNV == null)
                        IO.Writexy("Nhập lại mã nhân viên...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdb.maNV == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fkh.Hien(1, 13, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    hdb.maKH = IO.ReadString(40, 4);
                    if (hdb.maKH == null)
                        IO.Writexy("Nhập lại mã khách hàng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdb.maKH == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fmt.Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    hdb.maMT = IO.ReadString(64, 4);
                    if (hdb.maMT == null)
                        IO.Writexy("Nhập lại mã máy tính...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdb.maMT == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                Hien(1, 13, hdban.LayDSHDBan(), 5, 0);
                IO.Writexy("Nhập ngày bán định dạng 'dd/MM/yyyy'...", 5, 9, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    hdb.ngayBan = IO.ReadString(85, 4);
                    if (hdb.ngayBan == null)
                        IO.Writexy("Nhập lại ngày bán...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (hdb.ngayBan == null);
                IO.Clear(4, 9, 60, ConsoleColor.Black);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    hdb.soLuong = int.Parse(IO.ReadNumber(13, 6));
                    if (hdb.soLuong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(12, 6, 14, ConsoleColor.Black);
                    }
                } while (hdb.soLuong <= 0);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    hdb.donGia = double.Parse(IO.ReadNumber(42, 6));
                    if (hdb.donGia <= 0)
                    {
                        IO.Writexy("Nhập lại đơn giá...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(41, 6, 14, ConsoleColor.Black);
                    }
                } while (hdb.donGia <= 0);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy(hdb.tongTien.ToString(), 79, 6);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(35, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(4, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn bán đã được thêm...", 5, 8);
                    hdban.ThemHDBan(hdb);
                    Hien(1, 13, hdban.LayDSHDBan(), 5, 1);
                }
            } while (true);
        }
        public void Sua()
        {
            do
            {
                IHDBanBLL hdban = new HDBanBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                IKhachHangBLL khachhang = new KhachHangBLL();
                IMayTinhBLL maytinh = new MayTinhBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormKhachHang fkh = new FormKhachHang();
                FormMayTinh fmt = new FormMayTinh();

                Console.Clear();
                IO.BoxTitle("                               CẬP NHẬT THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 10, 100);
                IO.Writexy("Mã HD bán:", 3, 4);
                IO.Writexy("Mã nhân viên:", 23, 4);
                IO.Writexy("Mã khách hàng:", 50, 4);
                IO.Writexy("Mã máy tính:", 76, 4);
                IO.Writexy("Ngày bán:", 3, 6);
                IO.Writexy("Số lượng:", 28, 6);
                IO.Writexy("Đơn giá:", 50, 6);
                IO.Writexy("Tổng tiền:", 74, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                Hien(1, 13, hdban.LayDSHDBan(), 5, 0);

                string mahdb;
                string manv;
                string makh;
                string mamt;
                string ngayban;
                int soluong;
                double dongia;

                do
                {
                    mahdb = IO.ReadString(14, 4);
                    if (mahdb == null)
                        IO.Writexy("Nhập lại mã hóa đơn bán...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else
                        mahdb = CongCu.CatXau(mahdb.ToUpper());
                } while (mahdb == null);
                HDBan hdb = hdban.LayHDBan(mahdb);
                IO.Writexy(hdb.maNV.ToString(), 37, 4);
                IO.Writexy(hdb.maKH.ToString(), 65, 4);
                IO.Writexy(hdb.maMT.ToString(), 89, 4);
                IO.Writexy(hdb.ngayBan, 13, 6);
                IO.Writexy(hdb.soLuong.ToString(), 38, 6);
                IO.Writexy(hdb.donGia.ToString(), 59, 6);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fnv.Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
                do
                {
                    manv = IO.ReadString(37, 4);
                    if (manv == null)
                        IO.Writexy("Nhập lại mã nhân viên...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (manv != hdb.maNV && manv != null)
                        hdb.maNV = CongCu.CatXau(manv.ToUpper());
                } while (manv == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fkh.Hien(1, 13, khachhang.LayDSKhachHang(), 5, 0);
                do
                {
                    makh = IO.ReadString(65, 4);
                    if (makh == null)
                        IO.Writexy("Nhập lại mã khách hàng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (makh != hdb.maKH && makh != null)
                        hdb.maKH = CongCu.CatXau(makh.ToUpper());
                } while (makh == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fmt.Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    mamt = IO.ReadString(89, 4);
                    if (mamt == null)
                        IO.Writexy("Nhập lại mã máy tính...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (mamt != hdb.maMT && mamt != null)
                        hdb.maMT = CongCu.CatXau(mamt.ToUpper());
                } while (mamt == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                Hien(1, 13, hdban.LayDSHDBan(), 5, 0);
                IO.Writexy("Nhập ngày bán định dạng 'dd/MM/yyyy'...", 5, 9, ConsoleColor.Black, ConsoleColor.White);
                do
                {
                    ngayban = IO.ReadString(13, 6);
                    if (ngayban == null)
                        IO.Writexy("Nhập lại ngày bán...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (ngayban != hdb.ngayBan && ngayban != null)
                        hdb.ngayBan = CongCu.CatXau(ngayban);
                } while (ngayban == null);
                IO.Clear(4, 9, 60, ConsoleColor.Black);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    soluong = int.Parse(IO.ReadNumber(38, 6));
                    if (soluong <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(37, 6, 12, ConsoleColor.Black);
                    }
                    else if (soluong != hdb.soLuong && soluong > 0)
                        hdb.soLuong = soluong;
                } while (soluong <= 0);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    dongia = double.Parse(IO.ReadNumber(59, 6));
                    if (dongia <= 0)
                    {
                        IO.Writexy("Nhập lại đơn giá...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(58, 6, 14, ConsoleColor.Black);
                    }
                    else if (dongia != hdb.donGia && dongia > 0)
                        hdb.donGia = dongia;
                } while (dongia <= 0);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy(hdb.tongTien.ToString(), 85, 6);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(39, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(4, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Hóa đơn bán đã được cập nhật...", 5, 8);
                    hdban.SuaHDBan(hdb);
                    Hien(1, 13, hdban.LayDSHDBan(), 5, 1);
                }
            } while (true);
        }
        public void Xoa()
        {
            string mahdb = "";
            do
            {
                Console.Clear();
                IHDBanBLL hdban = new HDBanBLL();
                Console.Clear();
                IO.BoxTitle("                                      XÓA HÓA ĐƠN BÁN", 1, 1, 7, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần xóa:", 5, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                Hien(1, 8, hdban.LayDSHDBan(), 5, 0);
                do
                {
                    mahdb = IO.ReadString(34, 4);
                    if (mahdb == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                        mahdb = CongCu.CatXau(mahdb.ToUpper());
                        hdban.XoaHDBan(mahdb);
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Hóa đơn bán đã được xóa...", 5, 6);
                    }
                } while (mahdb == null);
                Hien(1, 8, hdban.LayDSHDBan(), 5, 1);
            } while (true);
        }
        public void Xem()
        {
            IHDBanBLL hdban = new HDBanBLL();
            Console.Clear();
            Hien(1, 1, hdban.LayDSHDBan(), 5, 1);
            HienChucNang();
        }
        public void Tim()
        {
            string mahdb = "";
            do
            {
                Console.Clear();
                IHDBanBLL hdban = new HDBanBLL();
                Console.Clear();
                IO.BoxTitle("                                    TÌM KIẾM HÓA ĐƠN BÁN", 1, 1, 7, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, hdban.LayDSHDBan(), 5, 0);
                do
                {
                    mahdb = IO.ReadString(32, 4);
                    if (mahdb == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã hóa đơn bán...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Hóa đơn bán tìm được...", 5, 6);
                        mahdb = CongCu.CatXau(mahdb.ToUpper());
                        List<HDBan> list = hdban.TimHDBan(new HDBan(mahdb, null, null, null, null, 0, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (mahdb == null);
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
                IO.Clear(xx, yy, 1500, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                                        DANH SÁCH HÓA ĐƠN BÁN", x, y);
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
        public void HienChucNang()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhập danh sách hóa đơn bán ",
                " F2.Sửa thông tin hóa đơn bán ",
                " F3.Xóa hóa đơn bán ",
                " F4.Hiển thị danh sách hóa đơn bán ",
                " F5.Tìm kiếm hóa đơn bán ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuHDB mnhdb = new MenuHDB(mn);
            mnhdb.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuHDB : Menu
        {
            public MenuHDB(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormHDBan hdban = new FormHDBan();
                FormMenuChinh fhd = new FormMenuChinh();
                switch (location)
                {
                    case 0:
                        hdban.Nhap();
                        break;
                    case 1:
                        hdban.Sua();
                        break;
                    case 2:
                        hdban.Xoa();
                        break;
                    case 3:
                        hdban.Xem();
                        break;
                    case 4:
                        hdban.Tim();
                        break;
                    case 5:
                        fhd.HienHoaDon();
                        break;
                }
            }
        }
    }
}
