using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 3, 4, 5, 7, 9 };
            int pos = BinarySearch(numbers, 9);
            Console.WriteLine();
        }

        static int BinarySearch(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int left = 0;
            int right = nums.Length - 1;

            
            while (left <= right)
            {
                int mid = left + (right-left)/ 2;

                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid+1;
                else right = mid-1;
            }
            return -1;
        }
            
    }
}
