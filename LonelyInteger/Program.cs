using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    static int lonelyinteger(int[] a)
    {
        int res = 0;
        foreach (var i in a)
            res  ^= i;

        return res;
    }
    // Complete the lonelyinteger function below.
    static int lonelyintegerOld(int[] a)
    {
        Dictionary<int,int> dic = new Dictionary<int,int>();
        for (int i=0; i<a.Length; i++)
        {
            if (dic.ContainsKey(a[i]))
                dic[a[i]] = ++dic[a[i]];
            else //firsttime
                dic.Add(a[i], 1);
        }
        

        foreach (var k in dic.Keys)
        {
            if (dic[k] == 1)
                Console.WriteLine("unique int is: " + k);
        }
        return 0;
    }

    static void Main(string[] args)
    {

        int[] a = new int[] { 1, 2, 3, 3, 2, 1,4 };
        
        int result = lonelyinteger(a);
        
    }
}
