using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormLoaiMay
    {
        public void Nhap()
        {
            do
            {
                ILoaiMayBLL loaimay = new LoaiMayBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN LOẠI MÁY", 1, 1, 10, 100);
                IO.Writexy("Tên loại máy:", 5, 4);
                IO.Writexy("Đặc điểm:", 5, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, loaimay.LayDSLoaiMay(), 5, 0);
                LoaiMay lm = new LoaiMay();
                lm.tenLM = IO.ReadString(19, 4);
                lm.dacDiem = IO.ReadString(15, 6);
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, loaimay.LayDSLoaiMay(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    loaimay.ThemLoaiMay(lm);
            } while (true);
        }
        public void Sua()
        {
            ILoaiMayBLL loaimay = new LoaiMayBLL();
            Console.Clear();
            IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN LOẠI MÁY", 1, 1, 10, 100);
            IO.Writexy("Mã loại máy:", 5, 4);
            IO.Writexy("Tên loại máy:", 40, 4);
            IO.Writexy("Đặc điểm:", 5, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, loaimay.LayDSLoaiMay(), 5, 0);
            int malm;
            string tenlm;
            string daciem;

            malm = int.Parse(IO.ReadNumber(18, 4));
            LoaiMay lm = loaimay.LayLoaiMay(malm);
            IO.Writexy(lm.tenLM, 54, 4);
            IO.Writexy(lm.dacDiem, 15, 6);

            tenlm = IO.ReadString(54, 4);
            if (tenlm != lm.tenLM && tenlm != null)
                lm.tenLM = tenlm;
            daciem = IO.ReadString(15, 6);
            if (daciem != lm.dacDiem && daciem != null)
                lm.dacDiem = daciem;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                ComputerStore.Program.Hien();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, loaimay.LayDSLoaiMay(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                loaimay.SuaLoaiMay(lm);
                Hien(1, 13, loaimay.LayDSLoaiMay(), 5, 1);
            }
            ComputerStore.Program.Hien();
        }
        public void Xoa()
        {
            int malm = 0;
            do
            {
                Console.Clear();
                ILoaiMayBLL loaimay = new LoaiMayBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA LOẠI MÁY", 1, 1, 5, 100);
                IO.Writexy("Nhập mã loại máy cần xóa:", 5, 4);
                Hien(1, 8, loaimay.LayDSLoaiMay(), 5, 0);
                malm = int.Parse(IO.ReadNumber(31, 4));
                if (malm == 0)
                    break;
                else
                    loaimay.XoaLoaiMay(malm);
                Hien(1, 8, loaimay.LayDSLoaiMay(), 5, 1);
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Xem()
        {
            ILoaiMayBLL loaimay = new LoaiMayBLL();
            Console.Clear();
            Hien(1, 1, loaimay.LayDSLoaiMay(), 5, 1);
            ComputerStore.Program.Hien();
        }
        public void Tim()
        {
            string tenlm = "";
            do
            {
                Console.Clear();
                ILoaiMayBLL loaimay = new LoaiMayBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM LOẠI MÁY", 1, 1, 5, 100);
                IO.Writexy("Nhập tên loại máy cần tìm:", 3, 4);
                Hien(1, 8, loaimay.LayDSLoaiMay(), 5, 0);
                tenlm = IO.ReadString(30, 4);
                List<LoaiMay> list = loaimay.TimLoaiMay(new LoaiMay(0, tenlm, null));
                Hien(1, 8, list, 5, 1);
                if (tenlm == "")
                    break;
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Hien(int xx, int yy, List<LoaiMay> list, int n, int type)
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
                IO.Writexy("                                     DANH SÁCH LOẠI MÁY", x, y);
                IO.Writexy("┌─────────────┬────────────────────────┬────────────────────────────────────────────────────────┐", x, y + 1);
                IO.Writexy("│ Mã loại máy │      Tên loại máy      │                        Đặc điểm                        │", x, y + 2);
                IO.Writexy("├─────────────┼────────────────────────┼────────────────────────────────────────────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].maLM.ToString(), x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].tenLM, x + 15, y + d, 25);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].dacDiem, x + 40, y + d, 57);
                    IO.Writexy("│", x + 96, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────┼────────────────────────┼────────────────────────────────────────────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────┴────────────────────────┴────────────────────────────────────────────────────────┘", x, y + d - 1);
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
        public class MenuLM : Menu
        {
            public MenuLM(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormLoaiMay loaimay = new FormLoaiMay();
                switch (location)
                {
                    case 0:
                        loaimay.Nhap();
                        break;
                    case 1:
                        loaimay.Sua();
                        break;
                    case 2:
                        loaimay.Xoa();
                        break;
                    case 3:
                        loaimay.Xem();
                        break;
                    case 4:
                        loaimay.Tim();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
