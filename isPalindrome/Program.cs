using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abcdecba";
            bool res = isPalindrome(input);

            Console.WriteLine(res);
        }

        static bool isPalindrome(string src)
        {
            Console.WriteLine(src[1]);
            char[]  srca = src.ToUpper().ToCharArray();
            int aPnt = 0;
            int bPnt = srca.Length-1;

            while (aPnt<=bPnt)
            {
                if (src[aPnt] != src[bPnt])
                    return false;
                aPnt++;
                bPnt--;

            }
            return true;
        }
    }
}
