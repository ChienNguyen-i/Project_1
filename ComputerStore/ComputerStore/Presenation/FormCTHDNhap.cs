using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    class FormCTHDNhap
    {
        public void Nhap()
        {
            do
            {
                ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                            NHẬP THÔNG TIN CHI TIẾT HÓA ĐƠN NHẬP", 1, 1, 10, 100);
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                IO.Writexy("Mã máy tính:", 42, 4);
                IO.Writexy("Số lượng:", 75, 4);
                IO.Writexy("Đơn giá:", 5, 6);
                IO.Writexy("Thành tiền:", 42, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, cthdnhap.LayDSCTHDNhap(), 5, 0);
                CTHDNhap cthdn = new CTHDNhap();
                cthdn.maHDN = int.Parse(IO.ReadNumber(22, 4));
                cthdn.maMT = int.Parse(IO.ReadNumber(55, 4));
                cthdn.soLuong = int.Parse(IO.ReadNumber(85, 4));
                cthdn.donGia = double.Parse(IO.ReadNumber(14, 6));
                cthdn.thanhTien = double.Parse(IO.ReadNumber(54, 6));
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, cthdnhap.LayDSCTHDNhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    cthdnhap.ThemCTHDNhap(cthdn);
            } while (true);
        }
        public void Sua()
        {
            ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
            Console.Clear();
            IO.BoxTitle("                          CẬP NHẬT THÔNG TIN CHI TIẾT HÓA ĐƠN NHẬP", 1, 1, 10, 100);
            IO.Writexy("Mã CTHD nhập:", 3, 4);
            IO.Writexy("Mã hóa đơn nhập:", 37, 4);
            IO.Writexy("Mã máy tính:", 72, 4);
            IO.Writexy("Số lượng:", 3, 6);
            IO.Writexy("Đơn giá:", 37, 6);
            IO.Writexy("Thành tiền:", 72, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, cthdnhap.LayDSCTHDNhap(), 5, 0);
            int macthdn;
            int mahdn;
            int mamt;
            int soluong;
            double dongia;
            double thanhtien;

            macthdn = int.Parse(IO.ReadNumber(17, 4));
            CTHDNhap cthdn = cthdnhap.LayCTHDNhap(macthdn);
            IO.Writexy(cthdn.maHDN.ToString(), 54, 4);
            IO.Writexy(cthdn.maMT.ToString(), 85, 4);
            IO.Writexy(cthdn.soLuong.ToString(), 13, 6);
            IO.Writexy(cthdn.donGia.ToString(), 46, 6);
            IO.Writexy(cthdn.thanhTien.ToString(), 84, 6);

            mahdn = int.Parse(IO.ReadNumber(54, 4));
            if (mahdn != cthdn.maHDN && mahdn > 0)
                cthdn.maHDN = mahdn;
            mamt = int.Parse(IO.ReadNumber(85, 4));
            if (mamt != cthdn.maMT && mamt > 0)
                cthdn.maMT = mamt;
            soluong = int.Parse(IO.ReadNumber(13, 6));
            if (soluong != cthdn.soLuong && soluong > 0)
                cthdn.soLuong = soluong;
            dongia = double.Parse(IO.ReadNumber(46, 6));
            if (dongia != cthdn.donGia && dongia > 0)
                cthdn.donGia = dongia;
            thanhtien = double.Parse(IO.ReadNumber(84, 6));
            if (thanhtien != cthdn.thanhTien && thanhtien > 0)
                cthdn.thanhTien = thanhtien;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                ComputerStore.Program.Hien();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, cthdnhap.LayDSCTHDNhap(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                cthdnhap.SuaCTHDNhap(cthdn);
                Hien(1, 13, cthdnhap.LayDSCTHDNhap(), 5, 1);
            }
            ComputerStore.Program.Hien();
        }
        public void Xoa()
        {
            int macthdn = 0;
            do
            {
                Console.Clear();
                ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                    XÓA CHI TIẾT HÓA ĐƠN NHẬP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã chi tiết hóa đơn nhập cần xóa:", 5, 4);
                Hien(1, 8, cthdnhap.LayDSCTHDNhap(), 5, 0);
                macthdn = int.Parse(IO.ReadNumber(44, 4));
                if (macthdn == 0)
                    break;
                else
                    cthdnhap.XoaCTHDNhap(macthdn);
                Hien(1, 8, cthdnhap.LayDSCTHDNhap(), 5, 1);
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Xem()
        {
            ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
            Console.Clear();
            Hien(1, 1, cthdnhap.LayDSCTHDNhap(), 5, 1);
            ComputerStore.Program.Hien();
        }
        public void Tim()
        {
            int macthdn = 0;
            do
            {
                Console.Clear();
                ICTHDNhapBLL cthdnhap = new CTHDNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                 TÌM KIẾM CHI TIẾT HÓA ĐƠN NHẬP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã chi tiết hóa đơn nhập cần tìm:", 3, 4);
                Hien(1, 8, cthdnhap.LayDSCTHDNhap(), 5, 0);
                macthdn = int.Parse(IO.ReadNumber(42, 4));
                List<CTHDNhap> list = cthdnhap.TimCTHDNhap(new CTHDNhap(macthdn, 0, 0, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (macthdn == 0)
                    break;
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Hien(int xx, int yy, List<CTHDNhap> list, int n, int type)
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
                IO.Writexy("                          DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌──────────┬─────────────────┬─────────────┬────────────┬───────────────┬───────────────┐", x, y + 1);
                IO.Writexy("│ Mã CTHDN │ Mã hóa đơn nhập │ Mã máy tính │  Số lượng  │    Đơn giá    │   Thành tiền  │", x, y + 2);
                IO.Writexy("├──────────┼─────────────────┼─────────────┼────────────┼───────────────┼───────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 11);
                    IO.Writexy(list[i].maCTHDN.ToString(), x + 1, y + d, 11);
                    IO.Writexy("│", x + 11, y + d);
                    IO.Writexy(list[i].maHDN.ToString(), x + 12, y + d, 18);
                    IO.Writexy("│", x + 29, y + d);
                    IO.Writexy(list[i].maMT.ToString(), x + 30, y + d, 14);
                    IO.Writexy("│", x + 43, y + d);
                    IO.Writexy(list[i].soLuong.ToString(), x + 44, y + d, 13);
                    IO.Writexy("│", x + 56, y + d);
                    IO.Writexy(list[i].donGia.ToString(), x + 57, y + d, 16);
                    IO.Writexy("│", x + 72, y + d);
                    IO.Writexy(list[i].thanhTien.ToString(), x + 73, y + d, 16);
                    IO.Writexy("│", x + 88, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────┼─────────────────┼─────────────┼────────────┼───────────────┼───────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────┴─────────────────┴─────────────┴────────────┴───────────────┴───────────────┘", x, y + d - 1);
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
        public class MenuCTHDN : Menu
        {
            public MenuCTHDN(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormCTHDNhap cthdnhap = new FormCTHDNhap();
                switch (location)
                {
                    case 0:
                        cthdnhap.Nhap();
                        break;
                    case 1:
                        cthdnhap.Sua();
                        break;
                    case 2:
                        cthdnhap.Xoa();
                        break;
                    case 3:
                        cthdnhap.Xem();
                        break;
                    case 4:
                        cthdnhap.Tim();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
