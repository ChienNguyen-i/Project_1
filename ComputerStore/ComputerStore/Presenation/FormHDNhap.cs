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
                Console.Clear();
                IO.BoxTitle("                                 NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 100);
                IO.Writexy("Mã nhân viên:", 5, 4);
                IO.Writexy("Mã nhà cung cấp:", 45, 4);
                IO.Writexy("Ngày nhập:", 5, 6);
                IO.Writexy("Tổng tiền:", 45, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 0);
                HDNhap hdn = new HDNhap();
                hdn.maNV = int.Parse(IO.ReadNumber(19, 4));
                hdn.maNCC = int.Parse(IO.ReadNumber(62, 4));
                hdn.ngayNhap = DateTime.Parse(IO.ReadString(16, 6));
                hdn.tongTien = double.Parse(IO.ReadNumber(56, 6));
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    hdnhap.ThemHDNhap(hdn);
            } while (true);
        }
        public void Sua()
        {
            IHDNhapBLL hdnhap = new HDNhapBLL();
            Console.Clear();
            IO.BoxTitle("                               CẬP NHẬT THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 100);
            IO.Writexy("Mã hóa đơn nhập:", 3, 4);
            IO.Writexy("Mã nhân viên:", 35, 4);
            IO.Writexy("Mã nhà cung cấp:", 68, 4);
            IO.Writexy("Ngày nhập:", 3, 6);
            IO.Writexy("Tổng tiền:", 50, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 0);
            int mahdn;
            int manv;
            int mancc;
            DateTime ngaynhap;
            double tongtien;

            mahdn = int.Parse(IO.ReadNumber(20, 4));
            HDNhap hdn = hdnhap.LayHDNhap(mahdn);
            IO.Writexy(hdn.maNV.ToString(), 49, 4);
            IO.Writexy(hdn.maNCC.ToString(), 85, 4);
            IO.Writexy(hdn.ngayNhap.ToString("dd/MM/yyyy"), 14, 6);
            IO.Writexy(hdn.tongTien.ToString(), 61, 6);

            manv = int.Parse(IO.ReadNumber(49, 4));
            if (manv != hdn.maNV && manv > 0)
                hdn.maNV = manv;
            mancc = int.Parse(IO.ReadNumber(85, 4));
            if (mancc != hdn.maNCC && mancc > 0)
                hdn.maNCC = mancc;
            ngaynhap = DateTime.Parse(IO.ReadString(14, 6));
            if (ngaynhap != hdn.ngayNhap && ngaynhap != null)
                hdn.ngayNhap = ngaynhap;
            tongtien = double.Parse(IO.ReadNumber(61, 6));
            if (tongtien != hdn.tongTien && tongtien > 0)
                hdn.tongTien = tongtien;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                ComputerStore.Program.Hien();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdnhap.SuaHDNhap(hdn);
                Hien(1, 13, hdnhap.LayDSHDNhap(), 5, 1);
            }
            ComputerStore.Program.Hien();
        }
        public void Xoa()
        {
            int mahdn = 0;
            do
            {
                Console.Clear();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                      XÓA HÓA ĐƠN NHẬP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn nhập cần xóa:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHDNhap(), 5, 0);
                mahdn = int.Parse(IO.ReadNumber(35, 4));
                if (mahdn == 0)
                    break;
                else
                    hdnhap.XoaHDNhap(mahdn);
                Hien(1, 8, hdnhap.LayDSHDNhap(), 5, 1);
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Xem()
        {
            IHDNhapBLL hdnhap = new HDNhapBLL();
            Console.Clear();
            Hien(1, 1, hdnhap.LayDSHDNhap(), 5, 1);
            ComputerStore.Program.Hien();
        }
        public void Tim()
        {
            int mahdn = 0;
            do
            {
                Console.Clear();
                IHDNhapBLL hdnhap = new HDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                    TÌM KIẾM HÓA ĐƠN NHẬP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn nhập cần tìm:", 3, 4);
                Hien(1, 8, hdnhap.LayDSHDNhap(), 5, 0);
                mahdn = int.Parse(IO.ReadNumber(33, 4));
                List<HDNhap> list = hdnhap.TimHDNhap(new HDNhap(mahdn, 0, 0, DateTime.Now, 0));
                Hien(1, 8, list, 5, 1);
                if (mahdn == 0)
                    break;
            } while (true);
            ComputerStore.Program.Hien();
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
                IO.Writexy("                     DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌──────────┬──────────────┬───────────┬─────────────────┬───────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HDN  │ Mã nhân viên │ Mã nhà CC │    Ngày nhập    │     Tổng tiền     │", x, y + 2);
                IO.Writexy("├──────────┼──────────────┼───────────┼─────────────────┼───────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 11);
                    IO.Writexy(list[i].maHDN.ToString(), x + 1, y + d, 11);
                    IO.Writexy("│", x + 11, y + d);
                    IO.Writexy(list[i].maNV.ToString(), x + 12, y + d, 15);
                    IO.Writexy("│", x + 26, y + d);
                    IO.Writexy(list[i].maNCC.ToString(), x + 27, y + d, 12);
                    IO.Writexy("│", x + 38, y + d);
                    IO.Writexy(list[i].ngayNhap.ToString("dd/MM/yyyy"), x + 39, y + d, 18);
                    IO.Writexy("│", x + 56, y + d);
                    IO.Writexy(list[i].tongTien.ToString(), x + 57, y + d, 20);
                    IO.Writexy("│", x + 76, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────┼──────────────┼───────────┼─────────────────┼───────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────┴──────────────┴───────────┴─────────────────┴───────────────────┘", x, y + d - 1);
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
        public class MenuHDN : Menu
        {
            public MenuHDN(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormHDNhap hdnhap = new FormHDNhap();
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
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
