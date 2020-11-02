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
                " F1.Quản lý nhân viên ",
                " F2.Quản lý khách hàng ",
                " F3.Quản lý nhà cung cấp ",
                " F4.Quản lý loại máy ",
                " F5.Quản lý máy tính ",
                " F6.Quản lý giá bán ",
                " F7.Quản lý hóa đơn ",
                " F8.Kết thúc "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ComputerStore.Presenation.FormMenuChinh.MenuChinh mnc = new ComputerStore.Presenation.FormMenuChinh.MenuChinh(mn);
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
                FormNhanVien fnv = new FormNhanVien();
                FormKhachHang fkh = new FormKhachHang();
                FormNCC fncc = new FormNCC();
                FormLoaiMay flm = new FormLoaiMay();
                FormMayTinh fmt = new FormMayTinh();
                FormGiaBan fgb = new FormGiaBan();
                FormMenuChinh fhd = new FormMenuChinh();
                switch (location)
                {
                    case 0:
                        fnv.HienChucNang();
                        break;
                    case 1:
                        fkh.HienChucNang();
                        break;
                    case 2:
                        fncc.HienChucNang();
                        break;
                    case 3:
                        flm.HienChucNang();
                        break;
                    case 4:
                        fmt.HienChucNang();
                        break;
                    case 5:
                        fgb.HienChucNang();
                        break;
                    case 6:
                        fhd.HienHoaDon();
                        break;
                    case 7:
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
            ComputerStore.Presenation.FormMenuChinh.MenuHD mnhd = new ComputerStore.Presenation.FormMenuChinh.MenuHD(mn);
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
                        ComputerStore.Presenation.FormMenuChinh.Hien();
                        break;
                }
            }
        }
    }
}
