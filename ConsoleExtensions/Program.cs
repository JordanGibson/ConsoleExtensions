using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> chars = new List<int>();
            List<string> strings = new List<string>();
            Random random = new Random();
            for(int i = 0; i < 8; i++)
            {
                chars.Add(random.Next());
            }
            for(int i = 0; i < 12; i++)
            {
                strings.Add(Guid.NewGuid().ToString("n").Substring(0, random.Next(6, 22)));
            }
            strings.Add("This is a test of a longer string");
            Console.WriteTable(chars);
            Console.WriteTable(strings);
            Console.RealtimeType("This is a really cool way to do realtime typing", 50);
            Console.ReadLine();
        }
    }
}
