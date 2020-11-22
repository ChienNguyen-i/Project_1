using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Presenation;

namespace ComputerStore.Presenation
{
    public class FormMenuChinh
    {
        public static void HienMNC(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Quản lý máy tính", x + 15, y + 3);
                IO.Writexy("F2. Quản lý nhà cung cấp", x + 15, y + 5);
                IO.Writexy("F3. Quản lý khách hàng", x + 15, y + 7);
                IO.Writexy("F4. Quản lý nhân viên", x + 15, y + 9);
                IO.Writexy("F5. Quản lý hóa đơn", x + 15, y + 11);
                IO.Writexy("F6. Kết thúc", x + 15, y + 13);
                IO.Writexy("Chọn chức năng...", x + 15, y + 15);

                FormMayTinh fmt = new FormMayTinh();
                FormNCC fncc = new FormNCC();
                FormKhachHang fkh = new FormKhachHang();
                FormNhanVien fnv = new FormNhanVien();
                FormMenuChinh fhd = new FormMenuChinh();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        fmt.HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        fncc.HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        fkh.HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        fnv.HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        fhd.HienHoaDon(29, 8, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
        public void HienHoaDon(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 11, 56);
                IO.Writexy("F1. Quản lý hóa đơn nhập", x + 15, y + 3);
                IO.Writexy("F2. Quản lý hóa đơn bán", x + 15, y + 5);
                IO.Writexy("F3. Quay lại", x + 15, y + 7);
                IO.Writexy("Chọn chức năng...", x + 15, y + 9);

                FormHDNhap hdnhap = new FormHDNhap();
                FormHDBan hdban = new FormHDBan();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        hdnhap.HienChucNang(29, 5,  ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        hdban.HienChucNang(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        HienMNC(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
    }
}
