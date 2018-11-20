using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExtensions
{
    public static class ConsoleTable
    {
        private static string[] headers;
        private static int padLeft = 0;
        private static int padRight = 0;

        private static ConsoleColor currentColor {
            get { return System.Console.BackgroundColor; }
            set { System.Console.BackgroundColor = value; }
        }

        private static void WriteTableLine(string key, string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
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

        private static void WriteTableEntry(string key, string value)
        {
            currentColor = currentColor == ConsoleColor.Black ? ConsoleColor.DarkGray : ConsoleColor.Black;
            string[] lines = value.Split('∞');
            WriteTableLine(key, lines);
        }

        public static void WriteTable<T, U>(IList<Tuple<T, U>> list, string[] tableHeaders = null)
        {
            if (tableHeaders == null)
                headers = new string[] { "Index", "Value" };
            else
                headers = tableHeaders;

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

            string topper = " ╔" + "╦".PadLeft(padLeft, '═') + "".PadRight(padRight, '═') + "╗" + Environment.NewLine + header;
            string footer = " ╚" + "╩".PadLeft(padLeft, '═') + "".PadRight(padRight, '═') + "╝";

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(topper);

            for (int i = 0; i < list.Count; i++)
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
                WriteTableEntry(list[i].Item1.ToString(), value);
            }
            System.Console.WriteLine(footer);
        }
    }
}
