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

        public static int Width {
            get { return System.Console.WindowWidth; }
            set { System.Console.WindowWidth = value; }
        }

        public static int Height
        {
            get { return System.Console.WindowHeight; }
            set { System.Console.WindowHeight = value; }
        }

        public static ConsoleColor ForegroundColor
        {
            get { return System.Console.ForegroundColor; }
            set { System.Console.ForegroundColor = value; }
        }
        
        private static void WriteTable<T, U>(IList<Tuple<T, U>> list, string[] headers = null)
        {
            ConsoleTable consoleTable = new ConsoleTable(headers);
            consoleTable.WriteTable(list);
        }

        public static void WriteTable<T>(IList<T> list)
        {
            List<Tuple<int, T>> tupleList = new List<Tuple<int, T>>();
            for(int i = 0; i < list.Count; i++)
            {
                tupleList.Add(new Tuple<int, T>(i, list[i]));
            }
            WriteTable<int, T>(tupleList);
        }

        public static void WriteTable<T>(IList<T> list, string header1, string header2)
        {
            List<Tuple<int, T>> tupleList = new List<Tuple<int, T>>();
            for (int i = 0; i < list.Count; i++)
            {
                tupleList.Add(new Tuple<int, T>(i, list[i]));
            }
            WriteTable(tupleList, new string[] { header1, header2 });
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

        public static void Write(string text, params object[] args)
        {
            System.Console.Write(text, args);
        }

        public static void WriteLine(string text, params object[] args)
        {
            System.Console.WriteLine(text, args);
        }
    }
}
