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

        private static int padLeft = 0;
        private static int padRight = 0;

        //A line should be of the format "Key ║ Value"
        private static void WriteLineInTable(string key, string[] lines, ConsoleColor currentColor)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                System.Console.Write(" ║");
                System.Console.BackgroundColor = currentColor;
                if (i == 0)
                {
                    System.Console.Write(" " + key + " ║ ".PadLeft(padLeft - key.Length) + lines[i].PadRight(padRight - 1));
                }
                else
                {
                    System.Console.Write("║".PadLeft(padLeft) + lines[i].PadRight(padRight));
                }
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.WriteLine("║");
            }
        }

        private static void WriteTableValue(string key, string value, int i)
        {
            ConsoleColor currentColor = i % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Black;
            string[] lines = value.Split('∞');
            WriteLineInTable(key, lines, currentColor);
        }
        
        private static void WriteTable<T, U>(List<Tuple<T, U>> list, string[] headers = null)
        {
            if (headers == null)
                headers = new string[] { "Index", "Value" };

            padLeft = Math.Max(
                        list.Max(x => x.Item1.ToString().Length),
                        headers[0].Length)
                        + 3;

            padRight = Math.Min(Math.Max(
                        list.Max(x => x.Item2.ToString().Length),
                        headers[1].Length)
                        + 2, 50);

            string header = headers.Aggregate((a, b) => " ║ " + a + " ║ " + b + " ") +
                "".PadRight(padRight - headers[1].Length - 2) + "║";

            int maxWidth = padRight + padLeft + 10 > 50 ? 50 : padRight + padLeft + 10;

            string topper = " ╔" + "╦".PadLeft(padLeft, '═') + "".PadRight(padRight, '═') + "╗" + Environment.NewLine + header;
            string footer = " ╚" + "╩".PadLeft(padLeft, '═') + "".PadRight(padRight, '═') + "╝";

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(topper);

            for(int i = 0; i < list.Count; i++)
            {
                string[] values = list[i].Item2.ToString().Split(' ');
                int characterCount = 0;
                for (int j = 0; j < values.Length; j++)
                {
                    characterCount += values[j].Length;
                    if (characterCount >= 40 && !(values[0].Length > 40))
                    {
                        var tempList = values.ToList();
                        tempList.Insert(j, "∞");
                        values = tempList.ToArray();
                        characterCount = 0;
                    }
                }
                if (values[0].Length > 48)
                {
                    for (int j = 48; j < values[0].Length; j += 48)
                    {
                        var temp = values[0];
                        temp = temp.Insert(j, "∞ ");
                        values = new string[] { temp };
                    }
                }
                string value = values.Aggregate((a, b) => a + " " + b);
                WriteTableValue(list[i].Item1.ToString(), value, i);
            }
            System.Console.WriteLine(footer);
        }

        public static void WriteTable<T>(List<T> list)
        {
            List<Tuple<int, T>> keyValuePairList = new List<Tuple<int, T>>();
            list.ForEach(x => {
                keyValuePairList.Add(new Tuple<int, T>(list.IndexOf(x), x));
            });
            WriteTable<int, T>(keyValuePairList);
        }

        public static void WriteTable<T>(List<T> list, string header1, string header2)
        {
            List<Tuple<int, T>> keyValuePairList = new List<Tuple<int, T>>();
            list.ForEach(x => {
                keyValuePairList.Add(new Tuple<int, T>(list.IndexOf(x), x));
            });
            WriteTable(keyValuePairList, new string[] { header1, header2 });
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
