using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormMayTinh
    {
        public void Nhap()
        {
            do
            {
                IMayTinhBLL maytinh = new MayTinhBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN MÁY TÍNH", 1, 1, 10, 100);
                IO.Writexy("Mã loại máy:", 5, 4);
                IO.Writexy("Tên máy:", 5, 6);
                IO.Writexy("Mã nhà CC:", 39, 4);
                IO.Writexy("Số lượng nhập:", 75, 4);
                IO.Writexy("Số lượng còn:", 75, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                MayTinh mt = new MayTinh();
                mt.maLM = int.Parse(IO.ReadNumber(18, 4));
                mt.tenMT = IO.ReadString(14, 6);
                mt.maNCC = int.Parse(IO.ReadNumber(50, 4));
                mt.sLNhap = int.Parse(IO.ReadNumber(90, 4));
                mt.sLCon = int.Parse(IO.ReadNumber(89, 6));
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, maytinh.LayDSMayTinh(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    maytinh.ThemMayTinh(mt);
            } while (true);
        }
        public void Sua()
        {
            IMayTinhBLL maytinh = new MayTinhBLL();
            Console.Clear();
            IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN MÁY TÍNH", 1, 1, 10, 100);
            IO.Writexy("Mã MT:", 3, 4);
            IO.Writexy("Mã loại máy:", 24, 4);
            IO.Writexy("Tên máy:", 55, 4);
            IO.Writexy("Mã nhà CC:", 3, 6);
            IO.Writexy("Số lượng nhập:", 32, 6);
            IO.Writexy("Số lượng còn:", 63, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
            int mamt;
            int malm;
            string tenmay;
            int mancc;
            int sln;
            int slc;

            mamt = int.Parse(IO.ReadNumber(10, 4));
            MayTinh mt = maytinh.LayMayTinh(mamt);
            IO.Writexy(mt.maLM.ToString(), 37, 4);
            IO.Writexy(mt.tenMT, 64, 4);
            IO.Writexy(mt.maNCC.ToString(), 14, 6);
            IO.Writexy(mt.sLNhap.ToString(), 47, 6);
            IO.Writexy(mt.sLCon.ToString(), 77, 6);

            malm = int.Parse(IO.ReadNumber(37, 4));
            if (malm != mt.maLM && malm != 0)
                mt.maLM = malm;
            tenmay = IO.ReadString(64, 4);
            if (tenmay != mt.tenMT && tenmay != null)
                mt.tenMT = tenmay;
            mancc = int.Parse(IO.ReadNumber(14, 6));
            if (mancc != mt.maNCC && mancc != 0)
                mt.maNCC = mancc;
            sln = int.Parse(IO.ReadNumber(47, 6));
            if (sln != mt.sLNhap && sln != 0)
                mt.sLNhap = sln;
            slc = int.Parse(IO.ReadNumber(77, 6));
            if (slc != mt.sLCon && slc != 0)
                mt.sLCon = slc;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                ComputerStore.Program.Hien();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                maytinh.SuaMayTinh(mt);
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 1);
            }
            ComputerStore.Program.Hien();
        }
        public void Xoa()
        {
            int mamt = 0;
            do
            {
                Console.Clear();
                IMayTinhBLL maytinh = new MayTinhBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA MÁY TÍNH", 1, 1, 5, 100);
                IO.Writexy("Nhập mã máy tính cần xóa:", 5, 4);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 0);
                mamt = int.Parse(IO.ReadNumber(31, 4));
                if (mamt == 0)
                    break;
                else
                    maytinh.XoaMayTinh(mamt);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 1);
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Xem()
        {
            IMayTinhBLL maytinh = new MayTinhBLL();
            Console.Clear();
            Hien(1, 1, maytinh.LayDSMayTinh(), 5, 1);
            ComputerStore.Program.Hien();
        }
        public void Tim()
        {
            string tenmt = "";
            do
            {
                Console.Clear();
                IMayTinhBLL maytinh = new MayTinhBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM MÁY TÍNH", 1, 1, 5, 100);
                IO.Writexy("Nhập tên máy tính cần tìm:", 3, 4);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 0);
                tenmt = IO.ReadString(30, 4);
                List<MayTinh> list = maytinh.TimMayTinh(new MayTinh(0, 0, tenmt, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (tenmt == "")
                    break;
            } while (true);
            ComputerStore.Program.Hien();
        }
        public void Hien(int xx, int yy, List<MayTinh> list, int n, int type)
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
                IO.Writexy("                                         DANH SÁCH MÁY TÍNH", x, y);
                IO.Writexy("┌─────────────┬─────────────┬─────────────────────────┬───────────┬───────────────┬──────────────┐", x, y + 1);
                IO.Writexy("│ Mã máy tính │ Mã loại máy │      Tên máy tính       │ Mã nhà CC │ Số lượng nhập │ Số lượng còn │", x, y + 2);
                IO.Writexy("├─────────────┼─────────────┼─────────────────────────┼───────────┼───────────────┼──────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].maMT.ToString(), x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].maLM.ToString(), x + 15, y + d, 14);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].tenMT, x + 29, y + d, 26);
                    IO.Writexy("│", x + 54, y + d);
                    IO.Writexy(list[i].maNCC.ToString(), x + 55, y + d, 12);
                    IO.Writexy("│", x + 66, y + d);
                    IO.Writexy(list[i].sLNhap.ToString(), x + 67, y + d, 16);
                    IO.Writexy("│", x + 82, y + d);
                    IO.Writexy(list[i].sLCon.ToString(), x + 83, y + d, 15);
                    IO.Writexy("│", x + 97, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────┼─────────────┼─────────────────────────┼───────────┼───────────────┼──────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────┴─────────────┴─────────────────────────┴───────────┴───────────────┴──────────────┘", x, y + d - 1);
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
        public class MenuMT : Menu
        {
            public MenuMT(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormMayTinh maytinh = new FormMayTinh();
                switch (location)
                {
                    case 0:
                        maytinh.Nhap();
                        break;
                    case 1:
                        maytinh.Sua();
                        break;
                    case 2:
                        maytinh.Xoa();
                        break;
                    case 3:
                        maytinh.Xem();
                        break;
                    case 4:
                        maytinh.Tim();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
