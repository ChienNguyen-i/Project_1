using System;
using System.Collections.Generic;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer;

namespace ComputerStore.Presenation
{
    public class FormThongKe
    {
        private string txtfile = "Data/HDBan.txt";
        public void TK_Ngay(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            string ngay = "";
            string s;
            double doanhthu = 0;

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            IO.BoxTitle("                                            THỐNG KÊ THEO NGÀY", x, y, 12, 112);
            IO.Writexy("Nhập ngày muốn thống kê:", x + 4, y + 3);
            IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
            IO.Writexy("Nhập ngày thống kê định dạng 'dd/MM/yyyy'...", x + 4, y + 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 7);
            
            do
            {
                Console.SetCursorPosition(x + 29, y + 3);
                ngay = Console.ReadLine();
                if (ngay == "" || CongCu.CheckDate(ngay) == false)
                {
                    IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại ngày thống kê...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(x + 28, y + 3, 60, ConsoleColor.Black);
                }
            } while (ngay == "" || CongCu.CheckDate(ngay) == false);

            StreamReader sr = new StreamReader(txtfile);
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                if (tmp[3] == ngay)
                {
                    double tt = double.Parse(tmp[4]);
                    doanhthu += tt;
                }
            }
            IO.Writexy("Doanh thu là:", x + 4, y + 9);
            IO.Writexy(doanhthu.ToString(), x + 18, y + 9);
            sr.Close();

            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
            IO.Clear(x + 3, y + 6, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát...", x + 4, y + 5);
            Console.SetCursorPosition(x + 26, y + 5);
        }
        public void TK_Thang(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            string thang = "";
            string s;
            double doanhthu = 0;

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            IO.BoxTitle("                                           THỐNG KÊ THEO THÁNG", x, y, 12, 112);
            IO.Writexy("Nhập tháng muốn thống kê:", x + 4, y + 3);
            IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
            IO.Writexy("Nhập tháng thống kê định dạng 'MM/yyyy'...", x + 4, y + 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 7);

            do
            {
                Console.SetCursorPosition(x + 30, y + 3);
                thang = Console.ReadLine();
                if (thang == "" || CongCu.CheckMonth(thang) == false)
                {
                    IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại tháng thống kê...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(x + 29, y + 3, 60, ConsoleColor.Black);
                }
            } while (thang == "" || CongCu.CheckMonth(thang) == false);

            StreamReader sr = new StreamReader(txtfile);
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                String[] d = tmp[3].Split('/');
                if ((d[1] + "/" + d[2]) == thang)
                {
                    double tt = double.Parse(tmp[4]);
                    doanhthu += tt;
                }
            }
            IO.Writexy("Doanh thu là:", x + 4, y + 9);
            IO.Writexy(doanhthu.ToString(), x + 18, y + 9);
            sr.Close();

            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
            IO.Clear(x + 3, y + 6, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát...", x + 4, y + 5);
            Console.SetCursorPosition(x + 26, y + 5);
        }
        public void TK_Nam(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            string nam = "";
            string s;
            double doanhthu = 0;

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
            IO.BoxTitle("                                            THỐNG KÊ THEO NĂM", x, y, 12, 112);
            IO.Writexy("Nhập năm muốn thống kê:", x + 4, y + 3);
            IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 4);
            IO.Writexy("Nhập năm thống kê định dạng 'yyyy'...", x + 4, y + 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------------------", x + 1, y + 7);

            do
            {
                Console.SetCursorPosition(x + 28, y + 3);
                nam = Console.ReadLine();
                if (nam == "" || Convert.ToInt16(nam) <= 0)
                {
                    IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại năm thống kê...", x + 4, y + 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(x + 27, y + 3, 60, ConsoleColor.Black);
                }
            } while (nam == "" || Convert.ToInt16(nam) <= 0);

            StreamReader sr = new StreamReader(txtfile);
            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                String[] d = tmp[3].Split('/');
                if (d[2] == nam)
                {
                    double tt = double.Parse(tmp[4]);
                    doanhthu += tt;
                }
            }
            IO.Writexy("Doanh thu là:", x + 4, y + 9);
            IO.Writexy(doanhthu.ToString(), x + 18, y + 9);
            sr.Close();

            IO.Clear(x + 3, y + 5, 60, ConsoleColor.Black);
            IO.Clear(x + 3, y + 6, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát...", x + 4, y + 5);
            Console.SetCursorPosition(x + 26, y + 5);
        }
        public void SL_Con(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            MayTinhDAL mtDAL = new MayTinhDAL();
            List<MayTinh> ds = mtDAL.GetData();
            List<MayTinh> kq = new List<MayTinh>();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);

            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].sLCon >= 5)
                {
                    kq.Add(ds[i]); 
                }
            }
            IO.Writexy("                                            DANH SÁCH MÁY TÍNH CÒN", x, y + 1);
            Hien(x + 11, y + 2, kq, 5, 1);
        }
        public void SL_SapHet(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            MayTinhDAL mtDAL = new MayTinhDAL();
            List<MayTinh> ds = mtDAL.GetData();
            List<MayTinh> kq = new List<MayTinh>();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);

            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].sLCon < 5)
                {
                    kq.Add(ds[i]);
                }
            }
            IO.Writexy("                                        DANH SÁCH MÁY TÍNH SẮP HẾT", x, y + 1);
            Hien(x + 11, y + 2, kq, 5, 1);
        }
        public void SL_Het(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            MayTinhDAL mtDAL = new MayTinhDAL();
            List<MayTinh> ds = mtDAL.GetData();
            List<MayTinh> kq = new List<MayTinh>();

            Console.Clear();
            IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);

            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].sLCon == 0)
                {
                    kq.Add(ds[i]);
                }
            }
            IO.Writexy("                                            DANH SÁCH MÁY TÍNH HẾT", x, y + 1);
            Hien(x + 11, y + 2, kq, 5, 1);
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
                //IO.Box(0, 0, 28, 114, ConsoleColor.Black, ConsoleColor.White);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
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
