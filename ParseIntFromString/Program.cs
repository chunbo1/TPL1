using System;
using System.Collections.Generic;
using System.Linq;

namespace ParseIntFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "123aa234b--12nn00789";
            //String input = "00789";
            ParseString(input);

        }

        static List<int> ParseString(string src0)
        {
            IEnumerable<char> src;
            src = src0.ToCharArray();
            string tem = "";
            int i;
            char prev = ' ';
            int count = src.Count();

            List<int> intRes = new List<int>();
            foreach (char c in src)
            {
                if (Char.IsDigit(c)) {
                    tem += c;
                }
                else//letters 
                {
                    i = -999;
                    if (Int32.TryParse(prev.ToString()+tem, out i))                    
                        intRes.Add(i);
                    tem = "";

                    if (c == '-')
                        prev = c;
                    else
                        prev = ' ';
                }

            }

            //Last char
            if (Int32.TryParse(prev.ToString() + tem, out i))
                intRes.Add(i);

            return intRes;
        }
    }
}
