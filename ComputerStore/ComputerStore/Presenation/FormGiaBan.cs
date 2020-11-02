using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormGiaBan
    {
        public void Nhap()
        {
            do
            {
                IGiaBanBLL giaban = new GiaBanBLL();
                Console.Clear();
                IO.BoxTitle("                                      NHẬP THÔNG TIN GIÁ BÁN", 1, 1, 10, 100);
                IO.Writexy("Mã máy tính:", 5, 4);
                IO.Writexy("Giá bán:", 44, 4);
                IO.Writexy("Ngày áp dụng:", 5, 6);
                IO.Writexy("Ngày thôi áp dụng:", 44, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, giaban.LayDSGiaBan(), 5, 0);
                GiaBan gb = new GiaBan();
                gb.maMT = int.Parse(IO.ReadNumber(18, 4));
                gb.giaBan = double.Parse(IO.ReadNumber(53, 4));
                gb.ngayAD = DateTime.Parse(IO.ReadString(19, 6));
                gb.ngayThoiAD = DateTime.Parse(IO.ReadString(63, 6));
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, giaban.LayDSGiaBan(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    giaban.ThemGiaBan(gb);
            } while (true);
        }
        public void Sua()
        {
            IGiaBanBLL giaban = new GiaBanBLL();
            Console.Clear();
            IO.BoxTitle("                                    CẬP NHẬT THÔNG TIN GIÁ BÁN", 1, 1, 10, 100);
            IO.Writexy("Mã giá bán:", 5, 4);
            IO.Writexy("Mã máy tính:", 30, 4);
            IO.Writexy("Giá bán:", 65, 4);
            IO.Writexy("Ngày áp dụng:", 5, 6);
            IO.Writexy("Ngày thôi áp dụng:", 50, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, giaban.LayDSGiaBan(), 5, 0);
            int magb;
            int mamt;
            double gia_ban;
            DateTime ngayad;
            DateTime ngaytad;

            magb = int.Parse(IO.ReadNumber(17, 4));
            GiaBan gb = giaban.LayGiaBan(magb);
            IO.Writexy(gb.maMT.ToString(), 43, 4);
            IO.Writexy(gb.giaBan.ToString(), 74, 4);
            IO.Writexy(gb.ngayAD.ToString("dd/MM/yyyy"), 19, 6);
            IO.Writexy(gb.ngayThoiAD.ToString("dd/MM/yyyy"), 69, 6);

            mamt = int.Parse(IO.ReadNumber(43, 4));
            if (mamt != gb.maMT && mamt > 0)
                gb.maMT = mamt;
            gia_ban = double.Parse(IO.ReadNumber(74, 4));
            if (gia_ban != gb.giaBan && gia_ban > 0)
                gb.giaBan = gia_ban;
            ngayad = DateTime.Parse(IO.ReadString(19, 6));
            if (ngayad != gb.ngayAD && ngayad != null)
                gb.ngayAD = ngayad;
            ngaytad = DateTime.Parse(IO.ReadString(69, 6));
            if (ngaytad != gb.ngayThoiAD && ngaytad != null)
                gb.ngayThoiAD = ngaytad;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, giaban.LayDSGiaBan(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                giaban.SuaGiaBan(gb);
                Hien(1, 13, giaban.LayDSGiaBan(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int magb = 0;
            do
            {
                Console.Clear();
                IGiaBanBLL giaban = new GiaBanBLL();
                Console.Clear();
                IO.BoxTitle("                                          XÓA GIÁ BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã giá bán cần xóa:", 5, 4);
                Hien(1, 8, giaban.LayDSGiaBan(), 5, 0);
                magb = int.Parse(IO.ReadNumber(30, 4));
                if (magb == 0)
                    break;
                else
                    giaban.XoaGiaBan(magb);
                Hien(1, 8, giaban.LayDSGiaBan(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            IGiaBanBLL giaban = new GiaBanBLL();
            Console.Clear();
            Hien(1, 1, giaban.LayDSGiaBan(), 5, 1);
            HienChucNang();
        }
        public void Tim()
        {
            int magb = 0;
            do
            {
                Console.Clear();
                IGiaBanBLL giaban = new GiaBanBLL();
                Console.Clear();
                IO.BoxTitle("                                        TÌM KIẾM GIÁ BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã giá bán cần tìm cần tìm:", 3, 4);
                Hien(1, 8, giaban.LayDSGiaBan(), 5, 0);
                magb = int.Parse(IO.ReadNumber(36, 4));
                List<GiaBan> list = giaban.TimGiaBan(new GiaBan(magb, 0, 0, DateTime.Now, DateTime.Now));
                Hien(1, 8, list, 5, 1);
                if (magb == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<GiaBan> list, int n, int type)
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
                IO.Writexy("                              DANH SÁCH GIÁ BÁN", x, y);
                IO.Writexy("┌────────────┬─────────────┬───────────────┬────────────────┬───────────────────┐", x, y + 1);
                IO.Writexy("│ Mã giá bán │ Mã máy tính │    Giá bán    │  Ngày áp dụng  │ Ngày thôi áp dụng │", x, y + 2);
                IO.Writexy("├────────────┼─────────────┼───────────────┼────────────────┼───────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 13);
                    IO.Writexy(list[i].maGB.ToString(), x + 1, y + d, 13);
                    IO.Writexy("│", x + 13, y + d);
                    IO.Writexy(list[i].maMT.ToString(), x + 14, y + d, 14);
                    IO.Writexy("│", x + 27, y + d);
                    IO.Writexy(list[i].giaBan.ToString(), x + 28, y + d, 16);
                    IO.Writexy("│", x + 43, y + d);
                    IO.Writexy(list[i].ngayAD.ToString("dd/MM/yyyy"), x + 44, y + d, 17);
                    IO.Writexy("│", x + 60, y + d);
                    IO.Writexy(list[i].ngayThoiAD.ToString("dd/MM/yyyy"), x + 61, y + d, 20);
                    IO.Writexy("│", x + 80, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────────┼─────────────┼───────────────┼────────────────┼───────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────────┴─────────────┴───────────────┴────────────────┴───────────────────┘", x, y + d - 1);
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
                " F1.Nhập danh sách giá bán ",
                " F2.Sửa thông tin giá bán ",
                " F3.Xóa giá bán ",
                " F4.Hiển thị danh sách giá bán ",
                " F5.Tìm kiếm giá bán ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ComputerStore.Presenation.FormHDBan.MenuHDB mnhdb = new ComputerStore.Presenation.FormHDBan.MenuHDB(mn);
            mnhdb.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuGB : Menu
        {
            public MenuGB(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormGiaBan giaban = new FormGiaBan();
                switch (location)
                {
                    case 0:
                        giaban.Nhap();
                        break;
                    case 1:
                        giaban.Sua();
                        break;
                    case 2:
                        giaban.Xoa();
                        break;
                    case 3:
                        giaban.Xem();
                        break;
                    case 4:
                        giaban.Tim();
                        break;
                    case 5:
                        ComputerStore.Presenation.FormMenuChinh.Hien();
                        break;
                }
            }
        }
    }
}
