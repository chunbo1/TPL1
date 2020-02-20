using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPL1
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            DoLoop();
            Console.WriteLine($"It takes  { watch.ElapsedMilliseconds} miliseconds");
            //Console.ReadLine();

            watch = Stopwatch.StartNew();
            DoLoop1();
            Console.WriteLine($" It takes {watch.ElapsedMilliseconds} miliseconds");
            Console.ReadLine();
        }

        private static void DoLoop()
        {
            for (int i = 2; i < 4; i++)
            {
                var result = SumRootN(i);
                Console.WriteLine("root {0} : {1} ", i, result);
            }
        }

        private static void DoLoop1()
        {
            Parallel.For(2, 4, (i) =>
                {
                var result = SumRootN(i);
                Console.WriteLine("root {0} : {1} ", i, result);
                }
            );

        }

        public static double SumRootN(int root)
        {
            double result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                result += Math.Exp(Math.Log(i) / root);
            }
            return result;
        }

    }//class
    
}//NS
