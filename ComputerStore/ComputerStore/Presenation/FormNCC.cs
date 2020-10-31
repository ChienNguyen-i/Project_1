using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormNCC
    {
        public void Nhap()
        {
            do
            {
                INCC_BLL nhacc = new NCC_BLL();
                Console.Clear();
                IO.BoxTitle("                                   NHẬP THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 100);
                IO.Writexy("Tên nhà cung cấp:", 5, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 40, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
                NCC ncc = new NCC();
                ncc.tenNCC = IO.ReadString(23, 4);
                ncc.diaChi = IO.ReadString(14, 6);
                ncc.soDT = IO.ReadNumber(55, 6);
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, nhacc.LayDSNCC(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    nhacc.ThemNCC(ncc);
            } while (true);
        }
        public void Sua()
        {
            INCC_BLL nhacc = new NCC_BLL();
            Console.Clear();
            IO.BoxTitle("                                 CẬP NHẬT THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 100);
            IO.Writexy("Mã NCC:", 5, 4);
            IO.Writexy("Tên nhà cung cấp:", 30, 4);
            IO.Writexy("Địa chỉ:", 5, 6);
            IO.Writexy("Số điện thoại:", 40, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
            int mancc;
            string tenncc;
            string diachi;
            string sdt;

            mancc = int.Parse(IO.ReadNumber(13, 4));
            NCC ncc = nhacc.LayNCC(mancc);
            IO.Writexy(ncc.tenNCC, 48, 4);
            IO.Writexy(ncc.diaChi, 14, 6);
            IO.Writexy(ncc.soDT, 55, 6);

            tenncc = IO.ReadString(48, 4);
            if (tenncc != ncc.tenNCC && tenncc != null)
                ncc.tenNCC = tenncc;
            diachi = IO.ReadString(14, 6);
            if (diachi != ncc.diaChi && diachi != null)
                ncc.diaChi = diachi;
            sdt = IO.ReadNumber(55, 6);
            if (sdt != ncc.soDT && sdt != null)
                ncc.soDT = sdt;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                ComputerStore.Program.Hien();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, nhacc.LayDSNCC(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nhacc.SuaNCC(ncc);
                Hien(1, 13, nhacc.LayDSNCC(), 5, 1);
            }
            ComputerStore.Program.Hien();
        }
        public void Xoa()
        {
            int mancc = 0;
            do
            {
                Console.Clear();
                INCC_BLL nhacc = new NCC_BLL();
                Console.Clear();
                IO.BoxTitle("                                       XÓA NHÀ CUNG CẤP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần xóa:", 5, 4);
                Hien(1, 8, nhacc.LayDSNCC(), 5, 0);
                mancc = int.Parse(IO.ReadNumber(35, 4));
                if (mancc == 0)
                    break;
                else
                    nhacc.XoaNCC(mancc);
                Hien(1, 8, nhacc.LayDSNCC(), 5, 1);
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Xem()
        {
            INCC_BLL nhacc = new NCC_BLL();
            Console.Clear();
            Hien(1, 1, nhacc.LayDSNCC(), 5, 1);
            ComputerStore.Program.Hien();
        }
        public void Tim()
        {
            string tenncc = "";
            do
            {
                Console.Clear();
                INCC_BLL nhacc = new NCC_BLL();
                Console.Clear();
                IO.BoxTitle("                                     TÌM KIẾM NHÀ CUNG CẤP", 1, 1, 5, 100);
                IO.Writexy("Nhập tên nhà cung cấp cần tìm:", 3, 4);
                Hien(1, 8, nhacc.LayDSNCC(), 5, 0);
                tenncc = ComputerStore.Utility.CongCu.ChuanHoaXau(IO.ReadString(34, 4));
                List<NCC> list = nhacc.TimNCC(new NCC(0, tenncc, null, null));
                Hien(1, 8, list, 5, 1);
                if (tenncc == "")
                    break;
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Hien(int xx, int yy, List<NCC> list, int n, int type)
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
                IO.Writexy("                     DANH SÁCH NHÀ CUNG CẤP", x, y);
                IO.Writexy("┌────────┬───────────────────────┬───────────────┬─────────────┐", x, y + 1);
                IO.Writexy("│ Mã NCC │   Tên nhà cung cấp    │    Địa chỉ    │    Số ĐT    │", x, y + 2);
                IO.Writexy("├────────┼───────────────────────┼───────────────┼─────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 9);
                    IO.Writexy(list[i].maNCC.ToString(), x + 1, y + d, 9);
                    IO.Writexy("│", x + 9, y + d);
                    IO.Writexy(list[i].tenNCC, x + 10, y + d, 24);
                    IO.Writexy("│", x + 33, y + d);
                    IO.Writexy(list[i].diaChi, x + 34, y + d, 16);
                    IO.Writexy("│", x + 49, y + d);
                    IO.Writexy(list[i].soDT, x + 50, y + d, 14);
                    IO.Writexy("│", x + 63, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────┼───────────────────────┼───────────────┼─────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────┴───────────────────────┴───────────────┴─────────────┘", x, y + d - 1);
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
        public class MenuNCC : Menu
        {
            public MenuNCC(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormNCC nhacc = new FormNCC();
                switch (location)
                {
                    case 0:
                        nhacc.Nhap();
                        break;
                    case 1:
                        nhacc.Sua();
                        break;
                    case 2:
                        nhacc.Xoa();
                        break;
                    case 3:
                        nhacc.Xem();
                        break;
                    case 4:
                        nhacc.Tim();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
