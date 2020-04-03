// C# Program to generate all the subsequence 
// starting with vowel and ending with consonant. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class KnapSack
{
    
    static void Main(string[] args)
    {
        int[] wheels = { 2,5,3,1};
        int[] speed = { -1,2,3,1 };
        List<int> selectedWheels = new List<int>();
        selectedWheels = wheels.ToList();
        List<int> selectedSpeeds = new List<int>();
        selectedSpeeds = speed.ToList();
        int res = knapSack(wheels, speed, selectedWheels, selectedSpeeds, wheels.Length - 1, 1);

    }
    // Set to store all the subsequences 
    static HashSet<String> st = new HashSet<String>();


    //n: number of remaining items in array; 
    //Num of maximum num of wheels needed;
    public static int knapSack(int[] wheels, int[] speed, 
        List<int> selectedWheels,  List<int> selectedSpeeds, int n,  int num)
    {
        if (num<=0 || n<= 0)
            return 0;

        //including current element
        int include = calc(selectedWheels, selectedSpeeds);// + knapSack(wheels, speed, selectedWheels, selectedSpeeds, n-1, num-1);

        //Exclude current element, recursive for the rest num-1 items
        selectedWheels.Remove(wheels[n]);
        selectedSpeeds.Remove(speed[n]);
        int exclude = knapSack(wheels, speed, selectedWheels, selectedSpeeds, n-1, num);//num is a weight, we exclude current, so we still have num of items left

        return Math.Max(include, exclude);

    }

    static int calc(List<int> wheels, List<int> speed)
    {
        int a = wheels.Sum(x => Convert.ToInt32(x));
        int b = speed.Min();

        return a*b;
    }
}

