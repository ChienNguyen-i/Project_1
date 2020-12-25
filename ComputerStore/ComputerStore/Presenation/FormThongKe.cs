using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.Business;
using ComputerStore.Business.Interface;
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
                if (tmp[4] == ngay)
                {
                    double gia = double.Parse(tmp[6]);
                    int soluong = int.Parse(tmp[5]);
                    doanhthu += gia * soluong;
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
                String[] d = tmp[4].Split('/');
                if ((d[1] + "/" + d[2]) == thang)
                {
                    double gia = double.Parse(tmp[6]);
                    int soluong = int.Parse(tmp[5]);
                    doanhthu += gia * soluong;
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
                if (nam == "" || Convert.ToInt32(nam) <= 0)
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
                String[] d = tmp[4].Split('/');
                if (d[2] == nam)
                {
                    double gia = double.Parse(tmp[6]);
                    int soluong = int.Parse(tmp[5]);
                    doanhthu += gia * soluong;
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
    }
}
