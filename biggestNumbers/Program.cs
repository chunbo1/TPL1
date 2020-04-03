using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biggestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] src = new int[] { 11, 3, 5, 7, 9 };
            FindMax(src, 3);
        }

      

        static int[] FindMax(int[] numbers, int n)
        {
            Console.WriteLine("--1");
            if (numbers == null) return null;
            if (numbers.Length <= 0) return null;
            if (n < 0) return null;

            int[] target = new int[numbers.Length];
            Console.WriteLine("--2");

            Array.Copy(numbers, target, numbers.Length);
            Array.Sort(target);
            Array.Reverse(target);
            if (n > numbers.Length)
                n = numbers.Length;
            Console.WriteLine("--3");

            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write(target[i] + " ");
                result[i] = target[i];
                
            }
             
            return result;



        }

    }
}
