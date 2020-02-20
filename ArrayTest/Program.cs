using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTest
{
    class Apple
    {
        internal int num;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 3, 4 };

            modifContenuSansRef(test);
            Console.WriteLine(test[0]); // OK --> 99 array is reference type

            //By default, all parameters are passed by value in C#. 
            //Parameters are only passed by reference if you explicitly include an out or ref modifier. 
            //However, you need to be aware that when the type of the parameter is a reference type, 
            //you're passing a reference rather than an actual object
            modifTailleSansRef(test);
            Console.WriteLine(test.Length); // KO --> 4 La taille n'est pas modifiée


            Apple a = new Apple();
            Console.WriteLine(a.num);
            changeApple(a);
            Console.WriteLine(a.num);
        }

        static void changeApple(Apple a)
        {
            //pass by value, another stack var also points to the same heap area
            a.num = 20;
        }

        static void modifContenuSansRef(int[] t)
        {
            //pass by value, a copy of array is passed by
            t[0] = 99;
        }

        static void modifTailleSansRef(int[] t)
        {
            //This method allocates a new array with the specified size, copies elements from the old array 
            //to the new one, and then replaces the old array with the new one.array must be a one-dimensional array.
            Array.Resize(ref t, 8);
            t[0] = -1;
        }
    }
}
