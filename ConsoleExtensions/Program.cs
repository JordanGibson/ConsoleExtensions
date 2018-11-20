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
            strings.Add("This is a test of a really really really really really much longer string, hopefully " +
                "long enough to have to make a new line in the console window");
            strings.Add("I'm hoping that eventually this string will be long enough to also create another" +
                "line in the console boi");
            strings.Add("dsjonDSNOSDONDSFONFDOJNionfsongjfsingosknfskdonosgnsonfsdlnokfs");
            Console.WriteTable(chars, "Dictionary Key", "Value");
            Console.WriteTable(strings);
            Console.ReadLine();
        }
    }
}
