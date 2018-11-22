﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExtensions
{
    public static class ConsoleTable
    {
        private static int leftSpacing = 0;
        private static int rightSpacing = 0;
        private static string[] headers;

        private static int FixedWidth { get { return rightSpacing - headers[0].Length + 2; } }

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
            string[] lines = value.Split('∞');
            colorIsBlack = !colorIsBlack;
            WriteTableLine(key, lines);
        }

        public static void WriteTable<T, U>(IList<Tuple<T, U>> list, string[] tableHeaders, int maxWidth = 25)
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
                string[] values = list[i].Item2.ToString().Replace("\n", "∞ ").Split(' ');
                int characterCount = 0;
                for (int j = 0; j < values.Length; j++)
                {
                    characterCount = values[j].Contains('∞') ? 
                        values[j].Length - values[j].IndexOf('∞') : 
                        characterCount + values[j].Length + 1;
                    
                    if (characterCount >= FixedWidth)
                    {
                        if(values[j].Length < FixedWidth)
                        {
                            values = values.Insert(j, "∞");
                            characterCount = 0;
                        }
                        else if(values[j].Length >= FixedWidth)
                        {
                            while (characterCount >= FixedWidth)
                            {
                                values[j] = values[j].Insert(values[j].Length - (characterCount -= FixedWidth), "-∞ ");
                            }
                        }
                    }
                }
                string value = values.Aggregate((a, b) => a + " " + b);
                WriteTableEntry(list[i].Item1.ToString(), value);
            }
            System.Console.WriteLine(footer);
        }
    }
}
