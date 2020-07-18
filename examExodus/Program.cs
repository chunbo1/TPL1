// A Dynamic Programming based solution for 
// 0-1 Knapsack problem 
using System;

class GFG
{

    // A utility function that returns  
    // maximum of two integers 
    static int max(int a, int b)
    {
        return (a > b) ? a : b;
    }

    // Returns the maximum value that 
    // can be put in a knapsack of  
    // capacity W 
    static int knapSack(int W, int[] wt,
                         int[] val, int n)
    {
        int i, w;
        int[,] K = new int[n + 1, W + 1];

        // Build table K[][] in bottom  
        // up manner 

        //for W=5, K should be a 3*5 matrix; but we created 4*6 matrix to hold values
        //row0 and column 0 always has ZEROs
        for (i = 0; i <= n; i++)
        {
            for (w = 0; w <= W; w++)
            {
                if (i == 0 || w == 0)
                    K[i, w] = 0;
                else if (wt[i] <= w) 
                    K[i, w] = Math.Max(val[i] + K[i - 1, w - wt[i]],   //include it
                                    K[i - 1, w]);                      //exclude it
                else //exclude it
                    K[i, w] = K[i - 1, w];

                Console.WriteLine($"i={i} w={w}, K={K[i,w]}");
            }
        }

        return K[n, W];
    }

    // Driver code 
    static void Main()
    {
        int[] val = new int[] {0, 60, 100, 120, 10 };
        int[] wt = new int[] { 0, 1, 2, 3, 0 };
        int W = 4;
        int n = val.Length-1; //take 1st element o off the count

        Console.WriteLine(
                  knapSack(W, wt, val, n));
        Console.ReadLine();
    }
}