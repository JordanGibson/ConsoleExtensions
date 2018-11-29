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
            //Bug when the previous word is equal to fixed width
            //BuildTestData(180);
            //testStrings.Add("abib mcfqsnr vguccqitotpljwkrg yisdqbiirmakxdprttdxspdqmiurrrtpjsqjisqsuv xsewlwtcrnkiifbrhhsraumbeogiadmdyqgzimjvzobb kidgaikbd dfcsypkcobhktzdivzytmslbufdbavcbuqc");
            testStrings.Add("yisdqbiirmakxdprttdxspdqmiurrrtpjsqjisqsuv xsewlwtcrnkiifbrhhsraumbeogiadmdyqgzimjvzobb");
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
