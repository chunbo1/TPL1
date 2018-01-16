using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPLLocalVariable2
{


    class Test
    {
        static void Main()
        {
            int[] nums = Enumerable.Range(0, 10).ToArray();            
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                     () => 0, // method to initialize the local variable
                                     (j, loop, subtotal) => // method invoked by the loop on each iteration
                                     {
                                         subtotal += j; //modify local variable
                                         Console.WriteLine($"In loop: {Thread.CurrentThread.GetHashCode()}; Manged Thread Id: { Thread.CurrentThread.ManagedThreadId}; J= {j}; nums[j]= {nums[j]} ");
                                         return subtotal; // value to be passed to next iteration
                                     },
                                                    // Method to be executed when each partition has completed.
                                                    // finalResult is the final value of subtotal for a particular partition.
                                                    (x) => {
                                                        Add(ref total, x);
                                                        Console.WriteLine($"Watch in Final ---: ManagedThreadId is {Thread.CurrentThread.ManagedThreadId} Total is {total}, x is {x}");
                                                    }

                                        //(finalResult) => Interlocked.Add(ref total, finalResult)
                                        );

            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static long Add(ref long a, long b)
        {
            object obj = new object();
            //Monitor.Enter(obj);
            a += b;
            //Monitor.Exit(obj);
            return -1;


        }
    }//Class
    // The example displays the following output:
    //        The total from Parallel.ForEach is 499,999,500,000



}
