using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Presenation;

namespace ComputerStore.Presenation
{
    public class FormMenuChinh
    {
        public static void Hien()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Quản lý máy tính ",
                " F2.Quản lý nhà cung cấp ",
                " F3.Quản lý khách hàng ",
                " F4.Quản lý nhân viên ",
                " F5.Quản lý hóa đơn ",
                " F6.Kết thúc "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuChinh mnc = new MenuChinh(mn);
            mnc.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuChinh : Menu
        {
            public MenuChinh(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormMayTinh fmt = new FormMayTinh();
                FormNCC fncc = new FormNCC();
                FormKhachHang fkh = new FormKhachHang();
                FormNhanVien fnv = new FormNhanVien();
                FormMenuChinh fhd = new FormMenuChinh();
                switch (location)
                {
                    case 0:
                        fmt.HienChucNang();
                        break;
                    case 1:
                        fncc.HienChucNang();
                        break;
                    case 2:
                        fkh.HienChucNang();
                        break;
                    case 3:
                        fnv.HienChucNang();
                        break;
                    case 4:
                        fhd.HienHoaDon();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void HienHoaDon()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Quản lý hóa đơn nhập ",
                " F2.Quản lý hóa đơn bán ",
                " F3.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuHD mnhd = new MenuHD(mn);
            mnhd.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuHD : Menu
        {
            public MenuHD(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormHDNhap hdnhap = new FormHDNhap();
                FormHDBan hdban = new FormHDBan();
                switch (location)
                {
                    case 0:
                        hdnhap.HienChucNang();
                        break;
                    case 1:
                        hdban.HienChucNang();
                        break;
                    case 2:
                        Hien();
                        break;
                }
            }
        }
    }
}
