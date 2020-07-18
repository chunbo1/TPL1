using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> col = new List<int>();
            col.Add(1);
            col.Add(2);
            col.Add(3);
            col.Add(4);
            hackerCards(col,5);
        }

        //if number already in collection, you can't use it
        //d is your budget , the sum you can use
        static List<int> hackerCards(List<int> collection, int d)
        {
            List<int> lst = new List<int>();
            int sum = 0;
            int col_m = 0;

            if (collection == null)
                col_m = 0;
            else
                col_m = collection.Max();
            
            int m = d;
            for (int i = 1; i <= m; i++)
            {
                if (!collection.Contains(i))
                {
                    sum += i;
                    if (sum <= d)
                        lst.Add(i);
                    else break;
                }

            }
            return lst;
        }


    }//class
}
