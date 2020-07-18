using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_cluster_count
{
    //subsequences so that no labels appear in more than one subsequence
    //https://gist.github.com/k9982874/5f0de0475a41aa5c4eebedf4961e3f98
    class Program
    {
        static void Main(string[] args)
        {
            List<char> inputList = new List<char>();
            inputList.Add('a');
            inputList.Add('b');
            inputList.Add('a');
            inputList.Add('b');
            List<int> lst = lengthEachScene(inputList);
        }

        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static List<int> lengthEachScene(List<char> inputList)
        {
            Dictionary<char, int> m = new Dictionary<char, int>();
            for (int i = 0; i < inputList.Count; i++)
            {
                m[inputList[i]] = i;
            }

            List<int> result = new List<int>();
            int left = 0;
            int right = 0;
            for (int i = 0; i < inputList.Count; i++)
            {
                right = Math.Max(right, m[inputList[i]]);
                if (right == i)
                {
                    result.Add(1 + right - left);
                    left = right + 1;
                }
            }
            return result;
        }
        // METHOD SIGNATURE ENDS
    }//Class
}

