// C# Program to generate all the subsequence 
// starting with vowel and ending with consonant. 
using System;
using System.Collections.Generic;
using System.Text;

class Subsequence
{

    // Set to store all the subsequences 
    static HashSet<String> st = new HashSet<String>();

    // It computes all the possible substring that 
    // starts with vowel and end with consonent 
    static void subsequence(String str)
    {
        // iterate over the entire string 
        for (int i = 0; i < str.Length; i++)
        {

            // test ith character for vowel 
            if (isVowel(str[i]))
            {

                // if the ith character is vowel 
                // iterate from end of the string 
                // and check for consonant. 
                for (int j = (str.Length - 1); j >= i; j--)
                {

                    // test jth character for consonant. 
                    if (isConsonant(str[j]))
                    {

                        // once we get a consonant add it to 
                        // the hashset 
                        String str_sub = str.Substring(i, j - i + 1);
                        st.Add(str_sub);

                        // drop each character of the substring 
                        // and recur to generate all subsequence 
                        // of the substring 
                        for (int k = 1; k < str_sub.Length - 1; k++)
                        {
                            StringBuilder sb = new StringBuilder(str_sub);
                            sb.Remove(k, 1);
                            subsequence(sb.ToString());
                        }
                    }
                }
            }
        }
    }

    // Utility method to check vowel 
    static bool isVowel(char c)
    {
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o'
                                            || c == 'u');
    }

    // Utility method to check consonant 
    static bool isConsonant(char c)
    {
        return !isVowel(c);
    }

    // Driver code 
    public static void Main(String[] args)
    {
        String s = "xabcef";
        subsequence(s);
        foreach (String str in st)
            Console.Write(str + ", ");
    }
}

// This code is contributed by Rajput-Ji 
