/*using System;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormNhanVien
    {
        public void Nhap()
        {
            do
            {
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN NHÂN VIÊN", 1, 1, 10, 79);
                IO.Writexy("Họ tên:", 5, 4);
                IO.Writexy("Ngày sinh:", 30, 4);
                IO.Writexy("Giới tính:", 45, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 25, 6);
                IO.Writexy("Loại nhân viên:", 45, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết!", 5, 8);
                Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();
                nv.tenNV = IO.ReadString(13, 4);
                nv.ngaySinh = DateTime.Parse(IO.ReadString(40, 4));
                nv.gioiTinh = IO.ReadString(50, 4);
                nv.diaChi = IO.ReadString(16, 6);
                nv.soDT = IO.ReadString(34, 6);
                nv.loaiNV = IO.ReadString(55, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    nhanvien.ThemNhanVien(nv);
            } while (true);
        }
        public void Hien(int xx, int yy, List<NhanVien> list, int n, int type)
        {
            int dau = 0;
            int curpage = 1;
            int totalpage = list.Count % n == 0 ? list.Count / n : list.Count / n + 1;
            int cuoi = list.Count <= n ? list.Count : n;
            int x, y, d;
            do
            {
                IO.Clear(xx, yy, 1500, ConsoleColor.Black);
                dau = (curpage - 1) * n;
                cuoi = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                     DANH SÁCH NHÂN VIÊN                              ", x, y);
                IO.Writexy("┌───────┬────────┬──────────┬──────────┬──────────┬──────────┬──────┐", x, y + 1);
                IO.Writexy("│ Mã NV │ Họ tên │Ngày sinh │Giới tính │ Địa chỉ  │  Số ĐT   │LoạiNV│", x, y + 2);
                IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼──────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].maNV.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].tenNV, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].ngaySinh.ToString("dd/MM/yyyy"), x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].gioiTinh, x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].diaChi, x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy(list[i].soDT, x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].loaiNV, x + 62, y + d, 7);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼──────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└───────┴────────┴──────────┴──────────┴──────────┴──────────┴──────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          Nhấn PagegUp xem trước, PagegDown xem tiep, Esc để thoát", x, y + d);
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
    }
}
*/