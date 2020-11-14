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
                INCC_BLL nhacc = new NCC_BLL();
                FormNCC fncc = new FormNCC();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN MÁY TÍNH", 1, 1, 10, 100);
                IO.Writexy("Tên máy:", 5, 4);
                IO.Writexy("Mã nhà cung cấp:", 57, 4);
                IO.Writexy("Số lượng nhập:", 5, 6);
                IO.Writexy("Số lượng còn:", 57, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                MayTinh mt = new MayTinh();

                do
                {
                    mt.tenMT = IO.ReadString(14, 4);
                    if (mt.tenMT == null)
                        IO.Writexy("Nhập lại tên máy...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (mt.tenMT == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fncc.Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    mt.maNCC = IO.ReadString(74, 4);
                    if (mt.maNCC == null)
                        IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else
                    {
                        if (nccBLL.KT_MaNCC(mt.maNCC.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(73, 4, 26, ConsoleColor.Black);
                        }
                        else
                            break;
                    }
                } while (mt.maNCC == null || nccBLL.KT_MaNCC(mt.maNCC) == false);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    mt.sLNhap = int.Parse(IO.ReadNumber(20, 6));
                    if (mt.sLNhap <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng nhập...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(19, 6, 20, ConsoleColor.Black);
                    }
                } while (mt.sLNhap <= 0);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    mt.sLCon = int.Parse(IO.ReadNumber(71, 6));
                    if (mt.sLCon < 0)
                    {
                        IO.Writexy("Nhập lại số lượng còn...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(70, 6, 20, ConsoleColor.Black);
                    }
                } while (mt.sLCon < 0);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(35, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(4, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Máy tính đã được thêm...", 5, 8);
                    maytinh.ThemMayTinh(mt);
                    Hien(1, 13, maytinh.LayDSMayTinh(), 5, 1);
                }
            } while (true);
        }
        public void Sua()
        {
            do
            {
                IMayTinhBLL maytinh = new MayTinhBLL();
                INCC_BLL nhacc = new NCC_BLL();
                FormNCC fncc = new FormNCC();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN MÁY TÍNH", 1, 1, 10, 100);
                IO.Writexy("Mã MT:", 3, 4);
                IO.Writexy("Tên máy:", 44, 4);
                IO.Writexy("Mã nhà CC:", 3, 6);
                IO.Writexy("Số lượng nhập:", 32, 6);
                IO.Writexy("Số lượng còn:", 63, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);

                string mamt;
                string tenmay;
                string mancc;
                int sln;
                int slc;

                do
                {
                    mamt = IO.ReadString(10, 4);
                    if (mamt == null)
                        IO.Writexy("Nhập lại mã máy tính...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else
                        mamt = CongCu.CatXau(mamt.ToUpper());
                } while (mamt == null);
                MayTinh mt = maytinh.LayMayTinh(mamt);
                IO.Writexy(mt.tenMT, 53, 4);
                IO.Writexy(mt.maNCC.ToString(), 14, 6);
                IO.Writexy(mt.sLNhap.ToString(), 47, 6);
                IO.Writexy(mt.sLCon.ToString(), 77, 6);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    tenmay = IO.ReadString(53, 4);
                    if (tenmay == null)
                        IO.Writexy("Nhập lại tên máy tính...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (tenmay != mt.tenMT && tenmay != null)
                        mt.tenMT = CongCu.HoaDau(tenmay);
                } while (tenmay == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                fncc.Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    mancc = IO.ReadString(14, 6);
                    if (mancc == null)
                        IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else
                    {
                        if (nccBLL.KT_MaNCC(mancc.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(13, 6, 18, ConsoleColor.Black);
                        }
                        else
                            break;
                        if (mancc != mt.maNCC && mancc != null)
                            mt.maNCC = CongCu.CatXau(mancc.ToUpper());
                    }
                } while (mancc == null || nccBLL.KT_MaNCC(mancc) == false);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                Hien(1, 13, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    sln = int.Parse(IO.ReadNumber(47, 6));
                    if (sln <= 0)
                    {
                        IO.Writexy("Nhập lại số lượng nhập...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(46, 6, 16, ConsoleColor.Black);
                    }
                    else if (sln != mt.sLNhap && sln > 0)
                        mt.sLNhap = sln;
                } while (sln <= 0);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    slc = int.Parse(IO.ReadNumber(77, 6));
                    if (slc < 0)
                    {
                        IO.Writexy("Nhập lại số lượng còn...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(76, 6, 20, ConsoleColor.Black);
                    }
                    else if (slc != mt.sLCon && slc >= 0)
                        mt.sLCon = slc;
                } while (slc < 0);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(39, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(4, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Máy tính đã được cập nhật...", 5, 8);
                    maytinh.SuaMayTinh(mt);
                    Hien(1, 13, maytinh.LayDSMayTinh(), 5, 1);
                }
            } while (true);
        }
        public void Xoa()
        {
            string mamt = "";
            do
            {
                Console.Clear();
                IMayTinhBLL maytinh = new MayTinhBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA MÁY TÍNH", 1, 1, 7, 100);
                IO.Writexy("Nhập mã máy tính cần xóa:", 5, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    mamt = IO.ReadString(31, 4);
                    if (mamt == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                        mamt = CongCu.CatXau(mamt.ToUpper());
                        maytinh.XoaMayTinh(mamt);
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Máy tính đã được xóa...", 5, 6);
                    }
                } while (mamt == null);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 1);
            } while (true);
        }
        public void Xem()
        {
            IMayTinhBLL maytinh = new MayTinhBLL();
            Console.Clear();
            Hien(1, 1, maytinh.LayDSMayTinh(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string tenmt = "";
            do
            {
                Console.Clear();
                IMayTinhBLL maytinh = new MayTinhBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM MÁY TÍNH", 1, 1, 7, 100);
                IO.Writexy("Nhập tên máy tính cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    tenmt = IO.ReadString(30, 4);
                    if (tenmt == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên máy tính...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Máy tính tìm được...", 5, 6);
                        List<MayTinh> list = maytinh.TimMayTinh(new MayTinh(null, tenmt, null, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }    
                } while (tenmt == null);
            } while (true);
        }
        public void TimMa()
        {
            string mamt = "";
            do
            {
                Console.Clear();
                IMayTinhBLL maytinh = new MayTinhBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM MÁY TÍNH", 1, 1, 7, 100);
                IO.Writexy("Nhập mã máy tính cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    mamt = IO.ReadString(29, 4);
                    if (mamt == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Máy tính tìm được...", 5, 6);
                        mamt = CongCu.CatXau(mamt.ToUpper());
                        List<MayTinh> list = maytinh.TimMayTinh(new MayTinh(mamt, null, null, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (mamt == null);
            } while (true);
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
                IO.Writexy("                              DANH SÁCH MÁY TÍNH", x, y);
                IO.Writexy("┌─────────────┬─────────────────────────┬───────────┬───────────────┬──────────────┐", x, y + 1);
                IO.Writexy("│ Mã máy tính │      Tên máy tính       │ Mã nhà CC │ Số lượng nhập │ Số lượng còn │", x, y + 2);
                IO.Writexy("├─────────────┼─────────────────────────┼───────────┼───────────────┼──────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].maMT, x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].tenMT, x + 15, y + d, 26);
                    IO.Writexy("│", x + 40, y + d);
                    IO.Writexy(list[i].maNCC, x + 41, y + d, 12);
                    IO.Writexy("│", x + 52, y + d);
                    IO.Writexy(list[i].sLNhap.ToString(), x + 53, y + d, 16);
                    IO.Writexy("│", x + 68, y + d);
                    IO.Writexy(list[i].sLCon.ToString(), x + 69, y + d, 15);
                    IO.Writexy("│", x + 83, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────┼─────────────────────────┼───────────┼───────────────┼──────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────┴─────────────────────────┴───────────┴───────────────┴──────────────┘", x, y + d - 1);
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
                " F1.Nhập danh sách máy tính ",
                " F2.Sửa thông tin máy tính ",
                " F3.Xóa máy tính ",
                " F4.Hiển thị danh sách máy tính ",
                " F5.Tìm kiếm máy tính ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuMT mnmt = new MenuMT(mn);
            mnmt.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
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
                        maytinh.HienTimKiem();
                        break;
                    case 5:
                        FormMenuChinh.Hien();
                        break;
                }
            }
        }
        public void HienTimKiem()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Tìm kiếm máy tính theo mã ",
                " F2.Tìm kiếm máy tính theo tên ",
                " F3.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuTimKiem mntk = new MenuTimKiem(mn);
            mntk.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuTimKiem : Menu
        {
            public MenuTimKiem(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormMayTinh maytinh = new FormMayTinh();
                switch (location)
                {
                    case 0:
                        maytinh.TimMa();
                        break;
                    case 1:
                        maytinh.TimTen();
                        break;
                    case 2:
                        maytinh.HienChucNang();
                        break;
                }
            }
        }
    }
}
