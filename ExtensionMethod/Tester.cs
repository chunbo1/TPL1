using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace ExtensionMethod
{
    class Tester
    {
        public static void Main()
        {
            string s = "Hello Extension Methods";
            int i = s.WordCount();
            Console.WriteLine($"World count is {i}");
        }
    }
}
