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
            string[] array = new string[] { "adsaff", "testString", "another test string", "a much longer test string once again" };
            Console.WriteTable(array);
            Console.ReadLine();
        }
    }
}
