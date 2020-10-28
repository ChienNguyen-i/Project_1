using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormNhanVien
    {
        public void Nhap()
        {
            do
            {
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                         NHẬP THÔNG TIN NHÂN VIÊN", 1, 1, 10, 79);
                IO.Writexy("Họ tên:", 5, 4);
                IO.Writexy("Ngày sinh:", 30, 4);
                IO.Writexy("Giới tính:", 45, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 25, 6);
                IO.Writexy("Loại nhân viên:", 45, 6);
                IO.Writexy("-----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();
                nv.tenNV = IO.ReadString(13, 4);
                nv.ngaySinh = DateTime.Parse(IO.ReadString(40, 4));
                nv.gioiTinh = IO.ReadString(50, 4);
                nv.diaChi = IO.ReadString(16, 6);
                nv.soDT = IO.ReadNumber(34, 6);
                nv.loaiNV = IO.ReadString(55, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    nhanvien.ThemNhanVien(nv);
            } while (true);
        }
        public void Sua()
        {
            INhanVienBLL nhanvien = new NhanVienBLL();
            Console.Clear();
            IO.BoxTitle("                       CẬP NHẬT THÔNG TIN NHÂN VIÊN", 1, 1, 10, 79);
            IO.Writexy("Mã NV:", 5, 4);
            IO.Writexy("Họ tên:", 20, 4);
            IO.Writexy("Ngày sinh:", 45, 4);
            IO.Writexy("Giới tính:", 5, 6);
            IO.Writexy("Địa chỉ:", 25, 6);
            IO.Writexy("Số điện thoại:", 45, 6);
            IO.Writexy("Loại nhân viên:", 50, 6);
            IO.Writexy("-----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
            int manv;
            string tennv;
            DateTime ngaysinh;
            string gioitinh;
            string diachi;
            string sdt;
            string loainv;

            manv = int.Parse(IO.ReadNumber(12, 4));
            NhanVien nv = nhanvien.LayNhanVien(manv);
            IO.Writexy(nv.tenNV, 28, 4);
            IO.Writexy(nv.ngaySinh.ToString("dd/MM/yyyy"), 55, 4);
            IO.Writexy(nv.gioiTinh, 16, 6);
            IO.Writexy(nv.diaChi, 34, 6);
            IO.Writexy(nv.soDT, 55, 6);
            IO.Writexy(nv.loaiNV, 60, 6);

            tennv = IO.ReadString(28, 4);
            if (tennv != nv.tenNV && tennv != null)
                nv.tenNV = tennv;
            ngaysinh = DateTime.Parse(IO.ReadString(55, 4));
            if (ngaysinh != nv.ngaySinh && ngaysinh != null)
                nv.ngaySinh = ngaysinh;
            gioitinh = IO.ReadString(16, 6);
            if (gioitinh != nv.gioiTinh && gioitinh != null)
                nv.gioiTinh = gioitinh;
            diachi = IO.ReadString(34, 6);
            if (diachi != nv.diaChi && diachi != null)
                nv.diaChi = diachi;
            sdt = IO.ReadNumber(55, 6);
            if (sdt != nv.soDT && sdt != null)
                nv.soDT = sdt;
            loainv = IO.ReadString(34, 6);
            if (loainv != nv.loaiNV && loainv != null)
                nv.loaiNV = loainv;

            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                ComputerStore.Program.Hien();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nhanvien.SuaNhanVien(nv);
                Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
            }
            ComputerStore.Program.Hien();
        }
        public void Xoa()
        {
            int manv = 0;
            do
            {
                Console.Clear();
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                             XÓA NHÂN VIÊN", 1, 1, 5, 79);
                IO.Writexy("Nhập mã nhân viên cần xóa:", 5, 4);
                Hien(1, 8, nhanvien.LayDSNhanVien(), 5, 0);
                manv = int.Parse(IO.ReadNumber(32, 4));
                if (manv == 0)
                    break;
                else
                    nhanvien.XoaNhanVien(manv);
                Hien(1, 8, nhanvien.LayDSNhanVien(), 5, 1);
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Tim()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                            TÌM KIẾM NHÂN VIÊN", 1, 1, 5, 79);
                IO.Writexy("Nhập họ tên nhân viên cần tìm:", 3, 4);
                Hien(1, 8, nhanvien.LayDSNhanVien(), 5, 0);
                hoten = IO.ReadString(34, 4);
                List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(0, hoten, DateTime.Now, null, null, null, null));
                Hien(1, 8, list, 5, 1);
                if (hoten == "")
                    break;
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Xem()
        {
            Console.Clear();
            INhanVienBLL nhanvien = new NhanVienBLL();
            Console.Clear();
            IO.BoxTitle("                          XEM THÔNG TIN NHÂN VIÊN", 1, 1, 5, 79);
            Hien(1, 1, nhanvien.LayDSNhanVien(), 5, 1);
            ComputerStore.Program.Hien();
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
                IO.Clear(xx, yy, 1500);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                     DANH SÁCH NHÂN VIÊN                              ", x, y);
                IO.Writexy("┌───────┬────────┬──────────┬──────────┬──────────┬──────────┬──────┐", x, y + 1);
                IO.Writexy("│ Mã NV │ Họ tên │Ngày sinh │Giới tính │ Địa chỉ  │  Số ĐT   │LoạiNV│", x, y + 2);
                IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼──────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].maNV.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].tenNV, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].ngaySinh.ToString("dd/MM/yyyy"), x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].gioiTinh, x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].diaChi, x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy(list[i].soDT, x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].loaiNV, x + 62, y + d, 7);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < final - 1)
                        IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼──────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└───────┴────────┴──────────┴──────────┴──────────┴──────────┴──────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          Nhấn PagegUp xem trước, PagegDown xem tiep, Esc để thoát...", x, y + d);
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
    public class MenuNV : Menu
    {
        public MenuNV(string[] mn) : base(mn)
        {
        }
        public override void ThucHien(int location)
        {
            FormNhanVien nhanvien = new FormNhanVien();
            switch (location)
            {
                case 0:
                    nhanvien.Nhap();
                    break;
                case 1:
                    nhanvien.Tim();
                    break;
                case 2:
                    nhanvien.Xoa();
                    break;
                case 3:
                    nhanvien.Sua();
                    break;
                case 4:
                    nhanvien.Xem();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
