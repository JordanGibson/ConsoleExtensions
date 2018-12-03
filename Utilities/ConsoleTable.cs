using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class ConsoleTable
    {
        private static int leftSpacing = 0;
        private static int rightSpacing = 0;
        private static string[] headers;
        private static char escapeChar = '䠣';
        private static int charCount = 1;

        private static int fixedWidth { get { return rightSpacing - 2; } }

        private static bool colorIsBlack = true;

        private static void WriteTableLine(string key, string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                System.Console.Write(" ║");
                System.Console.BackgroundColor = colorIsBlack ? ConsoleColor.DarkGray : ConsoleColor.Black;

                System.Console.Write(i == 0 ?
                    " " + key + " ║ ".PadLeft(leftSpacing - key.Length) + lines[i].PadRight(rightSpacing - 1)
                    : "║".PadLeft(leftSpacing) + lines[i].PadRight(rightSpacing));

                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.WriteLine("║");
            }
        }

        private static void WriteTableEntry(string key, string value)
        {
            string[] lines = value.Split(escapeChar);
            colorIsBlack = !colorIsBlack;
            WriteTableLine(key, lines);
        }

        public static void WriteTable<T, U>(IList<Tuple<T, U>> list, int maxWidth, string[] tableHeaders)
        {
            headers = tableHeaders;

            leftSpacing = Math.Max(
                        list.Max(x => x.Item1.ToString().Length),
                        headers[0].Length)
                        + 3;

            rightSpacing = Math.Min(Math.Max(
                        list.Max(x => x.Item2.ToString().Length),
                        headers[1].Length)
                        + 2, maxWidth);

            string header = headers.Aggregate((a, b) => string.Format(" ║ {0} ║ {1} ", a, b)) +
                "".PadRight(rightSpacing - headers[1].Length - 2) + "║";

            string topper = " ╔" + "╦".PadLeft(leftSpacing, '═') + "".PadRight(rightSpacing, '═') + "╗" + Environment.NewLine +
                header + Environment.NewLine +
                " ╠" + "╬".PadLeft(leftSpacing, '═') + "".PadRight(rightSpacing, '═') + "╣";
            string footer = " ╚" + "╩".PadLeft(leftSpacing, '═') + "".PadRight(rightSpacing, '═') + "╝";

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(topper);

            for (int i = 0; i < list.Count; i++)
            {
                charCount = 1;
                string[] values = list[i].Item2.ToString().Replace("\n", escapeChar + "").Split(' ');
                string value = "";
                string tempval = values.Aggregate((a, b) => a + " " + b);
                for (int j = 0; j < tempval.Length; j++)
                {
                    value += tempval[j];
                    charCount++;
                    if (charCount % fixedWidth - 1 == 0)
                        value += (tempval[j] == " ".ToCharArray()[0]) ? escapeChar + " " : "-" + escapeChar + " ";
                }
                //always end on escape char so new line not affected
                value += escapeChar;
                WriteTableEntry(list[i].Item1.ToString(), value);
            }
            System.Console.WriteLine(footer);
        }
    }
}