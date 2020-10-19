using Microsoft.VisualBasic;
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
                    s += kt.KeyChar.ToString();
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
        public static string ReadString(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            string s = null;
            ConsoleKeyInfo kt;
            do
            {
                kt = Console.ReadKey(true);
                if (kt.Key != ConsoleKey.Enter && kt.Key != ConsoleKey.Escape && kt.Key != ConsoleKey.Backspace)
                {
                    Console.Write(kt.KeyChar.ToString());
                    s += kt.KeyChar.ToString();
                }
                else if (kt.Key == ConsoleKey.Backspace)
                {
                    Clear(x, y, s.Length, ConsoleColor.Black);
                    if (s.Length <= 1)
                        s = "";
                    else
                        s = s.Substring(0, s.Length - 1);
                    if (s == "")
                    {
                        Writexy(" ", x, y);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                        Writexy(s, x, y);
                }
                else if (kt.Key == ConsoleKey.Enter)
                    break;
                else if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
            } while (true);
            return s;
        }
        public static string ReadNumber(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            string s = null;
            ConsoleKeyInfo kt;
            do
            {
                kt = Console.ReadKey(true);
                if (kt.Key != ConsoleKey.Enter && kt.Key != ConsoleKey.Escape && kt.KeyChar >= '0' && kt.KeyChar <= '9')
                {
                    Console.Write(kt.KeyChar.ToString());
                    s += kt.KeyChar.ToString();
                }
                else if (kt.Key == ConsoleKey.Backspace)
                {
                    Clear(x, y, s.Length, ConsoleColor.Black);
                    if (s.Length <= 1)
                        s = "";
                    else
                        s = s.Substring(0, s.Length - 1);
                    if (s == "")
                    {
                        Writexy(" ", x, y);
                        Console.SetCursorPosition(x, y);
                    }
                    else
                        Writexy(s, x, y);
                }
                else if (kt.Key == ConsoleKey.Enter)
                    break;
                else if (kt.Key == ConsoleKey.Escape)
                    ComputerStore.Program.Hien();
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
                    j += 1;
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
        public static void Box(int x, int y, int height, int width)
        {
            Writexy("┌", x, y);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y);
            Writexy("┐", x + (width - 1), y);

            for (int i = 1; i <= height - 2; ++i)
                Writexy("│", x, y + i);
            for (int i = 1; i <= height - 2; ++i)
                Writexy("│", x + (width - 1), y + i);

            Writexy("└", x, y + (height - 1));
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y + (height - 1));
            Writexy("┘", x + (width - 1), y + (height - 1));
        }
        public static void Box(int x, int y, int height, int width, ConsoleColor background_color, ConsoleColor text_color)
        {
            Writexy("┌", x, y, background_color, text_color);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y, background_color, text_color);
            Writexy("┐", x + (width - 1), y, background_color, text_color);

            for (int i = 1; i <= height - 2; ++i)
                Writexy("│", x, y + i, background_color, text_color);
            for (int i = 1; i <= height - 2; ++i)
                Writexy("│", x + (width - 1), y + i, background_color, text_color);

            Writexy("└", x, y + (height - 1), background_color, text_color);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y + (height - 1), background_color, text_color);
            Writexy("┘", x + (width - 1), y + (height - 1), background_color, text_color);
        }

        public static void BoxTitle(string title, int x, int y, int height, int width)
        {

            Writexy("┌", x, y);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y);
            Writexy("┐", x + (width - 1), y);

            Writexy("│", x, y + 1);
            Writexy(title, x + 2, y + 1);
            Writexy("│", x + (width - 1), y + 1);

            Writexy("├", x, y + 2);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y + 2);
            Writexy("┤", x + (width - 1), y + 2);

            for (int i = 3; i <= height - 2; ++i)
                Writexy("│", x + (width - 1), y + i);
            for (int i = 3; i <= height - 2; ++i)
                Writexy("│", x, y + i);

            Writexy("└", x, y + (height - 1));
            for (int i = 1; i < width - 1; ++i)
                Writexy("─", x + i, y + (height - 1));
            Writexy("┘", x + (width - 1), y + (height - 1));
        }
        public static void BoxTitle(string title, int x, int y, int height, int width, ConsoleColor background_color, ConsoleColor text_color)
        {

            Writexy("┌", x, y, background_color, text_color);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y, background_color, text_color);
            Writexy("┐", x + (width - 1), y, background_color, text_color);

            Writexy(title, x + 2, y + 1, background_color, text_color);

            Writexy("├", x, y + 2, background_color, text_color);
            for (int i = 1; i <= width - 2; ++i)
                Writexy("─", x + i, y + 2, background_color, text_color);
            Writexy("┤", x + (width - 1), y + 2, background_color, text_color);

            for (int i = 1; i <= height - 2; ++i)
                Writexy("│", x, y + i, background_color, text_color);
            for (int i = 1; i <= height - 2; ++i)
                Writexy("│", x + (width - 1), y + i, background_color, text_color);

            Writexy("└", x, y + (height - 1), background_color, text_color);
            for (int i = 1; i < width - 1; ++i)
                Writexy("─", x + i, y + (height - 1), background_color, text_color);
            Writexy("┘", x + (width - 1), y + (height - 1), background_color, text_color);
        }
    }
}
