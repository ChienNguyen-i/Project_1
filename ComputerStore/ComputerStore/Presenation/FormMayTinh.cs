using System;
using System.Text;
using System.Collections.Generic;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormMayTinh
    {
        public void Nhap(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                IMayTinhBLL maytinh = new MayTinhBLL();
                HDNhapBLL hdnBLL = new HDNhapBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();
                FormHDNhap fcthdn = new FormHDNhap();
                CTHDNhapBLL cthdnBLL = new CTHDNhapBLL();
                MayTinh mt = new MayTinh();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                          THÊM GIÁ BÁN MÁY TÍNH", x, y, 10, 110);
                IO.Writexy("Mã MT:", x + 2, y + 3);
                IO.Writexy("Tên máy:", x + 43, y + 3);
                IO.Writexy("Mã nhà CC:", x + 2, y + 5);
                IO.Writexy("Số lượng còn:", x + 37, y + 5);
                IO.Writexy("Giá bán:", x + 74, y + 5);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);

                fcthdn.HienCT_N(x - 1, y + 10, cthdnBLL.LayDS_CTHDNhap(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 9, y + 3);
                    mt.maMT = Console.ReadLine();
                    if (mt.maMT == null)
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mt.maMT == "!")
                        return;
                    else
                    {
                        if (cthdnBLL.KT_MaMT(CongCu.ChuanHoaMa(mt.maMT)) == false)
                        {
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 8, y + 3, 10, ConsoleColor.Black);
                        }
                        else if (mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mt.maMT)) == true)
                        {
                            IO.Writexy("Mã máy tính này đã tồn tại...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 8, y + 3, 10, ConsoleColor.Black);
                        }
                        else
                            mt.maMT = CongCu.ChuanHoaMa(mt.maMT);
                    }
                } while (mt.maMT == null || cthdnBLL.KT_MaMT(CongCu.ChuanHoaMa(mt.maMT)) == false || mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mt.maMT)) == true);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);

                CTHDNhap ctn = cthdnBLL.LayMT(CongCu.ChuanHoaMa(mt.maMT));
                IO.Writexy(ctn.tenMT, x + 52, y + 3);
                mt.tenMT = ctn.tenMT;

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                mt.maNCC = hdnBLL.LayMaNCC(CongCu.ChuanHoaMa(mt.maMT));
                IO.Writexy(mt.maNCC, x + 13, y + 5);

                IO.Writexy(ctn.soLuong.ToString(), x + 51, y + 5);
                mt.sLCon = ctn.soLuong;

                fcthdn.HienCT_N(x - 1, y + 10, cthdnBLL.LayDS_CTHDNhap(), 5, 0);
                IO.Clear(x + 13, y + 7, 60, ConsoleColor.Black);
                do
                {
                    mt.giaBan = double.Parse(IO.ReadNumber(x + 83, y + 5));
                    if (mt.giaBan <= 0)
                    {
                        IO.Writexy("Nhập lại giá bán...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 82, y + 5, 20, ConsoleColor.Black);
                    }
                    else if (mt.giaBan <= ctn.donGia)
                    {
                        IO.Writexy("Nhập lại giá bán lớn hơn giá nhập...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 82, y + 5, 20, ConsoleColor.Black);
                    }
                } while (mt.giaBan < 0 || mt.giaBan <= ctn.donGia);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 34, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Giá bán đã được thêm...", x + 4, y + 7);
                    maytinh.ThemMayTinh(mt);
                    Hien(x + 9, y + 10, maytinh.LayDSMayTinh(), 5, 1);
                }
            } while (true);
        }
        public void Sua(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                IMayTinhBLL maytinh = new MayTinhBLL();
                INCC_BLL nhacc = new NCC_BLL();
                FormNCC fncc = new FormNCC();
                NCC_BLL nccBLL = new NCC_BLL();
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                       CẬP NHẬT THÔNG TIN MÁY TÍNH", x, y, 10, 110);
                IO.Writexy("Mã MT:", x + 2, y + 3);
                IO.Writexy("Tên máy:", x + 43, y + 3);
                IO.Writexy("Mã nhà CC:", x + 2, y + 5);
                IO.Writexy("Số lượng còn:", x + 37, y + 5);
                IO.Writexy("Giá bán:", x + 74, y + 5);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 6);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 8);
                Hien(x + 9, y + 10, maytinh.LayDSMayTinh(), 5, 0);

                string mamt;
                string tenmay;
                string mancc;
                int slc;
                double giaban;

                do
                {
                    Console.SetCursorPosition(x + 9, y + 3);
                    mamt = Console.ReadLine();
                    if (mamt == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mamt == "!")
                        return;
                    else
                    {
                        if (mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mamt)) == false)
                        {
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 8, y + 3, 34, ConsoleColor.Black);
                        }
                        else
                            mamt = CongCu.ChuanHoaMa(mamt);
                    }
                } while (mamt == "" || mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mamt)) == false);
                MayTinh mt = maytinh.LayMayTinh(mamt);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Clear(x + 3, y + 8, 60, ConsoleColor.Black);
                do
                {
                    Console.SetCursorPosition(x + 52, y + 3);
                    tenmay = Console.ReadLine();
                    if (tenmay == "")
                        IO.Writexy("Nhập lại tên máy tính...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    else if (tenmay != mt.tenMT && tenmay != "")
                        mt.tenMT = CongCu.ChuanHoaXau(tenmay);
                } while (tenmay == "");
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                fncc.Hien(x + 16, y + 10, nhacc.LayDSNCC(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 13, y + 5);
                    mancc = Console.ReadLine();
                    if (mancc == "")
                    {
                        IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã nhà cung cấp...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else
                    {
                        if (nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false)
                        {
                            IO.Writexy("Không tồn tại mã nhà cung cấp này...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 12, y + 5, 24, ConsoleColor.Black);
                        }
                        else if (mancc != mt.maNCC && mancc != "")
                            mt.maNCC = CongCu.ChuanHoaMa(mancc);
                    }
                } while (mancc == "" || nccBLL.KT_MaNCC(CongCu.ChuanHoaMa(mancc)) == false);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                Hien(x + 9, y + 10, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    slc = int.Parse(IO.ReadNumber(x + 51, y + 5));
                    if (slc < 0)
                    {
                        IO.Writexy("Nhập lại số lượng còn...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 50, y + 5, 16, ConsoleColor.Black);
                    }
                    else if (slc != mt.sLCon && slc >= 0)
                        mt.sLCon = slc;
                } while (slc < 0);
                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                do
                {
                    giaban = double.Parse(IO.ReadNumber(x + 83, y + 5));
                    if (giaban <= 0)
                    {
                        IO.Writexy("Nhập lại giá bán...", x + 4, y + 7, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 82, y + 5, 20, ConsoleColor.Black);
                    }
                    else if (giaban != mt.giaBan && giaban > 0)
                        mt.giaBan = giaban;
                } while (giaban <= 0);

                IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                IO.Writexy("Enter để cập nhật, Esc để thoát...", x + 4, y + 7);
                Console.SetCursorPosition(x + 38, y + 7);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Clear(x + 3, y + 7, 60, ConsoleColor.Black);
                    IO.Writexy("Máy tính đã được cập nhật...", x + 4, y + 7);
                    maytinh.SuaMayTinh(mt);
                    Hien(x + 9, y + 10, maytinh.LayDSMayTinh(), 5, 1);
                }
            } while (true);
        }
        public void Xoa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mamt = "";
                IMayTinhBLL maytinh = new MayTinhBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                               XÓA MÁY TÍNH", x, y, 8, 110);
                IO.Writexy("Nhập mã máy tính cần xóa:", x + 4, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 9, y + 8, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 30, y + 3);
                    mamt = Console.ReadLine();
                    if (mamt == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mamt == "!")
                        return;
                    else
                    {
                        if (mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mamt)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 29, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            mamt = CongCu.ChuanHoaMa(mamt);
                            maytinh.XoaMayTinh(mamt);
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Clear(x + 29, y + 3, 60, ConsoleColor.Black);
                            IO.Writexy("Máy tính đã được xóa...", x + 4, y + 5);
                            Hien(x + 9, y + 8, maytinh.LayDSMayTinh(), 5, 1);
                        }
                    }
                } while (mamt == "" || mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mamt)) == false);
            } while (true);
        }
        public void Xem(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            IMayTinhBLL maytinh = new MayTinhBLL();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            Hien(x + 11, y + 1, maytinh.LayDSMayTinh(), 5, 1);
        }
        public void TimTen(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string tenmt = "";
                IMayTinhBLL maytinh = new MayTinhBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                             TÌM KIẾM MÁY TÍNH", x, y, 8, 110);
                IO.Writexy("Nhập tên máy tính cần tìm:", x + 2, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 9, y + 8, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 29, y + 3);
                    tenmt = Console.ReadLine();
                    if (tenmt == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại tên máy tính...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (tenmt == "!")
                        return;
                    else
                    {
                        if (mtBLL.KT_TenMayTinh(CongCu.ChuanHoaXau(tenmt)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại tên máy tính này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 28, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Máy tính tìm được...", x + 4, y + 5);
                            tenmt = CongCu.ChuanHoaXau(tenmt);
                            List<MayTinh> list = maytinh.TimMayTinh(new MayTinh(null, tenmt, null, 0, 0));
                            Hien(x + 9, y + 8, list, 5, 1);
                        }
                    }    
                } while (tenmt == "" || mtBLL.KT_TenMayTinh(CongCu.ChuanHoaXau(tenmt)) == false);
            } while (true);
        }
        public void TimMa(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            do
            {
                Console.BackgroundColor = background_color;
                Console.ForegroundColor = text_color;
                string mamt = "";
                IMayTinhBLL maytinh = new MayTinhBLL();
                MayTinhBLL mtBLL = new MayTinhBLL();

                Console.Clear();
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                IO.BoxTitle("                                            TÌM KIẾM MÁY TÍNH", x, y, 8, 110);
                IO.Writexy("Nhập mã máy tính cần tìm:", x + 2, y + 3);
                IO.Writexy("------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
                IO.Writexy("Nhập ! để thoát...", x + 4, y + 6);
                Hien(x + 9, y + 8, maytinh.LayDSMayTinh(), 5, 0);
                do
                {
                    Console.SetCursorPosition(x + 28, y + 3);
                    mamt = Console.ReadLine();
                    if (mamt == "")
                    {
                        IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                        IO.Writexy("Nhập lại mã máy tính...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    }
                    else if (mamt == "!")
                        return;
                    else
                    {
                        if (mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mamt)) == false)
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã máy tính này...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                            IO.Clear(x + 27, y + 3, 60, ConsoleColor.Black);
                        }
                        else
                        {
                            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                            IO.Writexy("Máy tính tìm được...", x + 4, y + 5);
                            mamt = CongCu.ChuanHoaMa(mamt);
                            List<MayTinh> list = maytinh.TimMayTinh(new MayTinh(mamt, null, null, 0, 0));
                            Hien(x + 9, y + 8, list, 5, 1);
                        }
                    }
                } while (mamt == "" || mtBLL.KT_MaMayTinh(CongCu.ChuanHoaMa(mamt)) == false);
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
                IO.Clear(xx, yy, 1900, ConsoleColor.Black);
                IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                                    DANH SÁCH MÁY TÍNH", x, y);
                IO.Writexy("┌─────────────┬─────────────────────────┬─────────────────┬──────────────┬───────────────┐", x, y + 1);
                IO.Writexy("│ Mã máy tính │      Tên máy tính       │ Mã nhà cung cấp │ Số lượng còn │    Giá bán    │", x, y + 2);
                IO.Writexy("├─────────────┼─────────────────────────┼─────────────────┼──────────────┼───────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].maMT, x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].tenMT, x + 15, y + d, 26);
                    IO.Writexy("│", x + 40, y + d);
                    IO.Writexy(list[i].maNCC, x + 41, y + d, 18);
                    IO.Writexy("│", x + 58, y + d);
                    IO.Writexy(list[i].sLCon.ToString(), x + 59, y + d, 15);
                    IO.Writexy("│", x + 73, y + d);
                    IO.Writexy(list[i].giaBan.ToString(), x + 74, y + d, 16);
                    IO.Writexy("│", x + 89, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────┼─────────────────────────┼─────────────────┼──────────────┼───────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────┴─────────────────────────┴─────────────────┴──────────────┴───────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để quay lại...", x, y + d);
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
