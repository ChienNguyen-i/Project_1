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
                Hien(1, 13, nhacc.LayDSNCC(), 5, 0);
                NCC ncc = new NCC();

                do
                {
                    ncc.tenNCC = IO.ReadString(23, 4);
                    if (ncc.tenNCC == null)
                        IO.Writexy("Nhập lại tên nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (ncc.tenNCC == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    ncc.diaChi = IO.ReadString(14, 6);
                    if (ncc.diaChi == null)
                        IO.Writexy("Nhập lại địa chỉ...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                } while (ncc.diaChi == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    ncc.soDT = IO.ReadNumber(55, 6);
                    if (ncc.soDT == null || ncc.soDT.Length < 10 || ncc.soDT.Length > 10)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(54, 6, 45, ConsoleColor.Black);
                    }
                } while (ncc.soDT == null || ncc.soDT.Length < 10 || ncc.soDT.Length > 10);
                
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(35, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(4, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Nhà cung cấp đã được thêm...", 5, 8);
                    nhacc.ThemNCC(ncc);
                    Hien(1, 13, nhacc.LayDSNCC(), 5, 1);
                }
            } while (true);
        }
        public void Sua()
        {
            do
            {
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.BoxTitle("                                 CẬP NHẬT THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 100);
                IO.Writexy("Mã NCC:", 5, 4);
                IO.Writexy("Tên nhà cung cấp:", 40, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 40, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                Hien(1, 13, nhacc.LayDSNCC(), 5, 0);

                string mancc;
                string tenncc;
                string diachi;
                string sdt;

                do
                {
                    mancc = IO.ReadString(13, 4);
                    if (mancc == null)
                    {
                        IO.Clear(4, 8, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(mancc.ToUpper()) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(12, 4, 27, ConsoleColor.Black);
                        }
                        else
                            mancc = CongCu.CatXau(mancc.ToUpper());
                    }
                } while (mancc == null || nccBLL.KT_MaNCC(mancc.ToUpper()) == false);
                NCC ncc = nhacc.LayNCC(mancc);
                IO.Writexy(ncc.tenNCC, 58, 4);
                IO.Writexy(ncc.diaChi, 14, 6);
                IO.Writexy(ncc.soDT, 55, 6);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    tenncc = IO.ReadString(58, 4);
                    if (tenncc == null)
                        IO.Writexy("Nhập lại tên nhà cung cấp...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (tenncc != ncc.tenNCC && tenncc != null)
                        ncc.tenNCC = CongCu.ChuanHoaXau(tenncc);
                } while (tenncc == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    diachi = IO.ReadString(14, 6);
                    if (diachi == null)
                        IO.Writexy("Nhập lại địa chỉ...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                    else if (diachi != ncc.diaChi && diachi != null)
                        ncc.diaChi = CongCu.ChuanHoaXau(diachi);
                } while (diachi == null);
                IO.Clear(4, 8, 60, ConsoleColor.Black);
                do
                {
                    sdt = IO.ReadNumber(55, 6);
                    if (sdt == null || sdt.Length < 10 || sdt.Length > 10)
                    {
                        IO.Writexy("Nhập lại số điện thoại...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(54, 6, 45, ConsoleColor.Black);
                    }
                    else if (sdt != ncc.soDT && sdt != null)
                        ncc.soDT = CongCu.CatXau(sdt);
                } while (sdt == null || sdt.Length < 10 || sdt.Length > 10);

                IO.Clear(4, 8, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", 5, 8);
                Console.SetCursorPosition(39, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(4, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Nhà cung cấp đã được cập nhật...", 5, 8);
                    nhacc.SuaNCC(ncc);
                    Hien(1, 13, nhacc.LayDSNCC(), 5, 1);
                }
            } while (true);
        }
        public void Xoa()
        {
            string mancc = "";
            do
            {
                Console.Clear();
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.BoxTitle("                                       XÓA NHÀ CUNG CẤP", 1, 1, 7, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần xóa:", 5, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để xóa, Esc để thoát...", 5, 6);
                Hien(1, 8, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    mancc = IO.ReadString(35, 4);
                    if (mancc == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(mancc.ToUpper()) == false)
                        {
                            IO.Clear(4, 6, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(34, 4, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mancc = CongCu.CatXau(mancc.ToUpper());
                            nhacc.XoaNCC(mancc);
                            IO.Clear(4, 6, 60, ConsoleColor.Black);
                            IO.Clear(34, 4, 60, ConsoleColor.Black);
                            IO.Writexy("Nhà cung cấp đã được xóa...", 5, 6);
                            Hien(1, 8, nhacc.LayDSNCC(), 5, 1);
                        }
                    }
                } while (mancc == null || nccBLL.KT_MaNCC(mancc.ToUpper()) == false);
            } while (true);
        }
        public void Xem()
        {
            INCC_BLL nhacc = new NCC_BLL();
            Console.Clear();
            Hien(1, 1, nhacc.LayDSNCC(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string tenncc = "";
            do
            {
                Console.Clear();
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.BoxTitle("                                     TÌM KIẾM NHÀ CUNG CẤP", 1, 1, 7, 100);
                IO.Writexy("Nhập tên nhà cung cấp cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    tenncc = IO.ReadString(34, 4);
                    if (tenncc == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên nhà cung cấp...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_TenNCC(CongCu.ChuanHoaXau(tenncc)) == false)
                        {
                            IO.Clear(4, 6, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại tên nhà cung cấp này...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(33, 4, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(4, 6, 60, ConsoleColor.Black);
                            IO.Writexy("Nhà cung cấp tìm được...", 5, 6);
                            tenncc = CongCu.ChuanHoaXau(tenncc);
                            List<NCC> list = nhacc.TimNCC(new NCC(null, tenncc, null, null));
                            Hien(1, 8, list, 5, 1);
                        }
                    }
                } while (tenncc == null || nccBLL.KT_TenNCC(tenncc) == false);
            } while (true);
        }
        public void TimMa()
        {
            string mancc = "";
            do
            {
                Console.Clear();
                INCC_BLL nhacc = new NCC_BLL();
                NCC_BLL nccBLL = new NCC_BLL();

                Console.Clear();
                IO.BoxTitle("                                     TÌM KIẾM NHÀ CUNG CẤP", 1, 1, 7, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần tìm:", 3, 4);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 5);
                IO.Writexy("Enter để tìm, Esc để thoát...", 5, 6);
                Hien(1, 8, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    mancc = IO.ReadString(33, 4);
                    if (mancc == null)
                    {
                        IO.Clear(4, 6, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(mancc.ToUpper()) == false)
                        {
                            IO.Clear(4, 6, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", 5, 6, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(32, 4, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(4, 6, 60, ConsoleColor.Black);
                            IO.Writexy("Nhà cung cấp tìm được...", 5, 6);
                            mancc = CongCu.CatXau(mancc.ToUpper());
                            List<NCC> list = nhacc.TimNCC(new NCC(mancc, null, null, null));
                            Hien(1, 8, list, 5, 1);
                        }
                    }
                } while (mancc == null || nccBLL.KT_MaNCC(mancc.ToUpper()) == false);
            } while (true);
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
                    IO.Writexy(list[i].maNCC, x + 1, y + d, 9);
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
        public void HienChucNang()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhập danh sách nhà cung cấp ",
                " F2.Sửa thông tin nhà cung cấp ",
                " F3.Xóa nhà cung cấp ",
                " F4.Hiển thị danh sách nhà cung cấp ",
                " F5.Tìm kiếm nhà cung cấp ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuNCC mnncc = new MenuNCC(mn);
            mnncc.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
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
                        nhacc.HienTimKiem();
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
                " F1.Tìm kiếm nhà cung cấp theo mã ",
                " F2.Tìm kiếm nhà cung cấp theo tên ",
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
                FormNCC nhacc = new FormNCC();
                switch (location)
                {
                    case 0:
                        nhacc.TimMa();
                        break;
                    case 1:
                        nhacc.TimTen();
                        break;
                    case 2:
                        nhacc.HienChucNang();
                        break;
                }
            }
        }
    }
}
