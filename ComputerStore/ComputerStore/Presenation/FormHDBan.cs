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
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, hdban.LayDSHDBan(), 5, 0);
                HDBan hdb = new HDBan();
                hdb.maNV = int.Parse(IO.ReadNumber(17, 4));
                hdb.maKH = int.Parse(IO.ReadNumber(40, 4));
                hdb.maMT = int.Parse(IO.ReadNumber(64, 4));
                hdb.ngayBan = DateTime.Parse(IO.ReadString(85, 4));
                hdb.soLuong = int.Parse(IO.ReadNumber(13, 6));
                hdb.donGia = double.Parse(IO.ReadNumber(42, 6));
                hdb.tongTien = double.Parse(IO.ReadNumber(79, 6));
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, hdban.LayDSHDBan(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    hdban.ThemHDBan(hdb);
            } while (true);
        }
        public void Sua()
        {
            IHDBanBLL hdban = new HDBanBLL();
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
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, hdban.LayDSHDBan(), 5, 0);
            int mahdb;
            int manv;
            int makh;
            int mamt;
            DateTime ngayban;
            int soluong;
            double dongia;
            double tongtien;

            mahdb = int.Parse(IO.ReadNumber(14, 4));
            HDBan hdb = hdban.LayHDBan(mahdb);
            IO.Writexy(hdb.maNV.ToString(), 37, 4);
            IO.Writexy(hdb.maKH.ToString(), 65, 4);
            IO.Writexy(hdb.maMT.ToString(), 89, 4);
            IO.Writexy(hdb.ngayBan.ToString("dd/MM/yyyy"), 13, 6);
            IO.Writexy(hdb.soLuong.ToString(), 38, 6);
            IO.Writexy(hdb.donGia.ToString(), 59, 6);
            IO.Writexy(hdb.tongTien.ToString(), 85, 6);

            manv = int.Parse(IO.ReadNumber(37, 4));
            if (manv != hdb.maNV && manv > 0)
                hdb.maNV = manv;
            makh = int.Parse(IO.ReadNumber(65, 4));
            if (makh != hdb.maKH && makh > 0)
                hdb.maKH = makh;
            mamt = int.Parse(IO.ReadNumber(89, 4));
            if (mamt != hdb.maMT && mamt > 0)
                hdb.maMT = mamt;
            ngayban = DateTime.Parse(IO.ReadString(13, 6));
            if (ngayban != hdb.ngayBan && ngayban != null)
                hdb.ngayBan = ngayban;
            soluong = int.Parse(IO.ReadNumber(38, 6));
            if (soluong != hdb.soLuong && soluong > 0)
                hdb.soLuong = soluong;
            dongia = double.Parse(IO.ReadNumber(59, 6));
            if (dongia != hdb.donGia && dongia > 0)
                hdb.donGia = dongia;
            tongtien = double.Parse(IO.ReadNumber(85, 6));
            if (tongtien != hdb.tongTien && tongtien > 0)
                hdb.tongTien = tongtien;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, hdban.LayDSHDBan(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdban.SuaHDBan(hdb);
                Hien(1, 13, hdban.LayDSHDBan(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int mahdb = 0;
            do
            {
                Console.Clear();
                IHDBanBLL hdban = new HDBanBLL();
                Console.Clear();
                IO.BoxTitle("                                      XÓA HÓA ĐƠN BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần xóa:", 5, 4);
                Hien(1, 8, hdban.LayDSHDBan(), 5, 0);
                mahdb = int.Parse(IO.ReadNumber(34, 4));
                if (mahdb == 0)
                    break;
                else
                    hdban.XoaHDBan(mahdb);
                Hien(1, 8, hdban.LayDSHDBan(), 5, 1);
            } while (true);
            HienChucNang();
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
            int mahdb = 0;
            do
            {
                Console.Clear();
                IHDBanBLL hdban = new HDBanBLL();
                Console.Clear();
                IO.BoxTitle("                                    TÌM KIẾM HÓA ĐƠN BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần tìm:", 3, 4);
                Hien(1, 8, hdban.LayDSHDBan(), 5, 0);
                mahdb = int.Parse(IO.ReadNumber(32, 4));
                List<HDBan> list = hdban.TimHDBan(new HDBan(mahdb, 0, 0, 0, DateTime.Now, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (mahdb == 0)
                    break;
            } while (true);
            HienChucNang();
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
                IO.Writexy("                                    DANH SÁCH HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌──────────┬──────────┬──────────┬──────────┬─────────────────┬────────────┬──────────────────┬─────────────────┐", x, y + 1);
                IO.Writexy("│  Mã HDB  │  Mã NV   │  Mã KH   │  Mã MT   │    Ngày nhập    │  Số lượng  │    Thành tiền    │    Tổng tiền    │", x, y + 2);
                IO.Writexy("├──────────┼──────────┼──────────┼──────────┼─────────────────┼────────────┼──────────────────┼─────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 11);
                    IO.Writexy(list[i].maHDB.ToString(), x + 1, y + d, 11);
                    IO.Writexy("│", x + 11, y + d);
                    IO.Writexy(list[i].maNV.ToString(), x + 12, y + d, 11);
                    IO.Writexy("│", x + 22, y + d);
                    IO.Writexy(list[i].maKH.ToString(), x + 23, y + d, 11);
                    IO.Writexy("│", x + 33, y + d);
                    IO.Writexy(list[i].maMT.ToString(), x + 34, y + d, 11);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].ngayBan.ToString("dd/MM/yyyy"), x + 45, y + d, 18);
                    IO.Writexy("│", x + 62, y + d);
                    IO.Writexy(list[i].soLuong.ToString(), x + 63, y + d, 13);
                    IO.Writexy("│", x + 75, y + d);
                    IO.Writexy(list[i].donGia.ToString(), x + 76, y + d, 18);
                    IO.Writexy("│", x + 93, y + d);
                    IO.Writexy(list[i].tongTien.ToString(), x + 94, y + d, 18);
                    IO.Writexy("│", x + 111, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────┼──────────┼──────────┼──────────┼─────────────────┼────────────┼──────────────────┼─────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────┴──────────┴──────────┴──────────┴─────────────────┴────────────┴──────────────────┴─────────────────┘", x, y + d - 1);
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
            ComputerStore.Presenation.FormHDBan.MenuHDB mnhdb = new ComputerStore.Presenation.FormHDBan.MenuHDB(mn);
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
                        ComputerStore.Presenation.FormMenuChinh.Hien();
                        break;
                }
            }
        }
    }
}
