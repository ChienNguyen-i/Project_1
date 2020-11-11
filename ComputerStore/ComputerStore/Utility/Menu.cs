using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Utility
{
    public abstract class Menu
    {
        private string[] mn;
        public Menu(string[] mn)
        {
            this.mn = mn;
        }
        public int MaxMuc()
        {
            int max = mn[0].Length;
            for (int i = 1; i < mn.Length; ++i)
                if (max < mn[i].Length)
                    max = mn[i].Length;
            return max;
        }
        public void ChuanHoaMenu()
        {
            int max = MaxMuc();
            for (int i = 0; i < mn.Length; ++i)
                mn[i] = CongCu.ChuanHoaXau(mn[i], max);
        }
        public void Writexy(int x, int y, int location, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            Console.Write(mn[location]);
        }
        public void Writexy(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public void HienTheoPhimTat(int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.SetWindowSize(113, 30);
            ChuanHoaMenu();
            IO.BoxTitle("                    CÁC CHỨC NĂNG", x, y, mn.Length * 2 + 5, MaxMuc() + 26);
            x += 5;
            y += 3;
            for (int i = 0; i < mn.Length; ++i)
                Writexy(x, y + i * 2, i, background_color, text_color);
            IO.Writexy("Chọn một chức năng để thực hiện...", x, y + mn.Length * 2);
            ConsoleKeyInfo kt = Console.ReadKey();

            string[] key = new string[mn.Length];
            for (int i = 0; i < mn.Length; ++i)
                key[i] = mn[i].Substring(0, mn[i].IndexOf("."));
            for (int i = 0; i < key.Length; ++i)
                if (kt.Key.ToString() == key[i])
                    ThucHien(i);
        }
        public abstract void ThucHien(int location);
    }
}
