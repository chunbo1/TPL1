using System;
using System.Collections.Generic;

namespace Point72
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lst = new List<string>();
            lst.Add("aa");
            lst.Add("bb");
            lst.Add("cc");
            //lst.RemoveAll(u => u.StartsWith("b"));

            foreach (string str in lst)
            {
                lst.Remove(str);
            }
        }





    }//class
}
