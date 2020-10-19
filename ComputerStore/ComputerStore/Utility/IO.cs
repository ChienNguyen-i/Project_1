using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Utility
{
    public class IO
    {
        public static string ReadPassword(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            string s = null;
            ConsoleKeyInfo kt;
            do
            {
                kt = Console.ReadKey(true);
                if (kt.Key != ConsoleKey.Enter && kt.Key != ConsoleKey.Escape && kt.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    s = s + kt.KeyChar.ToString();
                }
                else if (kt.Key == ConsoleKey.Backspace)
                {
                    Clear(x, y, s.Length, ConsoleColor.Black);
                    if (s.Length <= 1)
                        s = "";
                    else s = s.Substring(0, s.Length - 1);
                    if (s == "")
                    {
                        Writexy(" ", x, y);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        int i = 0;
                        while (i < s.Length)
                        {
                            Writexy("*", x + i, y);
                            i += 1;
                        }
                    }
                }
                else if (kt.Key == ConsoleKey.Enter || kt.Key == ConsoleKey.Escape)
                    break;
            } while (true);
            return s;
        }
        public static void Clear(int x, int y, int length, ConsoleColor background_color)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor text = Console.ForegroundColor;
            int i = x;
            int j = y;
            int d = 0;
            while (d < length)
            {
                if (i == 79)
                {
                    i = 0;
                    j = j + 1;
                }
                else 
                    i += 1;
                Writexy(" ", i, j, background_color, background_color);
                d++;
            }
            Console.BackgroundColor = background;
            Console.ForegroundColor = text;
        }
        public static void Writexy(string s, int x, int y, int length)
        {
            Console.SetCursorPosition(x, y);
            if (s.Length > length)
                Console.Write(s.Substring(0, length));
            else
                Console.Write(s);
        }
        public static void Writexy(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public static void Writexy(string s, int x, int y, ConsoleColor background_color, ConsoleColor text_color)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = text_color;
            Console.Write(s);
        }
    }
}
