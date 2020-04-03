using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLengthEncoding
{
    class Program
    {
        static void Main(string[] args)
        {

           
            byte[] original = new byte[7];

                byte originalItem = Convert.ToByte(97);
                original[0] = originalItem;
                originalItem = Convert.ToByte(97);
                original[1] = originalItem;

                originalItem = Convert.ToByte(97);
                original[2] = originalItem;
            //originalItem = Convert.ToByte(553);
            //original[3] = originalItem;
            byte[] data = BitConverter.GetBytes(553);
                int i = 3;
                foreach (var x in data)
                {
                    original[i++] = x;
                }
                

                Encode(original);
            
        }

        //void printRLE(string str)
        static IEnumerable<byte> Encode(IEnumerable<byte> original)
        {
            if (original.Count() <= 0) return null;
            
            byte[] arr = original.ToArray();
            byte[] result = new byte[1000];
            int n = arr.Length;
            int resCnt = 0;
            for (int i = 0; i < n; i++)
            {                
                // Count occurrences of current character 
                int count = 1;
                while (i < n - 1 && arr[i] == arr[i + 1])
                {
                    count++;
                    i++;
                }
                
                if (count<256)
                    result[resCnt++] = Convert.ToByte(count);// out of range if > 255
                else
                {
                    byte[] data = BitConverter.GetBytes(300);
                    foreach (var x in data)
                    {
                        result[resCnt++] = x;
                    }
                }
                    
                result[resCnt++] = arr[i];
            }
            
            //int cnt = 0;
            
            //for (int i = 0; i< result.Length; i++)
            //{
            //    if (result[i] != 0) cnt++;
            //    else break;
            //}
            byte[] final = new byte[resCnt];
            for (int i = 0; i < resCnt; i++)
            {
                final[i] = result[i];
            }

            return final;
           


        }
    }
}
