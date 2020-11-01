using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormCTHDBan
    {
        public void Nhap()
        {
            do
            {
                ICTHDBanBLL cthdban = new CTHDBanBLL();
                Console.Clear();
                IO.BoxTitle("                            NHẬP THÔNG TIN CHI TIẾT HÓA ĐƠN BÁN", 1, 1, 10, 100);
                IO.Writexy("Mã hóa đơn bán:", 5, 4);
                IO.Writexy("Mã máy tính:", 42, 4);
                IO.Writexy("Số lượng:", 75, 4);
                IO.Writexy("Đơn giá:", 5, 6);
                IO.Writexy("Thành tiền:", 42, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, cthdban.LayDSCTHDBan(), 5, 0);
                CTHDBan cthdb = new CTHDBan();
                cthdb.maHDB = int.Parse(IO.ReadNumber(21, 4));
                cthdb.maMT = int.Parse(IO.ReadNumber(55, 4));
                cthdb.soLuong = int.Parse(IO.ReadNumber(85, 4));
                cthdb.donGia = double.Parse(IO.ReadNumber(14, 6));
                cthdb.thanhTien = double.Parse(IO.ReadNumber(54, 6));
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, cthdban.LayDSCTHDBan(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    cthdban.ThemCTHDBan(cthdb);
            } while (true);
        }
        public void Sua()
        {
            ICTHDBanBLL cthdban = new CTHDBanBLL();
            Console.Clear();
            IO.BoxTitle("                          CẬP NHẬT THÔNG TIN CHI TIẾT HÓA ĐƠN BÁN", 1, 1, 10, 100);
            IO.Writexy("Mã CTHD bán:", 3, 4);
            IO.Writexy("Mã hóa đơn bán:", 37, 4);
            IO.Writexy("Mã máy tính:", 72, 4);
            IO.Writexy("Số lượng:", 3, 6);
            IO.Writexy("Đơn giá:", 37, 6);
            IO.Writexy("Thành tiền:", 72, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, cthdban.LayDSCTHDBan(), 5, 0);
            int macthdb;
            int mahdb;
            int mamt;
            int soluong;
            double dongia;
            double thanhtien;

            macthdb = int.Parse(IO.ReadNumber(16, 4));
            CTHDBan cthdb = cthdban.LayCTHDBan(macthdb);
            IO.Writexy(cthdb.maHDB.ToString(), 53, 4);
            IO.Writexy(cthdb.maMT.ToString(), 85, 4);
            IO.Writexy(cthdb.soLuong.ToString(), 13, 6);
            IO.Writexy(cthdb.donGia.ToString(), 46, 6);
            IO.Writexy(cthdb.thanhTien.ToString(), 84, 6);

            mahdb = int.Parse(IO.ReadNumber(53, 4));
            if (mahdb != cthdb.maHDB && mahdb > 0)
                cthdb.maHDB = mahdb;
            mamt = int.Parse(IO.ReadNumber(85, 4));
            if (mamt != cthdb.maMT && mamt > 0)
                cthdb.maMT = mamt;
            soluong = int.Parse(IO.ReadNumber(13, 6));
            if (soluong != cthdb.soLuong && soluong > 0)
                cthdb.soLuong = soluong;
            dongia = double.Parse(IO.ReadNumber(46, 6));
            if (dongia != cthdb.donGia && dongia > 0)
                cthdb.donGia = dongia;
            thanhtien = double.Parse(IO.ReadNumber(84, 6));
            if (thanhtien != cthdb.thanhTien && thanhtien > 0)
                cthdb.thanhTien = thanhtien;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, cthdban.LayDSCTHDBan(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                cthdban.SuaCTHDBan(cthdb);
                Hien(1, 13, cthdban.LayDSCTHDBan(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int macthdb = 0;
            do
            {
                Console.Clear();
                ICTHDBanBLL cthdban = new CTHDBanBLL();
                Console.Clear();
                IO.BoxTitle("                                    XÓA CHI TIẾT HÓA ĐƠN BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã chi tiết hóa đơn bán cần xóa:", 5, 4);
                Hien(1, 8, cthdban.LayDSCTHDBan(), 5, 0);
                macthdb = int.Parse(IO.ReadNumber(43, 4));
                if (macthdb == 0)
                    break;
                else
                    cthdban.XoaCTHDBan(macthdb);
                Hien(1, 8, cthdban.LayDSCTHDBan(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            ICTHDBanBLL cthdban = new CTHDBanBLL();
            Console.Clear();
            Hien(1, 1, cthdban.LayDSCTHDBan(), 5, 1);
            HienChucNang();
        }
        public void Tim()
        {
            int macthdb = 0;
            do
            {
                Console.Clear();
                ICTHDBanBLL cthdban = new CTHDBanBLL();
                Console.Clear();
                IO.BoxTitle("                                 TÌM KIẾM CHI TIẾT HÓA ĐƠN BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã chi tiết hóa đơn bán cần tìm:", 3, 4);
                Hien(1, 8, cthdban.LayDSCTHDBan(), 5, 0);
                macthdb = int.Parse(IO.ReadNumber(41, 4));
                List<CTHDBan> list = cthdban.TimCTHDBan(new CTHDBan(macthdb, 0, 0, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (macthdb == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<CTHDBan> list, int n, int type)
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
                IO.Writexy("                          DANH SÁCH CHI TIẾT HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌──────────┬─────────────────┬─────────────┬────────────┬───────────────┬───────────────┐", x, y + 1);
                IO.Writexy("│ Mã CTHDN │ Mã hóa đơn bán  │ Mã máy tính │  Số lượng  │    Đơn giá    │   Thành tiền  │", x, y + 2);
                IO.Writexy("├──────────┼─────────────────┼─────────────┼────────────┼───────────────┼───────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 11);
                    IO.Writexy(list[i].maCTHDB.ToString(), x + 1, y + d, 11);
                    IO.Writexy("│", x + 11, y + d);
                    IO.Writexy(list[i].maHDB.ToString(), x + 12, y + d, 18);
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
        public void HienChucNang()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhập danh sách chi tiết hóa đơn bán ",
                " F2.Sửa thông tin chi tiết hóa đơn bán ",
                " F3.Xóa chi tiết hóa đơn bán ",
                " F4.Hiển thị danh sách chi tiết hóa đơn bán ",
                " F5.Tìm kiếm chi tiết hóa đơn bán ",
                " F6.Quay lại trang chính "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ComputerStore.Presenation.FormCTHDBan.MenuCTHDB mncthdb = new ComputerStore.Presenation.FormCTHDBan.MenuCTHDB(mn);
            mncthdb.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuCTHDB : Menu
        {
            public MenuCTHDB(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormCTHDBan cthdban = new FormCTHDBan();
                switch (location)
                {
                    case 0:
                        cthdban.Nhap();
                        break;
                    case 1:
                        cthdban.Sua();
                        break;
                    case 2:
                        cthdban.Xoa();
                        break;
                    case 3:
                        cthdban.Xem();
                        break;
                    case 4:
                        cthdban.Tim();
                        break;
                    case 5:
                        ComputerStore.Presenation.FormMenuChinh.Hien();
                        break;
                }
            }
        }
    }
}
