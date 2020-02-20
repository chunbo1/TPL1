using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string src = "abcde";
            char[] arr = src.ToCharArray();
            Console.WriteLine(arr);
            ReverseString(arr);
            Console.WriteLine(arr);
        }


        static void ReverseString(char[] s)
        {
            int a = 0;
            int b = s.Length - 1;
            char tem = ' ';
            while (a < b)
            {
                tem = s[a];
                s[a] = s[b];
                s[b] = tem;
                a++;
                b--;
            }
        }
    }
}
