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
            List<string> strings = new List<string>();
            strings.Add("This example is also quite long but it has to have a really long word afterthefirstlinebreaksothaticanseewhathappenswhenwesplitthefirstvalueinarraysbutnotthesecond, then we can go ahead and add in some more normal words afterwards with spaces");
            strings.Add("Example");
            strings.Add("Another example");
            strings.Add("Another another example");
            strings.Add("Guess what? It's another example");
            strings.Add("Roses are red. \nI don't like stratified samples. \nWhy do I do this to myself. \nOh look it's another example");
            strings.Add("I can't believe it's another example!");
            strings.Add("Example shmample");
            strings.Add("I need help");
            strings.Add("Seriously");
            strings.Add("This is quite a long example but this time it actually has to be long with no line breaks to test for the new line function.");
            Console.WriteTable(strings);
            Console.ReadLine();
        }
    }
}
