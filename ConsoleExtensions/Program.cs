using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class Program
    {
        static string chars = "abcdefghijklmnopqrstuvwxyz ";
        static List<string> testStrings = new List<string>();
        static Random random = new Random();

        static void Main(string[] args)
        {
            //BuildTestData(80);
            //testStrings.Add("pc ph  hkwhjpx ebftnstzexqsfdsjegxagmrhfgvv");
            testStrings.Add("pcuasn unuasjnasjdjasbhsasdjnjndsbhashdbjwsadjkbasjdbaskj");
            Console.WriteTable(testStrings);
            Console.ReadLine();
        }

        static void BuildTestData(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string tempString = "";
                for(int j = 0; j < i; j++)
                {
                    int index = random.Next(0, chars.Length);
                    tempString += chars[index].ToString();
                }
                testStrings.Add(tempString);
            }

        }
    }
}
