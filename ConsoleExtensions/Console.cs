using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExtensions
{
    public static class Console
    {
        private static Random random = new Random();
        private static string chars = "abcdefghijklmnopqrstuvwxyz";

        public static ConsoleColor BackgroundColor { get { return System.Console.BackgroundColor; }
            set { System.Console.BackgroundColor = value; } }

        public static ConsoleColor ForegroundColor
        {
            get { return System.Console.ForegroundColor; }
            set { System.Console.ForegroundColor = value; }
        }

        public static void WriteTable<T>(List<T> list)
        {
            string header = " ║ Index     ║ Value";
            int count = header.Length + list.Max(s => s.ToString().Length);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(" ╔".PadRight(13, '═') + "╦".PadRight(count - 8, '═') + "╗" + Environment.NewLine + header.PadRight(count + 5) + "║");
            for(int i = 0; i < list.Count; i++)
            {
                string value = " " + i + "║ ".PadLeft(12 - i.ToString().Length) + list[i].ToString();
                System.Console.Write(" ║");
                System.Console.BackgroundColor = i % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Black;
                System.Console.Write(value + "".PadRight(count - value.Length + 3));
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.WriteLine("║");
            }
            System.Console.WriteLine(" ╚" + "".PadRight(11, '═') + "╩" + "".PadRight(count - 9, '═') + "╝");
        }

        public static void RealtimeType(string text, int milliDelay)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (random.Next(0, 10) == 3)
                {
                    System.Console.Write(chars[random.Next(0, chars.Length)]);
                    System.Threading.Thread.Sleep(milliDelay + (random.Next(0, milliDelay * 2) * 2));
                    System.Console.Write("\b");
                    i--;
                }
                else
                {
                    System.Console.Write(text[i]);
                    System.Threading.Thread.Sleep(milliDelay + (random.Next(0, milliDelay * 2) - milliDelay));
                }
            }
            System.Console.WriteLine();

        }

        public static int Read()
        {
            return System.Console.Read();
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public static void Clear()
        {
            System.Console.Clear();
        }

        public static void Write(string text)
        {
            System.Console.Write(text);
        }

        public static void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
