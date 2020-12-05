using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;

namespace ComputerStore.Presenation
{
    class Form_MN_NhanVien
    {
        public static void HienMNC_NV(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 15, 56);
                IO.Writexy("F1. Quản lý máy tính", x + 15, y + 3);
                IO.Writexy("F2. Quản lý nhà cung cấp", x + 15, y + 5);
                IO.Writexy("F3. Quản lý khách hàng", x + 15, y + 7);
                IO.Writexy("F4. Quản lý hóa đơn", x + 15, y + 9);
                IO.Writexy("F5. Kết thúc", x + 15, y + 11);
                IO.Writexy("Chọn chức năng...", x + 15, y + 13);

                Form_MN_NhanVien fmt = new Form_MN_NhanVien();
                Form_MN_NhanVien fncc = new Form_MN_NhanVien();
                Form_MN_NhanVien fkh = new Form_MN_NhanVien();
                Form_MN_NhanVien fhd = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        fmt.HienChucNang_MT(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        fncc.HienChucNang_NCC(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        fkh.HienChucNang_KH(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        fhd.HienHoaDon(29, 8, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
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
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 11, 56);
                IO.Writexy("F1. Quản lý hóa đơn nhập", x + 15, y + 3);
                IO.Writexy("F2. Quản lý hóa đơn bán", x + 15, y + 5);
                IO.Writexy("F3. Quay lại", x + 15, y + 7);
                IO.Writexy("Chọn chức năng...", x + 15, y + 9);

                Form_MN_NhanVien fhdnhap = new Form_MN_NhanVien();
                Form_MN_NhanVien fhdban = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        fhdnhap.HienChucNang_HDN(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        fhdban.HienChucNang_HDB(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        HienMNC_NV(29, 6, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        //---------------------------------------------------------------------------
        public void HienChucNang_MT(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách máy tính", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin máy tính", x + 12, y + 5);
                IO.Writexy("F3. Xóa máy tính", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách máy tính", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm máy tính", x + 12, y + 11);
                IO.Writexy("F6. Quay lại", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormMayTinh maytinh = new FormMayTinh();
                Form_MN_NhanVien ftk = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        maytinh.Nhap(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        maytinh.Sua(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        maytinh.Xoa(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        maytinh.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        ftk.HienTimKiem_MT(27, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        HienMNC_NV(29, 6, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        public void HienTimKiem_MT(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 11, 56);
                IO.Writexy("F1. Tìm kiếm máy tính theo mã", x + 12, y + 3);
                IO.Writexy("F2. Tìm kiếm máy tính theo tên", x + 12, y + 5);
                IO.Writexy("F3. Quay lại", x + 12, y + 7);
                IO.Writexy("Chọn chức năng...", x + 12, y + 9);

                FormMayTinh maytinh = new FormMayTinh();
                Form_MN_NhanVien fnv = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        maytinh.TimMa(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        maytinh.TimTen(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        fnv.HienChucNang_MT(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        //---------------------------------------------------------------------------
        public void HienChucNang_NCC(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách nhà cung cấp", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin nhà cung cấp", x + 12, y + 5);
                IO.Writexy("F3. Xóa nhà cung cấp", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách nhà cung cấp", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm nhà cung cấp", x + 12, y + 11);
                IO.Writexy("F6. Quay lại", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormNCC nhacc = new FormNCC();
                Form_MN_NhanVien ftk = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        nhacc.Nhap(6, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        nhacc.Sua(6, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        nhacc.Xoa(6, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        nhacc.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        ftk.HienTimKiem_NCC(27, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        HienMNC_NV(29, 6, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        public void HienTimKiem_NCC(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 11, 56);
                IO.Writexy("F1. Tìm kiếm nhà cung cấp theo mã", x + 10, y + 3);
                IO.Writexy("F2. Tìm kiếm nhà cung cấp theo tên", x + 10, y + 5);
                IO.Writexy("F3. Quay lại", x + 10, y + 7);
                IO.Writexy("Chọn chức năng...", x + 10, y + 9);

                FormNCC nhacc = new FormNCC();
                Form_MN_NhanVien fnv = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        nhacc.TimMa(6, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        nhacc.TimTen(6, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        fnv.HienChucNang_NCC(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        //---------------------------------------------------------------------------
        public void HienChucNang_KH(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách khách hàng", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin khách hàng", x + 12, y + 5);
                IO.Writexy("F3. Xóa khách hàng", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách khách hàng", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm khách hàng", x + 12, y + 11);
                IO.Writexy("F6. Quay lại ", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormKhachHang khachang = new FormKhachHang();
                Form_MN_NhanVien ftk = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        khachang.Nhap(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        khachang.Sua(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        khachang.Xoa(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        khachang.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        ftk.HienTimKiem_KH(27, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        HienMNC_NV(29, 6, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        public void HienTimKiem_KH(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 11, 56);
                IO.Writexy("F1. Tìm kiếm khách hàng theo mã", x + 12, y + 3);
                IO.Writexy("F2. Tìm kiếm khách hàng theo tên", x + 12, y + 5);
                IO.Writexy("F3. Quay lại", x + 12, y + 7);
                IO.Writexy("Chọn chức năng...", x + 12, y + 9);

                FormKhachHang khachang = new FormKhachHang();
                Form_MN_NhanVien fnv = new Form_MN_NhanVien();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        khachang.TimMa(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        khachang.TimTen(2, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        fnv.HienChucNang_KH(29, 5, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }        
        //---------------------------------------------------------------------------
        public void HienChucNang_HDN(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách hóa đơn nhập", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin hóa đơn nhập", x + 12, y + 5);
                IO.Writexy("F3. Xóa hóa đơn nhập", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách hóa đơn nhập", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm hóa đơn nhập", x + 12, y + 11);
                IO.Writexy("F6. Quay lại", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormHDNhap hdnhap = new FormHDNhap();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        hdnhap.Nhap(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        hdnhap.Sua(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        hdnhap.Xoa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        hdnhap.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        hdnhap.TimMa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        HienHoaDon(30, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
        //---------------------------------------------------------------------------
        public void HienChucNang_HDB(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.SetWindowSize(114, 28);
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, 17, 56);
                IO.Writexy("F1. Nhập danh sách hóa đơn bán", x + 12, y + 3);
                IO.Writexy("F2. Sửa thông tin hóa đơn bán", x + 12, y + 5);
                IO.Writexy("F3. Xóa hóa đơn bán", x + 12, y + 7);
                IO.Writexy("F4. Hiển thị danh sách hóa đơn bán", x + 12, y + 9);
                IO.Writexy("F5. Tìm kiếm hóa đơn bán", x + 12, y + 11);
                IO.Writexy("F6. Quay lại ", x + 12, y + 13);
                IO.Writexy("Chọn chức năng...", x + 12, y + 15);

                FormHDBan hdban = new FormHDBan();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        hdban.Nhap(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F2:
                        hdban.Sua(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F3:
                        hdban.Xoa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F4:
                        hdban.Xem(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F5:
                        hdban.TimMa(1, 1, ConsoleColor.Black, ConsoleColor.White);
                        break;
                    case ConsoleKey.F6:
                        HienHoaDon(30, 7, ConsoleColor.Black, ConsoleColor.White);
                        break;
                }
            } while (true);
        }
    }
}
