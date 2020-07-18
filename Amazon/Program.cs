using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Program
    {
        //https://www.geeksforgeeks.org/find-number-of-islands/
        static void Main(string[] args)
        {
            Program ins = new Program();
            int rows = 5;
            int column = 4;
            int[,] grid = { {1,1,0,0 },
                            {0,0,1,0 },
                            {0,0,0,0 },
                            {1,0,1,1 },
                            {1,1,1,1 }
            };
            int count = ins.numberAmazonGoStores(rows, column, grid);
            Console.WriteLine(count);
        }

        public int numberAmazonGoStores(int rows, int column, int[,] grid)
        {
            int cnt = 0;
            bool[,] visited = new bool[rows, column];

            for (int i = 0; i< rows; i++)
                for (int j = 0; j < column; j++)
                {
                    if (grid[i, j] == 1 && !visited[i, j])
                    {
                        DFS(grid, i, j, visited);
                        cnt++;
                    }
                }

            return cnt;
        }//

        static void DFS(int[,] M, int row,
                int col, bool[,] visited)
        {
            // These arrays are used to 
            // get row and column coordinate 
            // of 4 neighbors of a given cell 
            //   4
            // 1   3
            //   2

            int[] rowNbr = new int[] { 0, -1, 0, 1};
            int[] colNbr = new int[] { -1, 0, 1, 0};

            // Mark this cell 
            // as visited 
            visited[row, col] = true;

            // Recur for all 
            // connected neighbours 
            for (int k = 0; k < 4; ++k)
                if (checkBoundary(M, row + rowNbr[k], col + colNbr[k], visited))
                    DFS(M, row + rowNbr[k],
                        col + colNbr[k], visited);
        }

        static bool checkBoundary(int[,] M, int row,
                   int col, bool[,] visited)
        {
            List<int> lst = new List<int>();
            int aaa= lst.Count;

            // row number is in range, 
            // column number is in range 
            // and value is 1 and not 
            // yet visited 
            return (row >= 0) && (row < M.GetLength(0)) 
                && (col >= 0) && (col < M.GetLength(1)) 
                && (M[row, col] == 1 
                && !visited[row, col]);
        }

    }//class
}
